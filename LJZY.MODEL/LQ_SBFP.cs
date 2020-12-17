using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
	public class LQ_SBFP
	{
		public LQ_SBFP()
		{

		}
		private int _TROW;
		/// <summary>
		/// 排序号
		/// </summary>
		[DisplayName("TROW")]
		public int TROW
		{
			get { return _TROW; }
			set { _TROW = value; }
		}

		private string _ID;
		/// <summary>
		/// 主键Id
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

        private string _JH;
        /// <summary>
        /// 井筒号
        /// </summary>
        [DisplayName ( "JH" )]
        public string JH
        {
            get { return _JH; }
            set { _JH = value; }
        }
        private string _SBID;
		/// <summary>
		/// 设备ID
		/// </summary>
		[DisplayName("SBID")]
		public string SBID
		{
			get { return _SBID; }
			set { _SBID = value; }
		}

		private string _SBMC;
		/// <summary>
		/// 设备名称
		/// </summary>
		[DisplayName("SBMC")]
		public string SBMC
		{
			get { return _SBMC; }
			set { _SBMC = value; }
		}

		private string _SBFL;
		/// <summary>
		/// 设备分类
		/// </summary>
		[DisplayName("SBFL")]
		public string SBFL
		{
			get { return _SBFL; }
			set { _SBFL = value; }
		}
		private string _TJR;
		/// <summary>
		/// 添加人
		/// </summary>
		[DisplayName("TJR")]
		public string TJR
		{
			get { return _TJR; }
			set { _TJR = value; }
		}
		private DateTime _TJSJ;
		/// <summary>
		/// 添加时间
		/// </summary>
		[DisplayName("TJSJ")]
		public DateTime TJSJ
		{
			get { return _TJSJ; }
			set { _TJSJ = value; }
		}

		private string _CCBH;
		/// <summary>
		/// 规格型号
		/// </summary>
		[DisplayName("CCBH")]
		public string CCBH
		{
			get { return _CCBH; }
			set { _CCBH = value; }
		}

		private string _SBZK;
		/// <summary>
		/// 规格状态
		/// </summary>
		[DisplayName("SBZK")]
		public string SBZK
		{
			get { return _SBZK; }
			set { _SBZK = value; }
		}

		//private string _SZWZ;
		///// <summary>
		///// 所在位置
		///// </summary>
		//[DisplayName("SZWZ")]
		//public string SZWZ
		//{
		//	get { return _SZWZ; }
		//	set { _SZWZ = value; }
		//}

		private string _BZ;
		/// <summary>
		/// 备注
		/// </summary>
		[DisplayName("BZ")]
		public string BZ
		{
			get { return _BZ; }
			set { _BZ = value; }
		}
	}
}
