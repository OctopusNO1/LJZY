using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
	public class LQ_RYFP
	{
		public LQ_RYFP()
		{
            XM = "";
            LXDH = "";
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
		private string _JH;
		/// <summary>
		/// 井号
		/// </summary>
		[DisplayName("JH")]
		public string JH
		{
			get { return _JH; }
			set { _JH = value; }
		}
		private string _RYBH;
		/// <summary>
		/// 人员编号
		/// </summary>
		[DisplayName("RYBH")]
		public string RYBH
		{
			get { return _RYBH; }
			set { _RYBH = value; }
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

		private string _XM;
		/// <summary>
		/// 姓名
		/// </summary>
		[DisplayName("XM")]
		public string XM
		{
			get { return _XM; }
			set { _XM = value; }
		}

        private string _LXDH;
        /// <summary>
        /// 联系电话
        /// </summary>
        [DisplayName ( "LXDH" )]
        public string LXDH
        {
            get { return _LXDH; }
            set { _LXDH = value; }
        }
    }
}
