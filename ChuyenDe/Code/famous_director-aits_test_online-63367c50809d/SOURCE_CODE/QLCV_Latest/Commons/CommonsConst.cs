
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Web.UI.WebControls;
using CPanel.Models;
namespace CPanel.Commons
{
    public class ConstURL
    {
        public static string URL_MENU_LIST = "/Modules/MenuChucNang_List";
        public static string URL_MENU_EDIT = "/Modules/MenuChucNang_Edit";
        public static string URL_CHANGE_PASSWORD = "/Modules/ChangePassword";
        public static string URL_SIGN_IN = "/SignIn.aspx?returnUrl={0}";
        public static string URL_SIGN_IN_UNG_VIEN = "/Modules/UngVien/UVLogin?returnUrl={0}";
        public static string URL_USER_VIEW = "/Modules/UserList";
        public static string URL_USER_EDIT = "/Modules/UserDetails";

    }

    public class ConstTable
    {
        public static string TBL_JOS_MENU = "jos_menu";
        public static string TBL_JOS_CONTENT = "jos_content";
        public static string TBL_JOS_LINKS = "jos_links";
        public static string TBL_JOS_CONTACT = "jos_contact";
    }

    public class ConstValues
    {
        public static string SESSION_HOI_VIEN = "SESSION_HOI_VIEN";
        public static string SESSION_MENUS = "SESSION_MENUS";
        public static string SESSION_KHEN_THUONG = "SESSION_KHEN_THUONG";

        public static string SESSION_CHUDEBAITHI = "SESSION_CHUDEBAITHI";

        public static string SESSION_MUCDOBAITHI = "SESSION_MUCDOBAITHI";

        public static string SESSION_THOIGIANTHI = "SESSION_THOIGIANTHI";

        public static string SESSION_TENBAITHI = "SESSION_TENBAITHI";

        public static string SUPPER_ADMIN = "ADMIN";
        public static string CONFIG_EMAIL = "CONFIG_EMAIL";


        public static string LANGUAGE_VIETNAMESE = "vi_VN";
        public static string LANGUAGE_ENGLISH = "en_US";
    }
    public class SessionForFindingDocument
    {
        public string ID_DOC = "";

    }

    public class SessionForFindingHoiVien
    {
        public string ID_HOI_VIEN = "";
        public string ID_CAU_LAC_BO = "";
    }

    public class SessionForFindingKhenThuong
    {
        public string ID_HOI_VIEN = "";
        public string ID_TAP_THE = "";
        public string ID_KHEN_THUONG = "";
    }

    public class SessionForFindingLanguage
    {
        public string ID_LANGUAGE = "";

    }

    public class SessionForFindingPartner
    {
        public string ID_PARTNER = "";
        public string ID_LANGUAGE = "";

    }

    public class SessionForFindingFunction
    {
        public string ID_FUNCTION = "";
    }

    public class SessionForFindingCategory
    {
        public string ID_CATEGORY = "";
        public string ID_LANGUAGE = "";

    }

    public class SessionForFindingSection                                                    //added
    {
        public string ID_SECTION = "";
        public string ID_LANGUAGE = "";
    }

    public class SessionForFindingMenu
    {
        public string ID_MENU = "";
        public string ID_MENU_TYPE = "";
        public string ID_LANGUAGE = "";


    }
    public class SessionForChuDeBaiThi
    {
        public string ID_CHU_DE_BAI_THI = "";
        public string TEN_CHU_DE_BAI_THI = "";
        public string ID_MUC_DO_BAI_THI = "";
        public string THOI_GIAN = "";
        public string TEN_BAI_THI = "";
        public string SESSION_OBJECT_ID = "";
    }
    public class CommonFuncs
    {
        public static string POSITION_NONE = "";
        public static string POSITION_LEFT = "LEFT";
        public static string POSITION_RIGHT = "RIGHT";
        public static string POSITION_MIDDLE = "MIDDLE";
        public static string POSITION_POS_1 = "POS_1";
        public static string POSITION_POS_2 = "POS_2";
        public static string POSITION_POS_3 = "POS_3";
        public static string POSITION_POS_4 = "POS_4";
        public static string POSITION_TOP = "TOP";
        public static string POSITION_FOOTER = "FOOTER";
        public static string POSITION_BANNER = "BANNER";

        //BEGIN: Const for TYPE_OF_PAGE
        public static string TYPE_OF_PAGE_NEWS = "NEWS";
        public static string TYPE_OF_PAGE_CONTENT = "CONTENTS";
        public static string TYPE_OF_PAGE_FAQ = "FAQ";
        public static string TYPE_OF_PAGE_HOME = "HOME_PAGE";
        public static string TYPE_OF_PAGE_LINK = "LINK";

