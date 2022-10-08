using CPanel.Commons;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel
{
    public partial class SelectReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAnonymous_Click(object sender, EventArgs e)
        {
            //Set value for Anonymous User
            ATCL_Commons.setValueToSession(ATCL_Consts.SESSION_NAME_USER_ID, ATCL_Consts.NUMBER_ANONYMOUS_USER_ID.ToString(), Session);
            
            //Redirect Page
            Response.Redirect(txtUrlToRedirect.Text);
        }

        protected void btnIdentification_Click(object sender, EventArgs e)
        {
            redirectToLoginPage();
        }

        protected void redirectToLoginPage()
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_LOGIN"));
        }
        
        protected void btnDoActions_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["CODE_OPEN_REPORTS"].Equals(txtReportCode.Text))
            {
                DIV_MESSAGE.Visible = true;
                txtUrlToRedirect.Text = Commons.TitleConst.getTitleConst("URL_OPEN_REPORT_EDIT");
            }
            else if ((ConfigurationManager.AppSettings["CODE_FLIGHT_REPORTS"].Equals(txtReportCode.Text))
                    || (ConfigurationManager.AppSettings["CODE_TARGET_REPORTS"].Equals(txtReportCode.Text))
                    || (ConfigurationManager.AppSettings["CODE_VIOLATE_REPORTS"].Equals(txtReportCode.Text))
                    || (ConfigurationManager.AppSettings["CODE_URGENT_REPORTS"].Equals(txtReportCode.Text))
                    || (ConfigurationManager.AppSettings["CODE_RISK_REPORTS"].Equals(txtReportCode.Text))
                    || (ConfigurationManager.AppSettings["CODE_EXPLOITATION_REPORTS"].Equals(txtReportCode.Text))
                    || (ConfigurationManager.AppSettings["CODE_GUARD_REPORTS"].Equals(txtReportCode.Text))
                    || (ConfigurationManager.AppSettings["CODE_INVALID_REPORTS"].Equals(txtReportCode.Text))
                )
            {
                redirectToLoginPage();
            }
            else
            {
                redirectToLoginPage();
            }
        }

        protected void btlClosePopUp_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE.Visible = false;
            }
    }
}