using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_GCJD_ZT
    {
        public LQ_GCJD_ZT()
        {
            _ZTKSSJ = DateTime.Now;
            _ZTJSSJ = DateTime.Now;
        }

        private string _ID;
        private string _ZTMC;
        private DateTime? _ZTKSSJ;
        private DateTime? _ZTJSSJ;          
        private DateTime? _TJSJ;
        private string _ZJH;

        private string _ZTKSSJ_Str;
        private string _ZTJSSJ_Str;
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
        /// 中停结束时间
        /// </summary>
        [DisplayName ( "ZTJSSJ" )]
        public DateTime? ZTJSSJ
        {
            get
            {
                return _ZTJSSJ;
            }

            set
            {
                _ZTJSSJ = value;
            }
        }

        /// <summary>
        /// 中停开始时间
        /// </summary>
        [DisplayName ( "ZTKSSJ" )]
        public DateTime? ZTKSSJ
        {
            get
            {
                return _ZTKSSJ;
            }

            set
            {
                _ZTKSSJ = value;
            }
        }

        /// <summary>
        /// 中停名称
        /// </summary>
        [DisplayName ( "ZTMC" )]
        public string ZTMC
        {
            get
            {
                return _ZTMC;
            }

            set
            {
                _ZTMC = value;
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

        public string ZTKSSJ_Str
        {
            get
            {
                return _ZTKSSJ_Str;
            }

            set
            {
                _ZTKSSJ_Str = value;
            }
        }

        public string ZTJSSJ_Str
        {
            get
            {
                return _ZTJSSJ_Str;
            }

            set
            {
                _ZTJSSJ_Str = value;
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
