using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using S7.Net;
using System.Threading;

namespace 测量基于基准Kp的模型
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int i = 0;
        int temp = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1_start)
            {
                speed_1[0] = ((uint)plc.Read("DB1.DBD10.0")).ConvertToFloat();
                plc.Write("DB1.DBW54.0", Kp[i]);
                当前Kp.Text = Kp[i].ToString();
                plc.Write("DB1.DBX42.0", Start_PID_cycle);             
                
                float speed_min = speed_1.Min();
                float speed_max = speed_1.Max();

                y[i] = ((uint)plc.Read("DB1.DBD10.0")).ConvertToFloat();
                chart1.Series[0].Points.AddXY(temp, Specified_wind_speed);
                chart1.Series[i + 1].Points.AddXY(x[i], y[i]);
                x[i]++;
                temp++;
                if (time_start)
                {
                    if (speed_1[0] < Specified_wind_speed)
                    {
                        shortest_time[i]++;
                    }
                    else
                    {
                        最短到达时间.Text = shortest_time[i].ToString();
                        time_start = false;
                    }
                }             
                if (speed_1[0] > (Specified_wind_speed * Over_threshold/100))
                {
                    chart1.Series[i + 1].Points.Clear();
                    shortest_time[i] = 0;
                    最短到达时间.Text = shortest_time[i].ToString();
                    plc.Write("DB1.DBX42.0", Stop_PID_cycle);
                    plc.Write("DB1.DBW0.0", 0);
                    temp = 0;
                    i++;
                    for (int i = 0; i < times1; i++)
                    {
                        speed_1[i] = 0;
                    }
                    timer1_start = false;
                }
                if ((Math.Abs(Specified_wind_speed - speed_min)< Stability_threshold)&&(Math.Abs(Specified_wind_speed - speed_max) < Stability_threshold))
                {
                    plc.Write("DB1.DBX42.0", Stop_PID_cycle);
                    plc.Write("DB1.DBW0.0", 0);
                    temp = 0;
                    i++;
                    for (int i = 0; i < times1; i++)
                    {
                        speed_1[i] = 0;
                    }
                    //最短到达时间.Text = shortest_time[i].ToString();
                    timer1_start = false;
                }
                else
                {
                    for (int i = times1 - 1; i > 0; i--)
                    {
                        speed_1[i] = speed_1[i - 1];
                    }
                }
                if (i >= number)
                {
                    for(int i = 0; i < number; i++)
                    {
                        shortest_time_1[i] = shortest_time[i];
                    }
                    for(int i = 0; i < number - 1; i++)
                    {
                        for(int j = 0; j < number - i - 1; j++)
                        {
                            if (shortest_time_1[j] > shortest_time_1[j + 1])
                            {
                                int temp = shortest_time_1[j];
                                shortest_time_1[j] = shortest_time_1[j + 1];
                                shortest_time_1[j + 1] = temp;
                            }
                        }
                    }
                    int count = 0;
                    for(int i = 0; i < number; i++)
                    {
                        if (shortest_time_1[i] == 0)
                        {
                            count++;
                        }
                    }
                    int min = shortest_time_1[count];
                    最终最短到达时间.Text = min.ToString();
                    for (int i = 0; i < number; i++)
                    {
                        if (shortest_time[i] != min)
                        {
                            chart1.Series[i + 1].Points.Clear();
                        }
                        else
                        {
                            最佳Kp.Text = Kp[i].ToString();
                        }                      
                    }
                    timer1.Stop();
                    timer2.Stop();
                    plc.Write("DB1.DBW0.0", 0);
                    plc.Write("DB1.DBX30.0", Motor_stop);
                    plc.Write("DB1.DBX48.0", Motor_stop);
                    plc.Write("DB1.DBX42.0", Stop_PID_cycle);
                }
            }
           
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            speed_2[0] = ((uint)plc.Read("DB1.DBD10.0")).ConvertToFloat();
            风速.Text = ((uint)plc.Read("DB1.DBD10.0")).ConvertToFloat().ToString();
            转速.Text= ((ushort)plc.Read("DB1.DBW0.0")).ToString();
            float speed_min = speed_2.Min();
            float speed_max = speed_2.Max();
            if ((Math.Abs(speed_min) < 0.05) && (Math.Abs(speed_max) < 0.05))
            {
                timer1_start = true;
                time_start = true;
            }
            else
            {
                for (int i = times2 - 1; i > 0; i--)
                {
                    speed_2[i] = speed_2[i - 1];
                }
            }
        }
        Plc plc;

        int Time1_T = 1000;
        int Time2_T = 1000;
        float Specified_wind_speed;
        int Base_Kp;
        int Interval;
        int Base_Kp_min;
        int Base_Kp_max;
        int number;
        static int times1 = 20;
        static int times2 = 5;
        float Stability_threshold;
        int Over_threshold;
        bool Start_PID_cycle = true;
        bool Stop_PID_cycle = false;
        bool Motor_start = true;
        bool Motor_stop = false;
        bool timer1_start;
        bool time_start;
        int[] Kp = new int[1000];
        int[] x = new int[1000];
        float [] y = new float [1000];      
        float[] speed_1 = new float[times1];
        float[] speed_2 = new float[times2];
        int[] shortest_time = new int[1000];
        int[] shortest_time_1 = new int[1000];

        private void button1_Click(object sender, EventArgs e)
        {
            plc = new Plc(CpuType.S71500, "192.168.0.1", 0, 1);
            plc.Open();

            Specified_wind_speed = Convert.ToSingle(指定风速.Text);
            plc.Write("DB1.DBW38.0", Specified_wind_speed);

            Base_Kp = Convert.ToInt32(基准_Kp.Text);
            plc.Write("DB1.DBW44.0", Base_Kp);

            Interval = Convert.ToInt32(区间.Text);
            plc.Write("DB1.DBW50.0", Interval);

            Stability_threshold = Convert.ToSingle(稳定阈值.Text);
            Over_threshold = Convert.ToInt32(超出阈值.Text);
            

            plc.Write("DB1.DBX30.0", Motor_start);
            plc.Write("DB1.DBX48.0", Motor_start);

            Base_Kp_min = Base_Kp - Interval;
            Base_Kp_max = Base_Kp + Interval;

            
            number = 2 * Interval + 1;
            for(int i = 0; i < number; i++)
            {
                Kp[i] = Base_Kp - Interval + i;
            }
            

            timer1_start = true;

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

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            plc.Write("DB1.DBW0.0", 0);
            plc.Write("DB1.DBX30.0", Motor_stop);
            plc.Write("DB1.DBX48.0", Motor_stop);
            plc.Write("DB1.DBX42.0", Stop_PID_cycle);
            timer1.Stop();
            timer2.Stop();
            plc.Close();
        }

        

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
