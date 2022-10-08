using CPanel.Commons;
using CPanel.Models;
using CPanel.Models.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.Data.Extensions;

namespace CPanel.Modules.QuanLyBaiThi
{
    public partial class ChonLoaiCauHoi : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Commons.TitleConst.setTitleConst_ASPxGridView(grvCauHoi);
                Commons.ATCL_Commons.getChuDe(drpChuDeCauHoi, entities);
                getChuDeCauHoi();
                getMucDoCauHoi();
                getLoaiCauHoi();
                
            }
            getObjects();
        }

        public void getObjects()
        {
            //var lstOpenReports = entities.CAU_HOI.Where(x => (x.TT_XOA == false))
            //                     .Select(y => new CAU_HOI_VIEW()
            //                     {
            //                         ID = y.ID,
            //                         NOI_DUNG_CAU_HOI = y.NOI_DUNG_CAU_HOI,
            //                         ID_BAI_THI = y.ID_BAI_THI,
            //                         ID_CHU_DE_BAI_THI = y.ID_CHU_DE_BAI_THI,
            //                         ID_LOAI_CAU_HOI = y.ID_LOAI_CAU_HOI,

            //                     }).ToList();

            bool blChuDeCauHoi = false;
            int intChudeCauHoi = 0;
            //CommonFuncs.NUMBER_INVALID_INTEGER
            //if ((!drpChuDeCauHoi.SelectedValue.Contains(Commons.TitleConst.getTitleConst("BLANK_PARENT_ITEM_VALUE")))
            //   && (!Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE").Equals(drpChuDeCauHoi.SelectedValue)))
            //{
            //    intChudeCauHoi = Convert.ToInt32(drpChuDeCauHoi.SelectedValue);
            //    blChuDeCauHoi = true;
            //}


            if (drpChuDeCauHoi.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
            {
                blChuDeCauHoi = true;
            }
            else
            {
                intChudeCauHoi = Convert.ToInt32(drpChuDeCauHoi.SelectedValue);
            }

            bool blMucDoCauHoi = false, blLoaiCauHoi = false;
            int intMucDoCauHoi = 0, intLoaiCauHoi = 0;

            if (drpMucDoCauHoi.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
            {
                blMucDoCauHoi = true;
            }
            else
            {
                intMucDoCauHoi = Convert.ToInt32(drpMucDoCauHoi.SelectedValue);
            }

            //List<int> lstChuDeBaiThi = entities.CHU_DE_BAI_THI.Where(x => (x.ID == intChudeCauHoi) && (blChuDeCauHoi)).Select(x => x.ID).ToList();


            //if (lstChuDeBaiThi == null)
            //{
            //    lstChuDeBaiThi.Add(CommonFuncs.NUMBER_INVALID_INTEGER);
            //}

            if (drpLoaiCauHoi.SelectedValue.Equals(Commons.TitleConst.getTitleConst("BLANK_ITEM_VALUE")))
            {
                blLoaiCauHoi = true;
            }
            else
            {
                intLoaiCauHoi = Convert.ToInt32(drpLoaiCauHoi.SelectedValue);
            }
            //var lstCauHoi = entities.CAU_HOI.Join(entities.CAU_HOI_MUC_DO, CH => CH.ID, CHMD => CHMD.ID_CAU_HOI, (CH, CHMD) => new { CH, CHMD })
            //                         .Where(x => (blLoaiCauHoi ? true : x.CH.ID_LOAI_CAU_HOI == intLoaiCauHoi)
            //                         && (blMucDoCauHoi ? true : x.CHMD.ID_MUC_DO_CAU_HOI == intMucDoCauHoi))
            //                         .Select(y => new CAU_HOI_VIEW()
            //                         {
            //                             ID = y.CH.ID,
            //                             NOI_DUNG_CAU_HOI = y.CH.NOI_DUNG_CAU_HOI,
            //                             ID_BAI_THI = y.CH.ID_BAI_THI,
            //                             ID_CHU_DE_BAI_THI = y.CH.ID_CHU_DE_BAI_THI,
            //                             ID_LOAI_CAU_HOI = y.CH.ID_LOAI_CAU_HOI

            //                         }).
            ////.Select(y => y.CH)
            //Distinct().ToList();
            //lstChuDeBaiThi.Contains(CDBT.ID))
            var lstCauHoi = (from CH in entities.CAU_HOI
                             join CHMD in entities.CAU_HOI_MUC_DO on CH.ID equals CHMD.ID_CAU_HOI
                             join CDBT in entities.CHU_DE_BAI_THI on CH.ID_CHU_DE_BAI_THI equals CDBT.ID
                             where ((blLoaiCauHoi ? true : CH.ID_LOAI_CAU_HOI == intLoaiCauHoi)
                                     && (blMucDoCauHoi ? true : CHMD.ID_MUC_DO_CAU_HOI == intMucDoCauHoi)
                                     && (blChuDeCauHoi ? true : CDBT.ID == intChudeCauHoi))
                             select new CAU_HOI_VIEW()
                             {
                                 ID = CH.ID,
                                 NOI_DUNG_CAU_HOI = CH.NOI_DUNG_CAU_HOI,
                                 ID_BAI_THI = CH.ID_BAI_THI,
                                 ID_CHU_DE_BAI_THI = CH.ID_CHU_DE_BAI_THI,
                                 ID_LOAI_CAU_HOI = CH.ID_LOAI_CAU_HOI,
                                 TT_XOA = CH.TT_XOA,
                                NGAY_TAO = CH.NGAY_TAO
                             }).Where(x => x.TT_XOA == false).Distinct().OrderByDescending(x => x.NGAY_TAO).ToList();


            grvCauHoi.DataSource = lstCauHoi;
           grvCauHoi.DataBind();
            
        }

        protected void btnViewObject_Click(object sender, EventArgs e)
        {
            Session[ATCL_Consts.SESSION_OBJECT_ID] = txtObjectID.Text;
            int intObjectID = Convert.ToInt32(txtObjectID.Text);
            var objLoaiCH = entities.CAU_HOI.Where(x => x.ID == intObjectID).Select(x => x.ID_LOAI_CAU_HOI).FirstOrDefault();

            if (objLoaiCH == 1)
            {
                Response.Redirect(Commons.TitleConst.getTitleConst("/Modules/Admin/TaoCauHoiTN.aspx"));
            }

            if (objLoaiCH == 2)
            {
                Response.Redirect(Commons.TitleConst.getTitleConst("/Modules/Admin/TaoCauHoiTL.aspx"));
            }
            //Response.Redirect(Commons.TitleConst.getTitleConst("/Modules/Admin/TaoCauHoiTN.aspx"));
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

        protected void btlClosePopUp_Message_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE.Visible = false;
        }

        protected void btnOK_DeleteObject_Click(object sender, EventArgs e)
        {
            int intObjectID = Convert.ToInt32(txtObjectID.Text);

            ////Delete records in table "CAU_HOI_MUC_DO"
            //var lstCauHoiMucDo = entities.CAU_HOI_MUC_DO.Where(x => x.ID_CAU_HOI == intObjectID).ToList();
            //if ((lstCauHoiMucDo != null) && (lstCauHoiMucDo.Count > 1))
            //{
            //    foreach (var item in lstCauHoiMucDo)
            //    {
            //        entities.CAU_HOI_MUC_DO.Remove(item);
            //        entities.SaveChanges();
            //    }

            //}

            ////Delete records in table "DAP_AN"
            //var lstDapAn = entities.DAP_AN.Where(x => x.ID_CAU_HOI == intObjectID).ToList();
            //if ((lstDapAn != null) && (lstDapAn.Count > 1))
            //{
            //    foreach (var item in lstDapAn)
            //    {
            //        entities.DAP_AN.Remove(item);
            //        entities.SaveChanges();
            //    }
            //}

            //Delete records in table "CAU_HOI"
            var objCauHoi = entities.CAU_HOI.Find(intObjectID);
            if (objCauHoi != null)
            {
                objCauHoi.TT_XOA = true;
                entities.SaveChanges();
            }

            //refresh Gridview
            getObjects();

            //Close Popup
            DIV_MESSAGE.Visible = false;
            btnOK_DeleteObject.Visible = false;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("/HomePage.aspx"));
        }

        protected void btnTuLuan_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("TaoCauHoiTL.aspx"));
        }

        protected void btnTracNghiem_Click(object sender, EventArgs e)
        {
            setSessionForChuDeBaiThi();
            Response.Redirect(Commons.TitleConst.getTitleConst("TaoCauHoiTN.aspx"));
        }
        protected void getChuDeCauHoi()
        {
            drpChuDeCauHoi.DataSource = entities.CHU_DE_BAI_THI.Where(x => x.TT_XOA == false).ToList();
            drpChuDeCauHoi.DataValueField = "Id";
            drpChuDeCauHoi.DataTextField = "TEN_CHU_DE";
            drpChuDeCauHoi.DataBind();

            drpChuDeCauHoi.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpChuDeCauHoi.SelectedIndex = 0;
        }

        protected void getMucDoCauHoi()
        {
            drpMucDoCauHoi.DataSource = entities.MUC_DO_CAU_HOI.Where(x => x.TT_XOA == false).ToList();
            drpMucDoCauHoi.DataValueField = "Id";
            drpMucDoCauHoi.DataTextField = "MO_TA";
            drpMucDoCauHoi.DataBind();

            drpMucDoCauHoi.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpMucDoCauHoi.SelectedIndex = 0;
        }
        protected void getLoaiCauHoi()
        {
            drpLoaiCauHoi.DataSource = entities.LOAI_CAU_HOI.Where(x => x.TT_XOA == false).ToList();
            drpLoaiCauHoi.DataValueField = "Id";
            drpLoaiCauHoi.DataTextField = "MO_TA";
            drpLoaiCauHoi.DataBind();

            drpLoaiCauHoi.Items.Insert(0, new ListItem(Commons.CommonFuncs.BLANK_ITEM_TITLE, Commons.CommonFuncs.BLANK_ITEM_VALUE));
            drpLoaiCauHoi.SelectedIndex = 0;
        }

        protected void drpLoaiCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            getObjects();
        }

        protected void drpMucDoCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            getObjects();
        }

        protected void drpChuDeCauHoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            getObjects();
        }

        protected void setSessionForChuDeBaiThi()
        {
            SessionForChuDeBaiThi objSessionForChuDeBaiThi = new SessionForChuDeBaiThi();
            objSessionForChuDeBaiThi.ID_CHU_DE_BAI_THI = drpChuDeCauHoi.SelectedValue;
            Session[Commons.ConstValues.SESSION_CHUDEBAITHI] = objSessionForChuDeBaiThi;
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE_IMPORT.Visible = true;
        }

        /*-------------------Import Excel------------------------*/

        public DataTable funcReadExcelFile(FileUpload fileUpload, string isHDR, int intSheet, HttpServerUtility Server)
        {

            if (fileUpload.HasFile)
            {
                string FileName = Path.GetFileName(fileUpload.PostedFile.FileName);
                string Extension = Path.GetExtension(fileUpload.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["UPLOAD_DIRECTORY"];

                string FilePath = Server.MapPath(FolderPath + FileName);

                fileUpload.SaveAs(FilePath);

                try
                {


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

                    if (drpLoaiCH.SelectedValue.Equals("trac_nghiem"))
                    {
                        SheetName = "TRAC_NGHIEM$";
                    }
                    else if (drpLoaiCH.SelectedValue.Equals("tu_luan"))
                    {
                        SheetName = "TU_LUAN$";
                    }
                    else if (drpLoaiCH.SelectedValue.Equals("chu_de_bai_thi"))
                    {
                        SheetName = "DS_CHU_DE_CAU_HOIS";
                    }
                    connExcel.Close();

                    //Read Data from First Sheet
                    connExcel.Open();
                    cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                    oda.SelectCommand = cmdExcel;
                    oda.Fill(dt);

                    connExcel.Close();
                    //Bind Data to GridView

                    return dt;
                }
                catch (Exception ex)
                {
                    Response.Redirect("http://dantri.com?e="+ex.Message);
                    return null;
                }

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
        //---------------------------------Import file excel for Test_online_aits
        protected void insert_CHU_DE_BAI_THI(DataTable dt)
        {
            string strMaChuDe = "";

            int y = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (y < 1) //ignore the title rows in excel, 1 rows
                {
                    y++;
                    continue;
                }

                strMaChuDe = row["MA_CHU_DE"].ToString().Trim();

                //var objSearch = entities.CHU_DE_BAI_THI.Where(x => (x.MA_CHU_DE.Equals(strMaChuDe) && x.TT_XOA == false ).FirstOrDefault();
                var objSearch = entities.CHU_DE_BAI_THI.Where(x => (x.MA_CHU_DE.Equals(strMaChuDe))).FirstOrDefault();

                if (objSearch == null) //Check duplicate
                {
                    CHU_DE_BAI_THI obj = new CHU_DE_BAI_THI();
                    obj.MA_CHU_DE = row["MA_CHU_DE"].ToString().Trim();
                    obj.TEN_CHU_DE = row["TEN_CHU_DE"].ToString().Trim();
                    obj.NGAY_TAO = DateTime.Now;
                    obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    obj.TT_XOA = false;

                    entities.CHU_DE_BAI_THI.Add(obj);
                    entities.SaveChanges();
                }
            }
        }
        protected void insert_CAU_HOI_TRAC_NGHIEM(DataTable dt)
        {
            string strNoiDungCauHoi = "";
            string strMaChuDe = "";

            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (i < 3) //ignore the title rows in excel, 4 rows
                {
                    i++;
                    continue;
                }

                strNoiDungCauHoi = row["NOI_DUNG_CAU_HOI"].ToString().Trim();
                strMaChuDe = row["CHU_DE"].ToString().Trim();

                var objCauHoi = entities.CAU_HOI.Where(x => (strNoiDungCauHoi.Equals(x.NOI_DUNG_CAU_HOI))).FirstOrDefault();
                var objChuDeCauHoi = entities.CHU_DE_BAI_THI.Where(y => (strMaChuDe.Equals(y.MA_CHU_DE))).FirstOrDefault();

                if (objCauHoi == null)
                {
                    CAU_HOI obj = new CAU_HOI();
                    obj.NOI_DUNG_CAU_HOI = row["NOI_DUNG_CAU_HOI"].ToString().Trim();
                    obj.NGAY_TAO = DateTime.Now;
                    obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    obj.TT_XOA = false;
                    obj.ID_CHU_DE_BAI_THI = objChuDeCauHoi.ID;

                    obj.ID_LOAI_CAU_HOI = 1;

                    entities.CAU_HOI.Add(obj);
                    entities.SaveChanges();
                }
            }
        }
        protected void insert_CAU_HOI_TU_LUAN(DataTable dt)
        {
            string strNoiDungCauHoi = "";
            string strMaChuDe = "";

            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (i < 3) //ignore the title rows in excel, 4 rows
                {
                    i++;
                    continue;
                }
                strNoiDungCauHoi = row["NOI_DUNG_CAU_HOI"].ToString().Trim();
                strMaChuDe = row["CHU_DE"].ToString().Trim();

                if (strMaChuDe == "" || strNoiDungCauHoi == "") //Check row null
                    continue;

                var objCauHoi = entities.CAU_HOI.Where(x => x.NOI_DUNG_CAU_HOI.Equals(strNoiDungCauHoi)).FirstOrDefault();
                var objChuDeCauHoi = entities.CHU_DE_BAI_THI.Where(y => y.MA_CHU_DE.Equals(strMaChuDe)).FirstOrDefault();

                if (objCauHoi == null)
                {
                    CAU_HOI obj = new CAU_HOI();

                    obj.NOI_DUNG_CAU_HOI = row["NOI_DUNG_CAU_HOI"].ToString().Trim();
                    obj.NGAY_TAO = DateTime.Now;
                    obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                    obj.TT_XOA = false;
                    obj.ID_CHU_DE_BAI_THI = objChuDeCauHoi.ID;
                    obj.ID_LOAI_CAU_HOI = 2;

                    entities.CAU_HOI.Add(obj);
                    entities.SaveChanges();
                }
            }
        }
        protected void insert_CAU_HOI_MUC_DO(DataTable dt)
        {
            var strNoiDungCH = "";
            //int intId_CauHoi = 0;
            var strDe = "";
            var strTB = "";
            var strKho = "";
            int intId_MucDoCauHoi = 0;

            int y = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (y < 3) //ignore the title rows in excel, 4 rows
                {
                    y++;
                    continue;
                }

                strNoiDungCH = row["NOI_DUNG_CAU_HOI"].ToString().Trim();
                strDe = row["DE"].ToString().Trim();
                strTB = row["TB"].ToString().Trim();
                strKho = row["KHO"].ToString().Trim();

                if (strNoiDungCH == "" || strNoiDungCH == null) //check row null
                    continue;

                var objCauHoi = entities.CAU_HOI.Where(x => x.NOI_DUNG_CAU_HOI.Equals(strNoiDungCH)).FirstOrDefault();


                if (objCauHoi != null)
                {
                    if (strDe == "X")
                    {
                        intId_MucDoCauHoi = 1;
                    }
                    if (strTB == "X")
                    {
                        intId_MucDoCauHoi = 2;
                    }
                    if (strKho == "X")
                    {
                        intId_MucDoCauHoi = 3;
                    }
                    var objCauHoiMucDo = entities.CAU_HOI_MUC_DO.Where(c => (c.ID_CAU_HOI == objCauHoi.ID) && (c.ID_MUC_DO_CAU_HOI == intId_MucDoCauHoi)).FirstOrDefault();

                    if (objCauHoiMucDo == null) //check duplicate
                    {
                        CAU_HOI_MUC_DO obj = new CAU_HOI_MUC_DO();
                        obj.ID_CAU_HOI = objCauHoi.ID;
                        obj.ID_MUC_DO_CAU_HOI = intId_MucDoCauHoi;
                        obj.NGAY_TAO = DateTime.Now;
                        obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                        obj.TT_XOA = false;

                        entities.CAU_HOI_MUC_DO.Add(obj);

                        entities.SaveChanges();
                    }
                }
            }
        }
        protected void insert_DAP_AN(DataTable dt) //use for trac nghiem
        {
            var strNoiDungCH = "";
            var strNoiDungDapAn = "";
            int y = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (y < 3) //ignore the title rows in excel, 4 rows
                {
                    y++;
                    continue;
                }
                strNoiDungCH = row["NOI_DUNG_CAU_HOI"].ToString().Trim();

                var objCauHoi = entities.CAU_HOI.Where(x => (x.NOI_DUNG_CAU_HOI.Equals(strNoiDungCH)) && (x.TT_XOA == false)).FirstOrDefault();
                if (objCauHoi != null)
                {
                    for (int i = 1; i <= 8; i++) //set answer and status
                    {
                        DAP_AN obj = new DAP_AN();
                        strNoiDungDapAn = row["DA_" + i].ToString().Trim();

                        var objDapAn = entities.DAP_AN.Where(x => (x.NOI_DUNG_DAP_AN.Equals(strNoiDungDapAn)) && (x.ID_CAU_HOI == objCauHoi.ID)).FirstOrDefault();

                        if (objDapAn == null) //check duplicate
                        {
                            if (strNoiDungDapAn == "" || strNoiDungDapAn == null) //check null answer
                                continue;
                            obj.ID_CAU_HOI = objCauHoi.ID;
                            obj.NOI_DUNG_DAP_AN = strNoiDungDapAn;
                            if (row["TT_" + i].ToString().Trim().Equals("S"))
                            {
                                obj.TRANG_THAI = false;
                            }
                            else
                            {
                                obj.TRANG_THAI = true;
                            }
                            obj.NGAY_TAO = DateTime.Now;
                            obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
                            obj.TT_XOA = false;

                            entities.DAP_AN.Add(obj);
                            entities.SaveChanges();
                        }
                    }
                }
            }
        }
        protected void BtImport_test_online_Click(object sender, EventArgs e)
        {
            DataTable dt = funcReadExcelFile(FileUpload_test_online, "Yes", 0, Server);
            if (dt != null)
            {
                if (drpLoaiCH.SelectedValue.Equals("tu_luan"))
                {
                    insert_CAU_HOI_TU_LUAN(dt);
                    insert_CAU_HOI_MUC_DO(dt);

                    lbMessage.Text = "Cập nhật thành công";
                }
                else if (drpLoaiCH.SelectedValue.Equals("trac_nghiem"))
                {
                    insert_CAU_HOI_TRAC_NGHIEM(dt);
                    insert_DAP_AN(dt);
                    insert_CAU_HOI_MUC_DO(dt);

                    lbMessage.Text = "Cập nhật thành công";
                }
                else if (drpLoaiCH.SelectedValue.Equals("chu_de_bai_thi"))
                {
                    insert_CHU_DE_BAI_THI(dt);

                    lbMessage.Text = "Cập nhật thành công";
                }
                else
                {
                    lbMessage.Text = "Chọn bảng cần cập nhật";
                }
            }
            else
            {
                lbMessage.Text = "Bạn chưa chọn tệp tin";
            }
        }

        protected void btlClosePopUp_Import_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE_IMPORT.Visible = false;
            lbMessage.Text = "";
        }
    }
}