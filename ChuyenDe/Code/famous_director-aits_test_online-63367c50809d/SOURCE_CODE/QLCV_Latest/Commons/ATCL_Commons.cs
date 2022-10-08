using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web;
using CPanel.Models;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.IO;
using System.Web.UI;
using System.Configuration;
using Telerik.Web.UI;
using System.Web.SessionState;
using System.Globalization;

namespace CPanel.Commons
{
    /**********BEGIN: CLASS ATCL_Consts*************************/
    public class ATCL_Consts
    {
        public static int KIEU_NHIEM_VU_DU_AN = 1;
        public static int KIEU_NHIEM_VU_CHANGE_REQUEST = 0;

        public static int NUMBER_INVALID_INTEGER = -99999;
        public static int NUMBER_ANONYMOUS_USER_ID = -99999;
        public static string TRUE_VALUE = "1";
        public static string FALSE_VALUE = "0";
        public static string NO_FILE_TO_UPLOAD = "NO_FILE_TO_UPLOAD";

        public static string SESSION_OBJECT_ID = "SESSION_OBJECT_ID";
        public static string SESSION_PARENT_OBJECT_ID = "SESSION_PARENT_OBJECT_ID";
        public static string SESSION_HE_THONG_ID = "SESSION_HE_THONG_ID";


        public static string SESSION_NAME_REPORT_DATE = "SS_REPORT_DATE";
        public static string SESSION_NAME_REPORT_ID = "SS_REPORT_ID";
        public static string SESSION_NAME_OPENT_REPORT_ID = "SS_OPEN_REPORT_ID";
        public static string SESSION_NAME_RISK_REPORT_ID = "SS_RISK_REPORT_ID";
        public static string SESSION_NAME_INVALID_REPORT_ID = "SS_INVALID_REPORT_ID";
        public static string SESSION_NAME_VIOLATE_REPORT_ID = "SS_VIOLATE_REPORT_ID";
        public static string SESSION_NAME_EXPLOITATION_REPORT_ID = "SS_EXPLOITATION_REPORT_ID";

        public static string SESSION_NAME_GUARD_REPORT_ID = "SS_GUARD_REPORT_ID";
        public static string SESSION_NAME_URGENT_REPORT_ID = "SS_URGENT_REPORT_ID";
        public static string SESSION_NAME_NOTE_ID = "SS_NOTE_ID";
        public static string SESSION_NAME_RULE_NAME = "SS_RULE_NAME";
        public static string SESSION_NAME_DEPARTMENT_ID = "SS_DEPARTMENT_ID";
        public static string SESSION_NAME_USER_ID = "SS_USER_ID";
        //public static string SESSION_NAME_TARGET_REPORT_TYPE = "SS_TARGET_REPORT_TYPE";
        public static string SESSION_NAME_QUARTER_OF_YEAR = "SS_QUARTER_OF_YEAR";

        public static string REQUEST_CODE_CREATE_INVALID_REPORT = "CREATE_INVALID_REPORT";/*Request to create Invalid Report*/
    }
    /**********END: CLASS ATCL_Consts*************************/

    //public class Session_HeTHong
    //{
    //    public static string ID_HE_THONG = "";
    //    public static string ID_NHIEM_VU = "";
    //}

    /**********BEGIN: CLASS ATCL_Rules*************************/
    public class ATCL_Rules
    {
        public static string RULE_NV_PTSPDVPM = "NV_PTSPDVPM";
        public static string RULE_LD_PTSPDVPM = "LD_PTSPDVPM";
        public static string RULE_TK_PTSPDVPM = "TK_PTSPDVPM";
    }

    public class Open_Report_Rules
    {
        public static string OPEN_REPORT = "OPEN_REPORT";
        public static string OPEN_REPORT_CREATE = "OPEN_REPORT_CREATE";
        public static string OPEN_REPORT_UPDATE = "OPEN_REPORT_UPDATE";
        public static string OPEN_REPORT_VALIDATE = "OPEN_REPORT_VALIDATE";
        public static string OPEN_REPORT_TRANSFER = "OPEN_REPORT_TRANSFER";
        public static string OPEN_REPORT_CONFIRM = "OPEN_REPORT_CONFIRM";
        public static string OPEN_REPORT_CREATE_INVALID_REPORT = "OPEN_REPORT_CREATE_INVALID_REPORT";
        public static string OPEN_REPORT_CLOSE = "OPEN_REPORT_CLOSE";
    }


