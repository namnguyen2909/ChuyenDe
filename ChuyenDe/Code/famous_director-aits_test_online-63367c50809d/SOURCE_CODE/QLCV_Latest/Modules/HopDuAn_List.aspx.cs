using CPanel.Commons;
using CPanel.Models;
using DevExpress.XtraRichEdit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using CPanel.Models.Views;
namespace CPanel.Modules
{
	public partial class HopDuAn_List : System.Web.UI.Page
	{
		private ATCLEntities entities = new ATCLEntities();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				Commons.TitleConst.setTitleConst_ASPxGridView(grvObjects);
				Commons.ATCL_Commons.getDanhMuc(drpKieuHop, entities, "KIEU_HOP");

				//get List of Objects for Gridview

			}
			getObjects();
		}

		protected void grvObjects_DataBinding(object sender, EventArgs e)
		{

		}

		/**
         * Get Date of Open Reports
         */
		protected void getObjects()
		{
			var lstObjs = entities.TBL_HOP_DA.Where(x => (x.TT_XOA == false)
									).Select(y => new TBL_HOP_DA_VIEW()
									{
										ID = y.ID,
										ID_HE_THONG = y.ID_HE_THONG,
										NGAY_HOP = y.NGAY_HOP,
										GIO_BAT_DAU = y.GIO_BAT_DAU,
										GIO_KET_THUC = y.GIO_KET_THUC,
										DIA_DIEM = y.DIA_DIEM,
										ID_KIEU_HOP = y.ID_KIEU_HOP,
										GHI_CHU = y.GHI_CHU,
										ID_HINH_THUC_HOP = y.ID_HINH_THUC_HOP,
										NOI_DUNG_HOP = y.NOI_DUNG_HOP,
										STT = y.STT,

									})
									.OrderBy(s => s.STT).ThenBy(n => n.NGAY_HOP).ToList();

			grvObjects.DataSource = lstObjs;
			grvObjects.DataBind();

		}

		/**
         * View Pop up window
         */
		protected void btnViewObject_Click(object sender, EventArgs e)
		{
			Session[ATCL_Consts.SESSION_OBJECT_ID] = txtObjectID.Text;
			Response.Redirect(Commons.TitleConst.getTitleConst("URL_HOP_DA_EDIT"));
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

		protected void btnOK_DeleteObject_Click(object sender, EventArgs e)
		{
			int intObjectID = Convert.ToInt32(txtObjectID.Text);
			var obj = entities.TBL_HOP_DONG.Find(intObjectID);
			if (obj != null)
			{
				obj.TT_XOA = true;
				entities.SaveChanges();
			}
			//refresh Gridview
			getObjects();

			//Close Popup
			DIV_MESSAGE.Visible = false;
			btnOK_DeleteObject.Visible = false;
		}

		protected void btlClosePopUp_Message_Click(object sender, EventArgs e)
		{
			DIV_MESSAGE.Visible = false;
		}

		protected void btnCreate_Click(object sender, EventArgs e)
		{
			Response.Redirect(Commons.TitleConst.getTitleConst("URL_HOP_DA_EDIT"));
		}

	}
}