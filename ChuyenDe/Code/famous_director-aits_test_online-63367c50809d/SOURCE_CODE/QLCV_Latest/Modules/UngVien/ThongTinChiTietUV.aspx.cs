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
    public partial class ThongTinChiTietUV : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getObject();
            }
        }

        public void getObject()
        {
            if (Commons.CheckUserInfo.GetUserId() == null)
            {
                return;
            }
            int intObjID = (int)Commons.CheckUserInfo.GetUserId();

            var objHoTen = entities.UNG_VIEN.Where(x => x.ID == intObjID).FirstOrDefault();
            if (objHoTen != null)
            {
                lblTen.Text = objHoTen.HO_TEN;
            }

            var objNgaySinh = entities.UNG_VIEN.Where(x => x.ID == intObjID).Select(y => new UNG_VIEN_VIEW()
            {
                NGAY_SINH = y.NGAY_SINH
            }).FirstOrDefault();
            if (objNgaySinh != null)
            {
                lblNgaySinh.Text = objNgaySinh.STR_NGAY_SINH;
            }

            var objEmail = entities.UNG_VIEN.Where(x => x.ID == intObjID).FirstOrDefault();
            if (objEmail != null)
            {
                lblEmail.Text = objEmail.EMAIL;
            }

            var objSoDienThoai = entities.UNG_VIEN.Where(x => x.ID == intObjID).FirstOrDefault();
            if (objSoDienThoai != null)
            {
                lblSDT.Text = objSoDienThoai.SO_DIEN_THOAI;
            }

            var objViTriTuyenDung = entities.UNG_VIEN.Where(x => x.ID == intObjID).Select(y => new UNG_VIEN_VIEW()
            {
                ID_CHU_DE_BAI_THI = y.ID_CHU_DE_BAI_THI
            }).FirstOrDefault();
            if (objViTriTuyenDung != null)
            {
                lblViTri.Text = objViTriTuyenDung.VI_TRI;
            }
        }

        
        protected void btnView_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("UVReviewBT_List.aspx"));
        }
    }
}