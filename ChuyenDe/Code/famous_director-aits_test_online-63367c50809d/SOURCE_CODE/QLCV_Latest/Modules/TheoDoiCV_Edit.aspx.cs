using CPanel.Commons;
using CPanel.Models;
using System;
using System.Configuration;
using System.Linq;
using System.Web.UI.WebControls;

namespace CPanel.Modules
{
	public partial class TheoDoiCV_Edit : System.Web.UI.Page
	{
		private ATCLEntities entities = new ATCLEntities();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				//Get Danh sach He Thong
				Commons.ATCL_Commons.getHeThong(drpHeThong, entities);

				//Get Danh sach Hop Dong
				Commons.ATCL_Commons.getHopDong(drpPLHD, entities);

				//get Session
				if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_OBJECT_ID]))
				{
					txtObjectID.Text = Session[ATCL_Consts.SESSION_OBJECT_ID].ToString();
					Session[ATCL_Consts.SESSION_OBJECT_ID] = null;
				}


				//Get Danh sach Ket qua cong viec
				Commons.ATCL_Commons.getDanhMuc(drpKetQuaCV, entities, ConfigurationManager.AppSettings["MA_DM_KET_QUA_CONG_VIEC"]);

				// Get Danh sach muc do cong viec
				Commons.ATCL_Commons.getDanhMuc(drpMucDoCV, entities, ConfigurationManager.AppSettings["MA_DM_MUC_DO"]);

				//Get Nguoi Dung
				Commons.ATCL_Commons.getNguoiDung(drpNguoiChuTri, entities);

				//Get Nguoi Dung
				var lst = entities.TBL_NGUOI_DUNG.Where(x => x.isEnabled == true).OrderBy(y => y.UserName).ToList();
				foreach (var item in lst)
				{
					var lstItem = new ListItem();
					lstItem.Value = item.Id.ToString();
					lstItem.Text = item.FullName;
					lbNguoiPhoiHop.Items.Add(lstItem);
				}
				lbNguoiPhoiHop.Attributes["multiple"] = "multiple";
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
				var obj = entities.TBL_THEO_DOI_CV.Where(x => x.ID == intObjectID).FirstOrDefault();
				if (obj != null)
				{
					txtTenCongViec.Text = obj.TEN_CONG_VIEC;

					if (obj.ID_HE_THONG != null)
						drpHeThong.SelectedValue = obj.ID_HE_THONG.ToString();

					if (obj.ID_HOP_DONG != null)
						drpPLHD.SelectedValue = obj.ID_HOP_DONG.ToString();

					if (obj.NGAY_BAT_DAU != null)
					{
						dtNgayBatDau.Text = ((DateTime)obj.NGAY_BAT_DAU).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
						dtNgayBatDau.Value = ((DateTime)obj.NGAY_BAT_DAU).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
					}


					dtNgayKetThuc.Text = ((DateTime)obj.NGAY_KET_THUC).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
					dtNgayKetThuc.Value = ((DateTime)obj.NGAY_KET_THUC).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);

					if (obj.ID_NGUOI_CHU_TRI != null)
						drpNguoiChuTri.SelectedValue = obj.ID_NGUOI_CHU_TRI.ToString();

					if (obj.ID_NGUOI_PHOI_HOP != null)
					{
						string strNguoiPhoiHop = obj.ID_NGUOI_PHOI_HOP;
						foreach (ListItem itemN in lbNguoiPhoiHop.Items)
						{
							foreach (var item in strNguoiPhoiHop.Split('|'))
							{
								if (itemN.Value.Equals(item))
								{
									itemN.Selected = true;
								}
							}
							
						}
					}

					if (obj.ID_KET_QUA_CV != null)
						drpKetQuaCV.SelectedValue = obj.ID_KET_QUA_CV.ToString();
					if (obj.ID_MUC_DO_CV != null)
						drpMucDoCV.SelectedValue = obj.ID_MUC_DO_CV.ToString();

					txtGhiChu.Text = obj.GHI_CHU;
				}
			}
		}

		/**
         * Config format of DateTime
         */
		protected void configFormatDateTime()
		{
			dtNgayBatDau.EditFormatString = Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY;
			dtNgayKetThuc.EditFormatString = Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY;
		}


		protected string saveObject()
		{
			try
			{
				TBL_THEO_DOI_CV obj = new TBL_THEO_DOI_CV();
				if (String.IsNullOrEmpty(txtObjectID.Text)) //Create new item
				{
					obj.NGAY_TAO = DateTime.Now;
					obj.ID_NGUOI_TAO = (int)Commons.CheckUserInfo.GetUserId();
					obj.TT_XOA = false;

					entities.TBL_THEO_DOI_CV.Add(obj);
				}
				else //Edit the item
				{
					int intObjID = Convert.ToInt32(txtObjectID.Text);
					obj = entities.TBL_THEO_DOI_CV.Find(intObjID);
				}

				obj.TEN_CONG_VIEC = txtTenCongViec.Text;

				//Set Hop Dong
				if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpPLHD.SelectedValue))
				{
					obj.ID_HOP_DONG = Convert.ToInt32(drpPLHD.SelectedValue);
				}

				//Set He Thong
				if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpHeThong.SelectedValue))
				{
					obj.ID_HE_THONG = Convert.ToInt32(drpHeThong.SelectedValue);
				}

				//Set Ket Qua CV
				if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpKetQuaCV.SelectedValue))
				{
					obj.ID_KET_QUA_CV = Convert.ToInt32(drpKetQuaCV.SelectedValue);
				}
				if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpMucDoCV.SelectedValue))
				{
					obj.ID_MUC_DO_CV = Convert.ToInt32(drpMucDoCV.SelectedValue);
				}

				obj.ID_NGUOI_CHU_TRI = Convert.ToInt32(drpNguoiChuTri.SelectedValue);
				string strId = "";
				foreach (ListItem listItem in lbNguoiPhoiHop.Items)
				{
					if (listItem.Selected)
					{
						strId += listItem.Value + "|";
					}
				}

				obj.ID_NGUOI_PHOI_HOP = strId;
				obj.NGAY_SUA = DateTime.Now;
				obj.ID_NGUOI_SUA = (int)Commons.CheckUserInfo.GetUserId();

				if (!String.IsNullOrEmpty(dtNgayBatDau.Text))
					obj.NGAY_BAT_DAU = DateTime.ParseExact(dtNgayBatDau.Text, Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY, System.Globalization.CultureInfo.InvariantCulture);

				obj.NGAY_KET_THUC = DateTime.ParseExact(dtNgayKetThuc.Text, Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY, System.Globalization.CultureInfo.InvariantCulture);

				obj.GHI_CHU = txtGhiChu.Text;

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
			Response.Redirect(Commons.TitleConst.getTitleConst("URL_THEO_DOI_CV_LIST"));
		}

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect(Commons.TitleConst.getTitleConst("URL_THEO_DOI_CV_LIST"));
		}
	}
}