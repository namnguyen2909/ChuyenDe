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
    public partial class DuAn_List : System.Web.UI.Page
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
            blViewAll = true;


            var lstObjs = entities.TBL_HE_THONG.Where(x => (x.TT_XOA == false) && (blViewAll ? true : x.ID_NGUOI_TAO == intNguoiDungID)  
                                                            && (x.TT_DBHD == 1)                      
                                    )
                                    .Select(y => new TBL_HE_THONG_VIEW()
                                     {
                                         ID = y.ID,
                                         MA_HE_THONG = y.MA_HE_THONG,
                                         TEN = y.TEN, 
                                         MO_TA = y.MO_TA,
                                         ID_NGUOI_TAO = y.ID_NGUOI_TAO,
                                         NGAY_BAT_DAU_LAM = y.NGAY_BAT_DAU_LAM,
                                         NGAY_NGHIEM_THU_TT = y.NGAY_NGHIEM_THU_TT,                                         
                                         ID_PM = y.ID_PM,
                                         ID_PRODUCT_OWNER = y.ID_PRODUCT_OWNER,
                                         ID_LOAI_TRIEN_KHAI_DA = y.ID_LOAI_TRIEN_KHAI_DA,
                                         ID_PHAM_VI_DA = y.ID_PHAM_VI_DA,
                                         ID_TIEN_DO = y.ID_TIEN_DO,
                                         ID_TRANG_THAI_DA = y.ID_TRANG_THAI_DA
                                     }).OrderByDescending(z=>z.NGAY_NGHIEM_THU_TT).ToList();
            
            grvObjects.DataSource = lstObjs;
            grvObjects.DataBind();
        
        }

        /**
         * View Pop up window
         */ 
        protected void btnViewObject_Click(object sender, EventArgs e)
        {
            Session[ATCL_Consts.SESSION_HE_THONG_ID] = txtObjectID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_NHIEM_VU_LIST"));
        }

        protected void btnOK_DeleteObject_Click(object sender, EventArgs e)
        {
            /*
            int intObjectID = Convert.ToInt32(txtObjectID.Text);
            var obj = entities.TBL_HE_THONG.Find(intObjectID);
            if (obj != null)
            {
                obj.TT_XOA = true;
                entities.SaveChanges();
            }
             */
 

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
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_NHIEM_VU_LIST"));
        }

        
        //protected int getObjectID()
        //{
        //    return Convert.ToInt32(txtObjectID.Text);
        //}

    }
}