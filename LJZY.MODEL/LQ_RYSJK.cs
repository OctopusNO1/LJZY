using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_RYSJK
    {

        private string _ID;
        private string _GW;
        private string _RYBH;
        private string _XM;
        private string _LXDH;
        private string _XB;
        private string _NL;
        private string _XL;
        private string _JKZK;
        private string _ZC;
        private string _JCZ;
        private string _SGZ;
        private string _NDSJTS;
        private string _HSE;
        private string _XMB;
        private string _RYZT;
        private string _TJR;
        private DateTime _TJSJ;
        private string _BZ;
        private string _YGXZ;
        private string _SJJH;
        private DateTime _KSSJRQ;
        private DateTime _JSSJRQ;
        private string _GWXS;
        private int _TROW;
        private string _TJSJ_DG;
        private string _KSSJRQ_DG;
        private string _JSSJRQ_DG;
        private string _ZJH;
        private int _BJSJTS;//本井上井天数
        private string _NDJZ;

        private string _JCZBH;
        private string _JCZYXQ;
        private string _JCZIMG;

        private string _SGZBH;
        private string _SGZYXQ;
        private string _SGZIMG;

        private string _HSEBH;
        private string _HSEYXQ;
        private string _HSEIMG;
        private string _JH;
        private string _JX;



        public LQ_RYSJK()
        {
            _KSSJRQ = DateTime.Now;
            _JSSJRQ = DateTime.Now;
        }
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName ( "ID" )]
        public string ID
        {
            get { return _ID; }

            set { _ID = value; }
        }

        /// <summary>
        /// 人员分类
        /// </summary>
        [DisplayName ( "GW" )]
        public string GW
        {
            get { return _GW; }

            set { _GW = value; }
        }
        /// <summary>
        /// 人员编号
        /// </summary>
        [DisplayName ( "RYBH" )]
        public string RYBH
        {
            get { return _RYBH; }

            set { _RYBH = value; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        [DisplayName ( "XM" )]
        public string XM
        {
            get { return _XM; }
            set { _XM = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        [DisplayName ( "LXDH" )]
        public string LXDH
        {
            get { return _LXDH; }
            set { _LXDH = value; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        [DisplayName ( "XB" )]
        public string XB
        {
            get { return _XB; }
            set { _XB = value; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        [DisplayName ( "NL" )]
        public string NL
        {
            get { return _NL; }
            set { _NL = value; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        [DisplayName ( "XL" )]
        public string XL
        {
            get { return _XL; }
            set { _XL = value; }
        }
        /// <summary>
        /// 健康状况
        /// </summary>
        [DisplayName ( "JKZK" )]
        public string JKZK
        {
            get { return _JKZK; }
            set { _JKZK = value; }
        }
        /// <summary>
        /// 职称
        /// </summary>
        [DisplayName ( "ZC" )]
        public string ZC
        {
            get { return _ZC; }
            set { _ZC = value; }
        }
        /// <summary>
        /// 井控证
        /// </summary>
        [DisplayName ( "JCZ" )]
        public string JCZ
        {
            get { return _JCZ; }
            set { _JCZ = value; }
        }
        /// <summary>
        /// 上岗证
        /// </summary>
        [DisplayName ( "SGZ" )]
        public string SGZ
        {
            get { return _SGZ; }
            set { _SGZ = value; }
        }
        /// <summary>
        /// 年度上井天数
        /// </summary>
        [DisplayName ( "NDSJTS" )]
        public string NDSJTS
        {
            get { return _NDSJTS; }
            set { _NDSJTS = value; }
        }
        /// <summary>
        /// HSE证
        /// </summary>
        [DisplayName ( "HSE" )]
        public string HSE
        {
            get { return _HSE; }
            set { _HSE = value; }
        }
        /// <summary>
        /// 项目部
        /// </summary>
        [DisplayName ( "XMB" )]
        public string XMB
        {
            get { return _XMB; }
            set { _XMB = value; }
        }
        /// <summary>
        /// 人员状态
        /// </summary>
        [DisplayName ( "RYZT" )]
        public string RYZT
        {
            get { return _RYZT; }
            set { _RYZT = value; }
        }
        /// <summary>
        /// 添加人
        /// </summary>
        [DisplayName ( "TJR" )]
        public string TJR
        {
            get { return _TJR; }
            set { _TJR = value; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        [DisplayName ( "TJSJ" )]
        public DateTime TJSJ
        {
            get { return _TJSJ; }
            set { _TJSJ = value; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        [DisplayName ( "BZ" )]
        public string BZ
        {
            get { return _BZ; }
            set { _BZ = value; }
        }

        /// <summary>
        /// 排序号
        /// </summary>
        [DisplayName ( "TROW" )]
        public int TROW
        {
            get { return _TROW; }
            set { _TROW = value; }
        }

        /// <summary>
        /// 添加时间(显示在datagrid)
        /// </summary>
        [DisplayName ( "TJSJ_DG" )]
        public string TJSJ_DG
        {
            get { return _TJSJ_DG; }
            set { _TJSJ_DG = value; }
        }

        /// <summary>
        /// 分配井号
        /// </summary>
        [DisplayName ( "ZJH" )]
        public string ZJH
        {
            get { return _ZJH; }
            set { _ZJH = value; }
        }
        /// <summary>
        /// 用工性质
        /// </summary>
        [DisplayName ( "YGXZ" )]
        public string YGXZ
        {
            get
            {
                return _YGXZ;
            }

            set
            {
                _YGXZ = value;
            }
        }
        /// <summary>
        /// 上井井号
        /// </summary>
        [DisplayName ( "SJJH" )]
        public string SJJH
        {
            get
            {
                return _SJJH;
            }

            set
            {
                _SJJH = value;
            }
        }
        /// <summary>
        /// 开始上井日期
        /// </summary>
        [DisplayName ( "KSSJRQ" )]
        public DateTime KSSJRQ
        {
            get
            {
                return _KSSJRQ;
            }

            set
            {
                _KSSJRQ = value;
            }
        }
        /// <summary>
        /// 结束上井日期
        /// </summary>
        [DisplayName ( "JSSJRQ" )]
        public DateTime JSSJRQ
        {
            get
            {
                return _JSSJRQ;
            }

            set
            {
                _JSSJRQ = value;
            }
        }

        /// <summary>
        /// 岗位系数
        /// </summary>
        [DisplayName ( "GWXS" )]
        public string GWXS
        {
            get
            {
                return _GWXS;
            }

            set
            {
                _GWXS = value;
            }
        }
        /// <summary>
        /// 本井上井天数
        /// </summary>
        [DisplayName ( "BJSJTS" )]
        public int BJSJTS
        {
            get
            {
                return _BJSJTS;
            }

            set
            {
                _BJSJTS = value;
            }
        }
        /// <summary>
        /// 年度结转
        /// </summary>
        [DisplayName ( "NDJZ" )]
        public string NDJZ
        {
            get
            {
                return _NDJZ;
            }

            set
            {
                _NDJZ = value;
            }
        }
        /// <summary>
        /// 开始上井日期(显示在dategrid)
        /// </summary>
        [DisplayName ( "KSSJRQ_DG" )]
        public string KSSJRQ_DG
        {
            get
            {
                return _KSSJRQ_DG;
            }

            set
            {
                _KSSJRQ_DG = value;
            }
        }
        /// <summary>
        /// 结束上井日期(显示在dategrid)
        /// </summary>
        [DisplayName ( "JSSJRQ_DG" )]
        public string JSSJRQ_DG
        {
            get
            {
                return _JSSJRQ_DG;
            }

            set
            {
                _JSSJRQ_DG = value;
            }
        }

        /// <summary>
        /// 井控证编号
        /// </summary>
        [DisplayName ( "JCZBH" )]
        public string JCZBH
        {
            get
            {
                return _JCZBH;
            }

            set
            {
                _JCZBH = value;
            }
        }
        /// <summary>
        /// 井控证有效期
        /// </summary>
        [DisplayName ( "JCZYXQ" )]
        public string JCZYXQ
        {
            get
            {
                return _JCZYXQ;
            }

            set
            {
                _JCZYXQ = value;
            }
        }
        /// <summary>
        /// 井控证图片
        /// </summary>
        public string JCZIMG
        {
            get
            {
                return _JCZIMG;
            }

            set
            {
                _JCZIMG = value;
            }
        }
        /// <summary>
        /// 上岗证编号
        /// </summary>
        [DisplayName ( "SGZBH" )]
        public string SGZBH
        {
            get
            {
                return _SGZBH;
            }

            set
            {
                _SGZBH = value;
            }
        }
        /// <summary>
        /// 上岗证有效期
        /// </summary>
        [DisplayName ( "SGZYXQ" )]
        public string SGZYXQ
        {
            get
            {
                return _SGZYXQ;
            }

            set
            {
                _SGZYXQ = value;
            }
        }
        /// <summary>
        /// 上岗证图片
        /// </summary>
        [DisplayName ( "SGZIMG" )]
        public string SGZIMG
        {
            get
            {
                return _SGZIMG;
            }

            set
            {
                _SGZIMG = value;
            }
        }
        /// <summary>
        /// hse证编号
        /// </summary>
        [DisplayName ( "HSEBH" )]
        public string HSEBH
        {
            get
            {
                return _HSEBH;
            }

            set
            {
                _HSEBH = value;
            }
        }
        /// <summary>
        /// hse有效期
        /// </summary>
        [DisplayName ( "HSEYXQ" )]
        public string HSEYXQ
        {
            get
            {
                return _HSEYXQ;
            }

            set
            {
                _HSEYXQ = value;
            }
        }
        /// <summary>
        /// hse图片
        /// </summary>
        [DisplayName ( "HSEIMG" )]
        public string HSEIMG
        {
            get
            {
                return _HSEIMG;
            }

            set
            {
                _HSEIMG = value;
            }
        }

        public string JH
        {
            get
            {
                return _JH;
            }

            set
            {
                _JH =  value ;
            }
        }

        public string JX
        {
            get
            {
                return _JX;
            }

            set
            {
                _JX =  value ;
            }
        }
    }
}
