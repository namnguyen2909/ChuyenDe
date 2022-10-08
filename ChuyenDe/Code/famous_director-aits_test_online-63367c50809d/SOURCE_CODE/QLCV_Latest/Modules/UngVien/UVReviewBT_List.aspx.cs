using CPanel.Commons;
using CPanel.Models;
using CPanel.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules.UngVien
{
    public partial class UVReviewBT_List : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            grvBaiThi.DataBind();
        }

        protected void btnViewObject_Click(object sender, EventArgs e)
        {
            int intCurrentUserID = Convert.ToInt32(txtObjectID.Text);
            BAI_THI_UNG_VIEN ngayhoanthanh = new BAI_THI_UNG_VIEN();
            ngayhoanthanh = entities.BAI_THI_UNG_VIEN.Where(x => x.ID == intCurrentUserID).FirstOrDefault();
            if (ngayhoanthanh.NGAY_HOAN_THANH_BAI_THI != null)
            {
                Session[ATCL_Consts.SESSION_OBJECT_ID] = txtObjectID.Text;
                Response.Redirect(Commons.TitleConst.getTitleConst("/Modules/UngVien/LamBaiThi_View"));
            }
            else
            {
                lbMessage.Text = "Bạn chưa làm bài thi! Không thể xem lại";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("ThongTinChiTietUV.aspx"));
        }

        protected void grvBaiThi_DataBinding(object sender, EventArgs e)
        {
            int intObjID = (int)Commons.CheckUserInfo.GetUserId();
            var lstBaithi = entities.BAI_THI_UNG_VIEN.Where(x => (x.ID_UNG_VIEN == intObjID) && ( x.NGAY_GUI_MAIL != null) ).ToList();
            grvBaiThi.DataSource = lstBaithi;
        }

        protected void btnTestObject_Click(object sender, EventArgs e)
        {
            int intCurrentUserID = Convert.ToInt32(txtObjectID.Text);
            BAI_THI_UNG_VIEN ngayhoanthanh = new BAI_THI_UNG_VIEN();
            ngayhoanthanh = entities.BAI_THI_UNG_VIEN.Where(x => x.ID == intCurrentUserID).FirstOrDefault();
            if (ngayhoanthanh.NGAY_HOAN_THANH_BAI_THI == null)
            {
                Session[ATCL_Consts.SESSION_OBJECT_ID] = txtObjectID.Text;
                Response.Redirect(Commons.TitleConst.getTitleConst("/Modules/UngVien/LamBaiThi"));
            }
            else
            {
                lbMessage.Text = "Bạn đã làm bài thi! Không thể làm lại";
            }
        }
    }
}