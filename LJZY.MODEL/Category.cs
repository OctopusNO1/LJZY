using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
	public class Category
	{
		public Category() { }

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


	}
}
