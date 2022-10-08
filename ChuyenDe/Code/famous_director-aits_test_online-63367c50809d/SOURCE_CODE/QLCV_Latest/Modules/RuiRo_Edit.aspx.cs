using CPanel.Commons;
using CPanel.Models;
using CPanel.Models.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules
{
    public partial class RuiRo_Edit : System.Web.UI.Page
    {        
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                //Get Danh sach He Thong
                Commons.ATCL_Commons.getHeThong(drpHeThong, entities);

                //Get Danh sach Hop Dong
                //Commons.ATCL_Commons.getHopDong(drpPLHD, entities);

                //get Session "OBJECT_ID"
                if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_OBJECT_ID]))
                {
                    txtObjectID.Text = Session[ATCL_Consts.SESSION_OBJECT_ID].ToString();
                    Session[ATCL_Consts.SESSION_OBJECT_ID] = null;
                }

                //get Session "HE_THONG_ID"
                if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_HE_THONG_ID]))
                {
                    txtHeThongID.Text = Session[ATCL_Consts.SESSION_HE_THONG_ID].ToString();
                    drpHeThong.SelectedValue = txtHeThongID.Text;
                    Session[ATCL_Consts.SESSION_HE_THONG_ID] = null;
                }

                
                //Get Danh sach Ket qua cong viec
                Commons.ATCL_Commons.getDanhMuc(drpKetQuaCV, entities, ConfigurationManager.AppSettings["MA_DM_KET_QUA_CONG_VIEC"]);

                //Get Nguoi Dung
                Commons.ATCL_Commons.getNguoiDung(drpNguoiChuTri, entities);

                //Config Date Time
                configFormatDateTime();

                //get Object info
                getObjects();
                                
            }
        }

        public void getObjects()
        {            
            if (!String.IsNullOrEmpty(txtObjectID.Text))
            {
                int intObjectID = Convert.ToInt32(txtObjectID.Text);
                var obj = entities.TBL_RUI_RO.Where(x => x.ID == intObjectID).FirstOrDefault();
                if (obj != null)
                {
                    txtMaRuiRo.Text = obj.MA_RUI_RO;
                    txtNoiDung.Text = obj.NOI_DUNG;
                    txtMoTa.Text = obj.MO_TA;
                    txtGiaiPhap.Text = obj.GIAI_PHAP;
                    txtKienNghi.Text = obj.KIEN_NGHI;
                    txtGhiChu.Text = obj.GHI_CHU;
                    
                    if (obj.ID_HE_THONG != null)
                        drpHeThong.SelectedValue = obj.ID_HE_THONG.ToString();

                    if (obj.NGAY_BAT_DAU != null)
                    {
                        dtNgayBatDau.Text = ((DateTime)obj.NGAY_BAT_DAU).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                        dtNgayBatDau.Value = ((DateTime)obj.NGAY_BAT_DAU).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                    }

                    if (obj.NGAY_KET_THUC != null)
                    {
                        dtNgayKetThuc.Text = ((DateTime)obj.NGAY_KET_THUC).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                        dtNgayKetThuc.Value = ((DateTime)obj.NGAY_KET_THUC).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                    }

                    if (obj.ID_NGUOI_CHU_TRI != null)
                        drpNguoiChuTri.SelectedValue = obj.ID_NGUOI_CHU_TRI.ToString();
                    

                    if (obj.ID_KET_QUA != null)
                        drpKetQuaCV.SelectedValue = obj.ID_KET_QUA.ToString();

                    cbTrachNhiemAITS.Checked = (bool)obj.TT_TRACH_NHIEM_AITS ? true : false;
                    cbTrachNhiemKH.Checked = (bool)obj.TT_TRACH_NHIEM_KH ? true : false;
                    cbTrachNhiemDT.Checked = (bool)obj.TT_TRACH_NHIEM_DT ? true : false;

                    txtGhiChu.Text = obj.GHI_CHU;
                }
            }
        }

        /**
         * Config format of DateTime
         */
        protected void configFormatDateTime()
        {            
            dtNgayBatDau.EditFormatString = Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY;
            dtNgayKetThuc.EditFormatString = Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY;
            dtNgayPhatSinh.EditFormatString = Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY;
        }

        
        protected string saveObject()
        {            
            try
            {
                TBL_RUI_RO obj = new TBL_RUI_RO();
                if (String.IsNullOrEmpty(txtObjectID.Text)) //Create new item
                {                    
                    obj.NGAY_TAO = DateTime.Now;
                    obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    obj.TT_XOA = false;

                    entities.TBL_RUI_RO.Add(obj);
                }
                else //Edit the item
                {
                    int intObjID = Convert.ToInt32(txtObjectID.Text);
                    obj = entities.TBL_RUI_RO.Find(intObjID);
                }

                obj.MA_RUI_RO = txtMaRuiRo.Text;
                obj.NOI_DUNG = txtNoiDung.Text;
                obj.MO_TA = txtMoTa.Text;
                obj.GIAI_PHAP = txtGiaiPhap.Text;
                obj.KIEN_NGHI = txtKienNghi.Text;
                obj.GHI_CHU = txtGhiChu.Text;

                //Set He Thong
                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpHeThong.SelectedValue))
                {
                    obj.ID_HE_THONG = Convert.ToInt32(drpHeThong.SelectedValue);
                }

                //Set Ket Qua CV
                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpKetQuaCV.SelectedValue))
                {
                    obj.ID_KET_QUA = Convert.ToInt32(drpKetQuaCV.SelectedValue);
                }

                obj.ID_NGUOI_CHU_TRI = Convert.ToInt32(drpNguoiChuTri.SelectedValue);

                obj.NGAY_SUA = DateTime.Now;
                obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

                if (!String.IsNullOrEmpty(dtNgayBatDau.Text))
                    obj.NGAY_BAT_DAU = DateTime.ParseExact(dtNgayBatDau.Text, Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY, System.Globalization.CultureInfo.InvariantCulture);
                
                if (!String.IsNullOrEmpty(dtNgayKetThuc.Text))
                    obj.NGAY_KET_THUC = DateTime.ParseExact(dtNgayKetThuc.Text, Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY, System.Globalization.CultureInfo.InvariantCulture);

                if (!String.IsNullOrEmpty(dtNgayPhatSinh.Text))
                    obj.NGAY_PHAT_SINH = DateTime.ParseExact(dtNgayPhatSinh.Text, Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY, System.Globalization.CultureInfo.InvariantCulture);

                obj.TT_TRACH_NHIEM_AITS = cbTrachNhiemAITS.Checked ? true : false;
                obj.TT_TRACH_NHIEM_KH = cbTrachNhiemKH.Checked ? true : false;
                obj.TT_TRACH_NHIEM_DT = cbTrachNhiemDT.Checked ? true : false;

                //Update Info
                entities.SaveChanges();

                //Return Result
                return obj.ID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {  

            //save Report
            string strReportID = saveObject();
            showMessage(Commons.TitleConst.getTitleConst("MSG_INSERT_SUCCESFULLY"));
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            redirectPage();
        }

        protected void redirectPage()
        {
            Session[ATCL_Consts.SESSION_HE_THONG_ID] = txtHeThongID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_RUI_RO_LIST"));
        }

       

        private int GetNumberOfWorkingDays (DateTime start, DateTime stop)
        {
            int days = 0;
            while (start <= stop)
            {
                if (start.DayOfWeek != DayOfWeek.Saturday && start.DayOfWeek != DayOfWeek.Sunday)
                {
                    ++days;
                }
                start = start.AddDays(1);
            }
            return days;
        }

    }
}