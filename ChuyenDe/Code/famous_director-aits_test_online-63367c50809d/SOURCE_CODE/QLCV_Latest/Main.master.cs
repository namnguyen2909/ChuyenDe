using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPanel.Commons;
using DevExpress.Web;
using System.Web.UI.HtmlControls;
using CPanel.Models;
namespace CPanel
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //If user is an anonymous
                if (ATCL_Consts.NUMBER_ANONYMOUS_USER_ID.ToString().Equals((String)Session[ATCL_Consts.SESSION_NAME_USER_ID]))
                {
                    return;
                }

                //Otherwise, get user's info
                CheckUserInfo.CheckLogin();
                int intUserID = (int)CheckUserInfo.GetUserId();
                var obj = entities.TBL_NGUOI_DUNG.Where(x => x.Id == intUserID).FirstOrDefault();
                txtFullName.Text = String.Format(Commons.TitleConst.getTitleConst("WELCOME_USER"), obj.UserName);

                //get Menus
                SystemMenus objSysMenus = new SystemMenus();
                objSysMenus.getAdministratorMenus(lbMenus);

                //get Departments by UserID
                ATCL_Commons.getDropDownList_Departments_ByUserID(drpDepartments, intUserID, Session, entities);
            }
        }

        protected void btlClosePopUp_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE.Visible = false;
            if (!String.IsNullOrEmpty(txtURL_ToRedirect.Text))
                Response.Redirect(txtURL_ToRedirect.Text);
        }
        public void showMessage(string strMessage, string strURL_ToRedirect)
        {
            DIV_MESSAGE.Visible = true;
            ltMessageContent.Text = strMessage;
            txtURL_ToRedirect.Text = strURL_ToRedirect;
        }

        /**
         * Close View Attachment file Window
         */
        protected void btlClosePopUp_ViewFile_Click(object sender, EventArgs e)
        {
            DIV_VIEW_FILE_POP_UP.Visible = false;
        }

        /**
         * View attachment file
         */
        protected void btnViewFile_Click(object sender, EventArgs e)
        {
            //int intFileID = Convert.ToInt32(txtFileID.Text);
            //string strResult = ATCL_UploadFilesCommons.displayOrDownloadFile(intFileID, Page, entities);
            //if (!String.IsNullOrEmpty(strResult))//Display File (Photo, PDF)
            //{
            //    DIV_VIEW_FILE_POP_UP.Visible = true;
            //    ltFileDisplay.Text = strResult;
            //}
            //else //Download file (Excel, DOC)
            //{

            //}
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_LOGIN"));
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConstURL.URL_CHANGE_PASSWORD);
        }

    }
}