        public static string TYPE_OF_PAGE_SERVICE_CONTENT = "SERVICE_CONTENT";
        public static string TYPE_OF_PAGE_SERVICE_TAB = "SERVICE_TAB";

        public static string TYPE_OF_PAGE_GUIDES = "GUIDES";
        public static string TYPE_OF_PAGE_FEEDBACK = "FEEDBACK";
        public static string TYPE_OF_PAGE_CONTACT = "CONTACT";
        public static string TYPE_OF_PAGE_SITEMAP = "SITEMAP";
        public static string TYPE_OF_PAGE_STATISTICS = "STATISTICS";


        public static string TYPE_OF_PAGE_OTHERS = "OTHERS";
        //END: Const for TYPE_OF_PAGE

        public static string BLANK_ITEM_VALUE = Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE");
        public static string BLANK_ITEM_TITLE = Commons.TitleConst.getTitleConst("BLANK_ITEM_TITLE");

        public static int NUMBER_INVALID_INTEGER = -99999;

        public static string LINK_MENU_TO_CATEGORY_NEWS = "/News/Index?catID={0}&menu={1}";
        public static string LINK_MENU_TO_CONTENT_NEWS = "/News/Details?contentID={0}&menu={1}";

        public static string RECYCLE_BIN_CATEGORY_TITLE = "Menus";
        public static string RECYCLE_BIN_CONTENT_TITLE = "Contents";

        //Image Path
        public static string OLD_IMAGE_PATH = "src=\"";
        public static string NEW_IMAGE_PATH = "src=\"../Upload/Images/"; //Do khac nhau ban Devexpress (13.0 va 14.0)        

        //VINH
        public static string CATEGORY_BLANK_ITEM_VALUE = "XXXXXXXXXXXXXXX";
        public static string[] getListOfPosition()
        {
            string[] lstPosition = new string[11];
            lstPosition[0] = POSITION_NONE;
            lstPosition[1] = POSITION_LEFT;
            lstPosition[2] = POSITION_RIGHT;
            lstPosition[3] = POSITION_MIDDLE;
            lstPosition[4] = POSITION_POS_1;
            lstPosition[5] = POSITION_POS_2;
            lstPosition[6] = POSITION_POS_3;
            lstPosition[7] = POSITION_POS_4;
            lstPosition[8] = POSITION_TOP;
            lstPosition[9] = POSITION_FOOTER;
            lstPosition[10] = POSITION_BANNER;
            return lstPosition;
        }

        //This funtion get Languages
        //public static void getLanguages(DropDownList drpLanguages, ATCLEntities entities)
        //{
        //    var lstLanguages = entities.ngon_ngu.Where(a => a.TT_KICH_HOAT == 1).OrderByDescending(x => x.TT_MAC_DINH).ToList();
        //    drpLanguages.DataValueField = "ID";
        //    drpLanguages.DataTextField = "TIEU_DE";
        //    drpLanguages.DataSource = lstLanguages;
        //    drpLanguages.DataBind();
        //}

        //This funtion get Languages
        //public static void getLanguagesByDefaultLangID(DropDownList drpLanguages, ATCLEntities entities)
        //{
        //    int intDefaultLangID = CommonFunctionsAndProcedures.getDefaultLanguageID(entities);
        //    var lstLanguages = entities.ngon_ngu.Where(a => a.TT_KICH_HOAT == 1 && a.ID == intDefaultLangID).ToList();
        //    drpLanguages.DataValueField = "ID";
        //    drpLanguages.DataTextField = "TIEU_DE";
        //    drpLanguages.DataSource = lstLanguages;
        //    drpLanguages.DataBind();
        //}

        ////This funtions get Categories
        //public static void getCategories(DropDownList drpCategory, ATCLEntities entities, short intLangID)
        //{            
        //    //var lstCategory = entities.jos_categories.Where (x=>x.lang_id == intLangID && x.published == true).ToList();
        //    var lstCategory = entities.jos_categories.Where(x => x.published == true).ToList();
        //    drpCategory.DataValueField = "id";
        //    drpCategory.DataTextField = "title";
        //    drpCategory.DataSource = lstCategory;
        //    drpCategory.DataBind();

        //    //Add Blank item into the top of Dropdownlist
        //    drpCategory.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
        //    drpCategory.SelectedIndex = 0;
        //}

        public static string convertContent(string strContent)
        {
            if (String.IsNullOrEmpty(strContent)) return "";
            string strContentTemp = strContent;

            if (!strContentTemp.Contains(NEW_IMAGE_PATH))
            {
                strContentTemp = strContent.Replace(OLD_IMAGE_PATH, NEW_IMAGE_PATH);
            }
            return strContentTemp;
        }




    }
}