using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_dang_nhap_click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_SIGN_IN"));
        }
    }
}