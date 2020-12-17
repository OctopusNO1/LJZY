using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_RYDT
    {
        private string _RYBH;
        private string _XM;
        private string _GW;
        private string _LXDH;
        private string _JH;
        private List<LQ_SJRZ> _sjrzList;

        /// <summary>
        /// 联系电话
        /// </summary>
        [DisplayName ( "LXDH" )]
        public string LXDH
        {
            get
            {
                return _LXDH;
            }

            set
            {
                _LXDH = value;
            }
        }
        /// <summary>
        /// 岗位
        /// </summary>
        [DisplayName ( "GW" )]
        public string GW
        {
            get
            {
                return _GW;
            }

            set
            {
                _GW = value;
            }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName ( "XM" )]
        public string XM
        {
            get
            {
                return _XM;
            }

            set
            {
                _XM = value;
            }
        }
        /// <summary>
        /// 人员编号
        /// </summary>
        [DisplayName ( "RYBH" )]
        public string RYBH
        {
            get
            {
                return _RYBH;
            }

            set
            {
                _RYBH = value;
            }
        }
        /// <summary>
        /// 井号
        /// </summary>
        [DisplayName ( "JH" )]
        public string JH
        {
            get
            {
                return _JH;
            }

            set
            {
                _JH = value;
            }
        }

        /// <summary>
        /// 上井日志列表
        /// </summary>
        [DisplayName ( "SjrzList" )]
        public List<LQ_SJRZ> SjrzList
        {
            get
            {
                return _sjrzList;
            }

            set
            {
                _sjrzList = value;
            }
        }
    }
}