    public class Flight_Report_Rules
    {
        public static string FLIGHT_REPORT = "FLIGHT_REPORT";
        public static string FLIGHT_REPORT_CREATE = "FLIGHT_REPORT_CREATE";
        public static string FLIGHT_REPORT_UPDATE = "FLIGHT_REPORT_UPDATE";
        public static string FLIGHT_REPORT_REQUEST_ADJUST_SEND = "FLIGHT_REPORT_REQUEST_ADJUST_SEND";
        public static string FLIGHT_REPORT_EXPORT = "FLIGHT_REPORT_EXPORT";
        public static string FLIGHT_REPORT_CONFIRM = "FLIGHT_REPORT_CONFIRM";

    }

    public class Violate_Report_Rules
    {
        public static string VIOLATE_REPORT = "VIOLATE_REPORT";
        public static string VIOLATE_REPORT_CREATE = "VIOLATE_REPORT_CREATE";
        public static string VIOLATE_REPORT_UPDATE = "VIOLATE_REPORT_UPDATE";
        public static string VIOLATE_REPORT_TRANSFER = "VIOLATE_REPORT_TRANSFER";
        public static string VIOLATE_REPORT_SEND_RESULT = "VIOLATE_REPORT_SEND_RESULT";
        public static string VIOLATE_REPORT_CREATE_INVALID_REPORT = "VIOLATE_REPORT_CREATE_INVALID_REPORT";
        public static string VIOLATE_REPORT_CONFIRM = "VIOLATE_REPORT_CONFIRM";
        public static string VIOLATE_REPORT_CLOSE = "VIOLATE_REPORT_CLOSE";
    }

    public class Urgent_Report_Rules
    {
        public static string URGENT_REPORT = "URGENT_REPORT";
        public static string URGENT_REPORT_CREATE = "URGENT_REPORT_CREATE";
        public static string URGENT_REPORT_UPDATE = "URGENT_REPORT_UPDATE";
        public static string URGENT_REPORT_TRANSFER = "URGENT_REPORT_TRANSFER";
        public static string URGENT_REPORT_CREATE_INVALID_REPORT = "URGENT_REPORT_CREATE_INVALID_REPORT";
        public static string URGENT_REPORT_CONFIRM = "URGENT_REPORT_CONFIRM";
        public static string URGENT_REPORT_CLOSE = "URGENT_REPORT_CLOSE";
    }

    public class Invalid_Report_Rules
    {
        public static string INVALID_REPORT = "INVALID_REPORT";
        public static string INVALID_REPORT_CREATE = "INVALID_REPORT_CREATE";
        public static string INVALID_REPORT_UPDATE = "INVALID_REPORT_UPDATE";
        public static string INVALID_REPORT_REQUEST_ADJUST = "INVALID_REPORT_REQUEST_ADJUST";
        public static string INVALID_REPORT_TRANSFER = "INVALID_REPORT_TRANSFER";
        public static string INVALID_REPORT_REQUEST_FIX = "INVALID_REPORT_REQUEST_FIX";
        public static string INVALID_REPORT_SEND_RESULT = "INVALID_REPORT_SEND_RESULT";
        public static string INVALID_REPORT_CONFIRM = "INVALID_REPORT_CONFIRM";
        public static string INVALID_REPORT_CLOSE = "INVALID_REPORT_CLOSE";
    }

    public class Exploitation_Report_Rules
    {
        public static string EXPLOITATION_REPORT = "EXPLOITATION_REPORT";
        public static string EXPLOITATION_REPORT_CREATE = "EXPLOITATION_REPORT_CREATE";
        public static string EXPLOITATION_REPORT_UPDATE = "EXPLOITATION_REPORT_UPDATE";
        public static string EXPLOITATION_REPORT_REQUEST_ADJUST = "EXPLOITATION_REPORT_REQUEST_ADJUST";
        public static string EXPLOITATION_REPORT_EXPORT = "EXPLOITATION_REPORT_EXPORT";
        public static string EXPLOITATION_REPORT_CONFIRM = "EXPLOITATION_REPORT_CONFIRM";
        public static string EXPLOITATION_REPORT_TRANSFER = "EXPLOITATION_REPORT_TRANSFER";

    }

