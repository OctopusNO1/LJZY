using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_SB_WX
    {
        private string _ID;
        private string _DW;
        private string _SBMC;
        private string _GGXH;
        private string _SCCJ;
        private string _GB;
        private DateTime _CCRQ;
        private string _CCBH;
        private DateTime _TCRQ;
        private string _ZCBH;
        private string _ZBH;
        private string _SBSZWZ;
        private string _SBZK;
        private string _BZ;
        private int _TROW;
        private string _CCRQ_GD;
        private string _TCRQ_GD;
        public LQ_SB_WX()
        {
            _CCRQ = DateTime.Now;
            _TCRQ = DateTime.Now;    
        }
        /// <summary>
        /// 主键ID
        /// </summary>
        [DisplayName("ID")]
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
        /// 单位名称
        /// </summary>
        [DisplayName("DW")]
        public string DW
        {
            get
            {
                return _DW;
            }

            set
            {
                _DW = value;
            }
        }
        /// <summary>
        /// 设备名称
        /// </summary>
        [DisplayName("SBMC")]
        public string SBMC
        {
            get
            {
                return _SBMC;
            }

            set
            {
                _SBMC = value;
            }
        }
        /// <summary>
        /// 规格型号
        /// </summary>
        [DisplayName("GGXH")]
        public string GGXH
        {
            get
            {
                return _GGXH;
            }

            set
            {
                _GGXH = value;
            }
        }
        /// <summary>
        /// 生产厂家
        /// </summary>
        [DisplayName("SCCJ")]
        public string SCCJ
        {
            get
            {
                return _SCCJ;
            }

            set
            {
                _SCCJ = value;
            }
        }
        /// <summary>
        /// 国别
        /// </summary>
        [DisplayName("GB")]
        public string GB
        {
            get
            {
                return _GB;
            }

            set
            {
                _GB = value;
            }
        }
        /// <summary>
        /// 出厂日期
        /// </summary>
        [DisplayName("CCRQ")]
        public DateTime CCRQ
        {
            get
            {
                return _CCRQ;
            }

            set
            {
                _CCRQ = value;
            }
        }
        /// <summary>
        /// 出厂编号
        /// </summary>
        [DisplayName("CCBH")]
        public string CCBH
        {
            get
            {
                return _CCBH;
            }

            set
            {
                _CCBH = value;
            }
        }
        /// <summary>
        /// 投产日期
        /// </summary>
        [DisplayName("TCRQ")]
        public DateTime TCRQ
        {
            get
            {
                return _TCRQ;
            }

            set
            {
                _TCRQ = value;
            }
        }
        /// <summary>
        /// 自编号
        /// </summary>
        [DisplayName("ZBH")]
        public string ZBH
        {
            get
            {
                return _ZBH;
            }

            set
            {
                _ZBH = value;
            }
        }
        /// <summary>
        /// 设备所在位置
        /// </summary>
        [DisplayName("SBSZWZ")]
        public string SBSZWZ
        {
            get
            {
                return _SBSZWZ;
            }

            set
            {
                _SBSZWZ = value;
            }
        }
        /// <summary>
        /// 设备状况
        /// </summary>
        [DisplayName("SBZK")]
        public string SBZK
        {
            get
            {
                return _SBZK;
            }

            set
            {
                _SBZK = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName("BZ")]
        public string BZ
        {
            get
            {
                return _BZ;
            }

            set
            {
                _BZ = value;
            }
        }
        /// <summary>
        /// 翻页序号
        /// </summary>
        [DisplayName("TROW")]
        public int TROW
        {
            get
            {
                return _TROW;
            }

            set
            {
                _TROW = value;
            }
        }
        /// <summary>
        /// 出厂日期(显示在dategrid)
        /// </summary>
        [DisplayName("CCRQ_GD")]
        public string CCRQ_GD
        {
            get
            {
                return _CCRQ_GD;
            }

            set
            {
                _CCRQ_GD = value;
            }
        }
        /// <summary>
        /// 投产日期(显示在dategrid)
        /// </summary>
        [DisplayName("TCRQ_GD")]
        public string TCRQ_GD
        {
            get
            {
                return _TCRQ_GD;
            }

            set
            {
                _TCRQ_GD = value;
            }
        }
        /// <summary>
        /// 资产编号
        /// </summary>
        [DisplayName("ZCBH")]
        public string ZCBH
        {
            get
            {
                return _ZCBH;
            }

            set
            {
                _ZCBH = value;
            }
        }
    }
}
