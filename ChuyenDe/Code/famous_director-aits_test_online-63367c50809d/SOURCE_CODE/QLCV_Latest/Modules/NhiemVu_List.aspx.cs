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
    public partial class NhiemVu_List : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        //private string strReportCode = ConfigurationManager.AppSettings["CODE_OPEN_REPORTS"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Set Captions for GridView
                Commons.TitleConst.setTitleConst_ASPxGridView(grvObjects);

                //Get "Cap do cua Nhiem vu"
                ATCL_Commons.getCapDo(drpCapDo);
                string strMileStone = Request.QueryString["mileStone"];
                if ("Y".Equals(strMileStone))
                {
                    drpCapDo.Visible = true;
                }

                //get menu "QLDA"                
                Commons.SystemMenus.getMenus_QLDA(lbMenus, ConfigurationManager.AppSettings["MENU_QLDA"], Request.RawUrl, entities);

                //get Session
                if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_HE_THONG_ID]))
                {
                    txtHeThongID.Text = Session[ATCL_Consts.SESSION_HE_THONG_ID].ToString();
                    //Session[ATCL_Consts.SESSION_HE_THONG_ID] = null;
                }
                else
                {
                    txtHeThongID.Text = ATCL_Consts.NUMBER_INVALID_INTEGER.ToString();
                }
                
                
            }

            //getObjects();
            grvObjects.DataBind();
        }

        protected void getListOfNhiemVu(int intCapMenu, int intCapDo_Max, string strIDMenu, List<TBL_NHIEM_VU_VIEW> lstResultOfNhiemVu, int intHeThongDA_ChangeReQuest_ID, int intKieuNhiemVu)
        {
            int intIDMenu = 0; bool blNumber = false;
            if (!String.IsNullOrEmpty(strIDMenu))
            {
                intIDMenu = Convert.ToInt32(strIDMenu);
                blNumber = true;
            }
            else //Begin --> reset DropDownlist
            {
                lstResultOfNhiemVu.Clear();
            }

            List<TBL_NHIEM_VU_VIEW> lstObjs = null;
            if (intKieuNhiemVu == ATCL_Consts.KIEU_NHIEM_VU_DU_AN)
            {
                lstObjs = entities.TBL_NHIEM_VU.Where(x => ((blNumber && x.ID_CHA == intIDMenu) || (blNumber == false && x.ID_CHA == 0))
                                                   && x.ID_HE_THONG_DA == intHeThongDA_ChangeReQuest_ID)
                                                   .Select(y => new TBL_NHIEM_VU_VIEW()
                                                   {
                                                       ID = y.ID,
                                                       ID_CHA = y.ID_CHA,
                                                       TEN_NHIEM_VU = y.TEN_NHIEM_VU,
                                                       ID_KET_QUA = y.ID_KET_QUA,
                                                       ID_NGUOI_CHU_TRI = y.ID_NGUOI_CHU_TRI,
                                                       NGAY_BAT_DAU_DK = y.NGAY_BAT_DAU_DK,
                                                       NGAY_KET_THUC_DK = y.NGAY_KET_THUC_DK,
                                                       SO_NGAY_DK = y.SO_NGAY_DK,
                                                       STT = y.STT,
                                                       GHI_CHU = y.GHI_CHU
                                                   })
                                                   .OrderBy(y => y.STT)
                                                   .ToList();
            }
            else if (intKieuNhiemVu == ATCL_Consts.KIEU_NHIEM_VU_CHANGE_REQUEST)
            {
                lstObjs = entities.TBL_NHIEM_VU.Where(x => ((blNumber && x.ID_CHA == intIDMenu) || (blNumber == false && x.ID_CHA == 0))
                                                   && x.ID_CHANGE_REQUEST == intHeThongDA_ChangeReQuest_ID)
                                                   .Select(y => new TBL_NHIEM_VU_VIEW()
                                                   {
                                                       ID = y.ID,
                                                       ID_CHA = y.ID_CHA,
                                                       TEN_NHIEM_VU = y.TEN_NHIEM_VU,
                                                       ID_KET_QUA = y.ID_KET_QUA,
                                                       ID_NGUOI_CHU_TRI = y.ID_NGUOI_CHU_TRI,
                                                       NGAY_BAT_DAU_DK = y.NGAY_BAT_DAU_DK,
                                                       NGAY_KET_THUC_DK = y.NGAY_KET_THUC_DK,
                                                       SO_NGAY_DK = y.SO_NGAY_DK,
                                                       STT = y.STT,
                                                       GHI_CHU = y.GHI_CHU
                                                   })
                                                   .OrderBy(y => y.STT)
                                                   .ToList();
            }


            

            if (lstObjs != null)
            {
                foreach (var item in lstObjs)
                {
                    string strLine = "";
                    strLine = strLine.PadLeft(intCapMenu * 6, (char)Commons.TitleConst.getTitleConst("TITLE_ICON").ElementAt(0));
                    TBL_NHIEM_VU_VIEW obj = new TBL_NHIEM_VU_VIEW();
                    obj.ID = item.ID;
                    obj.ID_CHA = (int)item.ID_CHA;
                    
                    obj.STT = item.STT == null ? 0 : (int)item.STT;
                    obj.SO_NGAY_DK = item.SO_NGAY_DK;

                    obj.TEN_NGUOI_CHU_TRI = String.Format("<span class='level_nv_css_{0}'>{1}</span>", intCapMenu, item.TEN_NGUOI_CHU_TRI);
                    obj.STR_NGAY_BAT_DAU_DK = String.Format("<span class='level_nv_css_{0}'>{1}</span>", intCapMenu,item.STR_NGAY_BAT_DAU_DK);
                    obj.STR_NGAY_KET_THUC_DK = String.Format("<span class='level_nv_css_{0}'>{1}</span>", intCapMenu,item.STR_NGAY_KET_THUC_DK);
                    obj.KET_QUA_NV = String.Format("<span class='level_nv_css_{0}'>{1}</span>", intCapMenu, item.KET_QUA_NV);


                    if (intCapMenu == 0) //Begining Level
                    {
                        obj.TEN_NHIEM_VU = strLine + item.TEN_NHIEM_VU;
                    }
                    else obj.TEN_NHIEM_VU = strLine + item.TEN_NHIEM_VU;
                    obj.TEN_NHIEM_VU = String.Format("<span class='level_nv_css_{0}'>{1}</span>", intCapMenu, obj.TEN_NHIEM_VU);

                    lstResultOfNhiemVu.Add(obj);
                    if (intCapMenu + 1 <= intCapDo_Max)
                        getListOfNhiemVu(intCapMenu + 1, intCapDo_Max, item.ID.ToString(), lstResultOfNhiemVu, intHeThongDA_ChangeReQuest_ID, intKieuNhiemVu);
                }
            }
        }
        
        protected void grvObjects_DataBinding(object sender, EventArgs e)
        {
            //get info from session for finding Menus
            //SessionForFindingMenu objSessionForFindingMenu = (SessionForFindingMenu)Session[Commons.ConstValues.SESSION_MENUS];
            //if (objSessionForFindingMenu != null)
            //{
            //    drpMenuType.SelectedValue = objSessionForFindingMenu.ID_MENU_TYPE;
            //}

            int intHeThongDA_ChangeRequest_ID = Convert.ToInt32(txtHeThongID.Text);


            List<TBL_NHIEM_VU_VIEW> lstNhiemVu = new List<TBL_NHIEM_VU_VIEW>();

            int intCapDo_Max = 9999;

            if (drpCapDo.Visible == true)
            {
                intCapDo_Max = Convert.ToInt32(drpCapDo.SelectedValue);
            }

            getListOfNhiemVu(0, intCapDo_Max -1, null, lstNhiemVu, intHeThongDA_ChangeRequest_ID, ATCL_Consts.KIEU_NHIEM_VU_DU_AN);
            grvObjects.DataSource = lstNhiemVu;

            //reset is null for session
            Session[Commons.ConstValues.SESSION_MENUS] = null;
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

            Session[ATCL_Consts.SESSION_PARENT_OBJECT_ID] = getParentObjectID();

            //Session[ATCL_Consts.SESSION_HE_THONG_ID] = txtHeThongID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_NHIEM_VU_EDIT"));            
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
            var obj = entities.TBL_NHIEM_VU.Find(intObjectID);
            if (obj != null)
            {
                entities.TBL_NHIEM_VU.Remove(obj);
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
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_NHIEM_VU_EDIT")); 
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_DU_AN_LIST"));
        }

        protected void btnCreateChildObject_Click(object sender, EventArgs e)
        {
            Session[ATCL_Consts.SESSION_PARENT_OBJECT_ID] = txtObjectID.Text;
            //Session[ATCL_Consts.SESSION_HE_THONG_ID] = txtHeThongID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("URL_NHIEM_VU_EDIT"));   
        }

    }
}