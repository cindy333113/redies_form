using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RedisForm
{
    public partial class Form1 : Form
    {
        UseAdapterToGetData useAdapterToGetData = new UseAdapterToGetData();
        UseReaderToGetData useReaderToGetData = new UseReaderToGetData();
        Stopwatch stopWatch = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
            var eTypeDictionary = new Dictionary<int, string> { { 0, "全部" }, { 1, "整股" }, { 2, "零股" }, { 3, "鉅額" }, { 4, "定盤" }, { 5, "盤中零股" } };
            comboBox1.DataSource = new BindingSource(eTypeDictionary, null); ;
            comboBox1.DisplayMember = "Value";

            var tTypeDictionary = new Dictionary<int, string> { { 0, "全部" }, { 1, "現股" }, { 2, "融資" }, { 3, "融券" } };
            cmbtType.DataSource = new BindingSource(tTypeDictionary, null); ;
            cmbtType.DisplayMember = "Value";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbhNo.Text)| string.IsNullOrWhiteSpace(txtcSeq.Text))
            {
                MessageBox.Show("分公司和帳號不可為空");
            }
            else
            {
                stopWatch.Restart();
                string requuestJosn = GetRequestData();
                dataGridView1.DataSource = useAdapterToGetData.getDataFromDB(requuestJosn);
                useAdapterToGetData.setColumOrder(dataGridView1);
                txtResponseJson.Text = useAdapterToGetData.ConvertDataTabletoString(requuestJosn);
                lblAdapterTime.Text = ShowProcessTime();

                if (!useAdapterToGetData.CheckSearchStockHasValue())
                {
                    MessageBox.Show("股票代號不存在");
                }
            }

        }
        private void btnSearchByReader_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbhNo.Text) | string.IsNullOrWhiteSpace(txtcSeq.Text))
            {
                MessageBox.Show("分公司和帳號不可為空");
            }
            else
            {
                stopWatch.Restart();
                string requestJson = GetRequestData();
                txtResponseJson.Text = useReaderToGetData.GetData(requestJson);
                lblReaderTIme.Text = ShowProcessTime();
                if (!useReaderToGetData.CheckSearchStockHasValue())
                {
                    MessageBox.Show("股票代號不存在");
                }
            }
        }
        private string ShowProcessTime()
        {
            stopWatch.Stop();
            var ts = stopWatch.Elapsed;
            //stopWatch.Restart();
            return $"{ts.Minutes}:{ts.Seconds}.{ts.Milliseconds / 10}";
        }
        private string GetRequestData()
        {
            Request request = new Request()
            {
                bhNo = txtbhNo.Text,
                cSeq = txtcSeq.Text,
                content = new Request.Content()
                {
                    eType = ((KeyValuePair<int, string>)comboBox1.SelectedValue).Key.ToString(),
                    tType = ((KeyValuePair<int, string>)cmbtType.SelectedValue).Key.ToString(),
                    stock = txtStock.Text,
                }
            };
            string requuestJosn = JsonConvert.SerializeObject(request);
            return requuestJosn;
        }

        private void txtbhNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbhNo.Text))
            {
                e.Cancel = true;
                txtbhNo.Focus();
                errorProvider1.SetError(txtbhNo, "should not be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtbhNo, "");
            }
        }
    }
}
