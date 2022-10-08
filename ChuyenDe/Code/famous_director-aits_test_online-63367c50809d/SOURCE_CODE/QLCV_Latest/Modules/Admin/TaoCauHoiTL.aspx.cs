using CPanel.Commons;
using CPanel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules.Admin
{
    public partial class TaoCauHoiTL : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Commons.ATCL_Commons.getChuDe(drpChuDeTL, entities);

                if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_OBJECT_ID]))
                {
                    txtObjectID.Text = Session[ATCL_Consts.SESSION_OBJECT_ID].ToString();
                    Session[ATCL_Consts.SESSION_OBJECT_ID] = null;
                }
                if (!String.IsNullOrEmpty(txtObjectID.Text))
                {
                    int intCauHoiID = Convert.ToInt32(txtObjectID.Text);
                    var CauHoiDaTonTai = entities.BAI_THI_CAU_HOI.Where(x => x.ID_CAU_HOI == intCauHoiID).Select(x => x.ID_BAI_THI).FirstOrDefault();
                    if (CauHoiDaTonTai != null)
                    {
                        int intCauHoiDaTonTai = Convert.ToInt32(CauHoiDaTonTai);
                        var checkBaiThiDaGui = entities.BAI_THI_UNG_VIEN.Where(x => x.ID_BAI_THI == intCauHoiDaTonTai).Select(x => x.NGAY_GUI_MAIL).FirstOrDefault();
                        if (checkBaiThiDaGui != null)
                        {
                            lbMessage.Text = "Câu hỏi này đã nằm trong một bài thi đã gửi cho ứng viên. Vì vậy, không thể sửa!";
                            drpChuDeTL.Enabled = false;
                            cbDeTL.Enabled = false;
                            cbTbTL.Enabled = false;
                            cbKhoTL.Enabled = false;
                            txtNoiDungTL.ReadOnly = true;
                        }
                    }
                        
                }
                getObjects();
            }
        }

        public void getObjects()
        {
            if (!String.IsNullOrEmpty(txtObjectID.Text))
            {
                int intObjectID = Convert.ToInt32(txtObjectID.Text);
                var obj = entities.CAU_HOI.Where(x => x.ID == intObjectID).FirstOrDefault();
                if (obj != null)
                {
                    txtNoiDungTL.Text = obj.NOI_DUNG_CAU_HOI;

                    if (obj.ID_CHU_DE_BAI_THI != null)
                        drpChuDeTL.SelectedValue = obj.ID_CHU_DE_BAI_THI.ToString();
                }

                var lstMucDoTL = entities.CAU_HOI_MUC_DO.Where(x => x.ID_CAU_HOI == intObjectID).ToList();
                if ((lstMucDoTL != null) && (lstMucDoTL.Count >= 1))
                {
                    foreach (var item in lstMucDoTL)
                    {
                        if (item.ID_MUC_DO_CAU_HOI == 1)
                        {
                            cbDeTL.Checked = true;
                        }
                        if (item.ID_MUC_DO_CAU_HOI == 2)
                        {
                            cbTbTL.Checked = true;
                        }
                        if (item.ID_MUC_DO_CAU_HOI == 3)
                        {
                            cbKhoTL.Checked = true;
                        }
                    }
                }
            }
        }

        protected string saveObject()
        {
            try
            {
                CAU_HOI obj = new CAU_HOI();
                if (String.IsNullOrEmpty(txtObjectID.Text))
                {
                    obj.NGAY_TAO = DateTime.Now;
                    obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    obj.TT_XOA = false;

                    entities.CAU_HOI.Add(obj);
                }
                else
                {
                    int intObjID = Convert.ToInt32(txtObjectID.Text);
                    obj = entities.CAU_HOI.Find(intObjID);
                }

                obj.ID_LOAI_CAU_HOI = 2;

                obj.NOI_DUNG_CAU_HOI = txtNoiDungTL.Text;

                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpChuDeTL.SelectedValue))
                {
                    obj.ID_CHU_DE_BAI_THI = Convert.ToInt32(drpChuDeTL.SelectedValue);
                }
                obj.NGAY_SUA = DateTime.Now;
                obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

                entities.SaveChanges();

                var objCauHoiMucDoDeTL = entities.CAU_HOI_MUC_DO.Join(entities.MUC_DO_CAU_HOI, CHMD => CHMD.ID_MUC_DO_CAU_HOI, MDCH => MDCH.ID, (CHMD, MDCH) => new { CHMD, MDCH })
                                    .Where(x => x.CHMD.ID_CAU_HOI == obj.ID && x.MDCH.MA_MUC_DO.Equals("M01")).Select(y => y.CHMD).FirstOrDefault();
                var idMucDeTL = entities.MUC_DO_CAU_HOI.Where(x => x.MA_MUC_DO == "M01").Select(x => x.ID).FirstOrDefault();
                if (cbDeTL.Checked == false)
                {
                    if (objCauHoiMucDoDeTL != null)
                    {
                        entities.CAU_HOI_MUC_DO.Remove(objCauHoiMucDoDeTL);
                        entities.SaveChanges();
                    }
                }
                else
                {
                    if (objCauHoiMucDoDeTL == null)
                    {
                        if (String.IsNullOrEmpty(txtObjectID.Text))
                        {
                            createNew_CHMDTL(ref objCauHoiMucDoDeTL);
                        }
                        else
                        {
                            int intObjID = Convert.ToInt32(txtObjectID.Text);
                            objCauHoiMucDoDeTL = entities.CAU_HOI_MUC_DO.Find(intObjID);
                        }
                        if (objCauHoiMucDoDeTL == null)
                        {
                            createNew_CHMDTL(ref objCauHoiMucDoDeTL);
                        }
                        objCauHoiMucDoDeTL.NGAY_SUA = DateTime.Now;
                        objCauHoiMucDoDeTL.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();
                        objCauHoiMucDoDeTL.ID_CAU_HOI = obj.ID;
                        objCauHoiMucDoDeTL.ID_MUC_DO_CAU_HOI = idMucDeTL;

                        entities.SaveChanges();
                    }
                }

                var objCauHoiMucDoTbTL = entities.CAU_HOI_MUC_DO.Join(entities.MUC_DO_CAU_HOI, CHMD => CHMD.ID_MUC_DO_CAU_HOI, MDCH => MDCH.ID, (CHMD, MDCH) => new { CHMD, MDCH })
                                                        .Where(x => x.CHMD.ID_CAU_HOI == obj.ID && x.MDCH.MA_MUC_DO.Equals("M02")).Select(y => y.CHMD).FirstOrDefault();
                var idMucTbTL = entities.MUC_DO_CAU_HOI.Where(x => x.MA_MUC_DO == "M02").Select(x => x.ID).FirstOrDefault();
                if (cbTbTL.Checked == false)
                {
                    if (objCauHoiMucDoTbTL != null)
                    {
                        entities.CAU_HOI_MUC_DO.Remove(objCauHoiMucDoTbTL);
                        entities.SaveChanges();
                    }
                }
                else
                {
                    if (objCauHoiMucDoTbTL == null)
                    {
                        if (String.IsNullOrEmpty(txtObjectID.Text))
                        {
                            createNew_CHMDTL(ref objCauHoiMucDoTbTL);
                        }
                        else
                        {
                            int intObjID = Convert.ToInt32(txtObjectID.Text);
                            objCauHoiMucDoTbTL = entities.CAU_HOI_MUC_DO.Find(intObjID);
                        }
                        if (objCauHoiMucDoTbTL == null)
                        {
                            createNew_CHMDTL(ref objCauHoiMucDoTbTL);
                        }
                        objCauHoiMucDoTbTL.NGAY_SUA = DateTime.Now;
                        objCauHoiMucDoTbTL.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();
                        objCauHoiMucDoTbTL.ID_CAU_HOI = obj.ID;
                        objCauHoiMucDoTbTL.ID_MUC_DO_CAU_HOI = idMucTbTL;

                        entities.SaveChanges();
                    }
                }

                var objCauHoiMucDoKhoTL = entities.CAU_HOI_MUC_DO.Join(entities.MUC_DO_CAU_HOI, CHMD => CHMD.ID_MUC_DO_CAU_HOI, MDCH => MDCH.ID, (CHMD, MDCH) => new { CHMD, MDCH })
                                        .Where(x => x.CHMD.ID_CAU_HOI == obj.ID && x.MDCH.MA_MUC_DO.Equals("M03")).Select(y => y.CHMD).FirstOrDefault();
                var idMucKho = entities.MUC_DO_CAU_HOI.Where(x => x.MA_MUC_DO == "M03").Select(x => x.ID).FirstOrDefault();
                if (cbKhoTL.Checked == false)
                {
                    if (objCauHoiMucDoKhoTL != null)
                    {
                        entities.CAU_HOI_MUC_DO.Remove(objCauHoiMucDoKhoTL);
                        entities.SaveChanges();
                    }
                }
                else
                {
                    if (objCauHoiMucDoKhoTL == null)
                    {
                        if (String.IsNullOrEmpty(txtObjectID.Text))
                        {
                            createNew_CHMDTL(ref objCauHoiMucDoKhoTL);
                        }
                        else
                        {
                            int intObjID = Convert.ToInt32(txtObjectID.Text);
                            objCauHoiMucDoKhoTL = entities.CAU_HOI_MUC_DO.Find(intObjID);
                        }
                        if (objCauHoiMucDoKhoTL == null)
                        {
                            createNew_CHMDTL(ref objCauHoiMucDoKhoTL);
                        }
                        objCauHoiMucDoKhoTL.NGAY_SUA = DateTime.Now;
                        objCauHoiMucDoKhoTL.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();
                        objCauHoiMucDoKhoTL.ID_CAU_HOI = obj.ID;
                        objCauHoiMucDoKhoTL.ID_MUC_DO_CAU_HOI = idMucKho;

                        entities.SaveChanges();
                    }
                }
                return obj.ID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("/Modules/Admin/ChonLoaiCauHoi.aspx"));
        }

        protected void showMessage(string strMessage)
        {
            DIV_MESSAGE.Visible = true;
            ltMessageContent.Text = strMessage;
        }

        protected void btlClosePopUp_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE.Visible = false;
            redirectPage();
        }

        protected void redirectPage()
        {
            Session[ATCL_Consts.SESSION_HE_THONG_ID] = txtHeThongID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("ChonLoaiCauHoi.aspx"));
        }

        protected void createNew_CHMDTL(ref CAU_HOI_MUC_DO objCauHoiMucDoTL)
        {
            objCauHoiMucDoTL = new CAU_HOI_MUC_DO();
            objCauHoiMucDoTL.NGAY_TAO = DateTime.Now;
            objCauHoiMucDoTL.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
            objCauHoiMucDoTL.TT_XOA = false;

            entities.CAU_HOI_MUC_DO.Add(objCauHoiMucDoTL);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strReportID = saveObject();
            Response.Redirect(Commons.TitleConst.getTitleConst("ChonLoaiCauHoi.aspx"));
        }
    }
}