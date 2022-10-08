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
    public partial class TimeSheet_Edit : System.Web.UI.Page
    {        
        private ATCLEntities entities = new ATCLEntities();
        private string strErrorMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_OBJECT_ID]))
                {
                    txtTimeSheetID.Text = Session[ATCL_Consts.SESSION_OBJECT_ID].ToString();
                    Session[ATCL_Consts.SESSION_OBJECT_ID] = null;
                }

                //Set Captions for GridView
                Commons.TitleConst.setTitleConst_ASPxGridView(grvObjects);

                
                //Get Danh sach Loai Cong viec
                Commons.ATCL_Commons.getDanhMuc(drpLoaiCongViec_1, entities, ConfigurationManager.AppSettings["MA_DM_LOAI_CONG_VIEC"]);                

                //Config Date
                configFormatDateTime();

                //get Info
                getTimeSheet();
                
            }
        }


        public void getTimeSheet()
        {
            getBaoCaoCV();
            if (!String.IsNullOrEmpty(txtTimeSheetID.Text))
            {
                int intTimeSheetID = Convert.ToInt32(txtTimeSheetID.Text);
                var objTimeSheet = entities.TBL_TIMESHEET.Where(x => x.ID == intTimeSheetID).FirstOrDefault();
                if (objTimeSheet != null)
                {
                    txtKhoKhanKN.Text = objTimeSheet.KHO_KHAN_KIEN_NGHI;
                    txtSangKien.Text = objTimeSheet.SANG_KIEN;
                    dtNgayBaoCao.Text = ((DateTime)objTimeSheet.NGAY_BAO_CAO).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                }
            }
        }

        public void getBaoCaoCV ()
        {
            int intTimeSheetID = 0;
            if (String.IsNullOrEmpty(txtTimeSheetID.Text)) intTimeSheetID = Commons.ATCL_Consts.NUMBER_INVALID_INTEGER;
            else intTimeSheetID = Convert.ToInt32(txtTimeSheetID.Text);


            
            var lstObjects = entities.TBL_BAO_CAO_CV.Where(x=>x.ID_TIMESHEET == intTimeSheetID
                                    ).Select(y => new TBL_BAO_CAO_CV_VIEW()
                                    {
                                        ID = y.ID,
                                        ID_LOAI_CONG_VIEC = y.ID_LOAI_CONG_VIEC,
                                        TEN_CONG_VIEC = y.TEN_CONG_VIEC,
                                        MO_TA = y.MO_TA,
                                        STT = y.STT,
                                        ID_NGUOI_SUA = y.ID_NGUOI_SUA,
                                        ID_NGUOI_TAO = y.ID_NGUOI_TAO,
                                        ID_TIMESHEET = y.ID_TIMESHEET,
                                        NGAY_SUA = y.NGAY_SUA,
                                        NGAY_TAO = y.NGAY_TAO,
                                        TONG_THOI_GIAN = y.TONG_THOI_GIAN
                                    })
                                    .OrderByDescending(z => z.STT).ToList();

            grvObjects.DataSource = lstObjects;
            grvObjects.DataBind();
        }

        /**
         * Config format of DateTime
         */
        protected void configFormatDateTime()
        {
            dtNgayBaoCao.EditFormatString = Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY;
            dtNgayBaoCao.Text = DateTime.Today.ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
        }

        protected bool validate ()
        {            
            if (String.IsNullOrEmpty(txtTenCongViec_1.Text))
            {
                showMessage(Commons.TitleConst.getTitleConst("MSG_NHAP_TEN_CONG_VIEC"));
                return false;
            }
            else if (String.IsNullOrEmpty(txtMoTaChiTiet_1.Text))
            {
                showMessage(Commons.TitleConst.getTitleConst("MSG_NHAP_MO_TA_CHO_CONG_VIEC_O_DONG_THU")) ;
                return false;
            }
            else if (Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_1.SelectedValue))
            {
                showMessage(Commons.TitleConst.getTitleConst("MSG_CHON_LOAI_CONG_VIEC_O_DONG_THU")) ;
                return false;
            }
            else if (String.IsNullOrEmpty(txtThoiGIan_1.Text))
            {
                showMessage(Commons.TitleConst.getTitleConst("MSG_NHAP_THOI_GIAN_O_DONG_THU")) ;
                return false;
            }
            else if (!String.IsNullOrEmpty(txtThoiGIan_1.Text))
            {
                try
                {
                    double dbTemp = Convert.ToDouble(txtThoiGIan_1.Text);
                }
                catch
                {
                    showMessage(Commons.TitleConst.getTitleConst("MSG_NHAP_SAI_FORMAT_THOI_GIAN_O_DONG_THU")) ;
                    return false;
                }

            }

            return true;            
        }

        protected void saveTimesheet()
        {
            TBL_TIMESHEET obj = new TBL_TIMESHEET();
            if (String.IsNullOrEmpty(txtTimeSheetID.Text)) //Create new item
            {
                obj.NGAY_TAO = DateTime.Now;
                obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                obj.TT_XOA = false;

                entities.TBL_TIMESHEET.Add(obj);
            }
            else //Edit the item
            {
                int intObjID = Convert.ToInt32(txtTimeSheetID.Text);
                obj = entities.TBL_TIMESHEET.Find(intObjID);
            }

            obj.KHO_KHAN_KIEN_NGHI = txtKhoKhanKN.Text;
            obj.SANG_KIEN = txtSangKien.Text;
            obj.NGAY_BAO_CAO = DateTime.ParseExact(dtNgayBaoCao.Text, Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY, System.Globalization.CultureInfo.InvariantCulture); 


            obj.NGAY_SUA = DateTime.Now;
            obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

            //Update Info
            entities.SaveChanges();

            //reset ID
            txtTimeSheetID.Text = obj.ID.ToString();
        }

        protected void saveObject()
        {            
            try
            {
                
                //validate
                if (!validate()) return;

                saveTimesheet();
                int intTimesheetID = Convert.ToInt32(txtTimeSheetID.Text);

                TBL_BAO_CAO_CV obj = new TBL_BAO_CAO_CV();
                if (String.IsNullOrEmpty(txtObjectID.Text)) //Create new item
                {                    
                    obj.NGAY_TAO = DateTime.Now;
                    obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    obj.TT_XOA = false;

                    entities.TBL_BAO_CAO_CV.Add(obj);
                }
                else //Edit the item
                {
                    int intObjID = Convert.ToInt32(txtObjectID.Text);
                    obj = entities.TBL_BAO_CAO_CV.Find(intObjID);
                }

                obj.ID_TIMESHEET = intTimesheetID;
                obj.TEN_CONG_VIEC = txtTenCongViec_1.Text;
                obj.MO_TA = txtMoTaChiTiet_1.Text;
                obj.TONG_THOI_GIAN = Convert.ToDouble(txtThoiGIan_1.Text);
                
                //Set Loai Cong Viec
                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_1.SelectedValue))
                {
                    obj.ID_LOAI_CONG_VIEC = Convert.ToInt32(drpLoaiCongViec_1.SelectedValue);
                }

                
                obj.NGAY_SUA = DateTime.Now;
                obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

                //Update Info
                entities.SaveChanges();

                //refresh GridView                
                getBaoCaoCV();
                
                
                //Close Popup
                DIV_BACKGROUND_POP_UP.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {  
            //save Report
            saveObject();
        }

        protected void showMessage(string strMessage)
        {
            DIV_MESSAGE.Visible = true;
            ltMessageContent.Text = strMessage;
        }

        public void resetFormBaoCaoCV() {
            txtObjectID.Text = "";
            txtTenCongViec_1.Text = "";
            txtMoTaChiTiet_1.Text = "";
            txtThoiGIan_1.Text = "";
            drpLoaiCongViec_1.SelectedValue = Commons.CommonFuncs.BLANK_ITEM_VALUE;
        }

        protected void btlClosePopUp_Message_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE.Visible = false;
            //Response.Redirect(Commons.TitleConst.getTitleConst("URL_THEO_DOI_CV_LIST"));
        }

        protected void btlClosePopUp_Click(object sender, EventArgs e)
        {
            DIV_BACKGROUND_POP_UP.Visible = false;
            //Response.Redirect(Commons.TitleConst.getTitleConst("URL_THEO_DOI_CV_LIST"));
        }

        protected void grvObjects_DataBinding(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            //Reset Form Bao Cao CV
            resetFormBaoCaoCV();

            //Open Popup
            DIV_BACKGROUND_POP_UP.Visible = true;
        }

        protected void btnSaveTimeSheet_Click(object sender, EventArgs e)
        {
            saveTimesheet();
            //showMessage(Commons.TitleConst.getTitleConst("MSG_INSERT_SUCCESFULLY"));
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_TIMESHEET_LIST"));
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_TIMESHEET_LIST"));
        }

        protected void btnViewObject_Click(object sender, EventArgs e)
        {
            int intObjectID = Convert.ToInt32(txtObjectID.Text);
            var obj = entities.TBL_BAO_CAO_CV.Find(intObjectID);
            if (obj != null)
            {
                txtTenCongViec_1.Text = obj.TEN_CONG_VIEC;
                drpLoaiCongViec_1.SelectedValue = obj.ID_LOAI_CONG_VIEC.ToString();
                txtMoTaChiTiet_1.Text = obj.MO_TA;
                txtThoiGIan_1.Text = obj.TONG_THOI_GIAN.ToString();
            }
            
            //Open Popup
            DIV_BACKGROUND_POP_UP.Visible = true;
        }

        protected void btlDeleteObject_Click(object sender, EventArgs e)
        {
            showMessage(Commons.TitleConst.getTitleConst("MSG_BAN_CO_CHAC_CHAN_XOA_KHONG"));
            
            //Open Popup
            btnOK_DeleteObject.Visible = true;
            DIV_MESSAGE.Visible = true;
        }

        protected void btnOK_DeleteObject_Click(object sender, EventArgs e)
        {
            int intObjectID = Convert.ToInt32(txtObjectID.Text);
            var obj = entities.TBL_BAO_CAO_CV.Find(intObjectID);
            if (obj != null)
            {
                entities.TBL_BAO_CAO_CV.Remove(obj);
                entities.SaveChanges();
            }
            //refresh Form Bao Cao CV
            getBaoCaoCV();

            //Close Popup
            DIV_MESSAGE.Visible = false;
            btnOK_DeleteObject.Visible = false;
        }

    }
}