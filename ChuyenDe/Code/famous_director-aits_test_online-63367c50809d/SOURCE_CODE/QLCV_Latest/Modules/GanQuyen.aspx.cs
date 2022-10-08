using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CPanel.Commons;
using System.Web.Services;
using CPanel.Models;
using Telerik.Web.UI;
using System.Configuration;
using DevExpress.Web;

namespace CPanel.Modules
{
    public partial class GanQuyen : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();        
        protected void Page_Load(object sender, EventArgs e)
        {               
            if (!IsPostBack)
            {
                //Load 'DS_QUYEN'
                Commons.CommonFunctionsAndProcedures.drawTreeInDropDownList(0, null, drpDS_Quyen, null, Commons.TitleConst.getTitleConst("TABLE_DS_QUYEN"), entities);
                
                //load Rule
                refreshRules();

                //load Menu tree
                refreshMenuTree();
            }

        }

        public void refreshMenuTree()
        {
            //load Menu tree
            radTreeView_Menus.Nodes.Clear();
            radTreeView_Menus.Visible = true;            

            if (!Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE").Equals(drpDS_Quyen.SelectedValue))
            {
                int intVaiTroID = Convert.ToInt32(drpDS_Quyen.SelectedValue);

                //get Menu Type (ADMINISTRATOR_MENU)
                Commons.CommonFunctionsAndProcedures.DrawTelericTreeView_Menus(radTreeView_Menus, intVaiTroID, 0, null, ConfigurationManager.AppSettings["MENU_ADMIN"], entities);                
            }

            
        }


        public void refreshRules()
        {
            //load Menu tree
            radTreeView_Rules.Nodes.Clear();
            radTreeView_Rules.Visible = true;
            if (!Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE").Equals(drpDS_Quyen.SelectedValue))
            {
                int intVaiTroID = Convert.ToInt32(drpDS_Quyen.SelectedValue);
            
                Commons.CommonFunctionsAndProcedures.DrawTelericTreeView_DS_Quyen(radTreeView_Rules, intVaiTroID, 0, null, entities);                
            }
            
        }
        protected void btnTempToFocus_Click(object sender, EventArgs e)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "MyKey", "selectNode('', '" + Request.QueryString["ElementID"] + "', '" + Request.QueryString["NextElementID"] + "');", true);
        }

        protected void drpDS_Quyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpDS_Quyen.SelectedValue.Contains(Commons.TitleConst.getTitleConst("BLANK_PARENT_ITEM_VALUE")))
            {
                radTreeView_Rules.Nodes.Clear();
                radTreeView_Menus.Nodes.Clear();
                Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_SELECT_CHILD_ITEM"), Page);           
            }
            else
            {
                refreshRules();
                refreshMenuTree();
            }
            
        }

        protected void btnSave_Click (object sender, EventArgs e)
        {
            int intQuyenID = Convert.ToInt32(drpDS_Quyen.SelectedValue);

            //Delete
            var lstQuyenRule = entities.TBL_QUYEN_RULE.Where(x => x.ID_QUYEN == intQuyenID).ToList();
            if (lstQuyenRule != null && lstQuyenRule.Count > 0)
            {
                foreach (TBL_QUYEN_RULE item in lstQuyenRule)
                {
                    entities.TBL_QUYEN_RULE.Remove(item);
                    entities.SaveChanges();
                }
            }

            //Save DS_QUYEN
            saveQuyen(intQuyenID);

            //save Menus
            saveMenus(intQuyenID);

            //refresh page
            refreshRules();
            refreshMenuTree();

            //Display Message Box
            Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_UPDATE_SUCCESFULLY"), Page);           
        }

        protected void saveQuyen(int intQuyenID)
        {
            bool blSave_ParentItem = false;
            foreach (TreeViewNode item1 in radTreeView_Rules.Nodes)
            {
                blSave_ParentItem = false;
                foreach (TreeViewNode item2 in item1.Nodes)
                {
                    if (!item2.Checked) continue;//Skip if item have no check
                    insertInto_DS_Quyen(item2, intQuyenID);
                    blSave_ParentItem = true;
                }

                if ((!item1.Checked) && (!blSave_ParentItem)) continue;//Skip if item have no check
                insertInto_DS_Quyen(item1, intQuyenID);                
            }
        }

        protected void insertInto_DS_Quyen(TreeViewNode item, int intQuyenID)
        {
            //Insert into DB
            TBL_QUYEN_RULE objQuyenRule = new TBL_QUYEN_RULE();
            if (entities.TBL_QUYEN_RULE.Count() > 0) objQuyenRule.ID = entities.TBL_QUYEN_RULE.Max(x => x.ID) + 1;
            else objQuyenRule.ID = 1;
            objQuyenRule.ID_QUYEN = intQuyenID;
            objQuyenRule.ID_RULE = Convert.ToInt32(item.Name);
            entities.TBL_QUYEN_RULE.Add(objQuyenRule);
            entities.SaveChanges();
        }

        protected void saveMenus(int intQuyenID)
        {            

            //Delete
            var lstQuyenMenu = entities.TBL_MENU_QUYEN.Where(x => x.ID_QUYEN == intQuyenID).ToList();
            if (lstQuyenMenu != null && lstQuyenMenu.Count > 0)
            {
                foreach (TBL_MENU_QUYEN itemVaiTroMenu in lstQuyenMenu)
                {
                    entities.TBL_MENU_QUYEN.Remove(itemVaiTroMenu);
                    entities.SaveChanges();
                }
            }

            //save Menus
            saveMenus_FromTreeView(intQuyenID);
        }

        protected void saveMenus_FromTreeView(int intQuyenID)
        {
            bool blSave_ParentItem = false;
            foreach (TreeViewNode item1 in radTreeView_Menus.Nodes)
            {
                blSave_ParentItem = false;
                foreach (TreeViewNode item2 in item1.Nodes)
                {
                    if (!item2.Checked) continue;//Skip if item have no check
                    insertInto_Menus(item2, intQuyenID);
                    blSave_ParentItem = true;
                }

                if ((!item1.Checked) && (!blSave_ParentItem)) continue;//Skip if item have no check
                insertInto_Menus(item1, intQuyenID);
            }
        }

        protected void insertInto_Menus(TreeViewNode item, int intQuyenID)
        {            
            //Insert into DB
            TBL_MENU_QUYEN objVaiTroMenu = new TBL_MENU_QUYEN();
            if (entities.TBL_MENU_QUYEN.Count() > 0) objVaiTroMenu.ID = entities.TBL_MENU_QUYEN.Max(x => x.ID) + 1;
            else objVaiTroMenu.ID = 1;
            objVaiTroMenu.ID_QUYEN = intQuyenID;
            objVaiTroMenu.ID_MENU = Convert.ToInt32(item.Name);
            entities.TBL_MENU_QUYEN.Add(objVaiTroMenu);
            entities.SaveChanges();
        }
        
    }
}