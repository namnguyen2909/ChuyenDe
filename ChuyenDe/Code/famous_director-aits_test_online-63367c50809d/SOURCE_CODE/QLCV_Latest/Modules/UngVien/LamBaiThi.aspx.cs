using CPanel.Commons;
using CPanel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CPanel.Modules.UngVien
{
    public partial class LamBaiThi : System.Web.UI.Page
    {
        private ATCLEntities entities = new ATCLEntities();
        public double seconds;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty((string)Session[ATCL_Consts.SESSION_OBJECT_ID]))
            {
                txtObjectID.Text = Session[ATCL_Consts.SESSION_OBJECT_ID].ToString();
                Session[ATCL_Consts.SESSION_OBJECT_ID] = null;
            }

            int intBaiThiUngVienID = Convert.ToInt32(txtObjectID.Text);
            int intBaiThiID = Convert.ToInt32(entities.BAI_THI_UNG_VIEN.Where(x => x.ID == intBaiThiUngVienID).Select(x => x.ID_BAI_THI).FirstOrDefault());
            if (!IsPostBack)
            {
                int BaiThiUVID = Convert.ToInt32(txtObjectID.Text);
                int BaiThiID = (int)entities.BAI_THI_UNG_VIEN.Where(x => x.ID == BaiThiUVID).Select(x => x.ID_BAI_THI).FirstOrDefault();
                BAI_THI thoigian = entities.BAI_THI.Where(x => x.ID == BaiThiID).FirstOrDefault();
                //lblTime.Text = thoigian.THOI_GIAN.ToString() +  " phút";

                double tg = Convert.ToDouble(thoigian.THOI_GIAN);
                TimeSpan time = TimeSpan.FromSeconds(Convert.ToInt32(LabelTimer.Text) * 60 * tg);
                string str = time.ToString(@"hh\:mm\:ss");
                LabelTimer.Text = str;

                string strTraLoiCSS = "traLoiCss_";
                string strTraLoi_TextBoxs = "";

                List<DAP_AN> lstAnswer;
                var lstLoad = entities.BAI_THI_CAU_HOI.Where(x => x.ID_BAI_THI == intBaiThiID).ToList();

                if ((lstLoad != null) && (lstLoad.Count > 0))
                {
                    int i = 0;
                    int SoCau = 1;

                    //Lay danh sach cauhoi
                    foreach (var item in lstLoad)
                    {
                        ltQuestion.Text = ltQuestion.Text + "<div class='cau_hoi_css'>";
                        ltQuestion.Text = ltQuestion.Text + string.Format(@"
                                <p>Câu {0}: <b> {1}</p></b>  
                                ", SoCau, item.CAU_HOI.NOI_DUNG_CAU_HOI);


                        //Lay danh sach Dap an
                        lstAnswer = entities.CAU_HOI.Join(entities.DAP_AN, CH => CH.ID, DA => DA.ID_CAU_HOI, (CH, DA) => new { CH, DA }).Where(x => (x.CH.ID == x.DA.ID_CAU_HOI) && (x.DA.ID_CAU_HOI == item.ID_CAU_HOI)).Select(y => y.DA).ToList();
                        if ((lstAnswer != null) && (lstAnswer.Count > 0))
                        {
                            foreach (var item1 in lstAnswer)
                            {
                                ltQuestion.Text = ltQuestion.Text + string.Format(@"
                                <div class='dap_an_css'><p><input type='checkbox' name='cbAnswer' value='{0}|{1}|{2}'/>{3}</p></div>
                                        ", item.ID_BAI_THI, item1.ID_CAU_HOI, item1.ID, item1.NOI_DUNG_DAP_AN);//Format: value = ID_BAI_THI|ID_CAU_HOI|ID_DAP_AN
                            }
                        }
                        else
                        {
                           ltQuestion.Text = ltQuestion.Text + string.Format(@"
                           <div class='dap_an_TL_css'>
                                
                                <textarea name= '{0}{1}'style='width:100%;' rows='5'></textarea>
                                </div>", strTraLoiCSS, item.ID_CAU_HOI);
                            strTraLoi_TextBoxs = strTraLoi_TextBoxs == "" ? strTraLoiCSS + item.ID_CAU_HOI : (strTraLoi_TextBoxs + "|" + strTraLoiCSS + item.ID_CAU_HOI);
                        }
                        /*< p >< input name = '{0}{1}' type = 'text' aria - multiline = 'true' style = 'width:100%;height:90px;' /></ p >*/

                                   ltQuestion.Text = ltQuestion.Text + "</div>";//The dong "CAU HOI"
                        i++;
                        SoCau++;
                    }

                    ltQuestion.Text = ltQuestion.Text + String.Format("<div style='display:none'><input name = 'txtTraLoiTL' value='{0}' type = 'text' /></ div >", strTraLoi_TextBoxs);

                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan result = TimeSpan.FromSeconds(TimeSpan.Parse(LabelTimer.Text).TotalSeconds - 1);
            string fromTimeString = result.ToString(@"hh\:mm\:ss");
            LabelTimer.Text = fromTimeString;

            if (fromTimeString == "00:00:00")
            {
                NopBai();
            }
        }

        protected void NopBai()
        {
            updateKetQua();
            int intUngVienID = (int)Commons.CheckUserInfo.GetUserId();
            int BTUV = Convert.ToInt32(txtObjectID.Text);
            int intBaiThiID = (int)entities.BAI_THI_UNG_VIEN.Where(x => x.ID == BTUV).Select(x => x.ID_BAI_THI).FirstOrDefault();
            BAI_THI_UNG_VIEN objNgayHoanThanh = entities.BAI_THI_UNG_VIEN.Where(x => (x.ID_UNG_VIEN == intUngVienID) && (x.ID_BAI_THI == intBaiThiID)).FirstOrDefault();
            objNgayHoanThanh.NGAY_HOAN_THANH_BAI_THI = DateTime.Now;

            objNgayHoanThanh.TRANG_THAI_GUI_MAIL = "Chưa gửi";

            //Lấy số câu trắc nghiệm trả lời đúng
            var objSoCauDung = entities.UNG_VIEN_TRA_LOI.Where(x => (x.TT_KET_QUA == true) && (x.ID_BAI_THI == intBaiThiID) && (x.ID_UNG_VIEN == intUngVienID)).Count();

            //Lấy tổng số câu trắc nghiệm
            var objTongCauTNDe = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 1)).Sum(a => a.SO_LUONG_CAU_DE);
            var objTongCauTNTb = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 1)).Sum(b => b.SO_LUONG_CAU_TB);
            var objTongCauTNKho = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 1)).Sum(c => c.SO_LUONG_CAU_KHO);
            var sumCauTN = objTongCauTNDe + objTongCauTNTb + objTongCauTNKho;

            //Lấy tổng số câu tự luận
            var objTongCauTLDe = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 2)).Sum(a => a.SO_LUONG_CAU_DE);
            var objTongCauTLTb = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 2)).Sum(b => b.SO_LUONG_CAU_TB);
            var objTongCauTLKho = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 2)).Sum(c => c.SO_LUONG_CAU_KHO);
            var sumCauTL = objTongCauTLDe + objTongCauTLTb + objTongCauTLKho;

            objNgayHoanThanh.DIEM_TRAC_NGHIEM = objSoCauDung.ToString() + "/" + sumCauTN.ToString();
            objNgayHoanThanh.SO_CAU_TU_LUAN = sumCauTL;
            entities.SaveChanges();
            Response.Redirect(Commons.TitleConst.getTitleConst("UVReviewBaiThi.aspx"));
        }
        protected void btnNopBai_Click(object sender, EventArgs e)
        {
            updateKetQua();
            int intUngVienID = (int)Commons.CheckUserInfo.GetUserId();
            int BTUV = Convert.ToInt32(txtObjectID.Text);
            int intBaiThiID = (int)entities.BAI_THI_UNG_VIEN.Where(x => x.ID == BTUV).Select(x => x.ID_BAI_THI).FirstOrDefault();
            BAI_THI_UNG_VIEN objNgayHoanThanh = entities.BAI_THI_UNG_VIEN.Where(x => (x.ID_UNG_VIEN == intUngVienID) && (x.ID_BAI_THI == intBaiThiID)).FirstOrDefault();
            objNgayHoanThanh.NGAY_HOAN_THANH_BAI_THI = DateTime.Now;

            objNgayHoanThanh.TRANG_THAI_GUI_MAIL = "Chưa gửi";

            //Lấy số câu trắc nghiệm trả lời đúng
            var objSoCauDung = entities.UNG_VIEN_TRA_LOI.Where(x => (x.TT_KET_QUA == true) && (x.ID_BAI_THI == intBaiThiID) && (x.ID_UNG_VIEN == intUngVienID)).Count();

            //Lấy tổng số câu trắc nghiệm
            var objTongCauTNDe = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 1)).Sum(a => a.SO_LUONG_CAU_DE);
            var objTongCauTNTb = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 1)).Sum(b => b.SO_LUONG_CAU_TB);
            var objTongCauTNKho = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 1)).Sum(c => c.SO_LUONG_CAU_KHO);
            var sumCauTN = objTongCauTNDe + objTongCauTNTb + objTongCauTNKho;

            //Lấy tổng số câu tự luận
            var objTongCauTLDe = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 2)).Sum(a => a.SO_LUONG_CAU_DE);
            var objTongCauTLTb = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 2)).Sum(b => b.SO_LUONG_CAU_TB);
            var objTongCauTLKho = entities.CAU_HINH_BAI_THI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_LOAI_CAU_HOI == 2)).Sum(c => c.SO_LUONG_CAU_KHO);
            var sumCauTL = objTongCauTLDe + objTongCauTLTb + objTongCauTLKho;

            objNgayHoanThanh.DIEM_TRAC_NGHIEM = objSoCauDung.ToString() + "/" + sumCauTN.ToString();
            objNgayHoanThanh.SO_CAU_TU_LUAN = sumCauTL;
            entities.SaveChanges();
            Response.Redirect(Commons.TitleConst.getTitleConst("UVReviewBaiThi.aspx"));
        }

        private void updateTraLoiTuLuan()
        {
            int intCauHoiID;
            string strTraLoiTL = Request.Form["txtTraLoiTL"];
            if (!String.IsNullOrEmpty(strTraLoiTL))
            {
                string[] arrTraLoiTL = strTraLoiTL.Split('|');
                for (int i=0; i< arrTraLoiTL.Length; i++)
                {
                    //Lay ID cau hoi
                    string[] arrTraLoiID = arrTraLoiTL[i].Split('_');
                    intCauHoiID = Convert.ToInt32(arrTraLoiID[1]);

                    string strTraLoi = Request.Form[arrTraLoiTL[i]];
                    int intUngVienID = (int)Commons.CheckUserInfo.GetUserId();
                    int intBaiThiUngVienID = Convert.ToInt32(txtObjectID.Text);
                    int intBaiThiID = Convert.ToInt32(entities.BAI_THI_UNG_VIEN.Where(x => x.ID == intBaiThiUngVienID).Select(x => x.ID_BAI_THI).FirstOrDefault());
                    UNG_VIEN_TRA_LOI objUVTLTuLuan = new UNG_VIEN_TRA_LOI();
                    objUVTLTuLuan.ID_BAI_THI = intBaiThiID;
                    objUVTLTuLuan.ID_UNG_VIEN = intUngVienID;
                    objUVTLTuLuan.ID_CAU_HOI = intCauHoiID;
                    objUVTLTuLuan.NOI_DUNG_TRA_LOI = strTraLoi;
                    entities.UNG_VIEN_TRA_LOI.Add(objUVTLTuLuan);
                    entities.SaveChanges();
                }
            }
        }

        public void updateKetQua()
        {
            updateTraLoiTuLuan();

            List<UNG_VIEN_TRA_LOI> lstUVTL = new List<UNG_VIEN_TRA_LOI>();
            List<UNG_VIEN_TRA_LOI> lstUVTL_CH;
            UNG_VIEN_TRA_LOI objUVTL_1;
            int intUngVienID = (int)Commons.CheckUserInfo.GetUserId();
            string strDapAnID = "";
            int intCauHoiID = 0;
            int intBaiThiID = 0;
            if (!String.IsNullOrEmpty(txtCheckBoxValue.Text))
            {
                string[] arrCheckBoxValue = txtCheckBoxValue.Text.Split('*');
                string[] arrUVTL;

                List<int> lstCauHoiID = new List<int>();
                for (int i = 0; i < arrCheckBoxValue.Length; i++)
                {
                    arrUVTL = arrCheckBoxValue[i].Split('|');
                    intCauHoiID = Convert.ToInt32(arrUVTL[1]);

                    UNG_VIEN_TRA_LOI objUVTL = new UNG_VIEN_TRA_LOI();
                    objUVTL.ID_BAI_THI = Convert.ToInt32(arrUVTL[0]);
                    objUVTL.ID_CAU_HOI = intCauHoiID;
                    objUVTL.ID_DAP_AN = arrUVTL[2].ToString();
                    lstUVTL.Add(objUVTL);

                    //Lay danh sach ID cau hoi
                    if (!lstCauHoiID.Contains(intCauHoiID))
                    {
                        lstCauHoiID.Add(intCauHoiID);
                    }

                }

                foreach (var m in lstCauHoiID)
                {
                    lstUVTL_CH = lstUVTL.Where(x => x.ID_CAU_HOI == m).ToList();
                    if ((lstUVTL_CH != null) && (lstUVTL_CH.Count > 0))
                    {
                        strDapAnID = "";
                        foreach (var item in (lstUVTL_CH))
                        {
                            intCauHoiID = (int)item.ID_CAU_HOI;
                            intBaiThiID = (int)item.ID_BAI_THI;
                            strDapAnID = (String.IsNullOrEmpty(strDapAnID) ? item.ID_DAP_AN : strDapAnID + ',' + item.ID_DAP_AN);
                        }

                        //Update into DB
                        //Neu ban ghi ton tai
                        objUVTL_1 = entities.UNG_VIEN_TRA_LOI.Where(x => (x.ID_BAI_THI == intBaiThiID) && (x.ID_CAU_HOI == intCauHoiID) && (x.ID_UNG_VIEN == intUngVienID)).FirstOrDefault();
                        if (objUVTL_1 != null)
                        {
                            objUVTL_1.ID_DAP_AN = strDapAnID;
                        }
                        else
                        {
                            objUVTL_1 = new UNG_VIEN_TRA_LOI();
                            objUVTL_1.ID_BAI_THI = intBaiThiID;
                            objUVTL_1.ID_CAU_HOI = intCauHoiID;
                            objUVTL_1.ID_DAP_AN = strDapAnID;
                            objUVTL_1.ID_UNG_VIEN = intUngVienID;
                            entities.UNG_VIEN_TRA_LOI.Add(objUVTL_1);
                        }

                        objUVTL_1.TT_KET_QUA = true;

                        //Kiem tra ket qua
                        var lstDapAn = entities.DAP_AN.Where(x => (x.ID_CAU_HOI == intCauHoiID)).ToList();
                        if ((lstDapAn != null) && (lstDapAn.Count > 0))
                        {
                            foreach (var item in lstDapAn)
                            {
                                if (item.TRANG_THAI == true)
                                {
                                    if (!strDapAnID.Contains(item.ID.ToString()))
                                        objUVTL_1.TT_KET_QUA = false;
                                }
                                else if (item.TRANG_THAI == false)
                                {
                                    if (strDapAnID.Contains(item.ID.ToString()))
                                        objUVTL_1.TT_KET_QUA = false;
                                }
                            }
                        }
                        
                    }
                    entities.SaveChanges();
                }
            }
        }
    }
}