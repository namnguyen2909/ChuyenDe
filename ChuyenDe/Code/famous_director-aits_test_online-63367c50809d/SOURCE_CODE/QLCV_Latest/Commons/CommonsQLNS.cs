using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Xml;
using System.Linq;
using log4net;
using System.Collections.Generic;
using DevExpress.Web;
using CPanel.Models;
using Telerik.Web.UI;

namespace CPanel.Commons
{
    //public class Session
    //{
    //    public static string MENU_CHUC_NANG_ID = "MENU_CHUC_NANG_ID";        
    //}

    /**
     * @Description: This class declares Value Const
     * @Written by: TuyenDV
     **/
    public class ValueConst
    {
        public static string BLANK_ITEM = "BLANK_ITEM";
    }       

    public class PositionClass {
        public static string getPositionByCategory(string strCategoryName, string strPositionName_Origin, DropDownList drpCategory, ATCLEntities entities)
        {
            string strPositionName = ""; 
            switch (strCategoryName)
            {
                case "Home":
                    if (!String.IsNullOrEmpty(strPositionName_Origin) && (strPositionName_Origin.Equals(CommonFuncs.POSITION_BANNER)))
                    {
                        strPositionName = CommonFuncs.POSITION_BANNER; 
                    }
                    break;

                case "OurTeams":
                    strPositionName = CommonFuncs.POSITION_BANNER;
                    break;
                case "About":
                    strPositionName = CommonFuncs.POSITION_BANNER + " " + CommonFuncs.POSITION_RIGHT;
                    break;
                case "Services":
                    strPositionName = CommonFuncs.POSITION_BANNER;
                    break;
                case "CaseStudy":                    
                    strPositionName = "";
                    break;
                case "News":
                    strPositionName = "";
                    break;
                case "Clients":
                    strPositionName = "";
                    break;
                case "Support":
                    strPositionName = "";
                    break;               
                default:
                    break;
            }
            return strPositionName;
        }
    }
    
    /**
     * @Description: This class to get Title Const from XML file     
     * @Written by: TuyenDV
     **/
    public class TitleConst
    {
        /**
         * @Description: This function to get Title Const from XML file
         * @Parameters: name of tag
         * @Return: the content of XML tag
         * @Written by: TuyenDV
         **/
        public static string getTitleConst (string strItem)
        {
            XmlDocument doc = new XmlDocument();

            var XMLLoadfullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            Path.Combine("App_Data", "TitleConst.xml"));

            doc.Load(XMLLoadfullPath);

            //Display all the book titles.
            XmlNodeList elemList = doc.GetElementsByTagName(strItem);

            string result = "";
            for (int i = 0; i < elemList.Count; i++)
            {
                result = elemList[i].InnerXml;
            }

            return String.IsNullOrEmpty(result) ? strItem : result;
        }