    public class Target_Report_Rules
    {
        public static string TARGET_REPORT = "TARGET_REPORT";
        public static string TARGET_REPORT_CREATE = "TARGET_REPORT_CREATE";
        public static string TARGET_REPORT_UPDATE = "TARGET_REPORT_UPDATE";
        public static string TARGET_REPORT_REQUEST_ADJUST = "TARGET_REPORT_REQUEST_ADJUST";
        public static string TARGET_REPORT_EXPORT = "TARGET_REPORT_EXPORT";
        public static string TARGET_REPORT_CONFIRM = "TARGET_REPORT_CONFIRM";
        public static string TARGET_REPORT_TRANSFER = "TARGET_REPORT_TRANSFER";

    }

    public class Risk_Report_Rules
    {
        public static string RISK_REPORT = "RISK_REPORT";
        public static string RISK_REPORT_CREATE = "RISK_REPORT_CREATE";
        public static string RISK_REPORT_UPDATE = "RISK_REPORT_UPDATE";
        public static string RISK_REPORT_REQUEST_ADJUST = "RISK_REPORT_REQUEST_ADJUST";
        public static string RISK_REPORT_TRANSFER = "RISK_REPORT_TRANSFER";
        public static string RISK_REPORT_CONTROL_RISK = "RISK_REPORT_CONTROL_RISK";
        public static string RISK_REPORT_SEND_RESULT = "RISK_REPORT_SEND_RESULT";
        public static string RISK_REPORT_CONFIRM = "RISK_REPORT_CONFIRM";
        public static string RISK_REPORT_CLOSE = "RISK_REPORT_CLOSE";
    }

    /**********END: CLASS ATCL_Rules*************************/

    /**********BEGIN: CLASS Status Report*************************/
    public class ATCL_OpenReport_Status
    {
        public static string OPEN_REPORT = "OR_OPEN_REPORT";
        public static string WAIT_DEPARTMENT_NOTE = "OR_WAIT_DEPARTMENT_NOTE";
        public static string WAIT_DEPARTMENT_ADJUSTMENT = "OR_WAIT_DEPARTMENT_ADJUSTMENT";
        public static string DEPARTMENT_NOTE = "OR_DEPARTMENT_NOTE";
        public static string WAIT_CEO_APPROVAL = "OR_WAIT_CEO_APPROVAL";
        public static string CLOSE_REPORT = "OR_CLOSE_REPORT";
        public static string CEO_REJECTION = "OR_CEO_REJECTION";
        public static string CEO_APPROVAL = "OR_CEO_APPROVAL";
    }

    public class ATCL_FlightReport_Status
    {
        public static string WAIT_OC_APPROVAL = "FR_WAIT_OC_APPROVAL";
        public static string WAIT_DEPARTMENT_ADJUSTMENT = "FR_WAIT_DEPARTMENT_ADJUSTMENT";
        public static string OC_APPROVAL = "FR_OC_APPROVAL";
    }

    public class ATCL_TargetReport_Status
    {
        public static string REGISTER = "TR_REGISTER";
        public static string WAIT_DEPARTMENT_ADJUSTMENT = "TR_WAIT_DEPARTMENT_ADJUSTMENT";
        public static string WAIT_CEO_APPROVEMENT = "TR_WAIT_CEO_APPROVEMENT";
        public static string CEO_APPROVEMENT = "TR_CEO_APPROVEMENT";
    }

    public class ATCL_TargetReportOfQuarter_Status
    {
        public static string REGISTER = "TR_RE_REGISTER";
        public static string WAIT_DEPARTMENT_ADJUSTMENT = "TR_RE_WAIT_DEPARTMENT_ADJUSTMENT";
        public static string WAIT_CEO_APPROVEMENT = "TR_RE_WAIT_CEO_APPROVEMENT";
        public static string CEO_APPROVEMENT = "TR_RE_CEO_APPROVEMENT";
    }

    public class ATCL_UrgentReport_Status
    {
        public static string WAIT_DEPARTMENT_NOTE = "UR_WAIT_DEPARTMENT_NOTE";
        public static string DEPARTMENT_NOTE = "UR_DEPARTMENT_NOTE";
        public static string REQUEST_TO_ADD_INVALID_REPORT = "UR_REQUEST_TO_ADD_INVALID_REPORT";
        public static string CLOSE_REPORT = "UR_CLOSE_REPORT";
    }

