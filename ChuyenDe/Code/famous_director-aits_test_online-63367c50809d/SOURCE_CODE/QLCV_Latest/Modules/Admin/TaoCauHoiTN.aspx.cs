using CPanel.Commons;
using CPanel.Models;
using System;
using System.Configuration;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;

namespace CPanel.Modules.Admin
{
    public partial class TaoCauHoiTN : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Commons.ATCL_Commons.getChuDe(drpChuDe, entities);

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
                            drpChuDe.Enabled = false;
                            cbDe.Enabled = false;
                            cbTB.Enabled = false;
                            cbKho.Enabled = false;
                            txtNoiDung.ReadOnly = true;
                            cbDapAn1.Enabled = false;
                            cbDapAn2.Enabled = false;
                            cbDapAn3.Enabled = false;
                            cbDapAn4.Enabled = false;
                            txtDA1.ReadOnly = true;
                            txtDA2.ReadOnly = true;
                            txtDA3.ReadOnly = true;
                            txtDA4.ReadOnly = true;
                        }
                    }
                    
                }
                getObjects();
            }

            //int intChuDeBaiThi;
            //SessionForChuDeBaiThi objSessionForChuDeBaiThi = (SessionForChuDeBaiThi)Session[Commons.ConstValues.SESSION_CHUDEBAITHI];

            //if ((objSessionForChuDeBaiThi != null) && (!String.IsNullOrEmpty(objSessionForChuDeBaiThi.ID_CHU_DE_BAI_THI)))
            //{
            //    intChuDeBaiThi = Convert.ToInt32(objSessionForChuDeBaiThi.ID_CHU_DE_BAI_THI);
            //    Session[Commons.ConstValues.SESSION_CHUDEBAITHI] = null;

            //    var objChuDeBT = entities.CHU_DE_BAI_THI.Find(intChuDeBaiThi);
            //    if (objChuDeBT != null)
            //        drpChuDe.SelectedValue = objChuDeBT.TEN_CHU_DE;
            //}
        }
        public void getObjects()
        {
            if (!String.IsNullOrEmpty(txtObjectID.Text))
            {
                int intObjectID = Convert.ToInt32(txtObjectID.Text);
                var obj = entities.CAU_HOI.Where(x => x.ID == intObjectID).FirstOrDefault();
                if (obj != null)
                {
                    txtNoiDung.Text = obj.NOI_DUNG_CAU_HOI;

                    if (obj.ID_CHU_DE_BAI_THI != null)
                        drpChuDe.SelectedValue = obj.ID_CHU_DE_BAI_THI.ToString();
                }

                var lstMucDo = entities.CAU_HOI_MUC_DO.Where(x => x.ID_CAU_HOI == intObjectID).ToList();
                if ((lstMucDo != null) && (lstMucDo.Count >= 1))
                {
                    foreach (var item in lstMucDo)
                    {
                        if (item.ID_MUC_DO_CAU_HOI == 1)
                        {
                            cbDe.Checked = true;
                        }

                        if (item.ID_MUC_DO_CAU_HOI == 2)
                        {
                            cbTB.Checked = true;
                        }

                        if (item.ID_MUC_DO_CAU_HOI == 3)
                        {
                            cbKho.Checked = true;
                        }
                    }
                }

                var lstDapAn = entities.DAP_AN.Where(x => x.ID_CAU_HOI == intObjectID).ToList();
                if ((lstDapAn != null) && (lstDapAn.Count > 1))
                {
                    int i = 1;
                    foreach (var item in lstDapAn)
                    {
                        if (i == 1)
                        {
                            txtDA1.Text = item.NOI_DUNG_DAP_AN;
                            cbDapAn1.Checked = (bool)item.TRANG_THAI ? true : false;
                            cbDapAn1.TabIndex = (short)item.ID;
                        }
                        i++;
                    }

                    int i2 = 1;
                    foreach (var item in lstDapAn)
                    {
                        if (i2 == 2)
                        {
                            txtDA2.Text = item.NOI_DUNG_DAP_AN;
                            cbDapAn2.Checked = (bool)item.TRANG_THAI ? true : false;
                            cbDapAn2.TabIndex = (short)item.ID;
                        }
                        i2++;
                    }

                    int i3 = 1;
                    foreach (var item in lstDapAn)
                    {
                        if (i3 == 3)
                        {
                            txtDA3.Text = item.NOI_DUNG_DAP_AN;
                            cbDapAn3.Checked = (bool)item.TRANG_THAI ? true : false;
                            cbDapAn3.TabIndex = (short)item.ID;
                        }
                        i3++;
                    }

                    int i4 = 1;
                    foreach (var item in lstDapAn)
                    {
                        if (i4 == 4)
                        {
                            txtDA4.Text = item.NOI_DUNG_DAP_AN;
                            cbDapAn4.Checked = (bool)item.TRANG_THAI ? true : false;
                            cbDapAn4.TabIndex = (short)item.ID;
                        }
                        i4++;
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

                obj.ID_LOAI_CAU_HOI = 1;

                obj.NOI_DUNG_CAU_HOI = txtNoiDung.Text;
                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpChuDe.SelectedValue))
                {
                    obj.ID_CHU_DE_BAI_THI = Convert.ToInt32(drpChuDe.SelectedValue);
                }
                obj.NGAY_SUA = DateTime.Now;
                obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

                entities.SaveChanges();

                var objCauHoiMucDoDe = entities.CAU_HOI_MUC_DO.Join(entities.MUC_DO_CAU_HOI, CHMD => CHMD.ID_MUC_DO_CAU_HOI, MDCH => MDCH.ID, (CHMD, MDCH) => new { CHMD, MDCH })
                                    .Where(x => x.CHMD.ID_CAU_HOI == obj.ID && x.MDCH.MA_MUC_DO.Equals("M01")).Select(y => y.CHMD).FirstOrDefault();
                var idMucDe = entities.MUC_DO_CAU_HOI.Where(x => x.MA_MUC_DO == "M01").Select(x => x.ID).FirstOrDefault();
                if (cbDe.Checked == false)
                {
                    if (objCauHoiMucDoDe != null)
                    {
                        entities.CAU_HOI_MUC_DO.Remove(objCauHoiMucDoDe);
                        entities.SaveChanges();
                    }
                }
                else
                {
                    if (objCauHoiMucDoDe == null)
                    {
                        if (String.IsNullOrEmpty(txtObjectID.Text))
                        {
                            createNew_CHMD(ref objCauHoiMucDoDe);
                        }
                        else
                        {
                            int intObjID = Convert.ToInt32(txtObjectID.Text);
                            objCauHoiMucDoDe = entities.CAU_HOI_MUC_DO.Find(intObjID);
                        }
                        if (objCauHoiMucDoDe == null)
                        {
                            createNew_CHMD(ref objCauHoiMucDoDe);
                        }
                        objCauHoiMucDoDe.NGAY_SUA = DateTime.Now;
                        objCauHoiMucDoDe.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();
                        objCauHoiMucDoDe.ID_CAU_HOI = obj.ID;
                        objCauHoiMucDoDe.ID_MUC_DO_CAU_HOI = idMucDe;

                        entities.SaveChanges();
                    }
                }

                var objCauHoiMucDoTB = entities.CAU_HOI_MUC_DO.Join(entities.MUC_DO_CAU_HOI, CHMD => CHMD.ID_MUC_DO_CAU_HOI, MDCH => MDCH.ID, (CHMD, MDCH) => new { CHMD, MDCH })
                                                        .Where(x => x.CHMD.ID_CAU_HOI == obj.ID && x.MDCH.MA_MUC_DO.Equals("M02")).Select(y => y.CHMD).FirstOrDefault();
                var idMucTB = entities.MUC_DO_CAU_HOI.Where(x => x.MA_MUC_DO == "M02").Select(x => x.ID).FirstOrDefault();
                if (cbTB.Checked == false)
                {
                    if (objCauHoiMucDoTB != null)
                    {
                        entities.CAU_HOI_MUC_DO.Remove(objCauHoiMucDoTB);
                        entities.SaveChanges();
                    }
                }
                else
                {
                    if (objCauHoiMucDoTB == null)
                    {
                        if (String.IsNullOrEmpty(txtObjectID.Text))
                        {
                            createNew_CHMD(ref objCauHoiMucDoTB);
                        }
                        else
                        {
                            int intObjID = Convert.ToInt32(txtObjectID.Text);
                            objCauHoiMucDoTB = entities.CAU_HOI_MUC_DO.Find(intObjID);
                        }
                        if (objCauHoiMucDoTB == null)
                        {
                            createNew_CHMD(ref objCauHoiMucDoTB);
                        }
                        objCauHoiMucDoTB.NGAY_SUA = DateTime.Now;
                        objCauHoiMucDoTB.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();
                        objCauHoiMucDoTB.ID_CAU_HOI = obj.ID;
                        objCauHoiMucDoTB.ID_MUC_DO_CAU_HOI = idMucTB;

                        entities.SaveChanges();
                    }
                }

                var objCauHoiMucDoKho = entities.CAU_HOI_MUC_DO.Join(entities.MUC_DO_CAU_HOI, CHMD => CHMD.ID_MUC_DO_CAU_HOI, MDCH => MDCH.ID, (CHMD, MDCH) => new { CHMD, MDCH })
                                        .Where(x => x.CHMD.ID_CAU_HOI == obj.ID && x.MDCH.MA_MUC_DO.Equals("M03")).Select(y => y.CHMD).FirstOrDefault();
                var idMucKho = entities.MUC_DO_CAU_HOI.Where(x => x.MA_MUC_DO == "M03").Select(x => x.ID).FirstOrDefault();
                if (cbKho.Checked == false)
                {
                    if (objCauHoiMucDoKho != null)
                    {
                        entities.CAU_HOI_MUC_DO.Remove(objCauHoiMucDoKho);
                        entities.SaveChanges();
                    }
                }
                else
                {
                    if (objCauHoiMucDoKho == null)
                    {
                        if (String.IsNullOrEmpty(txtObjectID.Text))
                        {
                            createNew_CHMD(ref objCauHoiMucDoKho);
                        }
                        else
                        {
                            int intObjID = Convert.ToInt32(txtObjectID.Text);
                            objCauHoiMucDoKho = entities.CAU_HOI_MUC_DO.Find(intObjID);
                        }
                        if (objCauHoiMucDoKho == null)
                            createNew_CHMD(ref objCauHoiMucDoKho);


                        objCauHoiMucDoKho.NGAY_SUA = DateTime.Now;
                        objCauHoiMucDoKho.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();
                        objCauHoiMucDoKho.ID_CAU_HOI = obj.ID;
                        objCauHoiMucDoKho.ID_MUC_DO_CAU_HOI = idMucKho;

                        entities.SaveChanges();
                    }
                }

                //Tạo đáp án 1
                DAP_AN da1 = new DAP_AN();
                if (String.IsNullOrEmpty(txtObjectID.Text))
                {
                    da1.NGAY_TAO = DateTime.Now;
                    da1.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    da1.TT_XOA = false;

                    entities.DAP_AN.Add(da1);
                }
                else
                {
                    int intDA1 = Convert.ToInt32(cbDapAn1.TabIndex);
                    da1 = entities.DAP_AN.Find(intDA1);
                }

                if (cbDapAn1.Checked == true)
                {
                    da1.TRANG_THAI = true;
                }
                else
                {
                    da1.TRANG_THAI = false;
                }

                da1.NOI_DUNG_DAP_AN = txtDA1.Text;
                da1.NGAY_SUA = DateTime.Now;
                da1.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();
                da1.ID_CAU_HOI = obj.ID;

                //Tạo đáp án 2
                DAP_AN da2 = new DAP_AN();
                if (String.IsNullOrEmpty(txtObjectID.Text))
                {
                    da2.NGAY_TAO = DateTime.Now;
                    da2.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    da2.TT_XOA = false;

                    entities.DAP_AN.Add(da2);
                }
                else
                {
                    int intDA2 = Convert.ToInt32(cbDapAn2.TabIndex);
                    da2 = entities.DAP_AN.Find(intDA2);
                }

                if (cbDapAn2.Checked == true)
                {
                    da2.TRANG_THAI = true;
                }
                else
                {
                    da2.TRANG_THAI = false;
                }

                da2.NOI_DUNG_DAP_AN = txtDA2.Text;
                da2.NGAY_SUA = DateTime.Now;
                da2.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();
                da2.ID_CAU_HOI = obj.ID;

                //Tạo đáp án 3
                DAP_AN da3 = new DAP_AN();
                if (String.IsNullOrEmpty(txtObjectID.Text))
                {
                    da3.NGAY_TAO = DateTime.Now;
                    da3.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    da3.TT_XOA = false;

                    entities.DAP_AN.Add(da3);
                }
                else
                {
                    int intDA3 = Convert.ToInt32(cbDapAn3.TabIndex);
                    da3 = entities.DAP_AN.Find(intDA3);
                }

                if (cbDapAn3.Checked == true)
                {
                    da3.TRANG_THAI = true;
                }
                else
                {
                    da3.TRANG_THAI = false;
                }

                da3.NOI_DUNG_DAP_AN = txtDA3.Text;
                da3.NGAY_SUA = DateTime.Now;
                da3.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();
                da3.ID_CAU_HOI = obj.ID;

                //Tạo đáp án 4
                DAP_AN da4 = new DAP_AN();
                if (String.IsNullOrEmpty(txtObjectID.Text))
                {
                    da4.NGAY_TAO = DateTime.Now;
                    da4.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    da4.TT_XOA = false;

                    entities.DAP_AN.Add(da4);
                }
                else
                {
                    int intDA4 = Convert.ToInt32(cbDapAn4.TabIndex);
                    da4 = entities.DAP_AN.Find(intDA4);
                }

                if (cbDapAn4.Checked == true)
                {
                    da4.TRANG_THAI = true;
                }
                else
                {
                    da4.TRANG_THAI = false;
                }

                da4.NOI_DUNG_DAP_AN = txtDA4.Text;
                da4.NGAY_SUA = DateTime.Now;
                da4.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();
                da4.ID_CAU_HOI = obj.ID;

                entities.SaveChanges();

                return obj.ID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("ChonLoaiCauHoi.aspx"));
        }

        protected void createNew_CHMD(ref CAU_HOI_MUC_DO objCauHoiMucDo)
        {
            objCauHoiMucDo = new CAU_HOI_MUC_DO();
            objCauHoiMucDo.NGAY_TAO = DateTime.Now;
            objCauHoiMucDo.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
            objCauHoiMucDo.TT_XOA = false;

            entities.CAU_HOI_MUC_DO.Add(objCauHoiMucDo);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            lbChude.Text = "";
            lbDapan.Text = "";
            if (cbDe.Checked == false && cbKho.Checked == false && cbTB.Checked == false)
            {
                lbChude.Text = "Chưa chọn chủ đề";
            }
            else if (cbDapAn1.Checked == false && cbDapAn2.Checked == false && cbDapAn3.Checked == false && cbDapAn4.Checked == false)
            {
                lbDapan.Text = "Chưa chọn đáp án đúng";
            }
            else
            {
                string strReportID = saveObject();
                Response.Redirect(Commons.TitleConst.getTitleConst("ChonLoaiCauHoi.aspx"));
            }
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
    }
}