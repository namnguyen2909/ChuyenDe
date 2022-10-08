using System;
using System.Linq;
using CPanel.Models;
using System.Configuration;
using CPanel.Commons;
namespace CPanel.Models.Views
{
	public class TBL_HOP_DA_VIEW : TBL_HOP_DA
	{

		private string _TEN_HE_THONG;
		private string _STR_KIEU_HOP;
		private string _STR_HINH_THUC_HOP;
		private string _STR_NGAY_HOP;
		private string _STR_GIO_HOP;
		private string _STR_KET_QUA_HOP;

		ATCLEntities entities = new ATCLEntities();
		string strMaDanhMuc = ConfigurationManager.AppSettings["MA_DM_KET_QUA_CONG_VIEC"];

		public string STR_NGAY_HOP
		{
			get
			{
				if (NGAY_HOP != null)
				{
					return ((DateTime)NGAY_HOP).ToString(Commons.DateTimeType.DATE_FORMAT_DD_MM_YYYY);
				}
				else
				{
					return null;
				}

			}
			set
			{
				_STR_NGAY_HOP = value;
			}
		}
		public string STR_GIO_HOP
		{
			get
			{
				if (GIO_BAT_DAU != null)
				{
					return ((TimeSpan)GIO_BAT_DAU).ToString(Commons.DateTimeType.TIME_FORMAT_HH_MM);
				}
				else
				{
					return null;
				}

			}
			set
			{
				_STR_GIO_HOP = value;
			}
		}

		public string TEN_HE_THONG
		{
			get
			{
				TBL_HE_THONG obj = entities.TBL_HE_THONG.FirstOrDefault(x => x.ID == ID_HE_THONG);
				if (obj != null)
				{
					return obj.TEN;
				}
				else
				{
					return null;
				}

			}
			set
			{
				_TEN_HE_THONG = value;
			}
		}

		public string STR_KIEU_HOP
		{
			get
			{
				TBL_DANH_MUC obj = entities.TBL_DANH_MUC.FirstOrDefault(x => x.ID == ID_KIEU_HOP);
				if (obj != null)
				{
					return obj.TEN;
				}
				else
				{
					return null;
				}

			}
			set
			{
				_STR_KIEU_HOP = value;
			}
		}

		public string STR_HINH_THUC_HOP
		{
			get
			{
				TBL_DANH_MUC obj = entities.TBL_DANH_MUC.FirstOrDefault(x => x.ID == ID_HINH_THUC_HOP);
				if (obj != null)
				{
					return obj.TEN;
				}
				else
				{
					return null;
				}

			}
			set
			{
				_STR_HINH_THUC_HOP = value;
			}
		}
		public string STR_KET_QUA_HOP
		{
			get
			{
				if (string.IsNullOrWhiteSpace(URL))
				{
					return string.Format("<a href=\"{0}\">{1}</a>",URL, Commons.TitleConst.getTitleConst("KET_QUA_HOP"));
				}
				else
				{
					return null;
				}

			}
			set
			{
				STR_KET_QUA_HOP = value;
			}
		}
	}
}