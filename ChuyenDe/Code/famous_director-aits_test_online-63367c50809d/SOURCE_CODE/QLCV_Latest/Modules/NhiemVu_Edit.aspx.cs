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
    public partial class NhiemVu_Edit : System.Web.UI.Page
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

                //get Session "NHIEM_VU_ID"
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

                //get Session "NHIEM VU CHA"
                if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_PARENT_OBJECT_ID]))
                {
                    txtParentObjectID.Text = Session[ATCL_Consts.SESSION_PARENT_OBJECT_ID].ToString();
                    int intNhiemVu_Cha = Convert.ToInt32(txtParentObjectID.Text);
                    var parentObjID = entities.TBL_NHIEM_VU.Find(intNhiemVu_Cha);
                    if (parentObjID != null)
                        txtNhiemVuCha.Text = parentObjID.TEN_NHIEM_VU;
                    Session[ATCL_Consts.SESSION_PARENT_OBJECT_ID] = null;
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
                var obj = entities.TBL_NHIEM_VU.Where(x => x.ID == intObjectID).FirstOrDefault();
                if (obj != null)
                {
                    txtTenNhiemVu.Text = obj.TEN_NHIEM_VU;
                    
                    if (obj.ID_HE_THONG_DA != null)
                        drpHeThong.SelectedValue = obj.ID_HE_THONG_DA.ToString();

                    if (obj.NGAY_BAT_DAU_DK != null)
                    {
                        dtNgayBatDauDK.Text = ((DateTime)obj.NGAY_BAT_DAU_DK).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                        dtNgayBatDauDK.Value = ((DateTime)obj.NGAY_BAT_DAU_DK).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                    }

                    if (obj.NGAY_KET_THUC_DK != null)
                    {
                        dtNgayKetThucDK.Text = ((DateTime)obj.NGAY_KET_THUC_DK).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                        dtNgayKetThucDK.Value = ((DateTime)obj.NGAY_KET_THUC_DK).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
                    }

                    if (obj.ID_NGUOI_CHU_TRI != null)
                        drpNguoiChuTri.SelectedValue = obj.ID_NGUOI_CHU_TRI.ToString();
                    

                    if (obj.ID_KET_QUA != null)
                        drpKetQuaCV.SelectedValue = obj.ID_KET_QUA.ToString();

                    txtGhiChu.Text = obj.GHI_CHU;
                }
            }
        }

        /**
         * Config format of DateTime
         */
        protected void configFormatDateTime()
        {            
            dtNgayBatDauDK.EditFormatString = Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY;
            dtNgayKetThucDK.EditFormatString = Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY;
        }

        
        protected string saveObject()
        {            
            try
            {
                TBL_NHIEM_VU obj = new TBL_NHIEM_VU();
                if (String.IsNullOrEmpty(txtObjectID.Text)) //Create new item
                {                    
                    obj.NGAY_TAO = DateTime.Now;
                    obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    obj.TT_XOA = false;

                    entities.TBL_NHIEM_VU.Add(obj);
                }
                else //Edit the item
                {
                    int intObjID = Convert.ToInt32(txtObjectID.Text);
                    obj = entities.TBL_NHIEM_VU.Find(intObjID);
                }

                obj.TEN_NHIEM_VU = txtTenNhiemVu.Text;

                if (!String.IsNullOrEmpty(txtParentObjectID.Text))
                {
                    obj.ID_CHA = Convert.ToInt32(txtParentObjectID.Text);
                }
                else
                    obj.ID_CHA = 0;

                //Set Hop Dong
                //if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpPLHD.SelectedValue))
                //{
                //    obj.ID_HOP_DONG = Convert.ToInt32(drpPLHD.SelectedValue);
                //}

                //Set He Thong
                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpHeThong.SelectedValue))
                {
                    obj.ID_HE_THONG_DA = Convert.ToInt32(drpHeThong.SelectedValue);
                }

                //Set Ket Qua CV
                if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpKetQuaCV.SelectedValue))
                {
                    obj.ID_KET_QUA = Convert.ToInt32(drpKetQuaCV.SelectedValue);
                }

                obj.ID_NGUOI_CHU_TRI = Convert.ToInt32(drpNguoiChuTri.SelectedValue);

                obj.NGAY_SUA = DateTime.Now;
                obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

                if (!String.IsNullOrEmpty(dtNgayBatDauDK.Text))
                    obj.NGAY_BAT_DAU_DK = DateTime.ParseExact(dtNgayBatDauDK.Text, Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY, System.Globalization.CultureInfo.InvariantCulture);
                
                if (!String.IsNullOrEmpty(dtNgayKetThucDK.Text))
                    obj.NGAY_KET_THUC_DK = DateTime.ParseExact(dtNgayKetThucDK.Text, Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY, System.Globalization.CultureInfo.InvariantCulture);

                obj.GHI_CHU = txtGhiChu.Text;

                //Update Info
                entities.SaveChanges();

                //Update Tat ca Nhiem Vu
                int intHeThongDA_ChangeRequest_ID = (int) obj.ID_HE_THONG_DA;
                update_TatCaNhiemVu(0, null, intHeThongDA_ChangeRequest_ID, ATCL_Consts.KIEU_NHIEM_VU_DU_AN);

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
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_NHIEM_VU_LIST"));
        }

        protected void updateItemNhiemVu(int intID)
        {
            var objNV_Con = entities.TBL_NHIEM_VU.Find(intID);

            DateTime? dtNgayBatDau_Min = entities.TBL_NHIEM_VU.Where(x => x.ID_CHA == intID).Min(y => y.NGAY_BAT_DAU_DK);
            DateTime? dtNgayKetThuc_Max = entities.TBL_NHIEM_VU.Where(x => x.ID_CHA == intID).Max(y => y.NGAY_KET_THUC_DK);


            if (dtNgayBatDau_Min != null)
            {
                objNV_Con.NGAY_BAT_DAU_DK = dtNgayBatDau_Min;
            }

            if (dtNgayKetThuc_Max != null)
            {
                objNV_Con.NGAY_KET_THUC_DK = dtNgayKetThuc_Max;

            }

            if ((objNV_Con.NGAY_BAT_DAU_DK != null) && (objNV_Con.NGAY_KET_THUC_DK != null))
                objNV_Con.SO_NGAY_DK = GetNumberOfWorkingDays((DateTime)objNV_Con.NGAY_BAT_DAU_DK, (DateTime)objNV_Con.NGAY_KET_THUC_DK);

            entities.SaveChanges();
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

        protected void update_TatCaNhiemVu(int intCapMenu, string strIDMenu, int intHeThongDA_ChangeReQuest_ID, int intKieuNhiemVu)
        {
            int intIDMenu = 0; bool blNumber = false;
            if (!String.IsNullOrEmpty(strIDMenu))
            {
                intIDMenu = Convert.ToInt32(strIDMenu);
                blNumber = true;
            }
            

            List<TBL_NHIEM_VU> lstObjs = null;
            if (intKieuNhiemVu == ATCL_Consts.KIEU_NHIEM_VU_DU_AN)
            {
                lstObjs = entities.TBL_NHIEM_VU.Where(x => ((blNumber && x.ID_CHA == intIDMenu) || (blNumber == false && x.ID_CHA == 0))
                                                   && x.ID_HE_THONG_DA == intHeThongDA_ChangeReQuest_ID)
                                                   .ToList();
            }
            else if (intKieuNhiemVu == ATCL_Consts.KIEU_NHIEM_VU_CHANGE_REQUEST)
            {
                lstObjs = entities.TBL_NHIEM_VU.Where(x => ((blNumber && x.ID_CHA == intIDMenu) || (blNumber == false && x.ID_CHA == 0))
                                                   && x.ID_CHANGE_REQUEST == intHeThongDA_ChangeReQuest_ID)
                                                   .ToList();
            }




            if (lstObjs != null)
            {
                foreach (var item in lstObjs)
                {   
                    update_TatCaNhiemVu(intCapMenu + 1, item.ID.ToString(), intHeThongDA_ChangeReQuest_ID, intKieuNhiemVu);

                    updateItemNhiemVu(item.ID);
                }
            }

            
        }
    }
}