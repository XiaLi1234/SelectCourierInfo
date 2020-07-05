using KdGoldAPI;
using SearchForm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchForm.common;

namespace SearchForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //窗体居中显示
            this.StartPosition = FormStartPosition.CenterScreen;
            BindComboBox();
            InitListView();
        }

        #region 绑定comboBox下拉框
        /// <summary>
        /// 绑定comboBox下拉框
        /// </summary>
        public void BindComboBox()
        {
            //绑定comboBox下拉框
            IList<CourierCompany> infoList = new List<CourierCompany>();
            CourierCompany info1 = new CourierCompany() { Text = "圆通", Value = "YTO" };
            CourierCompany info2 = new CourierCompany() { Text = "申通", Value = "STO" };
            CourierCompany info3 = new CourierCompany() { Text = "中通", Value = "ZTO" };
            infoList.Add(info1);
            infoList.Add(info2);
            infoList.Add(info3);
            comboBox1.DataSource = infoList;
            comboBox1.ValueMember = "Value";
            comboBox1.DisplayMember = "Text";
        }
        #endregion

        #region 初始化ListView表头
        /// <summary>
        /// 初始化ListView表头
        /// </summary>
        public void InitListView()
        {
            listView1.View = View.Details;
            //绑定表头
            listView1.Columns.Add("到达时间", 180, HorizontalAlignment.Left);
            listView1.Columns.Add("快递详情", 1200, HorizontalAlignment.Left);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            //数据验证
            if (!string.IsNullOrWhiteSpace(tbx_Dh.Text.Trim()) && !string.IsNullOrWhiteSpace(tbx_Phone.Text.Trim()))
            {
                KdApiSearchDemo demo = new KdApiSearchDemo();
                //获取控件值
                string dh = tbx_Dh.Text.Trim();
                string phone = tbx_Phone.Text.Trim();
                string bsCode = comboBox1.SelectedValue.ToString();
                //接受返回值
                string result = demo.getOrderTracesByJson(dh, phone, bsCode);
                List<LogisticsModel> logisticsList = new List<LogisticsModel>();
                if (!string.IsNullOrWhiteSpace(result))
                {
                    //Json转化实体类
                    LogisticsInfoResultModel logisticsModelList = JsonNewtonsoft.FromJSON<LogisticsInfoResultModel>(result);
                    if (logisticsModelList != null && logisticsModelList.Traces != null && logisticsModelList.Traces.Count() > 0)
                    {
                        //接收快递信息列表，按最新时间倒序排列
                        logisticsList = logisticsModelList.Traces.OrderByDescending(x => x.AcceptTime).ToList();
                    }
                }
                if (logisticsList != null && logisticsList.Count() > 0)
                {
                    listView1.BeginUpdate();   //数据更新，UI暂时挂起，直到EndUpdate绘制控件，可以有效避免闪烁并大大提高加载速度
                    int i = 0;
                    foreach (var trace in logisticsList)
                    {
                        //绑定数据
                        ListViewItem lvi = new ListViewItem();
                        //lvi.Text第一列
                        lvi.Text = trace.AcceptTime.ToString();
                        //第二列，第三列、第四列以此类推，与第一列不同
                        lvi.SubItems.Add(trace.AcceptStation);
                        //设置最新一条记录的样式区别于其他记录
                        if (i == 0)
                        {
                            lvi.Font = new Font("仿宋", 12, FontStyle.Bold);
                            //设置字体颜色
                            lvi.ForeColor = Color.Blue;
                        }
                        listView1.Items.Add(lvi);
                        i++;
                    } 
                    listView1.EndUpdate();
                }
                else
                {
                    MessageBox.Show("未获取到快递信息", "提示");
                }
            }
            else
            {
                MessageBox.Show("快递单号与收件人手机号不能为空", "提示");
            }
        }
    }

    /// <summary>
    /// 快递公司标识
    /// </summary>
    public class CourierCompany
    {
        /// <summary>
        /// 显示值
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 实际值
        /// </summary>
        public string Value { get; set; }
    }
}
