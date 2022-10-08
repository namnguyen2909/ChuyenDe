using CPanel.Commons;
using CPanel.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;

namespace CPanel.Modules
{
	public partial class HopDuAn_Edit : System.Web.UI.Page
	{
		private ATCLEntities entities = new ATCLEntities();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//get Session "OBJECT_ID"
				if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_OBJECT_ID]))
				{
					txtObjectID.Text = Session[ATCL_Consts.SESSION_OBJECT_ID].ToString();
					Session[ATCL_Consts.SESSION_OBJECT_ID] = null;
				}


				//Get Danh sach Ket qua cong viec
				Commons.ATCL_Commons.getDanhMuc(drpKieuHop, entities, ConfigurationManager.AppSettings["MA_DM_KIEU_HOP"]);

				//Get Nguoi Dung
				Commons.ATCL_Commons.getDanhMuc(drpHinhThuc, entities, ConfigurationManager.AppSettings["MA_DM_HINH_THUC_HOP"]);

				//Config Date Time
				configFormatDateTime();

				//get Object info
				getObjects();

			}
		}

		public void getObjects()
		{
			if (!String.IsNullOrEmpty(txtObjectID.Text))
			{
				int intObjectID = Convert.ToInt32(txtObjectID.Text);
				var obj = entities.TBL_HOP_DA.FirstOrDefault(x => x.ID == intObjectID);
				if (obj != null)
				{
					txtNoiDung.Text = obj.NOI_DUNG_HOP;
					txtDiaDiem.Text = obj.DIA_DIEM;
					if (obj.ID_KIEU_HOP != null)
						drpKieuHop.SelectedValue = obj.ID_KIEU_HOP.ToString();

					if (obj.NGAY_HOP != null)
					{
						dtNgayHop.Text = ((DateTime)obj.NGAY_HOP).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
						dtNgayHop.Value = ((DateTime)obj.NGAY_HOP).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
					}

					if (obj.GIO_BAT_DAU != null)
					{
						tsGioHop.Text = ((TimeSpan)obj.GIO_BAT_DAU).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
						tsGioHop.Value = ((TimeSpan)obj.GIO_BAT_DAU).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
					}

					if (obj.ID_HINH_THUC_HOP != null)
					{
						drpHinhThuc.SelectedValue = obj.ID_HINH_THUC_HOP.ToString();
					}

					txtGhiChu.Text = obj.GHI_CHU;
				}
			}
		}

		/**
         * Config format of DateTime
         */
		protected void configFormatDateTime()
		{
			dtNgayHop.EditFormatString = Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY;
			tsGioHop.EditFormatString = Commons.DateTimeType.TIME_FORMAT_HH_MM;
		}


		protected string saveObject()
		{
			try
			{
				if (String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_HE_THONG_ID]))
				{
					return null;
				}

				var idHeThong = (string)Session[ATCL_Consts.SESSION_HE_THONG_ID];
				Session[ATCL_Consts.SESSION_HE_THONG_ID] = null;
				TBL_HOP_DA obj = new TBL_HOP_DA();
				if (String.IsNullOrEmpty(txtObjectID.Text)) //Create new item
				{
					obj.NGAY_TAO = DateTime.Now;
					obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
					obj.TT_XOA = false;

					entities.TBL_HOP_DA.Add(obj);
				}
				else //Edit the item
				{
					int intObjID = Convert.ToInt32(txtObjectID.Text);
					obj = entities.TBL_HOP_DA.Find(intObjID);
				}

				if (!String.IsNullOrEmpty(dtNgayHop.Text))
				{
					obj.NGAY_HOP = DateTime.ParseExact(dtNgayHop.Text, Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY, System.Globalization.CultureInfo.InvariantCulture);
				}

				if (!String.IsNullOrEmpty(tsGioHop.Text))
				{
					obj.GIO_BAT_DAU = TimeSpan.Parse(tsGioHop.Text);
				}

				if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpKieuHop.SelectedValue))
				{
					obj.ID_KIEU_HOP = Convert.ToInt32(drpKieuHop.SelectedValue);
				}

				if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpHinhThuc.SelectedValue))
				{
					obj.ID_HINH_THUC_HOP = Convert.ToInt32(drpHinhThuc.SelectedValue);
				}

				var url = string.Empty;
				if (FileUpload_KetQua.HasFile)
				{
					string FileName = Path.GetFileName(FileUpload_KetQua.PostedFile.FileName);
					string Extension = Path.GetExtension(FileUpload_KetQua.PostedFile.FileName);
					string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

					string FilePath = Server.MapPath(FolderPath + FileName);

					FileUpload_KetQua.SaveAs(FilePath);
					url = FilePath;
				}

				obj.DIA_DIEM = txtDiaDiem.Text;
				obj.NOI_DUNG_HOP = txtNoiDung.Text;
				obj.GHI_CHU = txtGhiChu.Text;
				obj.URL = url;
				obj.ID_HE_THONG = Convert.ToInt32(idHeThong);

				//Update Info
				entities.SaveChanges();

				//Return Result
				return obj.ID.ToString();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		protected void btnSave_Click(object sender, EventArgs e)
		{

			//save Report
			string strReportID = saveObject();
			showMessage(Commons.TitleConst.getTitleConst("MSG_INSERT_SUCCESFULLY"));
		}

		protected void showMessage(string strMessage)
		{
			DIV_MESSAGE.Visible = true;
			ltMessageContent.Text = strMessage;
		}

		protected void btlClosePopUp_Click(object sender, EventArgs e)
		{
			DIV_MESSAGE.Visible = false;
			redirectPage();
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			redirectPage();
		}

		protected void redirectPage()
		{
			Response.Redirect(Commons.TitleConst.getTitleConst("URL_HOP_DA_EDIT"));
		}

	}
}