    public class ATCL_RiskReport_Status
    {
        public static string NEW_REPORT = "RR_NEW_REPORT";
        public static string WAIT_SAFETY_APPROVEMENT = "RR_WAIT_SAFETY_APPROVEMENT";
        public static string WAIT_ADJUSTMENT = "RR_WAIT_ADJUSTMENT";
        public static string DO_CONTROL = "RR_DO_CONTROL";
        public static string SEND_REPORT_AFTER_CONTROLLING = "RR_SEND_REPORT_AFTER_CONTROLLING";
        public static string DO_NEW_CONTROL = "RR_DO_NEW_CONTROL";
        public static string WAIT_CEO_APPROVEMENT = "RR_WAIT_CEO_APPROVEMENT";
        public static string CEO_APPROVEMENT = "RR_CEO_APPROVEMENT";

    }

    public class ATCL_ViolateReport_Status
    {
        public static string WAIT_DEPARTMENT_NOTE = "VR_WAIT_DEPARTMENT_NOTE";
        public static string DEPARTMENT_NOTE = "VR_DEPARTMENT_NOTE";
        public static string SEND_RESULT_OF_PROCESSING = "VR_SEND_RESULT_OF_PROCESSING";
        public static string REQUEST_TO_ADD_INVALID_REPORT = "VR_REQUEST_TO_ADD_INVALID_REPORT";
        public static string CLOSE_REPORT = "VR_CLOSE_REPORT";
    }

    public class ATCL_InvalidReport_Status
    {
        public static string TEMPORARY = "IR_TEMPORARY";
        public static string NEW_REPORT = "IR_NEW_REPORT";
        public static string WAIT_ADJUSTMENT = "IR_WAIT_ADJUSTMENT";
        public static string WAIT_SAFETY_APPROVEMENT = "IR_WAIT_SAFETY_APPROVEMENT";
        public static string WAIT_CEO_APPROVEMENT = "IR_WAIT_CEO_APPROVEMENT";
        public static string CEO_APPROVEMENT = "IR_CEO_APPROVEMENT";
        public static string LONG_TERM_RECOVERY = "IR_LONG_TERM_RECOVERY";
        public static string SEND_REPORT_AFTER_LT_RECOVERY = "IR_SEND_REPORT_AFTER_LT_RECOVERY";
        public static string CLOSE_REPORT = "IR_CLOSE_REPORT";
        public static string VERIFIED_REPORT = "IR_VERIFIED_REPORT";
        public static string NEW_LONG_TERM_RECOVERY = "IR_NEW_LONG_TERM_RECOVERY";
    }
    public class ATCL_GuardReport_Status
    {
        public static string NEW_REPORT = "GR_NEW_REPORT";
        public static string WAIT_ADJUSTMENT = "GR_WAIT_ADJUSTMENT";
        public static string SEND_REPORT = "GR_SEND_REPORT";
        public static string APPROVAL = "GR_APPROVAL";
    }

    public class ATCL_ExploitationReport_Status
    {
        public static string WAIT_OC_APPROVAL = "ER_WAIT_OC_APPROVAL";
        public static string WAIT_DEPARTMENT_ADJUSTMENT = "ER_WAIT_DEPARTMENT_ADJUSTMENT";
        public static string OC_APPROVAL = "ER_OC_APPROVAL";
    }
    /**********END: CLASS Status Report*************************/

    /**********BEGIN: CLASS DateTimeType*************************/
    /**
     * @Description: This class declares variables used for DateTime type
     * @Written by: TuyenDV
     **/
    public class DateTimeType
    {
        public static string TIME_FORMAT_HH_MM = "HH:mm";
        public static string TIME_FORMAT_HH_MM_EMPTY = "00:00";
        public static string TIME_FORMAT_HH_MM_SS_EMPTY = "00:00:00";

        public static string TIME_FORMAT_G = "g";

