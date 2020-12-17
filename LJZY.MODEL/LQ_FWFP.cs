using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
	public class LQ_FWFP
	{
		public LQ_FWFP()
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

		private string _FWID;
		/// <summary>
		/// 主键Id
		/// </summary>
		[DisplayName("FWID")]
		public string FWID
		{
			get { return _FWID; }
			set { _FWID = value; }
		}
		private string _JH;
		/// <summary>
		/// 井号
		/// </summaryJH
		[DisplayName( "JH" )]
		public string JH
        {
			get { return _JH; }
			set { _JH = value; }
		}
		private string _CCBH;
		/// <summary>
		/// 编号
		/// </summary>
		[DisplayName("CCBH")]
		public string CCBH
		{
			get { return _CCBH; }
			set { _CCBH = value; }
		}

		private string _FL;
		/// <summary>
		/// 房屋分类
		/// </summary>
		[DisplayName("FL")]
		public string FL
		{
			get { return _FL; }
			set { _FL = value; }
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
		private DateTime _TJRQ;
		/// <summary>
		/// 添加时间
		/// </summary>
		[DisplayName("TJRQ")]
		public DateTime TJRQ
		{
			get { return _TJRQ; }
			set { _TJRQ = value; }
		}

		private string _GGXH;
		/// <summary>
		/// 规格型号
		/// </summary>
		[DisplayName("GGXH")]
		public string GGXH
		{
			get { return _GGXH; }
			set { _GGXH = value; }
		}

		private string _SBZK;
		/// <summary>
		/// 房屋状态
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
