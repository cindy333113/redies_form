using System.Collections.Generic;
using System.Windows.Forms;

namespace RedisForm
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblbhNo = new System.Windows.Forms.Label();
            this.lblcSeq = new System.Windows.Forms.Label();
            this.txtbhNo = new System.Windows.Forms.TextBox();
            this.txtcSeq = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbtType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtResponseJson = new System.Windows.Forms.TextBox();
            this.btnSearchByReader = new System.Windows.Forms.Button();
            this.lblAdapterTime = new System.Windows.Forms.Label();
            this.lblReaderTIme = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 294);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(156, 48);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "搜尋(Adapter)";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblbhNo
            // 
            this.lblbhNo.AutoSize = true;
            this.lblbhNo.Location = new System.Drawing.Point(25, 26);
            this.lblbhNo.Name = "lblbhNo";
            this.lblbhNo.Size = new System.Drawing.Size(106, 24);
            this.lblbhNo.TabIndex = 1;
            this.lblbhNo.Text = "分公司：";
            // 
            // lblcSeq
            // 
            this.lblcSeq.AutoSize = true;
            this.lblcSeq.Location = new System.Drawing.Point(25, 72);
            this.lblcSeq.Name = "lblcSeq";
            this.lblcSeq.Size = new System.Drawing.Size(58, 24);
            this.lblcSeq.TabIndex = 2;
            this.lblcSeq.Text = "帳號";
            // 
            // txtbhNo
            // 
            this.txtbhNo.Location = new System.Drawing.Point(191, 23);
            this.txtbhNo.Name = "txtbhNo";
            this.txtbhNo.Size = new System.Drawing.Size(140, 36);
            this.txtbhNo.TabIndex = 3;
            this.txtbhNo.Text = "5604";
            this.txtbhNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtbhNo_Validating);
            // 
            // txtcSeq
            // 
            this.txtcSeq.Location = new System.Drawing.Point(191, 72);
            this.txtcSeq.Name = "txtcSeq";
            this.txtcSeq.Size = new System.Drawing.Size(140, 36);
            this.txtcSeq.TabIndex = 4;
            this.txtcSeq.Text = "0065271";
            this.txtcSeq.Validating += new System.ComponentModel.CancelEventHandler(this.txtbhNo_Validating);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(992, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 38;
            this.dataGridView1.Size = new System.Drawing.Size(801, 804);
            this.dataGridView1.TabIndex = 5;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(191, 125);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 32);
            this.comboBox1.TabIndex = 6;
            // 
            // cmbtType
            // 
            this.cmbtType.FormattingEnabled = true;
            this.cmbtType.Location = new System.Drawing.Point(191, 172);
            this.cmbtType.Name = "cmbtType";
            this.cmbtType.Size = new System.Drawing.Size(140, 32);
            this.cmbtType.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "盤別";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "交易別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "股票代碼：";
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(191, 226);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(140, 36);
            this.txtStock.TabIndex = 11;
            // 
            // txtResponseJson
            // 
            this.txtResponseJson.AllowDrop = true;
            this.txtResponseJson.Location = new System.Drawing.Point(375, 26);
            this.txtResponseJson.Multiline = true;
            this.txtResponseJson.Name = "txtResponseJson";
            this.txtResponseJson.ReadOnly = true;
            this.txtResponseJson.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResponseJson.Size = new System.Drawing.Size(570, 804);
            this.txtResponseJson.TabIndex = 12;
            // 
            // btnSearchByReader
            // 
            this.btnSearchByReader.Location = new System.Drawing.Point(12, 369);
            this.btnSearchByReader.Name = "btnSearchByReader";
            this.btnSearchByReader.Size = new System.Drawing.Size(156, 48);
            this.btnSearchByReader.TabIndex = 13;
            this.btnSearchByReader.Text = "搜尋(Reader)";
            this.btnSearchByReader.UseVisualStyleBackColor = true;
            this.btnSearchByReader.Click += new System.EventHandler(this.btnSearchByReader_Click);
            // 
            // lblAdapterTime
            // 
            this.lblAdapterTime.AutoSize = true;
            this.lblAdapterTime.Location = new System.Drawing.Point(187, 306);
            this.lblAdapterTime.Name = "lblAdapterTime";
            this.lblAdapterTime.Size = new System.Drawing.Size(106, 24);
            this.lblAdapterTime.TabIndex = 14;
            this.lblAdapterTime.Text = "執行時間";
            // 
            // lblReaderTIme
            // 
            this.lblReaderTIme.AutoSize = true;
            this.lblReaderTIme.Location = new System.Drawing.Point(187, 381);
            this.lblReaderTIme.Name = "lblReaderTIme";
            this.lblReaderTIme.Size = new System.Drawing.Size(106, 24);
            this.lblReaderTIme.TabIndex = 15;
            this.lblReaderTIme.Text = "執行時間";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2018, 937);
            this.Controls.Add(this.lblReaderTIme);
            this.Controls.Add(this.lblAdapterTime);
            this.Controls.Add(this.btnSearchByReader);
            this.Controls.Add(this.txtResponseJson);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbtType);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtcSeq);
            this.Controls.Add(this.txtbhNo);
            this.Controls.Add(this.lblcSeq);
            this.Controls.Add(this.lblbhNo);
            this.Controls.Add(this.btnSearch);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblbhNo;
        private System.Windows.Forms.Label lblcSeq;
        private System.Windows.Forms.TextBox txtbhNo;
        private System.Windows.Forms.TextBox txtcSeq;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbtType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtResponseJson;
        private System.Windows.Forms.Button btnSearchByReader;
        private Label lblAdapterTime;
        private Label lblReaderTIme;
        private ErrorProvider errorProvider1;
    }
}