        public static void setTitleConst_ASPxGridView(ASPxGridView gridView)
        {
            //Set Captions for GridView
            for (int i = 0; i < gridView.Columns.Count; i++)
            {
                gridView.Columns[i].Caption = Commons.TitleConst.getTitleConst(gridView.Columns[i].Caption);
            }
        }

        
    }




    public class TreeObject
    {
        public decimal ID { get; set; }
        public string TIEU_DE { get; set; }

        public bool CHECKED { get; set; }
    }

    /**
     * @Description: This class's used for Log File
     * @Written by: TuyenDV
     **/
    public class LoggerUtil
    {
        private ILog aLog = null;

        public LoggerUtil(string pClassName)
        {
            log4net.Config.XmlConfigurator.Configure();
            aLog = LogManager.GetLogger(pClassName);

        }

        public void Debug(object pMessage)
        {
            aLog.Debug(pMessage);
        }

        public void Debug(object pMessage, Exception pException)
        {
            aLog.Debug(pMessage, pException);
        }

        public void Error(object pMessage)
        {
            aLog.Error(pMessage);
        }

        public void Error(object pMessage, Exception pException)
        {
            aLog.Error(pMessage, pException);
        }

        public void Close(string pClassName)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(pClassName);
            log4net.Repository.Hierarchy.Logger l = (log4net.Repository.Hierarchy.Logger)log.Logger;
            l.CloseNestedAppenders();

        }
    }

    /**
     * @Description: This class to draw menus
     * @Written by: TuyenDV
     **/
    public class SystemMenus {

        ATCLEntities entities = new ATCLEntities();

        public static void getMenuType(DropDownList drpMenuType, ATCLEntities entities)
        {
            drpMenuType.DataSource = entities.TBL_MENU_LOAI.ToList();
            drpMenuType.DataValueField = "ID";
            drpMenuType.DataTextField = "TIEU_DE";
            drpMenuType.DataBind();

            drpMenuType.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpMenuType.SelectedIndex = 0;
        }

        public void getAdministratorMenus(Label lbMenus)
        {
            //get User ID
            int intUserId = Convert.ToInt32(HttpContext.Current.Session[ATCL_Consts.SESSION_NAME_USER_ID].ToString());

            //get "VAI TRO"            
            List<int> lstRights = entities.TBL_NGUOI_DUNG_QUYEN.Where(x => x.ID_NGUOI_DUNG == intUserId).Select(y => (int)y.ID_QUYEN).ToList();
            if (lstRights != null && lstRights.Count > 0)
            {

                lbMenus.Text = @"
                    <div class='container_1'>
                        <nav class='navbar navbar-default'>
                        <div class='container-fluid'>
                          <div class='navbar-header'>
                            <button type='button' class='navbar-toggle collapsed' data-toggle='collapse' data-target='#navbar' aria-expanded='false' aria-controls='navbar'>
                              <span class='sr-only'>Toggle navigation</span>
                              <span class='icon-bar'></span>
                              <span class='icon-bar'></span>
                              <span class='icon-bar'></span>            </button>
          	                  <a class='navbar-brand' href='#'>&nbsp;</a>          
		                  </div>
                          <div id='navbar' class='navbar-collapse collapse'>
                              <ul class='nav navbar-nav'>
                            ";
                //get Menu Type ID
                string strMenuType = ConfigurationManager.AppSettings["MENU_ADMIN"];
                var objMenuType = entities.TBL_MENU_LOAI.Where(x => strMenuType.Equals(x.CODE)).FirstOrDefault();
                if (objMenuType != null)
                {
                    //draw Administrator Menus
                    drawAdministratorMenus(null, 0, (int)objMenuType.ID, lbMenus, lstRights);
                }


                lbMenus.Text = lbMenus.Text + @"
                                    </div><!--/.nav-collapse -->
                                </div><!--/.container-fluid -->
                                </nav>   
                            </div>
                        ";
            }
        }

        /**
         * @Description: This function to draw menus for "Quan Ly tien do du an"
         * @Parameters: Label Menu
         * @Return: void
         * @Written by: TuyenDV
         **/
        public static void getMenus_QLDA(Label lbMenus, string strMenuType, string strActiveURL, ATCLEntities entities)
        {
            lbMenus.Text = lbMenus.Text + @"
                        <div class='page-header'><h1 class='panel-title'>Thông tin chung về dự án</h1></div> 
                            <div class='bg_100pecents_css margin_css'>
                                <div class='col-xs-3'>
                                    <label class='control-label'>Ngày bắt đầu</label>: 30-07-2020                    
                                </div>
                                <div class='col-xs-3'>
                                    <label class='control-label'>Ngày kết thúc</label>: 31-12-2020                    
                                </div>
                                <div class='col-xs-3'>
                                    <label class='control-label'>Số ngày triển khai</label>: 90                    
                                </div>
                                <div class='col-xs-3'>
                                    <label class='control-label'>Số ngày còn lại</label>: 45                    
                                </div>
                            </div>

                            <div class='bg_100pecents_css margin_css'>
                                <div class='col-xs-3'>
                                    <label class='control-label'>Số task hoàn thành</label>: 9/50                    
                                </div>
                                <div class='col-xs-3'>
                                    <label class='control-label'>Số task quá hạn</label>: 10/50                   
                                </div>
                                <div class='col-xs-3'>
                                    <label class='control-label'>Số lượng rủi ro</label>: 3                    
                                </div>
                                <div class='col-xs-3'>
                                    <label class='control-label'>Kết quả</label>: 18%                    
                                </div>
                            </div>
                            <div class='bg_100pecents_css margin_css' style='margin-bottom: 50px;'>
                                <div class='col-xs-3'>
                                    <span style='background-color: red; padding: 2px; color: #ffffff'>Quá hạn</span>                    
                                </div>
                
                            </div>
                ";


            lbMenus.Text = lbMenus.Text + @"
                    <div class='container' style='float:left; width: 100%; margin-bottom: 0px !important;'>
                        <nav class='navbar navbar-default'>
                        <div class='container-fluid'>
                          <div class='navbar-header'>
                            <button type='button' class='navbar-toggle collapsed' data-toggle='collapse' data-target='#navbar' aria-expanded='false' aria-controls='navbar'>
                              <span class='sr-only'>Toggle navigation</span>
                              <span class='icon-bar'></span>
                              <span class='icon-bar'></span>
                              <span class='icon-bar'></span>            </button>
          	                  <a class='navbar-brand' href='#'>&nbsp;</a>          
		                  </div>
                          <div id='navbar' class='navbar-collapse collapse'>
                              <ul class='nav navbar-nav'>
                            ";
            //get Menu Type ID            
            var objMenuType = entities.TBL_MENU_LOAI.Where(x => strMenuType.Equals(x.CODE)).FirstOrDefault();
            if (objMenuType != null)
            {
                //draw Menus
                var objMenus = entities.TBL_MENU.Where(x => (x.ID_LOAI_MENU == objMenuType.ID) && (x.isEnabled == true)).OrderBy(y => y.STT).ToList();
                if (objMenus != null)
                {
                    foreach (var item in objMenus)
                    {
                        
                        lbMenus.Text = lbMenus.Text + String.Format("<li><a {0} href='{1}'>{2}</a></li>", strActiveURL.Equals(item.LINK) ? "class='active_menu_css'" : "", item.LINK, item.TEN) ;
                    }
                }
            }

            


            lbMenus.Text = lbMenus.Text + @"
                                    </div><!--/.nav-collapse -->
                                </div><!--/.container-fluid -->
                                </nav>   
                            </div>
                        ";

            
        } 



        /**
         * @Description: This function to draw menus
         * @Parameters: strIDMenu - ID of root menu; intCapMenu - Level of root menu
         * @Return: void
         * @Written by: TuyenDV
         **/
        public void drawAdministratorMenus(string strIDMenu, int intCapMenu, int intMenuTypeID, Label lbMenus, List<int> lstRights)
        {            
            int intIDMenu = 0; bool blNumber = false;
            if (!String.IsNullOrEmpty(strIDMenu))
            {
                intIDMenu = Convert.ToInt32(strIDMenu);
                blNumber = true;
            }


            var objMenus = entities.TBL_MENU.Where(x => ((blNumber && x.ID_CHA == intIDMenu) || (blNumber == false && x.ID_CHA == 0)) && (x.ID_LOAI_MENU == intMenuTypeID)).OrderBy(y=>y.STT).ToList();

            if (objMenus != null)
            {
                foreach (var item in objMenus)
                {
                    var objRight = entities.TBL_MENU_QUYEN.Where(x => x.ID_MENU == item.ID && lstRights.Contains(x.ID_QUYEN)).FirstOrDefault();
                    if (objRight != null) 
                    {
                        if (entities.TBL_MENU.Where(x => x.ID_CHA == item.ID).Count() > 0) //Have child menus
                        {
                            if (intCapMenu == 0) //Level 1
                            {
                                lbMenus.Text = lbMenus.Text + @"
                                                <li class='dropdown'>
                                                    <a href='#' class='dropdown-toggle' data-toggle='dropdown' 
                                                        role='button' aria-haspopup='true' aria-expanded='false'>" + item.TEN + @"<span class='caret'></span></a>
                                                        <ul class='dropdown-menu'>
                                                ";

                                drawAdministratorMenus(item.ID.ToString(), intCapMenu + 1, intMenuTypeID, lbMenus, lstRights);
                                lbMenus.Text = lbMenus.Text + @"</ul></li>";                            
                            }
                            else if (intCapMenu == 1) //Level 2
                            {   
                                lbMenus.Text = lbMenus.Text + @"
                                                <li class='dropdown-submenu'>
                                                    <a  tabindex='-1' href='"+item.LINK+"'>" + item.TEN + @"</a>
                                                        <ul class='dropdown-menu child-dropdown-menu'>
                                                ";
                                drawAdministratorMenus(item.ID.ToString(), intCapMenu + 1, intMenuTypeID, lbMenus, lstRights);
                                lbMenus.Text = lbMenus.Text + @"</ul></li>";
                            }
                            else if (intCapMenu == 2) //Level 3
                            {
                                lbMenus.Text = lbMenus.Text + "<li><a href='" + item.LINK + "'>" + item.TEN + "</a></li>";
                            }
                        
                        }
                        else //Have no child menus
                        {
                            lbMenus.Text = lbMenus.Text + "<li><a href='" + item.LINK + "'>" + item.TEN + "</a></li>";
                        }
                    }
                }
            }

        }
    }

    /**
     * @Description: This class declare all functions and procedures shared     
     * @Written by: TuyenDV
     **/

    public class CommonFunctionsAndProcedures
    {
        /**
        * Telerik:RadtreeView: variable to create TreeView (get DB from tbl SO_TAI_KHOAN)
        * intCap: Begin from 1
        * intParentNodeID: Begin from 0
        * node: Begin is null
        **/
        public static void DrawTelericTreeView_Menus(ASPxTreeView radTreeView, int intVaiTroID, int intParentNodeID, TreeViewNode node, string strMenuType, ATCLEntities entities)
        {
            bool blCheck = false;
            bool blZero = false;            
            if (intParentNodeID == 0) blZero = true;
            //var objMenus = entities.jos_menu.Where(x => (blZero ? x.parent == 0 : x.parent == intParentNodeID) && (x.id_menutype == intMenuType)).ToList();
            var objMenus = entities.TBL_MENU.Join(entities.TBL_MENU_LOAI, M => (int)M.ID_LOAI_MENU, T => T.ID, (M, T) => new { M, T })
                .Where(x => (x.M.isEnabled)
                    && (blZero ? x.M.ID_CHA == 0 : x.M.ID_CHA == intParentNodeID)
                    && (strMenuType.Equals(x.T.CODE))).Select(z => z.M).OrderBy(y => y.STT).ToList();


            if ((objMenus != null) && (objMenus.Count > 0))
            {
                foreach (var item in objMenus)
                {
                    var objVaiTroMenu = entities.TBL_MENU_QUYEN.Where(x => x.ID_QUYEN == intVaiTroID && x.ID_MENU == item.ID).ToList();
                    if (objVaiTroMenu != null && objVaiTroMenu.Count > 0)
                        blCheck = true;
                    else blCheck = false;

                    string strMoTa = item.TEN;//item.TIEU_DE
                    if (node == null)
                    {
                        TreeViewNode nodeCap1 = new TreeViewNode(strMoTa);
                        
                        nodeCap1.Name = item.ID.ToString();
                        DrawTelericTreeView_Menus(radTreeView, (int)intVaiTroID, (int)item.ID, nodeCap1, strMenuType, entities);
                        nodeCap1.Expanded = true; //Expand all
                        nodeCap1.Checked = blCheck;
                        radTreeView.Nodes.Add(nodeCap1);
                    }
                    else
                    {
                        TreeViewNode child = new TreeViewNode(strMoTa);
                        child.Name = item.ID.ToString();
                        child.Expanded = true; //Expand all
                        child.Checked = blCheck;
                        node.Nodes.Add(child);
                        DrawTelericTreeView_Menus(radTreeView, (int)intVaiTroID, (int)item.ID, child, strMenuType, entities);
                    }

                }

            }
        }


        public static void DrawTelericTreeView_DS_Quyen(ASPxTreeView radTreeView, int intQuyenID, int intParentNodeID, TreeViewNode node, ATCLEntities entities)
        {
            bool blCheck = false;
            bool blZero = false;
            if (intParentNodeID == 0) blZero = true;
            //var objMenus = entities.jos_menu.Where(x => (blZero ? x.parent == 0 : x.parent == intParentNodeID) && (x.id_menutype == intMenuType)).ToList();
            var objQuyen = entities.TBL_RULE.Where(x => (x.isEnabled)
                    && (blZero ? x.ID_PARENT == 0 : x.ID_PARENT == intParentNodeID)
                    ).OrderBy(y => y.ORDER).ToList();


            if ((objQuyen != null) && (objQuyen.Count > 0))
            {
                foreach (var item in objQuyen)
                {
                    var objQuyenRule = entities.TBL_QUYEN_RULE.Where(x => x.ID_QUYEN == intQuyenID && x.ID_RULE == item.ID).ToList();
                    if (objQuyenRule != null && objQuyenRule.Count > 0)
                        blCheck = true;
                    else blCheck = false;

                    string strMoTa = item.NAME;
                    if (node == null)
                    {
                        TreeViewNode nodeCap1 = new TreeViewNode(strMoTa);
                        nodeCap1.Name = item.ID.ToString();
                        DrawTelericTreeView_DS_Quyen(radTreeView, (int)intQuyenID, (int)item.ID, nodeCap1, entities);
                        nodeCap1.Expanded = true; //Expand all
                        nodeCap1.Checked = blCheck;
                        radTreeView.Nodes.Add(nodeCap1);
                    }
                    else
                    {
                        TreeViewNode child = new TreeViewNode(strMoTa);
                        child.Name = item.ID.ToString();
                        child.Expanded = true; //Expand all
                        child.Checked = blCheck;
                        node.Nodes.Add(child);
                        DrawTelericTreeView_DS_Quyen(radTreeView, (int)intQuyenID, (int)item.ID, child, entities);
                    }

                }

            }
        }

        /**
         * Draw Tree for DropDownlist
         */
        public static void drawTreeInDropDownList(int intCapMenu, string strID, DropDownList drpDownList1, ASPxComboBox aspComboBox, string strTableName, ATCLEntities entities)
        {
            int intID = 0; bool blNumber = false;
            if (!String.IsNullOrEmpty(strID))
            {
                intID = Convert.ToInt32(strID);
                blNumber = true;
            }
            else //Begin --> reset DropDownlist
            {
                if (drpDownList1 != null)
                {
                    drpDownList1.Items.Clear();
                    ListItem objListItem = new ListItem();
                    objListItem.Value = Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE");
                    objListItem.Text = Commons.TitleConst.getTitleConst("BLANK_ITEM_TITLE");
                    drpDownList1.Items.Add(objListItem);
                }
                else if (aspComboBox != null)
                {
                    aspComboBox.Items.Clear();
                    aspComboBox.Items.Add(Commons.TitleConst.getTitleConst("BLANK_ITEM_TITLE"), Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE"));
                }

            }


            List<TreeObject> lstTreeObjects = new List<TreeObject>();

            if (Commons.TitleConst.getTitleConst("TABLE_QT_MENUS").Equals(strTableName))
            {
                var lstObjects = entities.TBL_MENU.Where(x => (blNumber && x.ID_CHA == intID) || (blNumber == false && x.ID_CHA == 0)).ToList();

                if ((lstObjects != null) && (lstObjects.Count > 0))
                {
                    foreach (var item in lstObjects)
                    {
                        TreeObject objTreeObject = new TreeObject();
                        objTreeObject.ID = item.ID;
                        objTreeObject.TIEU_DE = item.TEN;
                        lstTreeObjects.Add(objTreeObject);
                    }
                }
            }
            else if (Commons.TitleConst.getTitleConst("TABLE_PHONG_BAN").Equals(strTableName))
            {
                var lstObjects = entities.TBL_PHONG_BAN.Where(x => (blNumber && x.IdParent == intID) || (blNumber == false && ((x.IdParent == 0) || (x.IdParent == null)))).ToList();

                if ((lstObjects != null) && (lstObjects.Count > 0))
                {
                    foreach (var item in lstObjects)
                    {
                        TreeObject objTreeObject = new TreeObject();
                        objTreeObject.ID = item.Id;
                        objTreeObject.TIEU_DE = item.DepartmentName;
                        lstTreeObjects.Add(objTreeObject);
                    }
                }
            }

            else if (Commons.TitleConst.getTitleConst("TABLE_DS_QUYEN").Equals(strTableName))
            {
                var lstObjects = entities.TBL_QUYEN.Where(x => (blNumber && x.ID_PARENT == intID) || (blNumber == false && ((x.ID_PARENT == 0) || (x.ID_PARENT == null)))).ToList();

                if ((lstObjects != null) && (lstObjects.Count > 0))
                {
                    foreach (var item in lstObjects)
                    {
                        TreeObject objTreeObject = new TreeObject();
                        objTreeObject.ID = item.ID;
                        objTreeObject.TIEU_DE = item.NAME;
                        lstTreeObjects.Add(objTreeObject);
                    }
                }
            }

            if ((lstTreeObjects != null) && (lstTreeObjects.Count > 0))
            {
                foreach (var item in lstTreeObjects)
                {

                    string strLine = "";
                    strLine = strLine.PadLeft(intCapMenu * 6, (char)Commons.TitleConst.getTitleConst("TITLE_ICON").ElementAt(0));
                    if (drpDownList1 != null)
                    {
                        ListItem objListItem = new ListItem();
                        objListItem.Value = item.ID.ToString();

                        objListItem.Text = strLine + item.TIEU_DE;

                        if ((intCapMenu == 0) && (!Commons.TitleConst.getTitleConst("TABLE_QT_MENUS").Equals(strTableName)) && (!Commons.TitleConst.getTitleConst("TABLE_PHONG_BAN").Equals(strTableName))) //Begining Level
                        {
                            objListItem.Value = Commons.TitleConst.getTitleConst("BLANK_PARENT_ITEM_VALUE") + item.ID.ToString();

                            objListItem.Attributes.Add("style", "font-weight: bold");
                        }
                        drpDownList1.Items.Add(objListItem);
                    }
                    else if (aspComboBox != null)
                    {
                        aspComboBox.Items.Add(strLine + item.TIEU_DE, item.ID.ToString());
                    }


                    drawTreeInDropDownList(intCapMenu + 1, item.ID.ToString(), drpDownList1, aspComboBox, strTableName, entities);
                }
            }
        }



        /**
         * Draw Tree for List Box
         */
        public static void drawTreeInListBox(int intCapMenu, string strID, ListBox objListBox, string strTableName, ATCLEntities entities)
        {
            int intID = 0; bool blNumber = false;
            if (!String.IsNullOrEmpty(strID))
            {
                intID = Convert.ToInt32(strID);
                blNumber = true;
            }
            else //Begin --> reset DropDownlist
            {
                if (objListBox != null)
                {
                    objListBox.Items.Clear();
                    ListItem objListItem = new ListItem();
                    objListItem.Value = Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE");
                    objListItem.Text = Commons.TitleConst.getTitleConst("BLANK_ITEM_TITLE");
                    objListBox.Items.Add(objListItem);
                }                
            }


            List<TreeObject> lstTreeObjects = new List<TreeObject>();

            if (Commons.TitleConst.getTitleConst("TABLE_QT_MENUS").Equals(strTableName))
            {
                var lstObjects = entities.TBL_MENU.Where(x => (blNumber && x.ID_CHA == intID) || (blNumber == false && x.ID_CHA == 0)).ToList();

                if ((lstObjects != null) && (lstObjects.Count > 0))
                {
                    foreach (var item in lstObjects)
                    {
                        TreeObject objTreeObject = new TreeObject();
                        objTreeObject.ID = item.ID;
                        objTreeObject.TIEU_DE = item.TEN;
                        lstTreeObjects.Add(objTreeObject);
                    }
                }
            }
            else if (Commons.TitleConst.getTitleConst("TABLE_PHONG_BAN").Equals(strTableName))
            {
                var lstObjects = entities.TBL_PHONG_BAN.Where(x => (blNumber && x.IdParent == intID) || (blNumber == false && ((x.IdParent == 0) || (x.IdParent == null)))).ToList();

                if ((lstObjects != null) && (lstObjects.Count > 0))
                {
                    foreach (var item in lstObjects)
                    {
                        TreeObject objTreeObject = new TreeObject();
                        objTreeObject.ID = item.Id;
                        objTreeObject.TIEU_DE = item.DepartmentName;
                        lstTreeObjects.Add(objTreeObject);
                    }
                }
            }

            if ((lstTreeObjects != null) && (lstTreeObjects.Count > 0))
            {
                foreach (var item in lstTreeObjects)
                {

                    string strLine = "";
                    strLine = strLine.PadLeft(intCapMenu * 6, (char)Commons.TitleConst.getTitleConst("TITLE_ICON").ElementAt(0));
                    if (objListBox != null)
                    {
                        ListItem objListItem = new ListItem();
                        objListItem.Value = item.ID.ToString();

                        objListItem.Text = strLine + item.TIEU_DE;

                        if (intCapMenu == 0) //Begining Level
                        {
                            objListItem.Attributes.Add("style", "font-weight: bold");
                        }
                        objListBox.Items.Add(objListItem);
                    }


                    drawTreeInListBox(intCapMenu + 1, item.ID.ToString(), objListBox, strTableName, entities);
                }
            }
        }

        /**
         * get Default Language
         */
        //public static int getDefaultLanguageID(ATCLEntities entities)
        //{
        //    var objDefaultLang = entities.ngon_ngu.Where(x => x.TT_MAC_DINH == 1).FirstOrDefault();
        //    return (int)objDefaultLang.ID;
        //}
    }

  
}