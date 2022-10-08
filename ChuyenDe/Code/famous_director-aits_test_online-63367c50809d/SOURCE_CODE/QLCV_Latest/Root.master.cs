using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.Internal;
using CPanel.Commons;
using CPanel.Models;
namespace CPanel
{
    public partial class RootMaster : System.Web.UI.MasterPage 
    {
        ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e) 
        {
            if(!IsPostBack)
            {
                //If user is an anonymous
                if (ATCL_Consts.NUMBER_ANONYMOUS_USER_ID.ToString().Equals((String)Session[ATCL_Consts.SESSION_NAME_USER_ID]))
                {
                    return;
                }
                
                //Otherwise, get user's info
                CheckUserInfo.CheckLogin();
                int intUserID = (int) CheckUserInfo.GetUserId();
                var obj = entities.TBL_NGUOI_DUNG.Where(x => x.Id == intUserID).FirstOrDefault();
                //txtFullName.Text = String.Format(Commons.TitleConst.getTitleConst("WELCOME_USER"), obj.UserName);

                //get Menus
                SystemMenus objSysMenus = new SystemMenus();
                objSysMenus.getAdministratorMenus(lbMenus);

                //get Departments by UserID
                //ATCL_Commons.getDropDownList_Departments_ByUserID(drpDepartments, intUserID, Session, entities);                
            }
        }

        //protected void btnLogout_Click(object sender, EventArgs e)
        //{
        //    Session.Clear();
        //    Response.Redirect(Commons.TitleConst.getTitleConst("URL_LOGIN"));
        //}

        //protected void btnChangePassword_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(ConstURL.URL_CHANGE_PASSWORD);
        //}

        //protected void drpDepartment_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Session[ATCL_Consts.SESSION_NAME_DEPARTMENT_ID] = drpDepartments.SelectedValue;
        //}
    }
}