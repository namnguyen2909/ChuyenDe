using CPanel.Commons;
using CPanel.Models;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using CPanel.Models.Views;
namespace CPanel.Modules
{
    public partial class HeThong_List : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Set Captions for GridView
                Commons.TitleConst.setTitleConst_ASPxGridView(grvObjects);

                //get List of Objects for Gridview
                
            }
            getObjects();
        }
        
        protected void grvObjects_DataBinding(object sender, EventArgs e)
        {
            
        }

        /**
         * Get Date of Open Reports
         */ 
        protected void getObjects()
        {  
            var lstObjs = entities.TBL_HE_THONG.Where(x => (x.TT_XOA == false)                                        
                                    )
                                    .OrderByDescending(z=>z.DO_UU_TIEN).ToList();
            
            grvObjects.DataSource = lstObjs;
            grvObjects.DataBind();
        
        }

        /**
         * View Pop up window
         */ 
        protected void btnViewObject_Click(object sender, EventArgs e)
        {
            Session[ATCL_Consts.SESSION_OBJECT_ID] = txtObjectID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_HE_THONG_EDIT"));            
        }
        

        protected int getObjectID()
        {
            return Convert.ToInt32(txtObjectID.Text);
        }

        protected void btlDeleteObject_Click(object sender, EventArgs e)
        {
            showMessage(Commons.TitleConst.getTitleConst("MSG_BAN_CO_CHAC_CHAN_XOA_KHONG"));

            //Open Popup
            btnOK_DeleteObject.Visible = true;
            DIV_MESSAGE.Visible = true;
        }

        protected void showMessage(string strMessage)
        {
            DIV_MESSAGE.Visible = true;
            ltMessageContent.Text = strMessage;
        }

        protected void btnOK_DeleteObject_Click(object sender, EventArgs e)
        {
            int intObjectID = Convert.ToInt32(txtObjectID.Text);
            var obj = entities.TBL_HOP_DONG.Find(intObjectID);
            if (obj != null)
            {
                obj.TT_XOA = true;                
                entities.SaveChanges();
            }
            //refresh Gridview
            getObjects();

            //Close Popup
            DIV_MESSAGE.Visible = false;
            btnOK_DeleteObject.Visible = false;
        }

        protected void btlClosePopUp_Message_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE.Visible = false;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_HE_THONG_EDIT")); 
        }

    }
}