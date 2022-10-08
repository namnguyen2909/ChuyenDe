using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPanel.Commons;
using System.Web.Services;
using CPanel.Models;
namespace CPanel.Modules
{
    public partial class MenuChucNang_Edit : System.Web.UI.Page
    {
        ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int intMenuID = 0;
                
                //get Default Language ID                
                Commons.CommonFunctionsAndProcedures.drawTreeInDropDownList(0, null, drpMenus, null, Commons.TitleConst.getTitleConst("TABLE_QT_MENUS"), entities);

                SystemMenus.getMenuType(drpMenuType, entities);
                
                //get Content ID from session for finding content
                SessionForFindingMenu objSessionForFindingMenu = (SessionForFindingMenu)Session[Commons.ConstValues.SESSION_MENUS];

                if ((objSessionForFindingMenu != null) && (!String.IsNullOrEmpty(objSessionForFindingMenu.ID_MENU)))
                {
                    intMenuID = Convert.ToInt32(objSessionForFindingMenu.ID_MENU);
                    Session[Commons.ConstValues.SESSION_MENUS] = null;

                    txtMenuID.Text = intMenuID.ToString();
                    
                    
                    CPanel.Models.TBL_MENU objMenu = entities.TBL_MENU.Find(intMenuID);
                    txtTieude.Text = objMenu.TEN;
                    txtURL.Text = objMenu.LINK;                    
                    txtSTT.Text = (objMenu.STT == null ? "" : objMenu.STT.ToString());
                    
                    if (objMenu.isEnabled)
                    {
                        cbPublishedStatus.Checked = true;
                    }
                    else
                    {
                        cbPublishedStatus.Checked = false;
                    }

                    if (objMenu.ID_CHA != 0)
                        drpMenus.SelectedValue = objMenu.ID_CHA.ToString();
                    
                    //set Menu Type
                    drpMenuType.SelectedValue = objMenu.ID_LOAI_MENU.ToString();

                }
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
                Commons.ValidationFuncs.errorMessage_TimeDelay("Bạn chưa nhập Tên Menu", Page);
                return false;
            }

            //Check whether URL is empty
            if (String.IsNullOrEmpty(objMenu.LINK))
            {
                Commons.ValidationFuncs.errorMessage_TimeDelay("Bạn chưa nhập URL", Page);
                return false;
            }

            return true;
        }

        
        protected void redirectURL()
        {
            Response.Redirect(Commons.ConstURL.URL_MENU_LIST);
        }

        protected void btnSave_Click (object sender, EventArgs e)
        {
            try
            {
                CPanel.Models.TBL_MENU objMenu = new CPanel.Models.TBL_MENU();
                if (String.IsNullOrEmpty(txtMenuID.Text)) //Create new item
                {
                    if (entities.TBL_MENU.Count() > 0) objMenu.ID = entities.TBL_MENU.Max(x => x.ID) + 1;
                    else objMenu.ID = 1;

                    entities.TBL_MENU.Add(objMenu);
                }
                else //Edit the item
                {
                    int intMenuID = Convert.ToInt32 (txtMenuID.Text);
                    objMenu = entities.TBL_MENU.Find(intMenuID);
                }

                

                objMenu.TEN = txtTieude.Text;                                
                objMenu.isEnabled = (cbPublishedStatus.Checked ? true : false);
                objMenu.LINK = txtURL.Text;
                objMenu.TEN_URL = "";

                if (!String.IsNullOrEmpty(txtSTT.Text))
                    objMenu.STT = Convert.ToInt16(txtSTT.Text);

                string str = drpMenus.SelectedValue;
                if (!drpMenus.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))                
                {
                    objMenu.ID_CHA = Convert.ToInt32(drpMenus.SelectedValue);

                    if (objMenu.ID == objMenu.ID_CHA) //Avoid assigning itself
                    {
                        Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_ERROR_KHONG_CHON_MENU_CHA"), Page);
                        return;
                    }
                    else
                    {
                        CPanel.Models.TBL_MENU objParentMenu = entities.TBL_MENU.Find(objMenu.ID_CHA);
                        if (objParentMenu != null)
                        {
                            objMenu.ID_LOAI_MENU = objParentMenu.ID_LOAI_MENU;
                        }
                    }
                }
                else
                {
                    objMenu.ID_CHA = 0;

                    if (!drpMenuType.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
                    {
                        objMenu.ID_LOAI_MENU = Convert.ToInt32(drpMenuType.SelectedValue);
                    }
                    else
                    {
                        Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_ERROR_SELECT_MENU_TYPE"), Page);
                        return;
                    }
                }



                if (validation(objMenu))
                {
                    //Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("ERROR_TITLE_THIEU"), Page);
                    
                    entities.SaveChanges();
                    
                    //set value for session
                    setSessionForFindingMenu();

                    redirectURL();
                }
            }
            catch (Exception ex)
            {
                //errorMsg.Text = "Lỗi: " + ex.Message + ex.InnerException + ex.StackTrace;
                // ghi log
                throw ex;
            }
        }

        

        //set session for finding Menus
        protected void setSessionForFindingMenu()
        {
            SessionForFindingMenu objSessionForFindingMenu = new SessionForFindingMenu();
            objSessionForFindingMenu.ID_MENU_TYPE = drpMenuType.SelectedValue;
            Session[Commons.ConstValues.SESSION_MENUS] = objSessionForFindingMenu;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {            
            redirectURL();
        }
        
        
    }
}