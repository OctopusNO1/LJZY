using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_RYSBCount
    {
        public LQ_RYSBCount()
        { }
        private int _DWZBHCount;
        private int _LJDHCount;
        private int _LJYQXHCount;
        private int _ZJHCount;
        private int _SGDHCount;
        private int _DQZTCount;
        private int _HXJWCount;
        private int _DzsListCount;
        private int _DzzlListCount;
        private int _DzgListCount;
        private int _CzyListCount;
        private int _GcsListCount;
        private int _DzfListCount;
        private int _ZfListCount;

        /// <summary>
        /// 住房统计
        /// </summary>
        [DisplayName ( "ZfListCount" )]
        public int ZfListCount
        {
            get
            {
                return _ZfListCount;
            }

            set
            {
                _ZfListCount =  value ;
            }
        }

        /// <summary>
        /// 地质房统计
        /// </summary>
        [DisplayName ( "DzfListCount" )]
        public int DzfListCount
        {
            get
            {
                return _DzfListCount;
            }

            set
            {
                _DzfListCount =  value ;
            }
        }

        /// <summary>
        /// 工程师统计
        /// </summary>
        [DisplayName ( "GcsListCount" )]
        public int GcsListCount
        {
            get
            {
                return _GcsListCount;
            }

            set
            {
                _GcsListCount =  value ;
            }
        }

        /// <summary>
        /// 操作员统计
        /// </summary>
        [DisplayName ( "CzyListCount" )]
        public int CzyListCount
        {
            get
            {
                return _CzyListCount;
            }

            set
            {
                _CzyListCount =  value ;
            }
        }

        /// <summary>
        /// 地质工统计
        /// </summary>
        [DisplayName ( "DzgListCount" )]
        public int DzgListCount
        {
            get
            {
                return _DzgListCount;
            }

            set
            {
                _DzgListCount =  value ;
            }
        }

        /// <summary>
        /// 地质助理统计
        /// </summary>
        [DisplayName ( "DzzlListCount" )]
        public int DzzlListCount
        {
            get
            {
                return _DzzlListCount;
            }

            set
            {
                _DzzlListCount =  value ;
            }
        }

        /// <summary>
        /// 地质师统计
        /// </summary>
        [DisplayName ( "DzsListCount" )]
        public int DzsListCount
        {
            get
            {
                return _DzsListCount;
            }

            set
            {
                _DzsListCount =  value ;
            }
        }

        /// <summary>
        /// 待录井统计
        /// </summary>
        [DisplayName ( "HXJWCount" )]
        public int HXJWCount
        {
            get
            {
                return _HXJWCount;
            }

            set
            {
                _HXJWCount =  value ;
            }
        }

        /// <summary>
        /// 设备状态统计
        /// </summary>
        [DisplayName ( "DQZTCount" )]
        public int DQZTCount
        {
            get
            {
                return _DQZTCount;
            }

            set
            {
                _DQZTCount =  value ;
            }
        }

        /// <summary>
        /// 钻井队统计
        /// </summary>
        [DisplayName ( "SGDHCount" )]
        public int SGDHCount
        {
            get
            {
                return _SGDHCount;
            }

            set
            {
                _SGDHCount =  value ;
            }
        }

        /// <summary>
        /// 正录井统计
        /// </summary>
        [DisplayName ( "ZJHCount" )]
        public int ZJHCount
        {
            get
            {
                return _ZJHCount;
            }

            set
            {
                _ZJHCount =  value ;
            }
        }

        /// <summary>
        /// 仪器型号统计
        /// </summary>
        [DisplayName ( "LJYQXHCount" )]
        public int LJYQXHCount
        {
            get
            {
                return _LJYQXHCount;
            }

            set
            {
                _LJYQXHCount =  value ;
            }
        }

        /// <summary>
        /// 录井队号统计
        /// </summary>
        [DisplayName ( "LJDHCount" )]
        public int LJDHCount
        {
            get
            {
                return _LJDHCount;
            }

            set
            {
                _LJDHCount =  value ;
            }
        }

        /// <summary>
        /// 队伍自编号统计
        /// </summary>
        [DisplayName ( "DWZBHCount" )]
        public int DWZBHCount
        {
            get
            {
                return _DWZBHCount;
            }

            set
            {
                _DWZBHCount =  value ;
            }
        }
    }
}
