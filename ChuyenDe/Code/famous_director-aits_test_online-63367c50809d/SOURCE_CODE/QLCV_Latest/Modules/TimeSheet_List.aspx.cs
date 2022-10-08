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
    public partial class TimeSheet_List : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        //private string strReportCode = ConfigurationManager.AppSettings["CODE_OPEN_REPORTS"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Set Captions for GridView
                Commons.TitleConst.setTitleConst_ASPxGridView(grvObjects);
                
               
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
            bool blViewAll = false;
            int intNguoiDungID = (int)Commons.CheckUserInfo.GetUserId();
            List<string> lstRights = ATCL_Commons.getRulesOfUser(entities);
            if (lstRights != null && lstRights.Count > 0)
            {
                if (lstRights.Contains(ATCL_Rules.RULE_LD_PTSPDVPM) || lstRights.Contains(ATCL_Rules.RULE_TK_PTSPDVPM))
                {
                    blViewAll = true;
                }

            }


            var lstOpenReports = entities.TBL_TIMESHEET.Where(x => (x.TT_XOA == false) && (blViewAll ? true : x.ID_NGUOI_TAO == intNguoiDungID)                                        
                                    )
                                    .Select(y => new TBL_TIMESHEET_VIEW()
                                     {
                                         ID = y.ID,
                                         ID_NGUOI_TAO = y.ID_NGUOI_TAO,
                                         NGAY_BAO_CAO = y.NGAY_BAO_CAO,
                                         KHO_KHAN_KIEN_NGHI = y.KHO_KHAN_KIEN_NGHI,
                                         SANG_KIEN = y.SANG_KIEN
                                     }).OrderByDescending(z=>z.NGAY_BAO_CAO).ToList();
            
            grvObjects.DataSource = lstOpenReports;
            grvObjects.DataBind();
        
        }

        /**
         * View Pop up window
         */ 
        protected void btnViewObject_Click(object sender, EventArgs e)
        {
            Session[ATCL_Consts.SESSION_OBJECT_ID] = txtObjectID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_TIMESHEET_EDIT"));
        }

        protected void btnOK_DeleteObject_Click(object sender, EventArgs e)
        {
            int intObjectID = Convert.ToInt32(txtObjectID.Text);
            var obj = entities.TBL_TIMESHEET.Find(intObjectID);
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

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_TIMESHEET_EDIT"));
        }

        
        //protected int getObjectID()
        //{
        //    return Convert.ToInt32(txtObjectID.Text);
        //}

    }
}