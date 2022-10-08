using DevExpress.Web;
using System;
using CPanel.Commons;
//using QLNS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using CPanel.Models;

namespace CPanel.Modules
{
    public partial class GanVaiTro : System.Web.UI.Page    
    {
        public string ACCOUNT_STATUS_PENDING = "0";
        public string ACCOUNT_STATUS_APPROVED = "1";
        public string ACCOUNT_STAUTS_REJECTED = "-1";

        public static string lbNotice;
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)            
            {
                //Set Captions for GridView
                Commons.TitleConst.setTitleConst_ASPxGridView(grvVaiTro);
                Commons.TitleConst.setTitleConst_ASPxGridView(grvUsers);

                //get Departments
                getDepartments();

                //get "ACCOUNT STAUTS"
                getAccountStatus();

                grvVaiTro.DataBind();
                grvUsers.DataBind();

            }
        }

        protected void getAccountStatus()
        {
            drpAccountStatus.Items.Add(new ListItem(Commons.TitleConst.getTitleConst("BLANK_ITEM_TITLE"), Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")));
            drpAccountStatus.Items.Add(new ListItem(Commons.TitleConst.getTitleConst("STATUS_ACTIVE_TITLE"), Commons.TitleConst.getTitleConst("STATUS_ACTIVE_VALUE")));
            drpAccountStatus.Items.Add(new ListItem(Commons.TitleConst.getTitleConst("STATUS_INACTIVE_TITLE"), Commons.TitleConst.getTitleConst("STATUS_INACTIVE_VALUE")));
        }

        protected void getDepartments()
        {
            drpDepartments.DataSource = entities.TBL_PHONG_BAN.Where(x=>((bool)x.isDeleted==false) && ((bool)x.isVisible)).ToList();
            drpDepartments.DataValueField = "Id";
            drpDepartments.DataTextField = "DepartmentName";
            drpDepartments.DataBind();

            drpDepartments.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpDepartments.SelectedIndex = 0;
        }

        protected void grvVaiTro_DataBinding(object sender, EventArgs e)
        {
            var lstGroup = entities.TBL_QUYEN.ToList();
            grvVaiTro.DataSource = lstGroup;
        }
                
        protected void grvVaiTro_FocusedRowChanged(object sender, EventArgs e)
        {
            grvUsers.Selection.UnselectAll();
            int intVaiTroId = (int)grvVaiTro.GetRowValues(grvVaiTro.FocusedRowIndex, grvVaiTro.KeyFieldName);
            List<int> objs = entities.TBL_NGUOI_DUNG_QUYEN.Where(x => x.ID_QUYEN == intVaiTroId).Select(x => x.ID_NGUOI_DUNG).Distinct().ToList();
            foreach (var i in objs)
            {
                grvUsers.Selection.SetSelectionByKey(i, true);
            }
            refreshPage();
        }
        
        protected void grvUsers_DataBinding(object sender, EventArgs e)
        {
            bool blAccountStatusALL = false, blDepartment = false;
            int intAccountStatus = 0, intDepartmentID = 0;
            if (drpAccountStatus.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
            {
                blAccountStatusALL = true;
            }
            else
            {
                intAccountStatus = Convert.ToInt32(drpAccountStatus.SelectedValue);
            }

            //get list of user by VAI_TRO
            int intVaiTroId = (int)grvVaiTro.GetRowValues(grvVaiTro.FocusedRowIndex, grvVaiTro.KeyFieldName);
            List<int> lstVaiTroUsers = entities.TBL_NGUOI_DUNG_QUYEN.Where(x => x.ID_QUYEN == intVaiTroId).Select(x => x.ID_NGUOI_DUNG).Distinct().ToList();

            //set beginning value if result = NULL
            if (lstVaiTroUsers == null) 
            {
                lstVaiTroUsers.Add(CommonFuncs.NUMBER_INVALID_INTEGER);
            }

            bool blStatus ; 
            if (intAccountStatus == 1)
            {
                blStatus = false;
            }
            else
            {
                blStatus = true;
            }


            if (drpDepartments.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
            {
                blDepartment = true;
            }
            else
            {
                intDepartmentID = Convert.ToInt32(drpDepartments.SelectedValue);
            }



            //var lstNhanVien = entities.TBL_NGUOI_DUNG.Where(x => (blAccountStatusALL ? true : x.isEnabled == blStatus)).ToList();
            var lstNhanVien = entities.TBL_NGUOI_DUNG.Join(entities.TBL_NGUOI_DUNG_PHONG_BAN, ND => ND.Id, PBND => PBND.UserID, (ND, PBND) => new { ND, PBND })
                                      .Where(x => (blAccountStatusALL ? true : x.ND.isEnabled == blStatus) && (blDepartment ? true : x.PBND.DepartmentID == intDepartmentID)).Select(y=>y.ND).ToList();
            

             grvUsers.DataSource = lstNhanVien;

             //Unchecked & Checked
             grvUsers.Selection.UnselectAll();             
             foreach (var i in lstVaiTroUsers)
             {
                 grvUsers.Selection.SetSelectionByKey(i, true);
             }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int intVaiTroID = Convert.ToInt16(grvVaiTro.GetRowValues(grvVaiTro.FocusedRowIndex, grvVaiTro.KeyFieldName));
            var lstUserId = grvUsers.GetSelectedFieldValues(grvUsers.KeyFieldName);

            // Xóa user khỏi group nếu không chọn
            var orgUserId = entities.TBL_NGUOI_DUNG_QUYEN.Where(x => x.ID_QUYEN == intVaiTroID).Select(x => x.ID_NGUOI_DUNG).ToList();
            foreach (int u in orgUserId)
            {
                if (!lstUserId.Contains(u))
                {
                    TBL_NGUOI_DUNG_QUYEN removeObj = entities.TBL_NGUOI_DUNG_QUYEN.FirstOrDefault(x => x.ID_QUYEN == intVaiTroID && x.ID_NGUOI_DUNG == u);
                    entities.TBL_NGUOI_DUNG_QUYEN.Remove(removeObj);
                    entities.SaveChanges();
                }
            }

            // Thêm user vào group nếu chọn nhưng chưa có trong group
            foreach (int i in lstUserId)
            {
                bool b = entities.TBL_NGUOI_DUNG_QUYEN.Where(x => x.ID_QUYEN == intVaiTroID && x.ID_NGUOI_DUNG == i).Any();
                if(!b)
                {
                    //Update status User
                    TBL_NGUOI_DUNG objNhanVien = entities.TBL_NGUOI_DUNG.Find(i);
                    //objNhanVien.isEnabled = false;                    

                    //Insert VAI_TRO cho USER
                    TBL_NGUOI_DUNG_QUYEN obj = new TBL_NGUOI_DUNG_QUYEN();
                    //if (entities.jos_rights_users.Count() > 0) obj.id = entities.jos_rights_users.Max(x => x.id) + 1;
                    //else obj.id=1;
                    obj.ID_QUYEN = (int)intVaiTroID;
                    obj.ID_NGUOI_DUNG = (int)i;
                    //obj.CREATED = obj.LASTMODIFY = DateTime.Now;
                    //obj.CREATEDBY = obj.MODIFYBY = CheckUserInfo.GetUserId();
                    entities.TBL_NGUOI_DUNG_QUYEN.Add(obj);
                    entities.SaveChanges();
                }
            }

            //Display Message Box
            Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_UPDATE_SUCCESFULLY"), Page);
        }

        protected void drpUnitName_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshPage();
        }

        protected void drpAccountStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshPage();
        }

        public void refreshPage()
        {
            grvVaiTro.DataBind();
            grvUsers.DataBind();
        }

        protected void drpDepartments_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            grvUsers.DataBind();
        }
    }
}