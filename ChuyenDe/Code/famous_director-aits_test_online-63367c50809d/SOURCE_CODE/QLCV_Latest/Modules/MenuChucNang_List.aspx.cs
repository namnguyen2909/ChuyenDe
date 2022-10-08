using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using QLNS.Commons;
using System.Web.Services;
using CPanel;
using CPanel.Models;
using CPanel.Commons;

namespace CPanel.Modules
{
    public partial class MenuChucNang_List : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SystemMenus.getMenuType(drpMenuType, entities);
                
                //load grid view
                grvLib.DataBind();
                
                
            }

        }
        protected void getListOfMenus(int intCapMenu, string strIDMenu, List<CPanel.Models.TBL_MENU> lstResultOfMenus, int intMenuTypeID)
        {
            int intIDMenu = 0; bool blNumber = false;
            if (!String.IsNullOrEmpty(strIDMenu))
            {
                intIDMenu = Convert.ToInt32(strIDMenu);
                blNumber = true;
            }
            else //Begin --> reset DropDownlist
            {
                lstResultOfMenus.Clear();   
            }

            var objMenus = entities.TBL_MENU.Where(x => ((blNumber && x.ID_CHA == intIDMenu) || (blNumber == false && x.ID_CHA == 0))                                                   
                                                   && (((intMenuTypeID != CommonFuncs.NUMBER_INVALID_INTEGER) && (x.ID_LOAI_MENU == intMenuTypeID)) || ((intMenuTypeID == CommonFuncs.NUMBER_INVALID_INTEGER) && true))
                                                   ).OrderBy(y => y.STT).ToList();

            
            if (objMenus != null)
            {
                foreach (var item in objMenus)
                {
                    string strLine = "";
                    strLine = strLine.PadLeft(intCapMenu * 6, (char)Commons.TitleConst.getTitleConst("TITLE_ICON").ElementAt(0));
                    CPanel.Models.TBL_MENU objMenu = new CPanel.Models.TBL_MENU();
                    objMenu.ID = item.ID;
                    objMenu.ID_CHA = item.ID_CHA;
                    objMenu.STT = item.STT;
                    objMenu.LINK = item.LINK;
                    
                    
                    if (intCapMenu == 0) //Begining Level
                    {
                        objMenu.TEN = strLine + item.TEN; 
                    }
                    else objMenu.TEN = strLine + item.TEN;
                    lstResultOfMenus.Add(objMenu);
                    getListOfMenus(intCapMenu + 1, item.ID.ToString(), lstResultOfMenus, intMenuTypeID);
                }
            }
        }

        public void drawTreeInDropDownList_Menus(int intCapMenu, string strIDMenu, DropDownList drpDownList, int intMenuTypeID)
        {
            int intIDMenu = 0; bool blNumber_IDMenu = false;
            
            if (!String.IsNullOrEmpty(strIDMenu))
            {
                intIDMenu = Convert.ToInt32(strIDMenu);
                blNumber_IDMenu = true;
            }
            else //Begin --> reset DropDownlist
            {
                drpDownList.Items.Clear();
                ListItem objListItem = new ListItem();
                objListItem.Value = Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE");
                objListItem.Text = Commons.TitleConst.getTitleConst("BLANK_ITEM_TITLE");
                drpDownList.Items.Add(objListItem);
            }

            var objMenus = entities.TBL_MENU.Where(x => ((blNumber_IDMenu && x.ID_CHA == intIDMenu) || (blNumber_IDMenu == false && x.ID_CHA == 0)) && ((intMenuTypeID != CommonFuncs.NUMBER_INVALID_INTEGER && (x.ID_LOAI_MENU == intMenuTypeID)) || (intMenuTypeID == CommonFuncs.NUMBER_INVALID_INTEGER && true))).ToList();

            if (objMenus != null)
            {
                foreach (var item in objMenus)
                {
                    string strLine = "";
                    strLine = strLine.PadLeft(intCapMenu * 6, (char) Commons.TitleConst.getTitleConst("TITLE_ICON").ElementAt(0));
                    ListItem objListItem = new ListItem();
                    objListItem.Value = item.ID.ToString();
                    objListItem.Text = strLine + item.TEN;                    
                    if (intCapMenu ==0) //Begining Level
                    {
                        objListItem.Attributes.Add("style", "font-weight: bold");
                    }                    
                    drpDownList.Items.Add(objListItem);
                    drawTreeInDropDownList_Menus(intCapMenu + 1, item.ID.ToString(), drpDownList, intMenuTypeID);
                }
            }
        }

        protected void grvLib_DataBinding(object sender, EventArgs e)
        {
            //get info from session for finding Menus
            SessionForFindingMenu objSessionForFindingMenu = (SessionForFindingMenu)Session[Commons.ConstValues.SESSION_MENUS];
            if (objSessionForFindingMenu != null)
            {
                drpMenuType.SelectedValue = objSessionForFindingMenu.ID_MENU_TYPE;
            }

            //get Data
            int intMenuTypeID = CommonFuncs.NUMBER_INVALID_INTEGER;
            if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpMenuType.SelectedValue))
            {
                intMenuTypeID = Convert.ToInt32(drpMenuType.SelectedValue);
            }

            List<CPanel.Models.TBL_MENU> lstMenus = new List<CPanel.Models.TBL_MENU>();
            
            getListOfMenus(0, null, lstMenus, intMenuTypeID);
            grvLib.DataSource = lstMenus;

            //reset is null for session
            Session[Commons.ConstValues.SESSION_MENUS] = null;
        }

        protected void grvLib_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                int intMenuID = (int)e.Keys[0];
                var objMenu = entities.TBL_MENU.Find(intMenuID);
                if (objMenu != null)
                {
                    //Remove tbl MENU_QUYEN
                    var lstMenuQuyens = entities.TBL_MENU_QUYEN.Where(x => x.ID_MENU == intMenuID).ToList();
                    if ((lstMenuQuyens != null) && (lstMenuQuyens.Count >0))
                    {
                        foreach (var item in lstMenuQuyens)
                        {
                            entities.TBL_MENU_QUYEN.Remove(item);
                            entities.SaveChanges();
                        }
                    }

                    //Remove Menu
                    entities.TBL_MENU.Remove(objMenu);
                    entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
                // ghi log
            }
            finally
            {
                e.Cancel = true;
            }
        }

        protected void grvLib_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                var objMenu = entities.TBL_MENU.Find(Convert.ToInt32(e.Keys[0]));
                

                if (objMenu != null)
                {
                    objMenu.TEN = Convert.ToString(e.NewValues["TEN"]);
                }
                
                //Validation and update into DB
                if (validation(objMenu))
                {
                    entities.SaveChanges();
                    grvLib.CancelEdit(); //This line closes the line Editor.
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
                // ghi log
            }
            finally
            {
                e.Cancel = true;

            }
        }

        /**
         * DESCRIPTION: This funtion check fomat before updating into DB
         * INPUTS: Menu is the object need updated into DB
         * OUTPUTS: TRUE if data is valid; FALSE if data is invalid
         * WRITTEN BY: TUYENDV
         **/
        protected bool validation(CPanel.Models.TBL_MENU objMenu)
        {
            //Check whether TITLE is empty
            if (String.IsNullOrEmpty(objMenu.TEN))
            {
                Commons.ValidationFuncs.errorMessage_TimeDelay("Bạn chưa nhập Tên menu", Page);
                return false;
            }

            return true;
        }

        protected void grvLib_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try {
                CPanel.Models.TBL_MENU objMenu = new CPanel.Models.TBL_MENU();

                if (entities.TBL_MENU.Count() > 0) objMenu.ID = entities.TBL_MENU.Max(x => x.ID) + 1;
                else objMenu.ID = 1;

                if (!String.IsNullOrEmpty(Convert.ToString(e.NewValues["TEN"])))
                {
                    objMenu.TEN = Convert.ToString(e.NewValues["TEN"]);
                }
                else
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("ERROR_TITLE_THIEU"), Page);                    
                    return;
                }
                entities.TBL_MENU.Add(objMenu);
                entities.SaveChanges();                

            }
            catch (Exception ex)
            {
                //errorMsg.Text = "Lỗi: " + ex.Message + ex.InnerException + ex.StackTrace;
                // ghi log
                throw ex;
            }
            finally
            {
                e.Cancel = true;
                
            }
        }

        protected void redirectURL()
        {
            Response.Redirect(Commons.ConstURL.URL_MENU_LIST);
        }
        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                CPanel.Models.TBL_MENU objMenu = new CPanel.Models.TBL_MENU();

                if (entities.TBL_MENU.Count() > 0) objMenu.ID = entities.TBL_MENU.Max(x => x.ID) + 1;
                else objMenu.ID = 1;

                if (!String.IsNullOrEmpty(txtTieude.Text))
                {
                    objMenu.TEN = txtTieude.Text;
                    string str = drpMenus.SelectedValue;
                    if (!drpMenus.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
                        objMenu.ID_CHA = Convert.ToInt32(drpMenus.SelectedValue);
                }
                else
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("ERROR_TITLE_THIEU"), Page);
                    return;
                }
                entities.TBL_MENU.Add(objMenu);
                entities.SaveChanges();

                redirectURL();
            }
            catch (Exception ex)
            {
                //errorMsg.Text = "Lỗi: " + ex.Message + ex.InnerException + ex.StackTrace;
                // ghi log
                throw ex;
            }
        }
                
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            setSessionForFindingMenu();
            Response.Redirect(Commons.ConstURL.URL_MENU_EDIT);
        }

        protected void drpMenuType_SelectedIndexChanged(object sender, EventArgs e)
        {
            grvLib.DataBind();
        }

        //set session for finding category
        protected void setSessionForFindingMenu()
        {

            SessionForFindingMenu objSessionForFindingMenu = new SessionForFindingMenu();            
            objSessionForFindingMenu.ID_MENU = txtMenuID.Text;
            objSessionForFindingMenu.ID_MENU_TYPE = drpMenuType.SelectedValue;
            //objSessionForFindingMenu.ID_LANGUAGE = drpLanguages.SelectedValue;
            Session[Commons.ConstValues.SESSION_MENUS] = objSessionForFindingMenu;
        }
        
    }
}