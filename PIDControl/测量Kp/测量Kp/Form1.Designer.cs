
namespace 测量Kp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.启动 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.测量电机转速 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.风速 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.auto = new System.Windows.Forms.Label();
            this.基准Kp = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.转速最大量程 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.区间比例 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.指定风速 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.采样间隔 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.稳定阈值 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.延迟时间 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.指定风速的电机转速 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.指定风速的电机转速_1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.测量风速 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // 启动
            // 
            this.启动.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.启动.Location = new System.Drawing.Point(1236, 552);
            this.启动.Name = "启动";
            this.启动.Size = new System.Drawing.Size(87, 38);
            this.启动.TabIndex = 0;
            this.启动.Text = "启动";
            this.启动.UseVisualStyleBackColor = true;
            this.启动.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(894, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "测量电机转速";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // 测量电机转速
            // 
            this.测量电机转速.Location = new System.Drawing.Point(1029, 152);
            this.测量电机转速.Name = "测量电机转速";
            this.测量电机转速.Size = new System.Drawing.Size(84, 25);
            this.测量电机转速.TabIndex = 2;
            this.测量电机转速.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(1119, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hz";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(974, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "风速";
            // 
            // 风速
            // 
            this.风速.Location = new System.Drawing.Point(1029, 97);
            this.风速.Name = "风速";
            this.风速.Size = new System.Drawing.Size(100, 25);
            this.风速.TabIndex = 5;
            this.风速.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(1136, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "m/s";
            // 
            // auto
            // 
            this.auto.AutoSize = true;
            this.auto.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.auto.Location = new System.Drawing.Point(1107, 439);
            this.auto.Name = "auto";
            this.auto.Size = new System.Drawing.Size(69, 20);
            this.auto.TabIndex = 7;
            this.auto.Text = "基准Kp";
            this.auto.Click += new System.EventHandler(this.label5_Click);
            // 
            // 基准Kp
            // 
            this.基准Kp.Location = new System.Drawing.Point(1182, 434);
            this.基准Kp.Name = "基准Kp";
            this.基准Kp.Size = new System.Drawing.Size(100, 25);
            this.基准Kp.TabIndex = 8;
            this.基准Kp.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // chart1
            // 
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisY.Interval = 0.5D;
            chartArea3.AxisY.Maximum = 6D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(25, 12);
            this.chart1.Name = "chart1";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = System.Drawing.Color.Red;
            series5.Legend = "Legend1";
            series5.Name = "Specify data";
            series5.Points.Add(dataPoint3);
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series6.Color = System.Drawing.Color.Lime;
            series6.Legend = "Legend1";
            series6.Name = "Fluctuating data";
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(742, 346);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1236, 610);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 43);
            this.button1.TabIndex = 10;
            this.button1.Text = "停止";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // 转速最大量程
            // 
            this.转速最大量程.Location = new System.Drawing.Point(160, 454);
            this.转速最大量程.Name = "转速最大量程";
            this.转速最大量程.Size = new System.Drawing.Size(100, 25);
            this.转速最大量程.TabIndex = 12;
            this.转速最大量程.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(25, 459);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "转速最大量程";
            // 
            // 区间比例
            // 
            this.区间比例.Location = new System.Drawing.Point(160, 505);
            this.区间比例.Name = "区间比例";
            this.区间比例.Size = new System.Drawing.Size(100, 25);
            this.区间比例.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(41, 510);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "区间比例";
            this.label6.Click += new System.EventHandler(this.label6_Click_1);
            // 
            // 指定风速
            // 
            this.指定风速.Location = new System.Drawing.Point(160, 410);
            this.指定风速.Name = "指定风速";
            this.指定风速.Size = new System.Drawing.Size(100, 25);
            this.指定风速.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(41, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "指定风速";
            // 
            // 采样间隔
            // 
            this.采样间隔.Location = new System.Drawing.Point(160, 562);
            this.采样间隔.Name = "采样间隔";
            this.采样间隔.Size = new System.Drawing.Size(100, 25);
            this.采样间隔.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(41, 567);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "采样间隔";
            // 
            // 稳定阈值
            // 
            this.稳定阈值.Location = new System.Drawing.Point(160, 622);
            this.稳定阈值.Name = "稳定阈值";
            this.稳定阈值.Size = new System.Drawing.Size(100, 25);
            this.稳定阈值.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(41, 627);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "稳定阈值";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(266, 567);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "ms";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(266, 415);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 20);
            this.label12.TabIndex = 23;
            this.label12.Text = "m/s";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(266, 459);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 20);
            this.label14.TabIndex = 21;
            this.label14.Text = "Hz";
            // 
            // 延迟时间
            // 
            this.延迟时间.Location = new System.Drawing.Point(1182, 474);
            this.延迟时间.Name = "延迟时间";
            this.延迟时间.Size = new System.Drawing.Size(100, 25);
            this.延迟时间.TabIndex = 26;
            this.延迟时间.TextChanged += new System.EventHandler(this.textBox1_TextChanged_2);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(1077, 479);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "延迟时间";
            // 
            // timer4
            // 
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(1288, 474);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "s";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(1119, 263);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "Hz";
            // 
            // 指定风速的电机转速
            // 
            this.指定风速的电机转速.Location = new System.Drawing.Point(1029, 258);
            this.指定风速的电机转速.Name = "指定风速的电机转速";
            this.指定风速的电机转速.Size = new System.Drawing.Size(84, 25);
            this.指定风速的电机转速.TabIndex = 29;
            this.指定风速的电机转速.TextChanged += new System.EventHandler(this.textBox1_TextChanged_3);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(834, 263);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(189, 20);
            this.label16.TabIndex = 28;
            this.label16.Text = "指定风速的电机转速";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(1119, 320);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 20);
            this.label17.TabIndex = 33;
            this.label17.Text = "Hz";
            // 
            // 指定风速的电机转速_1
            // 
            this.指定风速的电机转速_1.Location = new System.Drawing.Point(1029, 315);
            this.指定风速的电机转速_1.Name = "指定风速的电机转速_1";
            this.指定风速的电机转速_1.Size = new System.Drawing.Size(84, 25);
            this.指定风速的电机转速_1.TabIndex = 32;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(814, 320);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(209, 20);
            this.label18.TabIndex = 31;
            this.label18.Text = "指定风速的电机转速-1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(1119, 212);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(39, 20);
            this.label19.TabIndex = 36;
            this.label19.Text = "m/s";
            // 
            // 测量风速
            // 
            this.测量风速.Location = new System.Drawing.Point(1029, 207);
            this.测量风速.Name = "测量风速";
            this.测量风速.Size = new System.Drawing.Size(84, 25);
            this.测量风速.TabIndex = 35;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(914, 212);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 20);
            this.label20.TabIndex = 34;
            this.label20.Text = "测量风速";
            this.label20.Click += new System.EventHandler(this.label20_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(20, 372);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 28);
            this.label21.TabIndex = 37;
            this.label21.Text = "输入";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(1149, 372);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 28);
            this.label22.TabIndex = 38;
            this.label22.Text = "输出";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("宋体", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(1003, 46);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 28);
            this.label23.TabIndex = 39;
            this.label23.Text = "监测";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 665);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.测量风速);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.指定风速的电机转速_1);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.指定风速的电机转速);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.延迟时间);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.稳定阈值);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.采样间隔);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.指定风速);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.区间比例);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.转速最大量程);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.基准Kp);
            this.Controls.Add(this.auto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.风速);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.测量电机转速);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.启动);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button 启动;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox 测量电机转速;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox 风速;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label auto;
        private System.Windows.Forms.TextBox 基准Kp;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.TextBox 转速最大量程;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox 区间比例;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox 指定风速;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox 采样间隔;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox 稳定阈值;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox 延迟时间;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox 指定风速的电机转速;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox 指定风速的电机转速_1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox 测量风速;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
    }
}

