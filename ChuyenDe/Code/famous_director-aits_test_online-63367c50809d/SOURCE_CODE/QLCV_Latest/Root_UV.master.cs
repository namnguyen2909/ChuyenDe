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
    public partial class Root_UVMaster : System.Web.UI.MasterPage 
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
                CheckUserInfo.CheckLoginUngVien();
                int intUserID = (int) CheckUserInfo.GetUserId();
                var obj = entities.UNG_VIEN.Where(x => x.ID == intUserID).FirstOrDefault();
                txtFullName.Text = String.Format(Commons.TitleConst.getTitleConst(""));


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