using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchForm.Model
{
    public class LogisticsModel
    {
        /// <summary>
        /// 快递信息
        /// </summary>
        public string AcceptStation { get; set; }
        /// <summary>
        /// 接受时间
        /// </summary>
        public DateTime? AcceptTime { get; set; }
    }
}
