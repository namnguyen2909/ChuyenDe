using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using CPanel.Models;
namespace CPanel.Commons
{    
    public class CheckUserInfo
    {
        private static ATCLEntities entities = new ATCLEntities();
                
        
        /// <summary>
        /// Kiểm tra người dùng đã đăng nhập vào hệ thống hay chưa. Nếu chưa đăng nhập thì chuyển về trang SignIn
        /// </summary>
        public static void CheckLogin()
        {
            string strUserID = (string)HttpContext.Current.Session[ATCL_Consts.SESSION_NAME_USER_ID];
            if (strUserID != null)
            {
                //User is Anonymous
                if (ATCL_Consts.NUMBER_ANONYMOUS_USER_ID.ToString().Equals(strUserID)) return;

                //Get User
                int UserId = Convert.ToInt32(strUserID);
                var obj = entities.TBL_NGUOI_DUNG.Where(x => x.Id == UserId).FirstOrDefault();
                if (obj == null || obj.isEnabled == false) HttpContext.Current.Response.Redirect(String.Format(ConstURL.URL_SIGN_IN, HttpContext.Current.Request.RawUrl));                
                
            }            
            else HttpContext.Current.Response.Redirect(String.Format(ConstURL.URL_SIGN_IN, HttpContext.Current.Request.RawUrl));
        }

        public static void CheckLoginUngVien()
        {
            string strUserID = (string)HttpContext.Current.Session[ATCL_Consts.SESSION_NAME_USER_ID];
            if (strUserID != null)
            {
                //User is Anonymous
                if (ATCL_Consts.NUMBER_ANONYMOUS_USER_ID.ToString().Equals(strUserID)) return;

                //Get User
                int UserId = Convert.ToInt32(strUserID);
                var obj = entities.UNG_VIEN.Where(x => x.ID == UserId).FirstOrDefault();
                if (obj == null || obj.isEnabled == false) HttpContext.Current.Response.Redirect(String.Format(ConstURL.URL_SIGN_IN, HttpContext.Current.Request.RawUrl));

            }
            else HttpContext.Current.Response.Redirect(String.Format(ConstURL.URL_SIGN_IN_UNG_VIEN, HttpContext.Current.Request.RawUrl));
        }

        public static bool checkSupperAdmin()
        {
            if (HttpContext.Current.Session[ATCL_Consts.SESSION_NAME_USER_ID] != null)
            {
                int UserId = Convert.ToInt32(HttpContext.Current.Session[ATCL_Consts.SESSION_NAME_USER_ID].ToString());
                var obj = entities.TBL_NGUOI_DUNG.Where(x => x.Id == UserId).FirstOrDefault();
                if (Commons.ConstValues.SUPPER_ADMIN.ToUpper().Equals(obj.UserName.ToUpper()))
                {
                    return true;

                }

            }
            return false;
        }

        //public static int? GetCompanyID()
        //{
        //    int? usrId = CheckUserInfo.GetUserId();
        //    return (int) entities.userlogins.Where(x => x.ID == usrId && x.IS_ACTIVE == 1).FirstOrDefault().IDDOANH_NGHIEP;
        //}

        /// <summary>
        /// Lấy UserId của người dùng hiện tại
        /// </summary>
        /// <returns></returns>
        public static int? GetUserId()
        {
            if (HttpContext.Current.Session[ATCL_Consts.SESSION_NAME_USER_ID] != null)
            {
                return Convert.ToInt32(HttpContext.Current.Session[ATCL_Consts.SESSION_NAME_USER_ID]);
            }
            return null;
        }


        /// <summary>
        /// Kiểm tra quyền sử dụng chức năng của người dùng        
        public static bool checkPermission(int intUserID)
        {
            //Check Permission
            string strURL = HttpContext.Current.Request.RawUrl;
            var objMenu = entities.TBL_MENU.Where(x => (strURL.IndexOf(x.LINK) >= 0) && (x.LINK != null && x.LINK.Trim().Length > 0)).FirstOrDefault();
            if (objMenu != null)
            {
                //get List of Right
                List<int> lstRights = entities.TBL_NGUOI_DUNG_QUYEN.Where(x => x.ID_NGUOI_DUNG == intUserID).Select(y => (int)y.ID_QUYEN).ToList();
                //Check Permission
                if (lstRights != null && lstRights.Count > 0)
                {
                    var objPermission = entities.TBL_MENU_QUYEN.Where(x => x.ID_MENU == objMenu.ID && lstRights.Contains(x.ID_QUYEN)).FirstOrDefault();
                    if (objPermission == null)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check permission
        /// </summary>
        /// <param name="IDBM"></param>
        /// <param name="functionCode"></param>
        /// <returns>0: deny, 1: read, 2: edit, 3: full(inc. delete)</returns>
        public static int CheckPermissionV2(int IDBM, String functionCode)
        {
            int res = 0;            
            return res;
        }
        
    }
}