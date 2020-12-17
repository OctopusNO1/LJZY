using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LJZY.MODEL
{
	public class LQ_EJML
	{
		/// <summary>
		/// 默认构造方法
		/// </summary>
		public LQ_EJML()
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
		private string _MC;
		/// <summary>
		/// 名字
		/// </summary>
		[DisplayName("MC")]
		public string MC
		{
			get { return _MC; }
			set { _MC = value; }
		}
		private string _BM;
		/// <summary>
		/// 编码
		/// </summary>
		[DisplayName("BM")]
		public string BM
		{
			get { return _BM; }
			set { _BM = value; }
		}

		private string _PID;
		/// <summary>
		/// 父ID
		/// </summary>
		[DisplayName("PID")]
		public string PID
		{
			get { return _PID; }
			set { _PID = value; }
		}

		private string _TJR;
		/// <summary>
		///添加人
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

		private List<LQ_EJML> _itermList;
		/// <summary>
		/// 子集合
		/// </summary>
		[DisplayName("ItermList")]
		public List<LQ_EJML> ItermList
		{
			get { return _itermList; }
			set { _itermList = value; }
		}
	}

}
