using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
   public class LQ_SB_ZHY
    {
        private string _ID;
        private string _DW;
        private string _SBMC;
        private string _SSXD;
        private string _ZZ;
        private string _GGXH;
        private string _SCCJ;
        private string _GB;
        private DateTime _CCRQ;
        private string _CCBH;
        private DateTime _TCRQ;
        private string _SBXBH;
        private string _SBZBH;
        private string _SP;
        private Decimal _SPFXZQ;
        private string _SBZK;
        private string _SSDW;
        private string _SBSZWZ;
        private DateTime _DXSJ;
        private string _LHQTT;
        private string _LHQNJ;
        private string _QTBY;
        private string _BZ;
        private int _TROW;
        private string _CCRQ_GD;
        private string _TCRQ_GD;
        private string _DXSJ_GD;

        public LQ_SB_ZHY()
        {
            SPFXZQ = 0;
            _CCRQ = DateTime.Now;
            _TCRQ = DateTime.Now;
            _DXSJ = DateTime.Now;
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
        /// 所属小队
        /// </summary>
        [DisplayName("SSXD")] 
        public string SSXD
        {
            get
            {
                return _SSXD;
            }

            set
            {
                _SSXD = value;
            }
        }
        /// <summary>
        /// 资质
        /// </summary>
        [DisplayName("ZZ")]
        public string ZZ
        {
            get
            {
                return _ZZ;
            }

            set
            {
                _ZZ = value;
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
        /// 设备现编号
        /// </summary>
        [DisplayName("SBXBH")]
        public string SBXBH
        {
            get
            {
                return _SBXBH;
            }

            set
            {
                _SBXBH = value;
            }
        }
        /// <summary>
        /// 色谱
        /// </summary>
        [DisplayName("SP")]
        public string SP
        {
            get
            {
                return _SP;
            }

            set
            {
                _SP = value;
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
        /// 所属单位
        /// </summary>
        [DisplayName("SSDW")]
        public string SSDW
        {
            get
            {
                return _SSDW;
            }

            set
            {
                _SSDW = value;
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
        /// 大修时间
        /// </summary>
        [DisplayName("DXSJ")]
        public DateTime DXSJ
        {
            get
            {
                return _DXSJ;
            }

            set
            {
                _DXSJ = value;
            }
        }
        /// <summary>
        /// 硫化氢探头
        /// </summary>
        [DisplayName("LHQTT")]
        public string LHQTT
        {
            get
            {
                return _LHQTT;
            }

            set
            {
                _LHQTT = value;
            }
        }

        /// <summary>
        /// 硫化氢年检
        /// </summary>
        [DisplayName("LHQNJ")]
        public string LHQNJ
        {
            get
            {
                return _LHQNJ;
            }

            set
            {
                _LHQNJ = value;
            }
        }
        /// <summary>
        /// 气体标样
        /// </summary>
        [DisplayName("QTBY")]
        public string QTBY
        {
            get
            {
                return _QTBY;
            }

            set
            {
                _QTBY = value;
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
        ///大修时间(显示在dategrid)
        /// </summary>
        [DisplayName("DXSJ_GD")]
        public string DXSJ_GD
        {
            get
            {
                return _DXSJ_GD;
            }

            set
            {
                _DXSJ_GD = value;
            }
        }
        /// <summary>
        /// 设备自编号
        /// </summary>
        [DisplayName("SBZBH")]
        public string SBZBH
        {
            get
            {
                return _SBZBH;
            }

            set
            {
                _SBZBH = value;
            }
        }
        /// <summary>
        ///色谱分析周期
        /// </summary>
        [DisplayName("SPFXZQ")]
        public Decimal SPFXZQ
        {
            get
            {
                return _SPFXZQ;
            }

            set
            {
                _SPFXZQ = value;
            }
        }
    }
}
