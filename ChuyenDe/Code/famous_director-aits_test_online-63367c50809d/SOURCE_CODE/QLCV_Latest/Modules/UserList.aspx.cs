using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using CPanel.Models;

namespace CPanel.Modules
{
    public partial class UserList : System.Web.UI.Page    
    {        
        public bool blViewPopup = false;
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)            
            {   
                grvUsers.DataBind();
            }
        }

        void Page_LoadComplete(object sender, EventArgs e)
        {
            // call your download function
            if (blViewPopup)
                Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "viewPopup();", true);
        }

        protected void getUsers() {            
            
        }
        
        protected void grvUsers_DataBinding(object sender, EventArgs e)
        {
            string strAdminUserName = Commons.ConstValues.SUPPER_ADMIN.ToUpper();
            //var lstUser = entities.jos_users.Where (x=> !Commons.ConstValues.CONFIG_EMAIL.Equals(x.usertype) && !strAdminUserName.Equals(x.username.ToUpper())).ToList();
            var lstUser = entities.TBL_NGUOI_DUNG.ToList();
            grvUsers.DataSource = lstUser;
        }

        protected void btnMenuEdit_Click(object sender, EventArgs e)
        {
            blViewPopup = true;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.ConstURL.URL_USER_EDIT);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var lstUsers = grvUsers.GetSelectedFieldValues(grvUsers.KeyFieldName);
            int intCurrentUserID = Convert.ToInt32(Session["UserId"]);
            if ((lstUsers != null) && (lstUsers.Count > 0)) //Disable
            {
                foreach (int i in lstUsers)
                {

                    if (intCurrentUserID == i)
                    {
                        lbMessage.Text = "You can not delete your account";
                        return;
                    }

                    //delete info in all other table
                    deleteAllOtherTables(i);

                    TBL_NGUOI_DUNG objUser = entities.TBL_NGUOI_DUNG.Where(x => x.Id == i).FirstOrDefault();
                    entities.TBL_NGUOI_DUNG.Remove(objUser);
                    entities.SaveChanges();
                }
                Response.Redirect(Commons.ConstURL.URL_USER_VIEW);
            }
            else //No record to delte
            {
                Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_CHOOSE_ROW_TO_DELETE"), Page);
            }
        }

        protected void deleteAllOtherTables (int intUserID)
        {
            //delete in JOS_GROUPS_USERS tbl
            var lstGroupUser = entities.TBL_NGUOI_DUNG_PHONG_BAN.Where(x => x.UserID == intUserID).ToList();
            if ((lstGroupUser != null) && (lstGroupUser.Count > 0))
            {
                foreach (var item in lstGroupUser)
                {
                    entities.TBL_NGUOI_DUNG_PHONG_BAN.Remove(item);
                    entities.SaveChanges();
                }
            }

            //delete in JOS_RIGHTS_USERS tbl
            var lstRightUser = entities.TBL_NGUOI_DUNG_PHONG_BAN.Where(x => x.UserID == intUserID).ToList();
            if ((lstRightUser != null) && (lstRightUser.Count > 0))
            {
                foreach (var item in lstRightUser)
                {
                    entities.TBL_NGUOI_DUNG_PHONG_BAN.Remove(item);
                    entities.SaveChanges();
                }
            }
        }

        
    }
}