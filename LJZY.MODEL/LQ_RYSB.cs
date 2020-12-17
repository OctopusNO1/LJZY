using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_RYSB
    {
        public LQ_RYSB()
        {
            _SBSZD = "";
        }
        private int _TROW;
        /// <summary>
        /// 排序序号
        /// </summary>
        [DisplayName ( "TROW" )]
        public int TROW
        {
            get { return _TROW; }
            set { _TROW = value; }
        }

        private string _DWZBH;
        /// <summary>
        /// 队伍自编号
        /// </summary>
        [DisplayName ( "DWZBH" )]
        public string DWZBH
        {
            get { return _DWZBH; }
            set { _DWZBH = value; }
        }
        private string _LJDH;
        /// <summary>
        /// 录井队号
        /// </summary>
        [DisplayName ( "LJDH" )]
        public string LJDH
        {
            get { return _LJDH; }
            set { _LJDH = value; }
        }

        private string _LJYQXH;
        /// <summary>
        /// 设备型号
        /// </summary>
        [DisplayName ( "LJYQXH" )]
        public string LJYQXH
        {
            get { return _LJYQXH; }
            set { _LJYQXH = value; }
        }

        private string _JH;
        /// <summary>
        /// 井号
        /// </summary>
        [DisplayName ( "JH" )]
        public string JH
        {
            get { return _JH; }
            set { _JH = value; }
        }

        private string _JX;
        /// <summary>
        /// 井型
        /// </summary>
        [DisplayName ( "JX" )]
        public string JX
        {
            get { return _JX; }
            set { _JX = value; }
        }


        private List<LQ_RYDT> _dzsList;
        /// <summary>
        /// 地质师集合
        /// </summary>
        [DisplayName ( "DzsList" )]
        public List<LQ_RYDT> DzsList
        {
            get { return _dzsList; }

            set { _dzsList = value; }
        }

        private string _dzs;
        /// <summary>
        /// 地质师
        /// </summary>
        [DisplayName("Dzs")]
        public string Dzs
        {
            get { return _dzs; }

            set { _dzs = value; }
        }

        /// <summary>
        /// 地质助理集合
        /// </summary>
        [DisplayName ( "DzzlList" )]
        public List<LQ_RYDT> DzzlList
        {
            get
            {
                return _dzzlList;
            }

            set
            {
                _dzzlList = value;
            }
        }

        /// <summary>
        /// 地质助理
        /// </summary>
        [DisplayName("Dzzl")]
        public string Dzzl
        {
            get
            {
                return _dzzl;
            }

            set
            {
                _dzzl = value;
            }
        }

        /// <summary>
        /// 地质工集合
        /// </summary>
        [DisplayName ( "DzgList" )]
        public List<LQ_RYDT> DzgList
        {
            get
            {
                return _dzgList;
            }

            set
            {
                _dzgList = value;
            }
        }

        /// <summary>
        /// 地质工1
        /// </summary>
        [DisplayName("Dzg1")]
        public string Dzg1
        {
            get
            {
                return _dzg1;
            }

            set
            {
                _dzg1 = value;
            }
        }

        /// <summary>
        /// 地质工2
        /// </summary>
        [DisplayName("Dzg2")]
        public string Dzg2
        {
            get
            {
                return _dzg2;
            }

            set
            {
                _dzg2 = value;
            }
        }

        /// <summary>
        /// 地质工3
        /// </summary>
        [DisplayName("Dzg3")]
        public string Dzg3
        {
            get
            {
                return _dzg3;
            }

            set
            {
                _dzg3 = value;
            }
        }


        /// <summary>
        /// 地质工4
        /// </summary>
        [DisplayName("Dzg4")]
        public string Dzg4
        {
            get
            {
                return _dzg4;
            }

            set
            {
                _dzg4 = value;
            }
        }

        /// <summary>
        /// 操作员集合
        /// </summary>
        [DisplayName ( "CzyList" )]
        public List<LQ_RYDT> CzyList
        {
            get
            {
                return _czyList;
            }

            set
            {
                _czyList = value;
            }
        }

        /// <summary>
        /// 操作员1
        /// </summary>
        [DisplayName("Czy1")]
        public string Czy1
        {
            get
            {
                return _czy1;
            }

            set
            {
                _czy1 = value;
            }
        }

        /// <summary>
        /// 操作员2
        /// </summary>
        [DisplayName("Czy2")]
        public string Czy2
        {
            get
            {
                return _czy2;
            }

            set
            {
                _czy2 = value;
            }
        }

        /// <summary>
        /// 操作员3
        /// </summary>
        [DisplayName("Czy3")]
        public string Czy3
        {
            get
            {
                return _czy3;
            }

            set
            {
                _czy3 = value;
            }
        }

        /// <summary>
        /// 待录井
        /// </summary>
        [DisplayName ( "HXJW" )]
        public string HXJW
        {
            get
            {
                return _HXJW;
            }

            set
            {
                _HXJW = value;
            }
        }
        /// <summary>
        /// 设备状态
        /// </summary>
        [DisplayName ( "DQZT" )]
        public string DQZT
        {
            get
            {
                return _DQZT;
            }

            set
            {
                _DQZT = value;
            }
        }
        /// <summary>
        /// 施工队号
        /// </summary>
        [DisplayName ( "SGDH" )]
        public string SGDH
        {
            get
            {
                return _SGDH;
            }

            set
            {
                _SGDH = value;
            }
        }

        /// <summary>
        /// 工程师集合
        /// </summary>
        [DisplayName ( "GcsList" )]
        public List<LQ_RYDT> GcsList
        {
            get
            {
                return _gcsList;
            }

            set
            {
                _gcsList = value;
            }
        }

        /// <summary>
        /// 工程师
        /// </summary>
        [DisplayName("Gcs")]
        public string Gcs
        {
            get
            {
                return _gcs;
            }

            set
            {
                _gcs = value;
            }
        }

        /// <summary>
        /// 地质房列表
        /// </summary>
        [DisplayName ( "DzfList" )]
        public List<LQ_FWFP> DzfList
        {
            get
            {
                return _dzfList;
            }

            set
            {
                _dzfList = value;
            }
        }


        /// <summary>
        /// 地质房
        /// </summary>
        [DisplayName("Dzf")]
        public string Dzf
        {
            get
            {
                return _dzf;
            }

            set
            {
                _dzf = value;
            }
        }
        /// <summary>
        /// 住房列表
        /// </summary>
        [DisplayName ( "ZfList" )]
        public List<LQ_FWFP> ZfList
        {
            get
            {
                return _zfList;
            }

            set
            {
                _zfList = value;
            }
        }

        /// <summary>
        /// 住房1
        /// </summary>
        [DisplayName("Zf1")]
        public string Zf1
        {
            get
            {
                return _zf1;
            }

            set
            {
                _zf1 = value;
            }
        }

        /// <summary>
        /// 住房2
        /// </summary>
        [DisplayName("Zf2")]
        public string Zf2
        {
            get
            {
                return _zf2;
            }

            set
            {
                _zf2 = value;
            }
        }

        /// <summary>
        /// 设备所在地
        /// </summary>
        [DisplayName("SBSZD")]
        public string SBSZD
        {
            get
            {
                return _SBSZD;
            }

            set
            {
                _SBSZD = value;
            }
        }

        ///// <summary>
        ///// 设备所在地(用井号代替)
        ///// </summary>
        //[DisplayName ( "SBSZD" )]
        //public string SBSZD
        //{
        //    get
        //    {
        //        return _SBSZD;
        //    }

        //    set
        //    {
        //        _SBSZD = value;
        //    }
        //}

        private string _SGDH;
        private string _DQZT;
        private string _HXJW;
        private string _SBSZD;
        private List<LQ_RYDT> _dzzlList;
        private string _dzzl;
        private List<LQ_RYDT> _czyList;
        private string _czy1;
        private string _czy2;
        private string _czy3;
        private List<LQ_RYDT> _dzgList;
        private string _dzg1;
        private string _dzg2;
        private string _dzg3;
        private string _dzg4;
        private List<LQ_RYDT> _gcsList;
        private string _gcs;
        private List<LQ_FWFP> _zfList;
        private string _zf1;
        private string _zf2;
        private List<LQ_FWFP> _dzfList;
        private string _dzf;

        //private string _SBSZD;
    }
}
