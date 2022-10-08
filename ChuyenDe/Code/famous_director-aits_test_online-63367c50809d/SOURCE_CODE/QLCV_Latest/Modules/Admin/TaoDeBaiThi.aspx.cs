using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPanel.Commons;
using CPanel.Models;
using CPanel.Models.Views;

namespace CPanel.Modules.Admin
{
    public partial class TaoDeBaiThi : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        public double seconds;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Lay chu de bai thi
                int intChuDeBaiThi;
                SessionForChuDeBaiThi objSessionForChuDeBaiThi = (SessionForChuDeBaiThi)Session[Commons.ConstValues.SESSION_CHUDEBAITHI];

                //goi chu de cau hoi 
                getChuDeCauHoi();


                if (objSessionForChuDeBaiThi != null)
                {
                    //Lay ID bai thi
                    txtObjectID.Text = objSessionForChuDeBaiThi.SESSION_OBJECT_ID;

                    int intBaiThiID = Convert.ToInt32(txtObjectID.Text);
                    //lay ten chu de bai thi
                    intChuDeBaiThi = (int)entities.BAI_THI.Where(x => x.ID == intBaiThiID).Select(y => y.ID_CHU_DE_BAI_THI).FirstOrDefault();

                    var objChuDeBT = entities.CHU_DE_BAI_THI.Find(intChuDeBaiThi);
                    if (objChuDeBT != null)
                        lblLoaiBT.Text = objChuDeBT.TEN_CHU_DE;

                    // lay muc do bai thi
                    int intMucDoBaiThiID = (int)entities.BAI_THI.Where(x => x.ID == intBaiThiID).Select(y => y.ID_MUC_DO_BAI_THI).FirstOrDefault();
                    var objMucDoBaiThi = entities.MUC_DO_BAI_THI.Find(intMucDoBaiThiID);
                    if (objMucDoBaiThi != null)
                        lblMucDo.Text = objMucDoBaiThi.TEN_MUC_DO;

                    //lay ten bai thi
                    var objTenBaiThi = entities.BAI_THI.Find(intBaiThiID);
                    lblTenBaiThi.Text = objTenBaiThi.TEN_BAI_THI;

                    //lay thoi gian
                    var objThoiGianBaiThi = entities.BAI_THI.Find(intBaiThiID);
                    lblThoiGian.Text = objThoiGianBaiThi.THOI_GIAN.ToString() + " phút";

                    Session[Commons.ConstValues.SESSION_CHUDEBAITHI] = null;

                    //Kiểm tra bài thi đã được gửi chưa
                    var lstNgayGui = entities.BAI_THI_UNG_VIEN.Where(x => x.ID_BAI_THI == intBaiThiID).Select(y => y.NGAY_GUI_MAIL).ToList();
                    foreach (var item in lstNgayGui)
                    {
                        if (item != null)
                        {
                            btnAddCauHoi.Visible = false;
                            break;
                        }
                    }

                }

            }
            getObjects();
            grvCauHoi.DataBind();

        }

        protected void getObjects()
        {
            List<TAO_BAI_THI_VIEW> lstBaiThi = new List<TAO_BAI_THI_VIEW>();

            string strObjID = txtObjectID.Text;
            string strCauHoiID = txtCauHoiID.Text;

            if (!String.IsNullOrEmpty(strObjID))
            {
                txtObjectID.Text = strObjID;
                int intObjID = Convert.ToInt32(strObjID);
                Session[ATCL_Consts.SESSION_OBJECT_ID] = null;

                List<DAP_AN> lstAnswer;
                var lstLoad = entities.BAI_THI_CAU_HOI.Where(x => x.ID_BAI_THI == intObjID).ToList();

                if ((lstLoad != null) && (lstLoad.Count > 0))
                {
                    int i = 0;
                    int SoCau = 1;
                    string strDapAn = "";
                    //Lay danh sach cau hoi TN
                    foreach (var item in lstLoad)
                    {
                        TAO_BAI_THI_VIEW objBaiThiView = new TAO_BAI_THI_VIEW();
                        strDapAn = "";
                        //////var lstCauTN = entities.CAU_HOI.Where(x => x.ID_LOAI_CAU_HOI == 1).ToList();
                        //ltQuestion.Text = ltQuestion.Text + "<div class='cau_hoi_css'>";
                        //ltQuestion.Text = ltQuestion.Text + string.Format(@"
                        //    <p>Câu {0}: <b> {1}</p></b>  
                        //    ", SoCau, item.CAU_HOI.NOI_DUNG_CAU_HOI);

                        objBaiThiView.CAU_HOI = string.Format(@"
                                <p>Câu {0}: <b> {1}</p></b>  
                                ", SoCau, item.CAU_HOI.NOI_DUNG_CAU_HOI);

                        //Lay danh sach dap an cau hoi trac nghiem
                        lstAnswer = entities.CAU_HOI.Join(entities.DAP_AN, CH => CH.ID, DA => DA.ID_CAU_HOI, (CH, DA) => new { CH, DA }).Where(x => (x.CH.ID == x.DA.ID_CAU_HOI) && (x.DA.ID_CAU_HOI == item.ID_CAU_HOI) && (x.CH.ID_LOAI_CAU_HOI == 1)).Select(y => y.DA).ToList();
                        if ((lstAnswer != null) && (lstAnswer.Count > 0))//Trac nghiem
                        {
                            foreach (var item1 in lstAnswer)
                            {
                                strDapAn = strDapAn + string.Format(@"
                                <div class='dap_an_TN_css'><p><input type='checkbox' onclick='return false;'/>&nbsp{0}</p></div>
                                        ", item1.NOI_DUNG_DAP_AN);
                            }
                        }
                        else //Tu luan
                        {
                            strDapAn = strDapAn + string.Format(@"
                                <div class='dap_an_TL_css'><p><input type='text' readonly/></p></div>");
                        }
                        i++;
                        SoCau++;
                        //objBaiThiView.STT = String.Format("<input  type='text'/>"
                        objBaiThiView.DAP_AN = strDapAn;
                        objBaiThiView.ID = (int)item.ID_CAU_HOI;
                        lstBaiThi.Add(objBaiThiView);

                    }
                }
            }

            grvObjects.DataSource = lstBaiThi;
            grvObjects.DataBind();
            grvCauHoi.DataBind();
        }

        protected int getObjectID()
        {
            return Convert.ToInt32(txtObjectID.Text);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_DANH_SACH_BAI_THI_CAU_HOI_LIST"));
        }

        protected void grvObjects_DataBinding(object sender, EventArgs e)
        {

        }

        protected void grvCauHoi_DataBinding(object sender, EventArgs e)
        {
            if (!drpChuDeCauHoi.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
            {
                int intChudeCauHoi = Convert.ToInt32(drpChuDeCauHoi.SelectedValue);
                int intBaiThiID = Convert.ToInt32(txtObjectID.Text);
                var lstTrungLapCauHoi = entities.BAI_THI_CAU_HOI.Where(x => x.ID_BAI_THI == intBaiThiID).Select(y => y.ID_CAU_HOI).ToList();
                // tranh trung lap cau hoi
                var lstCauHoi = entities.CAU_HOI.Where(x => (x.ID_CHU_DE_BAI_THI == intChudeCauHoi) && (x.TT_XOA == false) && (!lstTrungLapCauHoi.Contains(x.ID))).ToList();
                grvCauHoi.DataSource = lstCauHoi;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var intObjIdCauHoi = grvCauHoi.GetSelectedFieldValues(grvCauHoi.KeyFieldName);
            if ((intObjIdCauHoi != null) && (intObjIdCauHoi.Count > 0))
            {
                int intBaiThiID = Convert.ToInt32(txtObjectID.Text);

                foreach (int item in intObjIdCauHoi)
                {
                    BAI_THI_CAU_HOI objBaiThiCauHoi = entities.BAI_THI_CAU_HOI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_CAU_HOI == item)).FirstOrDefault();
                    if (objBaiThiCauHoi == null)
                    {
                        BAI_THI_CAU_HOI obj = new BAI_THI_CAU_HOI();
                        obj.ID_CAU_HOI = item;
                        obj.ID_BAI_THI = intBaiThiID;
                        entities.BAI_THI_CAU_HOI.Add(obj);

                        int intIDMucDoCauHoi = (int)entities.CAU_HOI_MUC_DO.Where(x => x.ID_CAU_HOI == item).Select(y => y.ID_MUC_DO_CAU_HOI).FirstOrDefault();
                        int intIDLoaiCH = (int)entities.CAU_HOI.Where(x => x.ID == item).Select(y => y.ID_LOAI_CAU_HOI).FirstOrDefault();
                        CAU_HINH_BAI_THI objUpdateCauHinh = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == intIDLoaiCH)).FirstOrDefault();
                        switch (intIDMucDoCauHoi)
                        {
                            case 1:
                                objUpdateCauHinh.SO_LUONG_CAU_DE += 1;
                                break;
                            case 2:
                                objUpdateCauHinh.SO_LUONG_CAU_TB += 1;
                                break;
                            case 3:
                                objUpdateCauHinh.SO_LUONG_CAU_KHO += 1;
                                break;
                            default:
                                break;
                        }
                        entities.SaveChanges();
                    }
                }
            }
            getObjects();
            DIV_CAU_HOI.Visible = false;
        }


        protected void btlDeleteObject_Click(object sender, EventArgs e)
        {
            if (btnAddCauHoi.Visible == false)
            {
                Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Bài thi đã có người làm"), Page);
            }
            else
            {
                showMessage(Commons.TitleConst.getTitleConst("MSG_BAN_CO_CHAC_CHAN_XOA_KHONG"));
                //Open Popup
                btnOK_DeleteObject.Visible = true;
                DIV_MESSAGE.Visible = true;
            }

        }
        protected void showMessage(string strMessage)
        {
            DIV_MESSAGE.Visible = true;
            ltMessageContent.Text = strMessage;
        }

        protected void btnOK_DeleteObject_Click(object sender, EventArgs e)
        {
            int intCauHoiID = Convert.ToInt32(txtCauHoiID.Text);
            int intBaiThiID = Convert.ToInt32(txtObjectID.Text);
            BAI_THI_CAU_HOI obj = entities.BAI_THI_CAU_HOI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_CAU_HOI == intCauHoiID)).FirstOrDefault();
            if (obj != null)
            {
                entities.BAI_THI_CAU_HOI.Remove(obj);
                entities.SaveChanges();
            }
            int intIDMucDoCauHoi = (int)entities.CAU_HOI_MUC_DO.Where(x => x.ID_CAU_HOI == intCauHoiID).Select(y => y.ID_MUC_DO_CAU_HOI).FirstOrDefault();
            int intLoaiCauHoi = (int)entities.CAU_HOI.Where(x => x.ID == intCauHoiID).Select(x => x.ID_LOAI_CAU_HOI).FirstOrDefault();
            CAU_HINH_BAI_THI dltCauHoi = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == intLoaiCauHoi)).FirstOrDefault();
            switch (intIDMucDoCauHoi)
            {
                case 1:
                    dltCauHoi.SO_LUONG_CAU_DE -= 1;
                    break;
                case 2:
                    dltCauHoi.SO_LUONG_CAU_TB -= 1;
                    break;
                case 3:
                    dltCauHoi.SO_LUONG_CAU_KHO -= 1;
                    break;
                default:
                    break;
            }
            entities.SaveChanges();
            //refresh Gridview
            getObjects();

            //Close Popup
            DIV_MESSAGE.Visible = false;
            btnOK_DeleteObject.Visible = false;
        }

        protected void btlClosePopUp_Message_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE.Visible = false;
        }

        protected void drpChuDeCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvCauHoi.DataBind();
        }

        protected void getChuDeCauHoi()
        {
            drpChuDeCauHoi.DataSource = entities.CHU_DE_BAI_THI.Where(x => x.TT_XOA == false).ToList();
            drpChuDeCauHoi.DataValueField = "Id";
            drpChuDeCauHoi.DataTextField = "TEN_CHU_DE";
            drpChuDeCauHoi.DataBind();
            drpChuDeCauHoi.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpChuDeCauHoi.SelectedIndex = 0;
        }

        protected void btlClosePopUp_Click(object sender, EventArgs e)
        {
            DIV_CAU_HOI.Visible = false;
        }
        protected void btnAddCauHoi_Click(object sender, EventArgs e)
        {
            DIV_CAU_HOI.Visible = true;
        }
    }
}