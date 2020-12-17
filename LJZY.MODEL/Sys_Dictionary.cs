using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LJZY.MODEL
{
	public class Sys_Dictionary
	{
		/// <summary>
		/// 默认构造方法
		/// </summary>
		public Sys_Dictionary()
		{

		}

		private string _DICTIONARYID;
		/// <summary>
		/// ID
		/// </summary>
		[DisplayName("DICTIONARYID")]
		public string DICTIONARYID
		{
			get { return _DICTIONARYID; }
			set { _DICTIONARYID = value; }
		}
		private string _CODE;
		/// <summary>
		/// 编号
		/// </summary>
		[DisplayName("CODE")]
		public string CODE
		{
			get { return _CODE; }
			set { _CODE = value; }
		}
		private string _NAME;
		/// <summary>
		/// 名字
		/// </summary>
		[DisplayName("NAME")]
		public string NAME
		{
			get { return _NAME; }
			set { _NAME = value; }
		}
		private string _PTYPE;
		/// <summary>
		/// 父类
		/// </summary>
		[DisplayName("PTYPE")]
		public string PTYPE
		{
			get { return _PTYPE; }
			set { _PTYPE = value; }
		}

		private string _TYPE;
		/// <summary>
		/// 类型
		/// </summary>
		[DisplayName("TYPE")]
		public string TYPE
		{
			get { return _TYPE; }
			set { _TYPE = value; }
		}

		private string _ADDEMP;
		/// <summary>
		/// 添加人
		/// </summary>
		[DisplayName("ADDEMP")]
		public string ADDEMP
		{
			get { return _ADDEMP; }
			set { _ADDEMP = value; }
		}


		private DateTime _ADDTIME;
		/// <summary>
		/// 添加时间
		/// </summary>
		[DisplayName("ADDTIME")]
		public DateTime ADDTIME
		{
			get { return _ADDTIME; }
			set { _ADDTIME = value; }
		}
	}
}
