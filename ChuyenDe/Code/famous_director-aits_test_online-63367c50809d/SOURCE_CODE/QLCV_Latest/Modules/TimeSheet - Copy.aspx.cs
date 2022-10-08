using CPanel.Commons;
using CPanel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules
{
    public partial class TimeSheet : System.Web.UI.Page
    {        
        private ATCLEntities entities = new ATCLEntities();
        private string strErrorMessage = "";
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {   
                
                //Get Danh sach Loai Cong viec
                Commons.ATCL_Commons.getDanhMuc(drpLoaiCongViec_1, entities, ConfigurationManager.AppSettings["MA_DM_LOAI_CONG_VIEC"]);
                Commons.ATCL_Commons.getDanhMuc(drpLoaiCongViec_2, entities, ConfigurationManager.AppSettings["MA_DM_LOAI_CONG_VIEC"]);
                Commons.ATCL_Commons.getDanhMuc(drpLoaiCongViec_3, entities, ConfigurationManager.AppSettings["MA_DM_LOAI_CONG_VIEC"]);
                Commons.ATCL_Commons.getDanhMuc(drpLoaiCongViec_4, entities, ConfigurationManager.AppSettings["MA_DM_LOAI_CONG_VIEC"]);
                Commons.ATCL_Commons.getDanhMuc(drpLoaiCongViec_5, entities, ConfigurationManager.AppSettings["MA_DM_LOAI_CONG_VIEC"]);
                
            }
        }

        /**
         * Config format of DateTime
         */
        protected void configFormatDateTime()
        {
            dtNgayBaoCao.EditFormatString = Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY;            
        }

        protected bool validate_Row_1 ()
        {
            int i = 1;
            if (!String.IsNullOrEmpty(txtTenCongViec_1.Text))
            {
                if (String.IsNullOrEmpty(txtMoTaChiTiet_1.Text))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_MO_TA_CHO_CONG_VIEC_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_1.SelectedValue))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_CHON_LOAI_CONG_VIEC_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (String.IsNullOrEmpty(txtThoiGIan_1.Text))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_THOI_GIAN_O_DONG_THU") + ": " + i;
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
                        strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_SAI_FORMAT_THOI_GIAN_O_DONG_THU") + ": " + i;
                        return false;
                    }

                }

                return true;
            }

            return false;
        }

        protected bool validate_Row_2()
        {
            int i = 2;
            if (!String.IsNullOrEmpty(txtTenCongViec_2.Text))
            {
                if (String.IsNullOrEmpty(txtMoTaChiTiet_2.Text))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_MO_TA_CHO_CONG_VIEC_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_2.SelectedValue))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_CHON_LOAI_CONG_VIEC_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (String.IsNullOrEmpty(txtThoiGIan_2.Text))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_THOI_GIAN_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (!String.IsNullOrEmpty(txtThoiGIan_2.Text))
                {
                    try
                    {
                        double dbTemp = Convert.ToDouble(txtThoiGIan_2.Text);
                    }
                    catch
                    {
                        strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_SAI_FORMAT_THOI_GIAN_O_DONG_THU") + ": " + i;
                        return false;
                    }

                }

                return true;
            }

            return false;
        }

        protected bool validate_Row_3()
        {
            int i = 3;
            if (!String.IsNullOrEmpty(txtTenCongViec_3.Text))
            {
                if (String.IsNullOrEmpty(txtMoTaChiTiet_3.Text))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_MO_TA_CHO_CONG_VIEC_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_3.SelectedValue))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_CHON_LOAI_CONG_VIEC_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (String.IsNullOrEmpty(txtThoiGIan_3.Text))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_THOI_GIAN_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (!String.IsNullOrEmpty(txtThoiGIan_3.Text))
                {
                    try
                    {
                        double dbTemp = Convert.ToDouble(txtThoiGIan_3.Text);
                    }
                    catch
                    {
                        strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_SAI_FORMAT_THOI_GIAN_O_DONG_THU") + ": " + i;
                        return false;
                    }

                }

                return true;
            }

            return false;
        }

        protected bool validate_Row_4()
        {
            int i = 4;
            if (!String.IsNullOrEmpty(txtTenCongViec_4.Text))
            {
                if (String.IsNullOrEmpty(txtMoTaChiTiet_4.Text))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_MO_TA_CHO_CONG_VIEC_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_4.SelectedValue))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_CHON_LOAI_CONG_VIEC_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (String.IsNullOrEmpty(txtThoiGIan_4.Text))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_THOI_GIAN_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (!String.IsNullOrEmpty(txtThoiGIan_4.Text))
                {
                    try
                    {
                        double dbTemp = Convert.ToDouble(txtThoiGIan_4.Text);
                    }
                    catch
                    {
                        strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_SAI_FORMAT_THOI_GIAN_O_DONG_THU") + ": " + i;
                        return false;
                    }

                }

                return true;
            }

            return false;
        }

        protected bool validate_Row_5()
        {
            int i = 5;
            if (!String.IsNullOrEmpty(txtMoTaChiTiet_5.Text))
            {
                if (String.IsNullOrEmpty(txtTenCongViec_5.Text))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_MO_TA_CHO_CONG_VIEC_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_5.SelectedValue))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_CHON_LOAI_CONG_VIEC_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (String.IsNullOrEmpty(txtThoiGIan_5.Text))
                {
                    strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_THOI_GIAN_O_DONG_THU") + ": " + i;
                    return false;
                }
                else if (!String.IsNullOrEmpty(txtThoiGIan_5.Text))
                {
                    try
                    {
                        double dbTemp = Convert.ToDouble(txtThoiGIan_5.Text);
                    }
                    catch
                    {
                        strErrorMessage = strErrorMessage + "<br/>" + Commons.TitleConst.getTitleConst("MSG_NHAP_SAI_FORMAT_THOI_GIAN_O_DONG_THU") + ": " + i;
                        return false;
                    }

                }
                
                return true;
            }

            return false;
        }

        protected bool validate()
        {   
            if (String.IsNullOrEmpty(txtTenCongViec_1.Text) && String.IsNullOrEmpty(txtTenCongViec_2.Text)
                && String.IsNullOrEmpty(txtTenCongViec_3.Text) && String.IsNullOrEmpty(txtTenCongViec_4.Text)
                && String.IsNullOrEmpty(txtTenCongViec_5.Text))
            {
                showMessage(Commons.TitleConst.getTitleConst("MSG_HAY_NHAP_THONG_TIN_CONG_VIEC"));
                return false;
            }

            validate_Row_1();
            validate_Row_2();
            validate_Row_3();
            validate_Row_4();
            validate_Row_5();
            
            if (!String.IsNullOrEmpty (strErrorMessage))
            {
                showMessage(strErrorMessage);
                return false;
            }

            return true;

        }
        
        protected void saveObject_Row_1()
        {            
            try
            {
                //validate
                if (!validate_Row_1()) return;

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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void saveObject_Row_2()
        {
            try
            {
                //validate
                if (!validate_Row_2()) return;

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

                obj.TEN_CONG_VIEC = txtTenCongViec_2.Text;
                obj.MO_TA = txtMoTaChiTiet_2.Text;
                obj.TONG_THOI_GIAN = Convert.ToDouble(txtThoiGIan_2.Text);

                //Set Loai Cong Viec
                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_2.SelectedValue))
                {
                    obj.ID_LOAI_CONG_VIEC = Convert.ToInt32(drpLoaiCongViec_2.SelectedValue);
                }


                obj.NGAY_SUA = DateTime.Now;
                obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

                //Update Info
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void saveObject_Row_3()
        {
            try
            {
                //validate
                if (!validate_Row_3()) return;

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

                obj.TEN_CONG_VIEC = txtTenCongViec_3.Text;
                obj.MO_TA = txtMoTaChiTiet_3.Text;
                obj.TONG_THOI_GIAN = Convert.ToDouble(txtThoiGIan_3.Text);

                //Set Loai Cong Viec
                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_3.SelectedValue))
                {
                    obj.ID_LOAI_CONG_VIEC = Convert.ToInt32(drpLoaiCongViec_3.SelectedValue);
                }


                obj.NGAY_SUA = DateTime.Now;
                obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

                //Update Info
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void saveObject_Row_4()
        {
            try
            {
                //validate
                if (!validate_Row_4()) return;

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

                obj.TEN_CONG_VIEC = txtTenCongViec_4.Text;
                obj.MO_TA = txtMoTaChiTiet_4.Text;
                obj.TONG_THOI_GIAN = Convert.ToDouble(txtThoiGIan_4.Text);

                //Set Loai Cong Viec
                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_4.SelectedValue))
                {
                    obj.ID_LOAI_CONG_VIEC = Convert.ToInt32(drpLoaiCongViec_4.SelectedValue);
                }


                obj.NGAY_SUA = DateTime.Now;
                obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

                //Update Info
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void saveObject_Row_5()
        {
            try
            {
                //validate
                if (!validate_Row_5()) return;

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

                obj.TEN_CONG_VIEC = txtTenCongViec_5.Text;
                obj.MO_TA = txtMoTaChiTiet_5.Text;
                obj.TONG_THOI_GIAN = Convert.ToDouble(txtThoiGIan_5.Text);

                //Set Loai Cong Viec
                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpLoaiCongViec_5.SelectedValue))
                {
                    obj.ID_LOAI_CONG_VIEC = Convert.ToInt32(drpLoaiCongViec_5.SelectedValue);
                }


                obj.NGAY_SUA = DateTime.Now;
                obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

                //Update Info
                entities.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void saveObject()
        {
            if (!validate()) return;

            saveObject_Row_1();
            saveObject_Row_2();
            saveObject_Row_3();
            saveObject_Row_4();
            saveObject_Row_5();

            
            showMessage(Commons.TitleConst.getTitleConst("MSG_INSERT_SUCCESFULLY"));
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

        protected void btlClosePopUp_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE.Visible = false;
            //Response.Redirect(Commons.TitleConst.getTitleConst("URL_THEO_DOI_CV_LIST"));
        }
    }
}