        public static string DATE_FORMAT_DD_MM_YYYY = "dd-MM-yyyy";
        public static string DATE_FORMAT_YYYYMMDD = "yyyyMMdd";
        public static string DATE_FORMAT_MM_DD_YYYY = "MM/dd/yyyy";
        public static string DATE_FORMAT_DD_MM_YYYY_HH_MM_SS = "dd-MM-yyyy HH:mm:ss";
        public static string DATE_FORMAT_DD_MM_YYYY_HH_MM_SS_FILE = "yyyyMMddHHmmss";

        public static int getNumberOfWeek(DateTime dtDay)
        {
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int weekNum = ciCurr.Calendar.GetWeekOfYear(dtDay, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            return weekNum;
        }

    }
    /**********END: CLASS DateTimeType*************************/

    /**********BEGIN: CLASS ATCL_Commons*************************/
    public class ATCL_Commons
    {
        /**
         * Get value from TimeSpan
         */
        public static string getValueFromTimeSpan(TimeSpan obj)
        {
            return obj.ToString(Commons.DateTimeType.TIME_FORMAT_G).Substring(0, 5);
        }

        /**
         * Get "Cap do cua Nhiem vu"
         */
        public static void getCapDo(DropDownList drpObj)
        {
            //drpObj.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            for (int i = 1; i < 6; i++)
            {
                drpObj.Items.Insert(i - 1, new ListItem(i.ToString(), i.ToString()));
            }


            drpObj.SelectedIndex = 0;
        }

