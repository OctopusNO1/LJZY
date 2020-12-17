using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
	public class LQ_FILE
	{
		public LQ_FILE()
		{

		}

		private string _ID;
		/// <summary>
		/// 主键
		/// </summary>
		[DisplayName("ID")]
		public string ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private string _ZJH;
		/// <summary>
		/// 井号
		/// </summary>
		[DisplayName("ZJH")]
		public string ZJH
		{
			get { return _ZJH; }
			set { _ZJH = value; }
		}

		private string _REPORT_TYPE;
		/// <summary>
		/// 井别
		/// </summary>
		[DisplayName("REPORT_TYPE")]
		public string REPORT_TYPE
        {
			get { return _REPORT_TYPE; }
			set { _REPORT_TYPE = value; }
		}

		private string _JX;
		/// <summary>
		/// 井型
		/// </summary>
		[DisplayName("JX")]
		public string JX
		{
			get { return _JX; }
			set { _JX = value; }
		}

		private string _ND;
		/// <summary>
		/// 年度
		/// </summary>
		[DisplayName("ND")]
		public string ND
		{
			get { return _ND; }
			set { _ND = value; }
		}

		private string _TYPE;
		/// <summary>
		/// 文件类型
		/// </summary>
		[DisplayName("TYPE")]
		public string TYPE
		{
			get { return _TYPE; }
			set { _TYPE = value; }
		}

		private string _FILENAME;
		[DisplayName("FILENAME")]
		public string FILENAME
		{
			get { return _FILENAME; }
			set { _FILENAME = value; }
		}

		private string _FILEURL;
		/// <summary>
		/// 文件地址
		/// </summary>
		[DisplayName("FILEURL")]
		public string FILEURL
		{
			get { return _FILEURL; }
			set { _FILEURL = value; }
		}

		private string _PDFURL;
		/// <summary>
		/// PDF文件地址
		/// </summary>
		[DisplayName("PDFURL")]
		public string PDFURL
		{
			get { return _PDFURL; }
			set { _PDFURL = value; }
		}

		private DateTime _UPLOADTIME;
		/// <summary>
		/// 上传时间
		/// </summary>
		[DisplayName("UPLOADTIME")]
		public DateTime UPLOADTIME
		{
			get { return _UPLOADTIME; }
			set { _UPLOADTIME = value; }
		}

		private string _UPLOADEMP;
		/// <summary>
		/// 上传人
		/// </summary>
		[DisplayName("UPLOADEMP")]
		public string UPLOADEMP
		{
			get { return _UPLOADEMP; }
			set { _UPLOADEMP = value; }
		}
	}
}
