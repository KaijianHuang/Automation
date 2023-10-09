using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;//下载PLC的库
using System.Threading;

namespace 测量Kp
{
   
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        Plc plc;
        int Maximum_motor_range ;//电机转速的最大量程
        float Proportion ;//测量的比例
        bool Motor_start = true;//电机开始
        bool Motor_stop = false;//电机停止

        bool Test1_stop = true;//PLC里面的OB20停止
        bool Test2_stop = true;//PLC里面的OB21停止
        bool Test3_stop = true;//PLC里面的OB22停止
        bool Test4_stop = true;//PLC里面的OB23停止
        bool Test1_start = false;//PLC里面的OB20开始
        bool Test2_start = false;//PLC里面的OB21开始
        bool Test3_start = false;//PLC里面的OB22开始
        bool Test4_start = false;//PLC里面的OB23开始

        int Time1_T = 1000;//Time1的循环周期
        int Time2_T;//Time2的循环周期
        int Time3_T = 1000;
        int Time4_T = 1000;

        int Measuring_motor_speed;
        float Measuring_wind_speed;

        private void button1_Click(object sender, EventArgs e)
        {
            plc = new Plc(CpuType.S71500, "192.168.0.1", 0, 1);
            plc.Open();

            Maximum_motor_range = Convert.ToInt32(转速最大量程.Text);
            Proportion = Convert.ToSingle(区间比例.Text);
            Specified_wind_speed = Convert.ToSingle(指定风速.Text);
            Time2_T= Convert.ToInt32(采样间隔.Text);
            Stability_threshold= Convert.ToSingle(稳定阈值.Text);
            

            plc.Write("DB2.DBW6.0", 0);
            plc.Write("DB2.DBW8.0", 0.0);
            plc.Write("DB2.DBW24.0", 0);
            plc.Write("DB2.DBW18.0", 0.0);
            plc.Write("DB2.DBW12.0", 0);


            plc.Write("DB1.DBX30.0", Motor_start);
            plc.Write("DB2.DBW24.0", Maximum_motor_range);
            plc.Write("DB2.DBW18.0", Proportion);
           

            plc.Write("DB2.DBX0.0", Test1_stop);
            plc.Write("DB2.DBX22.0", Test2_stop);
            plc.Write("DB2.DBX36.0", Test3_stop);
            plc.Write("DB2.DBX36.1", Test4_stop);
            plc.Write("DB2.DBX0.0", Test1_start);


            if (timer1.Enabled == false)
            {
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
            timer1.Interval = Time1_T;
            
            if (timer2.Enabled == false)
            {
                timer2.Enabled = true;
            }
            else
            {
                timer2.Enabled = false;
            }
            timer2.Interval = Time2_T;

            if (timer3.Enabled == false)
            {
                timer3.Enabled = true;
            }
            else
            {
                timer3.Enabled = false;
            }
            timer3.Interval = Time3_T;

            if (timer4.Enabled == false)
            {
                timer4.Enabled = true;
            }
            else
            {
                timer4.Enabled = false;
            }
            timer4.Interval = Time4_T;

            

        }
        
        private void chart1_Click(object sender, EventArgs e)
        {

        }
        int x1 = 0;
        float y1 = 0;
        
        float Image_wind_speed;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            float y1 = ((uint)plc.Read("DB1.DBD10.0")).ConvertToFloat();
            chart1.Series[0].Points.AddXY(x1, y1);
            chart1.Series[1].Points.AddXY(x1, Specified_wind_speed);
            x1++;

            Measuring_motor_speed = (ushort)plc.Read("DB2.DBW6.0");
            测量电机转速.Text = Measuring_motor_speed.ToString();
            Image_wind_speed = ((uint)plc.Read("DB1.DBD10.0")).ConvertToFloat();
            风速.Text = Image_wind_speed.ToString();
 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
       
        int x2 = 0;
        static int times1 = 10;
        int Delay_time1 = 10;     
        float[] speed_1 = new float [times1];
        int base_Kp;
        float Stability_threshold;
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            if (x2> Delay_time1)
            {
                speed_1[0] = ((uint)plc.Read("DB1.DBD10.0")).ConvertToFloat();

                float speed_min = speed_1.Min();
                float speed_max = speed_1.Max();
                if ((speed_max - speed_min) < Stability_threshold)
                {
                    plc.Write("DB2.DBX22.0", Test2_start);
                    Measuring_wind_speed= ((uint)plc.Read("DB2.DBD8.0")).ConvertToFloat();
                    测量风速.Text = Measuring_wind_speed.ToString();
                    base_Kp = (ushort)plc.Read("DB2.DBW12.0");
                    基准Kp.Text = base_Kp.ToString();
                    if (base_Kp > 0)
                    {
                        Specified_wind_speed_motor_speed = Specified_wind_speed * base_Kp;
                        plc.Write("DB2.DBW28.0", Convert.ToInt32(Specified_wind_speed_motor_speed));
                        plc.Write("DB2.DBX36.0", Test3_start);
                        指定风速的电机转速.Text = Convert.ToInt32(Specified_wind_speed_motor_speed).ToString();

                        Specified_wind_speed_1 = Specified_wind_speed + Add_specified_wind_speed;
                        Specified_wind_speed_motor_speed_1 = Specified_wind_speed_1 * base_Kp;
                        timer3_start = true;
                        timer2.Stop();
                    }
                }
                else
                {
                    for (int i = speed_1.Length - 1; i > 0; i--)
                    {
                        speed_1[i] = speed_1[i - 1];
                    }
                }
            }
            else
            {
                x2++;
            }
                                 
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            plc.Write("DB1.DBW0.0", 0);
            plc.Write("DB1.DBX30.0", Motor_stop);
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            timer4.Stop();
            plc.Close();

        }

       
        float Specified_wind_speed;
        float Specified_wind_speed_1;
        float Specified_wind_speed_motor_speed;
        float Specified_wind_speed_motor_speed_1;
        int x3 = 0;
        static int times2 = 10;
        int Delay_time2 = 10;
        float[] speed_2 = new float[times2];
        float Add_specified_wind_speed = 0.5f;
        bool timer3_start;
        private void timer3_Tick(object sender, EventArgs e)
        {          
            if (timer3_start)
            {
                if (x3 > Delay_time2)
                {
                    speed_2[0] = ((uint)plc.Read("DB1.DBD10.0")).ConvertToFloat();

                    float speed_min = speed_2.Min();
                    float speed_max = speed_2.Max();
                    if ((speed_max - speed_min) < Stability_threshold)
                    {
                        plc.Write("DB2.DBW32.0", Convert.ToInt32(Specified_wind_speed_motor_speed_1));
                        plc.Write("DB2.DBX36.1", Test4_start);
                        指定风速的电机转速_1.Text = Convert.ToInt32(Specified_wind_speed_motor_speed_1).ToString();

                        timer4_start = true;
                        timer3.Stop();
                    }
                    else
                    {
                        for (int i = speed_2.Length - 1; i > 0; i--)
                        {
                            speed_2[i] = speed_2[i - 1];
                        }
                    }
                }
                else
                {
                    x3++;
                }
            }
            
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        int Delay_Time = 0;
        bool timer4_start;
        float wind_speed;
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (timer4_start)
            {
                wind_speed = ((uint)plc.Read("DB1.DBD10.0")).ConvertToFloat();
                if (wind_speed>= Specified_wind_speed_1)
                {
                    延迟时间.Text = Delay_Time.ToString();
                    plc.Write("DB1.DBW0.0", 0);
                    plc.Write("DB1.DBX30.0", Motor_stop);
                    timer1.Stop();
                    timer4.Stop();
                }
                else
                {
                    Delay_Time++;
                }
            }
        }

        private void textBox1_TextChanged_3(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
    }

}
