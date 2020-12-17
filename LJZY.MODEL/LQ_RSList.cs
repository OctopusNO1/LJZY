using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LJZY.MODEL
{
    public class LQ_RSList
    {
        public LQ_RSList()
        {

        }

        private List<LQ_RYSB> _List;
        private LQ_RYSBCount _ListCount;

        /// <summary>
        /// 列表数据
        /// </summary>
        [DisplayName ( "List" )]
        public List<LQ_RYSB> List
        {
            get
            {
                return _List;
            }

            set
            {
                _List =  value ;
            }
        }

        /// <summary>
        /// 列表统计数据
        /// </summary>
        [DisplayName ( "ListCount" )]
        public LQ_RYSBCount ListCount
        {
            get
            {
                return _ListCount;
            }

            set
            {
                _ListCount =  value ;
            }
        }
    }
}
