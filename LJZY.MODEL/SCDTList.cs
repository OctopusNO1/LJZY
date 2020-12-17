using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
	public class SCDTList
	{
		public SCDTList()
		{
            _XQXMB = "";
        }
		private string _XQXMB;
		/// <summary>
		/// 区块
		/// </summary>
		[DisplayName( "XQXMB" )]
		public string XQXMB
		{
			get { return _XQXMB; }
			set { _XQXMB = value; }
		}

		private List<LQ_SCDT> _itemList;
		/// <summary>
		/// 所属区块集合
		/// </summary>
		[DisplayName("LJFGS")]
		public List<LQ_SCDT> ItemList
		{
			get { return _itemList; }
			set { _itemList = value; }
		}
	}
}
