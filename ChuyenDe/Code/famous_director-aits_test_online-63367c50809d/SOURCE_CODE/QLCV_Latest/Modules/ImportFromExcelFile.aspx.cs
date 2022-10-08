using CPanel.Commons;
using CPanel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules
{
    public partial class ImportFromExcelFile : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        const int MAX_COLUMN = 56;
        string[] arrColName = new string[MAX_COLUMN];
        int[] arrRuleValue = new int[MAX_COLUMN];
        int[] arrIDMenuValue = new int[MAX_COLUMN];

        string strDefaultPass = "aits@412";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public DataTable funcReadExcelFile(FileUpload fileUpload, string isHDR, int intSheet, HttpServerUtility Server)
        {

            if (fileUpload.HasFile)
            {
                string FileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                string Extension = Path.GetExtension(fileUpload.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["UPLOAD_DIRECTORY"];

                string FilePath = Server.MapPath(FolderPath + FileName);

                fileUpload.SaveAs(FilePath);

                string conStr = "";
                switch (Extension)
                {
                    case ".xls": //Excel 97-03
                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07
                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }
                conStr = String.Format(conStr, FilePath, isHDR);
                OleDbConnection connExcel = new OleDbConnection(conStr);
                OleDbCommand cmdExcel = new OleDbCommand();
                OleDbDataAdapter oda = new OleDbDataAdapter();
                DataTable dt = new DataTable();
                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet
                connExcel.Open();
                DataTable dtExcelSchema;
                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                //string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                string SheetName = "";
                /*if (cbQuyenRule.Checked)
                {
                    SheetName = "MENU_RULE$";//Must have the character "$" after Sheetname
                }
                else if (cbQuyenUser.Checked)
                {

                }*/

                //SheetName = "USERS$";//Must have the character "$" after Sheetname
                //SheetName = "PLHD$";
                //SheetName = "HE_THONG$";


                /*---------------------------------- Test_online_aits */
                ////SheetName = "DS_CHU_DE_CAU_HOI$";
                //SheetName = "TRAC_NGHIEM$";
                //SheetName = "TU_LUAN$";

                //if (drpLoaiCH.SelectedValue.Equals("trac_nghiem"))
                //{
                //    SheetName = "TRAC_NGHIEM$";
                //}
                //else if (drpLoaiCH.SelectedValue.Equals("tu_luan"))
                //{
                //    SheetName = "TU_LUAN$";
                //}
                //else if (drpLoaiCH.SelectedValue.Equals("chu_de_bai_thi"))
                //{
                //    SheetName = "DS_CHU_DE_CAU_HOIS";
                //}
                //connExcel.Close();

                //Read Data from First Sheet
                connExcel.Open();
                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                oda.SelectCommand = cmdExcel;
                oda.Fill(dt);

                connExcel.Close();
                //Bind Data to GridView

                return dt;

            }
            else
            {
                return null;
            }

        }



        public string RemoveUnicode1(string text)
        {
            string[] arr1 = new string[] { "á", "à", "ả", "ã", "ạ", "â", "ấ", "ầ", "ẩ", "ẫ", "ậ", "ă", "ắ", "ằ", "ẳ", "ẵ", "ặ",
            "đ",
            "é","è","ẻ","ẽ","ẹ","ê","ế","ề","ể","ễ","ệ",
            "í","ì","ỉ","ĩ","ị",
            "ó","ò","ỏ","õ","ọ","ô","ố","ồ","ổ","ỗ","ộ","ơ","ớ","ờ","ở","ỡ","ợ",
            "ú","ù","ủ","ũ","ụ","ư","ứ","ừ","ử","ữ","ự",
            "ý","ỳ","ỷ","ỹ","ỵ",};
            string[] arr2 = new string[] { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a",
            "d",
            "e","e","e","e","e","e","e","e","e","e","e",
            "i","i","i","i","i",
            "o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o","o",
            "u","u","u","u","u","u","u","u","u","u","u",
            "y","y","y","y","y",};
            for (int i = 0; i < arr1.Length; i++)
            {
                text = text.Replace(arr1[i], arr2[i]);
                text = text.Replace(arr1[i].ToUpper(), arr2[i].ToUpper());
            }
            return text;
        }

        protected void insertDS_Quyen_Rule(DataTable dt)
        {
            int i = 0, j = 0;


        }

        public void insertParentItems(int intIDMenu_Child, int intIDMenu_Parent, int intTemp_IDRuleValue, DataRow row)
        {
            ////Insert Child Menu into DB
            //Menu_Quyen objVaiTroMenu = new Menu_Quyen();
            //if (entities.Menu_Quyen.Count() > 0) objVaiTroMenu.ID = entities.Menu_Quyen.Max(x => x.ID) + 1;
            //else objVaiTroMenu.ID = 1;
            //objVaiTroMenu.ID_QUYEN = Convert.ToInt32(row[arrColName[1]].ToString().Trim());
            //objVaiTroMenu.ID_MENU = intIDMenu_Child;
            //entities.Menu_Quyen.Add(objVaiTroMenu);
            //entities.SaveChanges();

            ////Insert Parent Menu into DB
            //intIDMenu_Parent = entities.Menus.Find(intIDMenu_Child).ID_CHA;
            //if (intIDMenu_Parent > 0)
            //{
            //    Menu_Quyen objVaiTroMenu_Parent = new Menu_Quyen();
            //    if (entities.Menu_Quyen.Count() > 0) objVaiTroMenu_Parent.ID = entities.Menu_Quyen.Max(x => x.ID) + 1;
            //    else objVaiTroMenu_Parent.ID = 1;
            //    objVaiTroMenu_Parent.ID_QUYEN = Convert.ToInt32(row[arrColName[1]].ToString().Trim());
            //    objVaiTroMenu_Parent.ID_MENU = intIDMenu_Parent;
            //    entities.Menu_Quyen.Add(objVaiTroMenu_Parent);
            //    entities.SaveChanges();
            //}

            ////Insert Parent Rule into DB
            //DS_Quyen_Rule objQuyenRule = new DS_Quyen_Rule();
            //if (entities.DS_Quyen_Rule.Count() > 0) objQuyenRule.ID = entities.DS_Quyen_Rule.Max(x => x.ID) + 1;
            //else objQuyenRule.ID = 1;

            //objQuyenRule.ID_QUYEN = Convert.ToInt32(row[arrColName[1]].ToString().Trim());
            //objQuyenRule.ID_RULE = entities.DS_Rule.Find(intTemp_IDRuleValue).ID_PARENT;
            //entities.DS_Quyen_Rule.Add(objQuyenRule);
            //entities.SaveChanges(); 
        }

        protected void insert_TBL_NGUOI_DUNG(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                //Add User
                TBL_NGUOI_DUNG objUserLogin = new TBL_NGUOI_DUNG();
                objUserLogin.UserName = row["USER_NAME"].ToString().Trim();
                objUserLogin.FullName = row["HO_VA_TEN"].ToString().Trim();
                objUserLogin.Email = row["EMAIL"].ToString().Trim();
                objUserLogin.Tel = row["DIEN_THOAI"].ToString().Trim();
                objUserLogin.Password = Formats.GetMD5(strDefaultPass);
                objUserLogin.isEnabled = true;
                entities.TBL_NGUOI_DUNG.Add(objUserLogin);
                entities.SaveChanges();

                //Assign to Department
                TBL_NGUOI_DUNG_PHONG_BAN objDept = new TBL_NGUOI_DUNG_PHONG_BAN();
                objDept.UserID = objUserLogin.Id;
                objDept.DepartmentID = 1;//1: Phong PTSPDVPM
                objDept.isDeleted = false;
                entities.TBL_NGUOI_DUNG_PHONG_BAN.Add(objDept);
                entities.SaveChanges();

            }
        }

        protected void insert_TBL_HE_THONG(DataTable dt)
        {
            string strPLHD = "", strHopDongID = "";

            foreach (DataRow row in dt.Rows)
            {
                strHopDongID = "";

                //Add Hop dong
                strPLHD = row["PLHD"].ToString().Trim();
                var objSearch = entities.TBL_HOP_DONG.Where(x => strPLHD.Equals(x.MA_HOP_DONG)).FirstOrDefault();
                if (objSearch != null)//Check duplicate
                {
                    strHopDongID = objSearch.ID.ToString();
                }

                //Add He Thong
                TBL_HE_THONG obj = new TBL_HE_THONG();

                obj.MA_HE_THONG = row["MA_HE_THONG"].ToString().Trim();
                obj.TEN = row["MO_TA_HE_THONG"].ToString().Trim();
                obj.MO_TA = row["MO_TA_HE_THONG"].ToString().Trim();
                obj.TT_XOA = false;
                obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                obj.NGAY_TAO = DateTime.Now;

                if (!String.IsNullOrEmpty(strHopDongID))
                    obj.ID_HOP_DONG = Convert.ToInt32(strHopDongID);

                entities.TBL_HE_THONG.Add(obj);

                //Save Change
                entities.SaveChanges();
            }
        }

        protected void insert_TBL_HOP_DONG(DataTable dt)
        {
            string strPLHD = "";
            foreach (DataRow row in dt.Rows)
            {
                strPLHD = row["PLHD"].ToString().Trim();
                var objSearch = entities.TBL_HOP_DONG.Where(x => strPLHD.Equals(x.MA_HOP_DONG)).FirstOrDefault();
                if (objSearch == null)//Check duplicate
                {
                    //Add User
                    TBL_HOP_DONG obj = new TBL_HOP_DONG();
                    obj.MA_HOP_DONG = strPLHD;
                    obj.TEN = strPLHD;
                    obj.MO_TA = strPLHD;
                    obj.TT_XOA = false;
                    obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    obj.NGAY_TAO = DateTime.Now;

                    entities.TBL_HOP_DONG.Add(obj);
                    entities.SaveChanges();
                }
            }
        }

        protected void BtImport_SoTaiKhoan_Click(object sender, EventArgs e)
        {
            DataTable dt = funcReadExcelFile(FileUpload_SoTaiKhoan, "Yes", 0, Server);
            if (dt != null)
            {
                //Import TBL_NGUOI_DUNG_QUYEN
                //if (cbQuyenUser.Checked)
                //{                    

                //}

                //insert_TBL_NGUOI_DUNG(dt);
                //insert_TBL_HOP_DONG(dt);
                insert_TBL_HE_THONG(dt);

                lbMessage.Text = "Update Successfully";
            }
        }


        ////---------------------------------Import file excel for Test_online_aits
        //protected void insert_CHU_DE_BAI_THI(DataTable dt)
        //{
        //    string strMaChuDe = "";

        //    int y = 0;

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (y < 1) //ignore the title rows in excel, 1 rows
        //        {
        //            y++;
        //            continue;
        //        }

        //        strMaChuDe = row["MA_CHU_DE"].ToString().Trim();

        //        //var objSearch = entities.CHU_DE_BAI_THI.Where(x => (x.MA_CHU_DE.Equals(strMaChuDe) && x.TT_XOA == false ).FirstOrDefault();
        //        var objSearch = entities.CHU_DE_BAI_THI.Where(x => (x.MA_CHU_DE.Equals(strMaChuDe))).FirstOrDefault();

        //        if (objSearch == null) //Check duplicate
        //        {
        //            CHU_DE_BAI_THI obj = new CHU_DE_BAI_THI();
        //            obj.MA_CHU_DE = row["MA_CHU_DE"].ToString().Trim();
        //            obj.TEN_CHU_DE = row["TEN_CHU_DE"].ToString().Trim();
        //            obj.NGAY_TAO = DateTime.Now;
        //            obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
        //            obj.TT_XOA = false;

        //            entities.CHU_DE_BAI_THI.Add(obj);
        //            entities.SaveChanges();
        //        }
        //    }
        //}
        //protected void insert_CAU_HOI_TRAC_NGHIEM(DataTable dt)
        //{
        //    string strNoiDungCauHoi = "";
        //    string strMaChuDe = "";

        //    int i = 0;

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (i < 3) //ignore the title rows in excel, 4 rows
        //        {
        //            i++;
        //            continue;
        //        }

        //        strNoiDungCauHoi = row["NOI_DUNG_CAU_HOI"].ToString().Trim();
        //        strMaChuDe = row["CHU_DE"].ToString().Trim();

        //        var objCauHoi = entities.CAU_HOI.Where(x => (strNoiDungCauHoi.Equals(x.NOI_DUNG_CAU_HOI))).FirstOrDefault();
        //        var objChuDeCauHoi = entities.CHU_DE_BAI_THI.Where(y => (strMaChuDe.Equals(y.MA_CHU_DE))).FirstOrDefault();

        //        if (objCauHoi == null)
        //        {
        //            CAU_HOI obj = new CAU_HOI();
        //            obj.NOI_DUNG_CAU_HOI = row["NOI_DUNG_CAU_HOI"].ToString().Trim();
        //            obj.NGAY_TAO = DateTime.Now;
        //            obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
        //            obj.TT_XOA = false;
        //            obj.ID_CHU_DE_BAI_THI = objChuDeCauHoi.ID;

        //            obj.ID_LOAI_CAU_HOI = 1;

        //            entities.CAU_HOI.Add(obj);
        //            entities.SaveChanges();
        //        }
        //    }
        //}
        //protected void insert_CAU_HOI_TU_LUAN(DataTable dt)
        //{
        //    string strNoiDungCauHoi = "";
        //    string strMaChuDe = "";

        //    int i = 0;

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (i < 3) //ignore the title rows in excel, 4 rows
        //        {
        //            i++;
        //            continue;
        //        }
        //        strNoiDungCauHoi = row["NOI_DUNG_CAU_HOI"].ToString().Trim();
        //        strMaChuDe = row["CHU_DE"].ToString().Trim();

        //        if (strMaChuDe == "" || strNoiDungCauHoi == "") //Check row null
        //            continue;

        //        var objCauHoi = entities.CAU_HOI.Where(x => (strNoiDungCauHoi.Equals(x.NOI_DUNG_CAU_HOI))).FirstOrDefault();
        //        var objChuDeCauHoi = entities.CHU_DE_BAI_THI.Where(y => (strMaChuDe.Equals(y.MA_CHU_DE))).FirstOrDefault();

        //        if (objCauHoi == null)
        //        {
        //            CAU_HOI obj = new CAU_HOI();

        //            obj.NOI_DUNG_CAU_HOI = row["NOI_DUNG_CAU_HOI"].ToString().Trim();
        //            obj.NGAY_TAO = DateTime.Now;
        //            obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
        //            obj.TT_XOA = false;
        //            obj.ID_CHU_DE_BAI_THI = objChuDeCauHoi.ID;
        //            obj.ID_LOAI_CAU_HOI = 2;

        //            entities.CAU_HOI.Add(obj);
        //            entities.SaveChanges();
        //        }
        //    }
        //}
        //protected void insert_CAU_HOI_MUC_DO(DataTable dt)
        //{
        //    var strNoiDungCH = "";
        //    int intId_CauHoi = 0;
        //    var strDe = "";
        //    var strTB = "";
        //    var strKho = "";
        //    int intId_MucDoCauHoi = 0;

        //    int y = 0;

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (y < 3) //ignore the title rows in excel, 4 rows
        //        {
        //            y++;
        //            continue;
        //        }

        //        strNoiDungCH = row["NOI_DUNG_CAU_HOI"].ToString().Trim();
        //        strDe = row["DE"].ToString().Trim();
        //        strTB = row["TB"].ToString().Trim();
        //        strKho = row["KHO"].ToString().Trim();

        //        if (strNoiDungCH == "" || strNoiDungCH == null) //check row null
        //            continue;

        //        var objCauHoi = entities.CAU_HOI.Where(x => (x.NOI_DUNG_CAU_HOI.Equals(strNoiDungCH))).FirstOrDefault();


        //        if (objCauHoi != null)
        //        {
        //            if (strDe == "X")
        //            {
        //                intId_MucDoCauHoi = 1;
        //            }
        //            if (strTB == "X")
        //            {
        //                intId_MucDoCauHoi = 2;
        //            }
        //            if (strKho == "X")
        //            {
        //                intId_MucDoCauHoi = 3;
        //            }
        //            var objCauHoiMucDo = entities.CAU_HOI_MUC_DO.Where(c => (c.ID_CAU_HOI == objCauHoi.ID) && (c.ID_MUC_DO_CAU_HOI == intId_MucDoCauHoi)).FirstOrDefault();

        //            if (objCauHoiMucDo == null) //check duplicate
        //            {
        //                CAU_HOI_MUC_DO obj = new CAU_HOI_MUC_DO();
        //                obj.ID_CAU_HOI = objCauHoi.ID;
        //                obj.ID_MUC_DO_CAU_HOI = intId_MucDoCauHoi;
        //                obj.NGAY_TAO = DateTime.Now;
        //                obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
        //                obj.TT_XOA = false;

        //                entities.CAU_HOI_MUC_DO.Add(obj);

        //                entities.SaveChanges();
        //            }
        //        }
        //    }
        //}
        //protected void insert_DAP_AN(DataTable dt) //use for trac nghiem
        //{
        //    var strNoiDungCH = "";
        //    var strNoiDungDapAn = "";
        //    int y = 0;

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (y < 3) //ignore the title rows in excel, 4 rows
        //        {
        //            y++;
        //            continue;
        //        }
        //        strNoiDungCH = row["NOI_DUNG_CAU_HOI"].ToString().Trim();

        //        var objCauHoi = entities.CAU_HOI.Where(x => (x.NOI_DUNG_CAU_HOI.Equals(strNoiDungCH)) && (x.TT_XOA == false)).FirstOrDefault();
        //        if (objCauHoi != null)
        //        {
        //            for (int i = 1; i <= 8; i++) //set answer and status
        //            {
        //                DAP_AN obj = new DAP_AN();
        //                strNoiDungDapAn = row["DA_" + i].ToString().Trim();

        //                var objDapAn = entities.DAP_AN.Where(x => (x.NOI_DUNG_DAP_AN.Equals(strNoiDungDapAn)) && (x.ID_CAU_HOI == objCauHoi.ID)).FirstOrDefault();

        //                if (objDapAn == null) //check duplicate
        //                {
        //                    if (strNoiDungDapAn == "" || strNoiDungDapAn == null) //check null answer
        //                        continue;
        //                    obj.ID_CAU_HOI = objCauHoi.ID;
        //                    obj.NOI_DUNG_DAP_AN = strNoiDungDapAn;
        //                    if (row["TT_" + i].ToString().Trim().Equals("S"))
        //                    {
        //                        obj.TRANG_THAI = false;
        //                    }
        //                    else
        //                    {
        //                        obj.TRANG_THAI = true;
        //                    }
        //                    obj.NGAY_TAO = DateTime.Now;
        //                    obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
        //                    obj.TT_XOA = false;

        //                    entities.DAP_AN.Add(obj);
        //                    entities.SaveChanges();
        //                }
        //            }
        //        }
        //    }
        //}
        //protected void BtImport_test_online_Click(object sender, EventArgs e)
        //{
        //    DataTable dt = funcReadExcelFile(FileUpload_test_online, "Yes", 0, Server);
        //    if (dt != null)
        //    {
        //        if (drpLoaiCH.SelectedValue.Equals("tu_luan"))
        //        {
        //            insert_CAU_HOI_TU_LUAN(dt);
        //            insert_CAU_HOI_MUC_DO(dt);

        //            lbMessage.Text = "Update file excel success";
        //        }
        //        else if (drpLoaiCH.SelectedValue.Equals("trac_nghiem"))
        //        {
        //            insert_CAU_HOI_TRAC_NGHIEM(dt);
        //            insert_DAP_AN(dt);
        //            insert_CAU_HOI_MUC_DO(dt);

        //            lbMessage.Text = "Update file excel success";
        //        }
        //        else if (drpLoaiCH.SelectedValue.Equals("chu_de_bai_thi"))
        //        {
        //            insert_CHU_DE_BAI_THI(dt);

        //            lbMessage.Text = "Update file excel success";
        //        }
        //        else
        //        {
        //            lbMessage.Text = "Please choose your sheet";
        //        }

        //    }
        //}
    }
}