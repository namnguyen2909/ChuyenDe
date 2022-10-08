using CPanel.Commons;
using CPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules.UngVien
{
    public partial class UVLogin : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string strAction = Request.QueryString["action"];
                if ((strAction != null) && (strAction.Equals("LOG_OUT")))
                {
                    Session.Clear();
                    Response.Redirect(Commons.TitleConst.getTitleConst("UVLogin.aspx"));
                }
                txtUserName.Focus();
            }
        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            try
            {
                lbNotice.Text = String.Empty;
                UNG_VIEN obj = null;
                string strPassword = Formats.GetMD5(txtPassword.Text);
                var lstUngVien = entities.UNG_VIEN.Where(x => x.UserName.Equals(txtUserName.Text) && x.Password.Equals(strPassword) && ((bool)x.isEnabled) && x.TT_XOA == false).ToList();
                if (lstUngVien.Count > 1)
                {

                }
                else
                {
                    obj = lstUngVien.FirstOrDefault();
                }

                if (obj != null)
                {
                    if (obj.isEnabled == false)
                    {
                        lbNotice.Text = "Tài khoản bị khóa!";
                        return;
                    }
                    Session[ATCL_Consts.SESSION_NAME_USER_ID] = obj.ID.ToString();
                    if (!String.IsNullOrEmpty(Request.QueryString["returnUrl"]))
                    {
                        Response.Redirect(Request.QueryString["returnUrl"].ToString());
                    }
                    else
                    {   
                        Response.Redirect(Commons.TitleConst.getTitleConst("ThongTinChiTietUV.aspx"));
                    }
                }
                else
                {
                    lbNotice.Text = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                    return;
                }
            }
            catch (Exception ex)
            {
                lbNotice.Text = "Lỗi: " + Formats.GetMD5(txtPassword.Text) + ex.Message + ex.TargetSite + ex.StackTrace;
            }
            //Response.Redirect(Commons.TitleConst.getTitleConst("ThongTinChiTietUV.aspx"));
        }

        protected int getObjectID()
        {
            return Convert.ToInt32("txtObjectID.Text");
        }

        protected Boolean UserValidate(string username, string password)
        {
            Boolean b = false;
            return b;
        }
    }
}