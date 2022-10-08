using CPanel.Commons;
using CPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules.QuanLyBaiThi
{
    public partial class DsUvDaThi : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            grvObjects.DataBind();
            
            if (!IsPostBack)
            {
                Commons.ATCL_Commons.getPhongBan(drpPhongban, entities);
            }
        }

        protected void grvObj_DataBinding(object sender, EventArgs e)
        {
            var lstUser = entities.BAI_THI_UNG_VIEN.Where(x => ((x.TT_XOA == false) || (x.TT_XOA == null)) && x.NGAY_HOAN_THANH_BAI_THI != null).OrderByDescending(y => y.NGAY_HOAN_THANH_BAI_THI).ToList();
            //var lstUser = entities.UNG_VIEN.Join(entities.BAI_THI_UNG_VIEN, UV => UV.ID, BTUV => BTUV.ID_UNG_VIEN, (UV, BTUV) => new { UV, BTUV }).Where(x => x.UV.TT_XOA == false).ToList();
            grvObjects.DataSource = lstUser;
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient();
            //ĐỊA CHỈ SMTP Server
            smtp.Host = Commons.TitleConst.getTitleConst("HOST");
            //Cổng SMTP
            smtp.Port = Convert.ToInt32(Commons.TitleConst.getTitleConst("PORT"));
            //SMTP yêu cầu mã hóa dữ liệu theo SSL
            smtp.EnableSsl = false;
            //UserName và Password của mail
            smtp.Credentials = new NetworkCredential(Commons.TitleConst.getTitleConst("USER_NAME"), Commons.TitleConst.getTitleConst("PASSWORD"));

            
            BAI_THI_UNG_VIEN objUngvien = new BAI_THI_UNG_VIEN();
            var lstUngvien = grvObjects.GetSelectedFieldValues(grvObjects.KeyFieldName);
            var lstNguoinhan = grvNguoinhan.GetSelectedFieldValues(grvNguoinhan.KeyFieldName);
            if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpPhongban.SelectedValue))
            {
                try
                {
                    if ((lstUngvien != null) && (lstUngvien.Count > 0))
                    {
                        Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("WAITING"), Page);
                        foreach (int i in lstUngvien)
                        {
                            objUngvien = entities.BAI_THI_UNG_VIEN.Where(x => x.ID == i).FirstOrDefault();
                            if ((lstNguoinhan != null) && (lstNguoinhan.Count > 0))
                            {
                                foreach (int j in lstNguoinhan)
                                {
                                    NGUOI_DANH_GIA objDanhgia = entities.NGUOI_DANH_GIA.Where(x => x.ID == j).FirstOrDefault();
                                    //string file = "H:/test1/2-9.png";
                                    //StreamReader reader = new StreamReader(Server.MapPath("~/tailieu1.html"));
                                    MailMessage message = new MailMessage(
                                                                            Commons.TitleConst.getTitleConst("USER_NAME"),
                                                                            objDanhgia.EMAIL,
                                                                            "Bài thi của " + objUngvien.UNG_VIEN.HO_TEN,
                                                                            "Chào bạn " + objDanhgia.HO_TEN + "\n"
                                                                            + "Bạn vui lòng đánh giá ứng viên sau:" + "\n"
                                                                            + "\t" + "•" + "   Họ tên ứng viên: " + objUngvien.UNG_VIEN.HO_TEN + "\n"
                                                                            + "\t" + "•" + "   Vị trí ứng tuyển: " + objUngvien.VI_TRI_TUYEN_DUNG + "\n"
                                                                            + "\t" + "•" + "   Thời gian đánh giá: Từ ngày " + ((DateTime)(objUngvien.NGAY_HOAN_THANH_BAI_THI)).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY) + " đến ngày " + ((DateTime)(objUngvien.NGAY_HOAN_THANH_BAI_THI)).AddDays(2).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY) + "\n"
                                                                            + "\t" + "•" + "   Đường link để vào đánh giá: http://localhost:1999/Modules/Admin/DsUvDaThi" + "\n\n"
                                                                            + "Trân trọng," + "\n\n"
                                                                            + "CÔNG TY CỔ PHẦN TIN HỌC – VIỄN THÔNG HÀNG KHÔNG (AITS)" + "\n"
                                                                            + "Đ/c: Số 412 Nguyễn Văn Cừ, Phường Bồ Đề, Quận Long Biên, TP Hà Nội, Việt Nam" + "\n"
                                                                            + "ĐT: 1900 98 98 66 * Máy lẻ: 9511" + "\n"
                                                                            + "Email: Helpdesk.aits@vietnamairlines.com" + "\n"
                                                                           );
                                    //Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                                    //message.Attachments.Add(data);
                                    //message.IsBodyHtml = true;
                                    smtp.Send(message);
                                    objUngvien.TRANG_THAI_GUI_MAIL = "Đã gửi";
                                    objUngvien.ID_NGUOI_DANH_GIA = objDanhgia.ID;
                                    entities.SaveChanges();
                                }
                            }
                        }
                        Response.Redirect(Commons.TitleConst.getTitleConst("DsUvDaThi.aspx"));
                    }
                    else
                    {
                        Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Bạn chưa chọn ứng viên"), Page);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("Bạn chưa chọn người đánh giá"), Page);
            }

            DIV_MESSAGE_NGUOI_DANH_GIA.Visible = false;
        }

        protected void drpPhongban_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpPhongban.SelectedValue))
            //{
            //    Commons.ATCL_Commons.getNguoiDanhGia(drpNguoidanhgia, Convert.ToInt32(drpPhongban.SelectedValue), entities);
            //}
            grvNguoinhan.DataBind();
        }

        protected void btnChonNguoiGui_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE_NGUOI_DANH_GIA.Visible = true;
        }

        protected void btlClosePopUp_NguoiDanhGia_Click(object sender, EventArgs e)
        {
            DIV_MESSAGE_NGUOI_DANH_GIA.Visible = false;
        }

        protected void grvNguoinhan_DataBinding(object sender, EventArgs e)
        {
            if (!Commons.CommonFuncs.BLANK_ITEM_VALUE.Equals(drpPhongban.SelectedValue))
            {
                int intIDPhongban = Convert.ToInt32(drpPhongban.SelectedValue);
                var lstNguoidanhgia = entities.NGUOI_DANH_GIA.Where(x => x.Id_PHONG_BAN == intIDPhongban).ToList();
                grvNguoinhan.DataSource = lstNguoidanhgia;
            }         
        }

        protected void btnViewObject_Click(object sender, EventArgs e)
        {
            Session[ATCL_Consts.SESSION_OBJECT_ID] = txtObjectID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("AdminReviewBT.aspx"));
        }

        protected int getObjectID()
        {
            return Convert.ToInt32(txtObjectID.Text);
        }
    }
}