        /**
         * Get DS Chu de cau hoi
         */
        public static void getChuDe(DropDownList drpObj, ATCLEntities entities)
        {
            drpObj.DataSource = entities.CHU_DE_BAI_THI.Where(x => x.TT_XOA == false).ToList();
            drpObj.DataValueField = "ID";
            drpObj.DataTextField = "TEN_CHU_DE";
            drpObj.DataBind();

            drpObj.Items.Insert(0, new ListItem("", Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpObj.SelectedIndex = 0;
        }

        public static void getMucDoBaiThi(DropDownList drpObj, ATCLEntities entities)
        {
            drpObj.DataSource = entities.MUC_DO_BAI_THI.Where(x => x.TT_XOA == false).ToList();
            drpObj.DataValueField = "ID";
            drpObj.DataTextField = "TEN_MUC_DO";
            drpObj.DataBind();

            drpObj.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpObj.SelectedIndex = 0;
        }

        /**
         * Get Phong ban, Nguoi danh gia
         */
        public static void getPhongBan(DropDownList drpObj, ATCLEntities entities)
        {
            drpObj.DataSource = entities.TBL_PHONG_BAN.ToList();
            drpObj.DataValueField = "Id";
            drpObj.DataTextField = "DepartmentName";
            drpObj.DataBind();

            drpObj.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpObj.SelectedIndex = 0;
        }

        //public static void getNguoiDanhGia(DropDownList drpObj, int intPhongBanID, ATCLEntities entities)
        //{
        //    drpObj.DataSource = entities.NGUOI_DANH_GIA.Where(x=>(x.Id_PHONG_BAN==intPhongBanID) && ((x.TT_XOA == null) || (x.TT_XOA == false))).ToList();
        //    drpObj.DataValueField = "ID";
        //    drpObj.DataTextField = "HO_TEN";
        //    drpObj.DataBind();

        //    drpObj.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
        //    drpObj.SelectedIndex = 0;
        //}

        /**
         * Get BaiThi
         */


        public static void getBaiThi(DropDownList drpObj, int intChuDeID, int intMucDoID, ATCLEntities entities)
        {
            drpObj.DataSource = entities.BAI_THI.Where(x => (x.ID_CHU_DE_BAI_THI == intChuDeID) && (x.ID_MUC_DO_BAI_THI == intMucDoID) && (x.TT_XOA == false)).OrderByDescending(y => y.NGAY_TAO).ToList();
            drpObj.DataValueField = "ID";
            drpObj.DataTextField = "TEN_BAI_THI";
            drpObj.DataBind();

            drpObj.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpObj.SelectedIndex = 0;
        }


        /**
         * Get DS He thong
         */
        public static void getHeThong(DropDownList drpObj, ATCLEntities entities)
        {
            drpObj.DataSource = entities.TBL_HE_THONG.Where(x => x.TT_XOA == false).OrderBy(y => y.STT).ToList();
            drpObj.DataValueField = "ID";
            drpObj.DataTextField = "TEN";
            drpObj.DataBind();

            drpObj.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpObj.SelectedIndex = 0;
        }

        /**
         * Get DS Hop Dong
         */
        public static void getHopDong(DropDownList drpObj, ATCLEntities entities)
        {
            drpObj.DataSource = entities.TBL_HOP_DONG.Where(x => x.TT_XOA == false).OrderBy(y => y.STT).ToList();
            drpObj.DataValueField = "ID";
            drpObj.DataTextField = "TEN";
            drpObj.DataBind();

            drpObj.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpObj.SelectedIndex = 0;
        }

        /**
         * Get DS Danh muc
         */
        public static void getDanhMuc(DropDownList drpObj, ATCLEntities entities, string strMaDanhMuc)
        {
            drpObj.DataSource = entities.TBL_DANH_MUC.Where(x => (strMaDanhMuc.Equals(x.MA_DANH_MUC)) && (x.TT_XOA == false)).OrderBy(y => y.STT).ToList();
            drpObj.DataValueField = "ID";
            drpObj.DataTextField = "TEN";
            drpObj.DataBind();

            drpObj.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpObj.SelectedIndex = 0;
        }

        /**
         * Get DS Nguoi Dung
         */
        public static void getNguoiDung(DropDownList drpObj, ATCLEntities entities)
        {
            drpObj.DataSource = entities.TBL_NGUOI_DUNG.Where(x => x.isEnabled == true).OrderBy(y => y.UserName).ToList();
            drpObj.DataValueField = "Id";
            drpObj.DataTextField = "FullName";
            drpObj.DataBind();

            drpObj.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpObj.SelectedIndex = 0;
        }


        /**
         * Get list of Department ID by User ID
         */
        public static List<int> getDepartmentID_ByUserID(int intUserID, ATCLEntities entities)
        {
            List<int> lstObj = entities.TBL_NGUOI_DUNG_PHONG_BAN.Join(entities.TBL_PHONG_BAN, NDPB => NDPB.DepartmentID, PB => PB.Id, (NDPB, PB) => new { NDPB, PB })
                                                    .Where(x => (x.NDPB.UserID == intUserID) && (x.PB.isDeleted == false)).Select(y => (int)y.NDPB.DepartmentID).ToList();


            return lstObj;
        }

        /**
         * Get Department ID by DepartmentCode
         */
        public static int getDepartmentID_ByDepartmentCode(string strDepartmentCode, ATCLEntities entities)
        {
            return entities.TBL_PHONG_BAN.Where(x => (strDepartmentCode.Equals(x.DepartmentCode) && (x.isDeleted == false))).Select(y => (int)y.Id).FirstOrDefault();
        }

        /**
         * Get list of Departments by User ID
         */
        public static List<TBL_PHONG_BAN> getDepartments_ByUserID(int intUserID, ATCLEntities entities)
        {
            List<TBL_PHONG_BAN> lstObj = entities.TBL_NGUOI_DUNG_PHONG_BAN.Join(entities.TBL_PHONG_BAN, NDPB => NDPB.DepartmentID, PB => PB.Id, (NDPB, PB) => new { NDPB, PB })
                                                    .Where(x => (x.NDPB.UserID == intUserID) && (x.PB.isDeleted == false)).Select(y => y.PB).ToList();
            return lstObj;
        }

        /**
         * get Rules of the login user
         */
        public static List<string> getRulesOfUser(ATCLEntities entities)
        {
            int intUserId = (int)Commons.CheckUserInfo.GetUserId();

            List<string> lstRights = entities.TBL_NGUOI_DUNG_QUYEN
                                          .Join(entities.TBL_QUYEN, NDQ => NDQ.ID_QUYEN, Q => Q.ID, (NDQ, Q) => new { NDQ, Q })
                                          .Where(x => x.NDQ.ID_NGUOI_DUNG == intUserId).Select(y => (string)y.Q.CODE).ToList();
            return lstRights;
        }

        public static List<string> getRulesOfUser_New(ATCLEntities entities)
        {
            int intUserId = (int)Commons.CheckUserInfo.GetUserId();

            List<int> lstRights = entities.TBL_NGUOI_DUNG_QUYEN
                                          .Join(entities.TBL_QUYEN, NDQ => NDQ.ID_QUYEN, Q => Q.ID, (NDQ, Q) => new { NDQ, Q })
                                          .Where(x => x.NDQ.ID_NGUOI_DUNG == intUserId).Select(y => (int)y.Q.ID).ToList();

            //add temperary (to avoid NULL)
            lstRights.Add(ATCL_Consts.NUMBER_INVALID_INTEGER);

            List<string> lstRules = entities.TBL_RULE
                                          .Join(entities.TBL_QUYEN_RULE, R => R.ID, QR => QR.ID_RULE, (R, QR) => new { R, QR })
                                          .Where(x => lstRights.Contains(x.QR.ID_QUYEN)).Select(y => (string)y.R.CODE).ToList();
            return lstRules;
        }






        /**
         * Get DropDownList of Departments by User ID
         */
        public static void getDropDownList_Departments_ByUserID(DropDownList drpDepartments, int intUserID, HttpSessionState objSession, ATCLEntities entities)
        {
            List<TBL_PHONG_BAN> lstObj = entities.TBL_NGUOI_DUNG_PHONG_BAN.Join(entities.TBL_PHONG_BAN, NDPB => NDPB.DepartmentID, PB => PB.Id, (NDPB, PB) => new { NDPB, PB })
                                                    .Where(x => (x.NDPB.UserID == intUserID) && (x.PB.isDeleted == false)).Select(y => y.PB).ToList();
            drpDepartments.DataSource = lstObj;
            drpDepartments.DataTextField = "DepartmentName";
            drpDepartments.DataValueField = "Id";
            drpDepartments.DataBind();

            string strDepartmentID = (string)objSession[ATCL_Consts.SESSION_NAME_DEPARTMENT_ID];
            if (!String.IsNullOrEmpty(strDepartmentID))
                drpDepartments.SelectedValue = strDepartmentID;
            else //Null or Empty
                objSession[ATCL_Consts.SESSION_NAME_DEPARTMENT_ID] = drpDepartments.SelectedValue;
        }

        /**
         * Get Department ID from Session
         */
        public static int getDepartmentID_OfUser_FromSession(HttpSessionState objSession)
        {
            return Convert.ToInt32((string)objSession[ATCL_Consts.SESSION_NAME_DEPARTMENT_ID]);
        }

        /**
         * Get Department Name from Session
         */
        public static string getDepartmentName_OfUser_FromSession(HttpSessionState objSession, ATCLEntities entities)
        {
            try
            {
                int intDepartmentID = getDepartmentID_OfUser_FromSession(objSession);
                return (entities.TBL_PHONG_BAN.Find(intDepartmentID).DepartmentName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }




        /**
         * Get value from Session
         */
        public static string getValueFromSession(string strName, HttpSessionState objSession)
        {
            string strResult = (string)objSession[strName];
            objSession[strName] = null;//reset value
            return strResult;
        }

        /**
         * Reset Session is NULL
         */
        public static void resetNullForSession(string strName, HttpSessionState objSession)
        {
            objSession[strName] = null;//reset value            
        }

        /**
         * Set value from Session
         */
        public static void setValueToSession(string strName, string strValue, HttpSessionState objSession)
        {
            objSession[strName] = strValue;
        }

        /**
         * Display Message Box
         */
        public static void displayMessageBox(Page objThis, string strMessage, string strURLToRedirect)
        {
            MainMaster objMasterPage = (MainMaster)objThis.Master;
            objMasterPage.showMessage(strMessage, strURLToRedirect);
        }

        /**
        * Telerik:RadtreeView: variable to create TreeView
        * intCap: Begin from 1
        * intParentNodeID: Begin from 0
        * node: Begin is null
        **/
        //public static void DrawTelericTreeView_Departments (RadTreeView radTreeView, string strParentNodeID, RadTreeNode node, int intReportID, int intReportTypeId, ATCLEntities entities)
        //{
        //    bool blCheck = false;
        //    int intID = 0; bool blNumber = false;
        //    if (!String.IsNullOrEmpty(strParentNodeID))
        //    {
        //        intID = Convert.ToInt32(strParentNodeID);
        //        blNumber = true;
        //    }


        //    List<TreeObject> lstTreeObjects = new List<TreeObject>();

        //    var lstObjects = entities.TBL_PHONG_BAN.Where(x => (blNumber && x.IdParent == intID) || (blNumber == false && ((x.IdParent == 0) || (x.IdParent == null)))).ToList();

        //    if ((lstObjects != null) && (lstObjects.Count > 0))
        //    {
        //        foreach (var item in lstObjects)
        //        {
        //            var objBaoCao_TBL_PHONG_BAN = entities.BaoCao_TBL_PHONG_BAN.Where(x => (x.ReportID == intReportID) && (x.DepartmentID == item.Id)
        //                                                                    && (x.ReportTypeID == intReportTypeId)).ToList();
        //            if (objBaoCao_TBL_PHONG_BAN != null && objBaoCao_TBL_PHONG_BAN.Count > 0)
        //                blCheck = true;
        //            else blCheck = false;

        //            string strMoTa = item.DepartmentName;//item.TIEU_DE
        //            if (node == null)
        //            {
        //                RadTreeNode nodeCap1 = new RadTreeNode(strMoTa);
        //                nodeCap1.Value = item.Id.ToString();
        //                DrawTelericTreeView_Departments (radTreeView, item.Id.ToString(), nodeCap1, intReportID, intReportTypeId, entities);
        //                nodeCap1.Expanded = true; //Expand all                        
        //                nodeCap1.Checked = blCheck;
        //                radTreeView.Nodes.Add(nodeCap1);
        //            }
        //            else
        //            {
        //                RadTreeNode child = new RadTreeNode(strMoTa);
        //                child.Value = item.Id.ToString();
        //                child.Expanded = true; //Expand all                        
        //                child.Checked = blCheck;
        //                node.Nodes.Add(child);
        //                DrawTelericTreeView_Departments(radTreeView, item.Id.ToString(), child, intReportID, intReportTypeId, entities);
        //            }

        //        }

        //    }
        //}

        //public static void DrawDEVTreeView_Departments (ASPxTreeView radTreeView, string strParentNodeID, TreeViewNode node, int intReportID, int intReportTypeId, ATCLEntities entities)
        //{
        //    bool blCheck = false;
        //    int intID = 0; bool blNumber = false;
        //    if (!String.IsNullOrEmpty(strParentNodeID))
        //    {
        //        intID = Convert.ToInt32(strParentNodeID);
        //        blNumber = true;
        //    }


        //    List<TreeObject> lstTreeObjects = new List<TreeObject>();

        //    var lstObjects = entities.TBL_PHONG_BAN.Where(x => (blNumber && x.IdParent == intID) || (blNumber == false && ((x.IdParent == 0) || (x.IdParent == null)))).ToList();

        //    if ((lstObjects != null) && (lstObjects.Count > 0))
        //    {
        //        foreach (var item in lstObjects)
        //        {
        //            var objBaoCao_TBL_PHONG_BAN = entities.BaoCao_TBL_PHONG_BAN.Where(x => (x.ReportID == intReportID) && (x.DepartmentID == item.Id)
        //                                                                    && (x.ReportTypeID == intReportTypeId)).ToList();
        //            if (objBaoCao_TBL_PHONG_BAN != null && objBaoCao_TBL_PHONG_BAN.Count > 0)
        //                blCheck = true;
        //            else blCheck = false;

        //            string strMoTa = item.DepartmentName;//item.TIEU_DE
        //            if (node == null)
        //            {
        //                TreeViewNode nodeCap1 = new TreeViewNode(strMoTa);
        //                nodeCap1.Name = item.Id.ToString();
        //                DrawDEVTreeView_Departments (radTreeView, item.Id.ToString(), nodeCap1, intReportID, intReportTypeId, entities);
        //                nodeCap1.Expanded = true; //Expand all                        
        //                nodeCap1.Checked = blCheck;
        //                radTreeView.Nodes.Add(nodeCap1);
        //            }
        //            else
        //            {
        //                TreeViewNode child = new TreeViewNode(strMoTa);
        //                child.Name = item.Id.ToString();
        //                child.Expanded = true; //Expand all                        
        //                child.Checked = blCheck;
        //                node.Nodes.Add(child);
        //                DrawDEVTreeView_Departments(radTreeView, item.Id.ToString(), child, intReportID, intReportTypeId, entities);
        //            }

        //        }

        //    }
        //}

    }




    /**********END: CLASS ATCL_Commons*************************/
}