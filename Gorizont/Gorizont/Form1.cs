using System;
using System.Drawing;
using System.Windows.Forms;



namespace Gorizont
{
    public partial class Form1 : Form
    {
        float x=0,x1 = 1, y=0, t = 0, ux =10, uy =10, g = 9.81f,a =-1;
        float f = 0, av = 0,k=0.01f, m = 1;

        private void Timer2_Tick(object sender, EventArgs e)
        {
            
            t = t + 0.1f;
            ux = ux - 0.1f * ux * ux * k/m;
            x = x + ux * 0.1f;
            uy = uy + 0.01f * g;
            y = y - uy * 0.1f;
            textBox6.Text = Convert.ToString(x);
            textBox4.Text = Convert.ToString(y);
            textBox5.Text = Convert.ToString(t);
            //x = ux * t - k * ux * ux * t * t / 2;
            //y = -uy * t - g * t * t / 20;
            axis1.PixDraw(x, y, Color.Blue, 1);
            if (y <= 0)
            {
                timer2.Stop();
                x = 0; y = 0; t = 0;
            }
           
           axis1.StatToPic();
        }

        private void Button3_MouseClick(object sender, MouseEventArgs e)
        {
            a = (float)Convert.ToDouble(textBox2.Text);
            ux = (float)(Convert.ToDouble(textBox1.Text) * Math.Cos(a*Math.PI/180 ));
            uy = (float)(Convert.ToDouble(textBox1.Text) * Math.Sin(-a*Math.PI/180 ));
            m = (float)(Convert.ToDouble(textBox3.Text));
            timer2.Interval = 1;
            timer2.Start();
            axis1.Refresh();
        }

        private void Button2_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            x = 0; y = 0; t = 0; 
        }

        private void Axis1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(30);
            textBox2.Text = Convert.ToString(45);
            textBox3.Text = Convert.ToString(1);
            axis1.Axis_Type = 3;
            axis1.x_Name = "Ox";
            axis1.y_Name = "Oy";
            axis1.x_Base = 1000;
            axis1.y_Base = 1000;
            axis1.Pix_Size = 0.0001f;
            axis1.AxisDraw();
            axis1.PixDraw(x, y, Color.Blue, 1);
            axis1.StatToPic();
            axis1.Refresh();
        }

        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            a = (float)Convert.ToDouble(textBox2.Text);
            ux = (float)(Convert.ToDouble(textBox1.Text) * Math.Cos(a * Math.PI / 180));
            uy = (float)(Convert.ToDouble(textBox1.Text) * Math.Sin(-a * Math.PI / 180));
            timer1.Interval = 10;
            timer1.Start();
            axis1.Refresh();

        }

        public Form1()
        {
            InitializeComponent();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            t = t + 0.1f;
            x = ux * t;
            y = -uy * t - g * t * t / 20;
            textBox6.Text = Convert.ToString(x);
            textBox4.Text = Convert.ToString(y);
            textBox5.Text = Convert.ToString(t);
            if (y <= 0)
            {
                timer1.Stop();
                x = 0; y = 0; t = 0;
            }
            axis1.PixDraw(x, y, Color.Red, 1);
            axis1.StatToPic();
        }
    }
}
