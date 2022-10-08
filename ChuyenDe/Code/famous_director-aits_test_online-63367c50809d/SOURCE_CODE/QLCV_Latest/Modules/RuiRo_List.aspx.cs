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
    public partial class RuiRo_List : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        //private string strReportCode = ConfigurationManager.AppSettings["CODE_OPEN_REPORTS"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Set Captions for GridView
                Commons.TitleConst.setTitleConst_ASPxGridView(grvObjects);

                //get menu "QLDA"                
                Commons.SystemMenus.getMenus_QLDA(lbMenus, ConfigurationManager.AppSettings["MENU_QLDA"], Request.RawUrl, entities);

                //get Session
                if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_HE_THONG_ID]))
                {
                    txtHeThongID.Text = Session[ATCL_Consts.SESSION_HE_THONG_ID].ToString();
                }
                else
                {
                    txtHeThongID.Text = ATCL_Consts.NUMBER_INVALID_INTEGER.ToString();
                }
                
                
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
            var lstOpenReports = entities.TBL_RUI_RO.Where(x => (x.TT_XOA == false)                                        
                                    )
                                    .Select(y => new TBL_RUI_RO_VIEW()
                                     {
                                         ID = y.ID,
                                         ID_HE_THONG = y.ID_HE_THONG,
                                         MA_RUI_RO = y.MA_RUI_RO,
                                         NOI_DUNG = y.NOI_DUNG,
                                         MO_TA = y.MO_TA,
                                         GIAI_PHAP = y.GIAI_PHAP,
                                         KIEN_NGHI = y.KIEN_NGHI,
                                         GHI_CHU = y.GHI_CHU,
                                         ID_MUC_UU_TIEN = y.ID_MUC_UU_TIEN,
                                         ID_KET_QUA = y.ID_KET_QUA,
                                         ID_NGUOI_CHU_TRI = y.ID_NGUOI_CHU_TRI,
                                         NGAY_BAT_DAU = y.NGAY_BAT_DAU,
                                         NGAY_KET_THUC = y.NGAY_KET_THUC,
                                         NGAY_PHAT_SINH = y.NGAY_PHAT_SINH,
                                         TT_TRACH_NHIEM_AITS = y.TT_TRACH_NHIEM_AITS,
                                         TT_TRACH_NHIEM_DT = y.TT_TRACH_NHIEM_DT,
                                         TT_TRACH_NHIEM_KH = y.TT_TRACH_NHIEM_KH
                                         
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

            Session[ATCL_Consts.SESSION_PARENT_OBJECT_ID] = getParentObjectID();

            //Session[ATCL_Consts.SESSION_HE_THONG_ID] = txtHeThongID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_RUI_RO_EDIT"));            
        }

        protected string getParentObjectID()
        {
            int intObjectID = Convert.ToInt32(txtObjectID.Text);
            var obj = entities.TBL_NHIEM_VU.Find(intObjectID);
            if (obj != null)
                return obj.ID_CHA.ToString();
            else
                return null;
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
            var obj = entities.TBL_RUI_RO.Find(intObjectID);
            if (obj != null)
            {
                entities.TBL_RUI_RO.Remove(obj);
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
            //Session[ATCL_Consts.SESSION_HE_THONG_ID] = txtHeThongID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_RUI_RO_EDIT")); 
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_DU_AN_LIST"));
        }

    }
}