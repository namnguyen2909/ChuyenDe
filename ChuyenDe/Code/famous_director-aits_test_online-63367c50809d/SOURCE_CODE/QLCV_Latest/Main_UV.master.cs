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
    public partial class Main_UVMaster : System.Web.UI.MasterPage
    {
        ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }


    }
}