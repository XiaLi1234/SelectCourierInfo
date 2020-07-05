using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForm.Model
{
    public class LogisticsInfoResultModel
    {
        /// <summary>
        /// 商家ID
        /// </summary>
        public string EBusinessID { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 快递公司标识
        /// </summary>
        public string ShipperCode { get; set; }
        /// <summary>
        /// 快递单号
        /// </summary>
        public string LogisticCode { get; set; }
        /// <summary>
        /// 成功与否
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 物流状态
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 物流信息
        /// </summary>
        public List<LogisticsModel> Traces { get; set; }
    }
}
