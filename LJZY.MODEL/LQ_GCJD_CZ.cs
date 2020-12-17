using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_GCJD_CZ
    {
        public LQ_GCJD_CZ()
        {
            _CZKSSJ = DateTime.Now;
            _CZJSSJ = DateTime.Now;
        }

        private string _ID;
        private string _CZMC;
        private DateTime? _CZKSSJ;
        private DateTime? _CZJSSJ;
        private decimal _CZKSJS;
        private decimal _CZJSJS;
        private DateTime? _TJSJ;
        private string _ZJH;
        private string _CZKSSJ_Str;
        private string _CZJSSJ_Str;
        private string _TJSJ_Str;

        /// <summary>
        /// 添加时间
        /// </summary>
        [DisplayName ( "TJSJ" )]
        public DateTime? TJSJ
        {
            get
            {
                return _TJSJ;
            }

            set
            {
                _TJSJ = value;
            }
        }

        /// <summary>
        /// 侧钻结束井深
        /// </summary>
        [DisplayName ( "CZJSJS" )]
        public decimal CZJSJS
        {
            get
            {
                return _CZJSJS;
            }

            set
            {
                _CZJSJS = value;
            }
        }

        /// <summary>
        /// 侧钻开始井深
        /// </summary>
        [DisplayName ( "CZKSJS" )]
        public decimal CZKSJS
        {
            get
            {
                return _CZKSJS;
            }

            set
            {
                _CZKSJS = value;
            }
        }

        /// <summary>
        /// 侧钻结束时间
        /// </summary>
        [DisplayName ( "CZJSSJ" )]
        public DateTime? CZJSSJ
        {
            get
            {
                return _CZJSSJ;
            }

            set
            {
                _CZJSSJ = value;
            }
        }

        /// <summary>
        /// 侧钻开始时间
        /// </summary>
        [DisplayName ( "CZKSSJ" )]
        public DateTime? CZKSSJ
        {
            get
            {
                return _CZKSSJ;
            }

            set
            {
                _CZKSSJ = value;
            }
        }

        /// <summary>
        /// 侧钻名称
        /// </summary>
        [DisplayName ( "CZMC" )]
        public string CZMC
        {
            get
            {
                return _CZMC;
            }

            set
            {
                _CZMC = value;
            }
        }

        /// <summary>
        /// ID
        /// </summary>
        [DisplayName ( "ID" )]
        public string ID
        {
            get
            {
                return _ID;
            }

            set
            {
                _ID = value;
            }
        }
        /// <summary>
        /// 井号
        /// </summary>
        [DisplayName ( "ZJH" )]
        public string ZJH
        {
            get
            {
                return _ZJH;
            }

            set
            {
                _ZJH = value;
            }
        }

        public string CZKSSJ_Str
        {
            get
            {
                return _CZKSSJ_Str;
            }

            set
            {
                _CZKSSJ_Str = value;
            }
        }

        public string CZJSSJ_Str
        {
            get
            {
                return _CZJSSJ_Str;
            }

            set
            {
                _CZJSSJ_Str = value;
            }
        }

        public string TJSJ_Str
        {
            get
            {
                return _TJSJ_Str;
            }

            set
            {
                _TJSJ_Str = value;
            }
        }
    }
}
