using CPanel.Commons;
using CPanel.Models;
using CPanel.Models.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules.Admin
{
    public partial class XemUngVien : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
            grvObjects.DataBind();
        }

        protected void grvObjects_DataBinding(object sender, EventArgs e)
        {
            var lstUser = entities.BAI_THI_UNG_VIEN.Where(x => (x.TT_XOA == false) || (x.TT_XOA == null)).OrderByDescending(y => y.ID).ToList();

            ASPxGridView1.DataSource = lstUser;
        }

        protected void getObjects()
        {
            var lstOpenReport = entities.UNG_VIEN.Where(x => (x.TT_XOA == false))
                                .Select(y => new UNG_VIEN_VIEW()
                                {
                                    ID = y.ID,
                                    HO_TEN = y.HO_TEN,
                                    NGAY_SINH = y.NGAY_SINH,
                                    SO_DIEN_THOAI = y.SO_DIEN_THOAI,
                                    EMAIL = y.EMAIL,
                                    ID_CHU_DE_BAI_THI = y.ID_CHU_DE_BAI_THI,
                                    ID_BAI_THI = y.ID_BAI_THI,
                                    TT_XOA = y.TT_XOA,
                                    MA_UNG_VIEN = y.MA_UNG_VIEN
                                }).ToList();
            grvObjects.DataSource = lstOpenReport;
            grvObjects.DataBind();
        }

        protected void btnViewObject_Click(object sender, EventArgs e)
        {
            Session[ATCL_Consts.SESSION_OBJECT_ID] = txtObjectID.Text;
            Response.Redirect(Commons.TitleConst.getTitleConst("/Modules/Admin/ThemUngVien"));
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
            var uv = entities.UNG_VIEN.Find(intObjectID);
            if (uv != null)
            {
                //entities.UNG_VIEN.Remove(uv);
                uv.TT_XOA = true;
                entities.SaveChanges();
            }
            //refresh Gridview
            getObjects();

            //Close Popup
            DIV_MESSAGE.Visible = false;
            btnOK_DeleteObject.Visible = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("ThemUngVien.aspx"));
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect(Commons.TitleConst.getTitleConst("ChonBaiThi.aspx"));
        }



        protected void btnSend_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient();
            //ĐỊA CHỈ SMTP Server
            smtp.Host = Commons.TitleConst.getTitleConst("HOST");
            //Cổng SMTP
            smtp.Port = Convert.ToInt32(Commons.TitleConst.getTitleConst("PORT"));
            //SMTP yêu cầu mã hóa dữ liệu theo SSL
            //smtp.EnableSsl = false;
            smtp.EnableSsl = false;
            //UserName và Password của mail
            smtp.Credentials = new NetworkCredential(Commons.TitleConst.getTitleConst("USER_NAME"), Commons.TitleConst.getTitleConst("PASSWORD"));


            BAI_THI_UNG_VIEN objUngvien = new BAI_THI_UNG_VIEN();
            var lstUngvien = ASPxGridView1.GetSelectedFieldValues(ASPxGridView1.KeyFieldName);
            try
            {
                if ((lstUngvien != null) && (lstUngvien.Count > 0))
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("WAITING"), Page);
                    foreach (int i in lstUngvien)
                    {
                        objUngvien = entities.BAI_THI_UNG_VIEN.Where(x => x.ID == i).FirstOrDefault();
                        objUngvien.NGAY_GUI_MAIL = DateTime.Now;
                        //string file = "H:/test1/2-9.png";
                        //StreamReader reader = new StreamReader(Server.MapPath("~/tailieu1.html"));
                        MailMessage message = new MailMessage(
                                                                Commons.TitleConst.getTitleConst("USER_NAME"),
                                                                objUngvien.EMAIL,
                                                                "Test",
                                                                "Xin chào bạn " + objUngvien.UNG_VIEN.HO_TEN + " ," + "\n\n"
                                                                + "Cảm ơn bạn đã ứng tuyển vào vị trí " + objUngvien.VI_TRI_TUYEN_DUNG + " tại Công ty Cổ phần Tin học Viễn thông Hàng không(AITS)" + "\n\n"
                                                                + "AITS đã nhận được thông tin hồ sơ ứng tuyển của bạn vào vị trí " + objUngvien.VI_TRI_TUYEN_DUNG + " ." + "\n"
                                                                + "Để có đánh giá tổng thể, quyết định xem hồ sơ của bạn có lọt vào vòng phỏng vấn tiếp theo hay không, " +
                                                                "bạn vui lòng tham gia làm bài kiểm tra Online theo đường link sau:" + "\n"
                                                                + "\t" + "•" + "   http://localhost:1999//Modules/UngVien/UVLogin" + "\n"
                                                                + "\t" + "•" + "   Tài khoản đăng nhập: " + objUngvien.UNG_VIEN.UserName + "\n"
                                                                + "\t" + "•" + "   Password: aits@412 " + "\n"
                                                                + "Sau khi nhận được kết quả bài kiểm tra Online của bạn, chúng tôi sẽ đánh giá chi tiết hồ sơ của bạn và sẽ cân nhắc, " +
                                                                "phản hồi lại bạn trong vòng 5-7 ngày sau đó." + "\n"
                                                                + "Chúc bạn một ngày tốt lành và đừng quên kiểm tra email thường xuyên. " + "\n\n"
                                                                + "Chúng tôi rất mong có cơ hội gặp bạn." + "\n\n"
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

                        entities.SaveChanges();
                    }
                    Response.Redirect(Commons.TitleConst.getTitleConst("XemUngVien.aspx"));
                }
                else
                {
                    Commons.ValidationFuncs.errorMessage_TimeDelay(Commons.TitleConst.getTitleConst("MSG_BAN_CHUA_CHON"), Page);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected void grvObjects_DataBinding1(object sender, EventArgs e)
        {
            var lstOpenReport = entities.UNG_VIEN.Where(x => (x.TT_XOA == false))
                                .Select(y => new UNG_VIEN_VIEW()
                                {
                                    ID = y.ID,
                                    HO_TEN = y.HO_TEN,
                                    NGAY_SINH = y.NGAY_SINH,
                                    SO_DIEN_THOAI = y.SO_DIEN_THOAI,
                                    EMAIL = y.EMAIL,
                                    ID_CHU_DE_BAI_THI = y.ID_CHU_DE_BAI_THI,
                                    ID_BAI_THI = y.ID_BAI_THI,
                                    TT_XOA = y.TT_XOA,
                                    MA_UNG_VIEN = y.MA_UNG_VIEN
                                }).ToList();
            grvObjects.DataSource = lstOpenReport;
        }

    }
}