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
    public partial class TheoDoiCV_List : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        //private string strReportCode = ConfigurationManager.AppSettings["CODE_OPEN_REPORTS"];

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
            bool blViewAll_KetQuaCV = false;            
  
           
            var lstOpenReports = entities.TBL_THEO_DOI_CV.Where(x => (x.TT_XOA == false)                                        
                                    )
                                    .Select(y => new TBL_THEO_DOI_CV_VIEW()
                                     {
                                         ID = y.ID,
                                         TEN_CONG_VIEC = y.TEN_CONG_VIEC,
                                         ID_HE_THONG = y.ID_HE_THONG,    
                                         ID_HOP_DONG = y.ID_HOP_DONG,
                                         ID_KET_QUA_CV = y.ID_KET_QUA_CV,
                                         ID_NGUOI_CHU_TRI = y.ID_NGUOI_CHU_TRI,
                                         NGAY_BAT_DAU = y.NGAY_BAT_DAU,
                                         NGAY_KET_THUC = y.NGAY_KET_THUC,   
                                         GHI_CHU = y.GHI_CHU
                                     }).OrderByDescending(z=>z.NGAY_KET_THUC).ToList();
            
            grvObjects.DataSource = lstOpenReports;
            grvObjects.DataBind();
        
        }

        /**
         * View Pop up window
         */ 
        protected void btnViewObject_Click(object sender, EventArgs e)
        {
            Session[ATCL_Consts.SESSION_OBJECT_ID] = txtObjectID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_THEO_DOI_CV_EDIT"));            
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
            var obj = entities.TBL_THEO_DOI_CV.Find(intObjectID);
            if (obj != null)
            {
                entities.TBL_THEO_DOI_CV.Remove(obj);
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
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_THEO_DOI_CV_EDIT")); 
        }

    }
}