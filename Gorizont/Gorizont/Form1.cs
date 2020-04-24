namespace Gorizont
{
    public partial class Form1 : Form
    {
        public float GRAVITATIONAL_ACCELERATION = 9.81f;
        public float MASS = 1;
        public double MEDIUM_RESISTANCE_COEFFICIENT = 0.1f;
        public float CoordinateX=0;
        public float CoordinateY =0;
        public float VelocityX;
        public float VelocityY;
        public double Alpfa;
        public float Time = 0;
        private void Timer2_Tick(object sender, EventArgs e)
        {
            Time = Time + 0.1f;
            VelocityX = VelocityX - (float)(MEDIUM_RESISTANCE_COEFFICIENT * VelocityX * VelocityX / (2 * MASS)) * 0.01f;
            CoordinateX = CoordinateX + VelocityX * 0.1f;
            VelocityY = VelocityY - GRAVITATIONAL_ACCELERATION * 0.01f;
            CoordinateY = CoordinateY + VelocityY * 0.1f;
            axis1.PixDraw(CoordinateX, CoordinateY, Color.Blue, 1);
            if (CoordinateY < 0)
            {
                timer2.Stop();
                CoordinateX = 0; 
                CoordinateY = 0;
                Time = 0;
            }
           axis1.StatToPic();
           axis1.Refresh();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Time = Time + 0.1f;
            CoordinateX = VelocityX * Time;
            CoordinateY = VelocityY * Time - GRAVITATIONAL_ACCELERATION * Time * Time / 20;
            if (CoordinateY <= 0)
            {
                timer1.Stop();
                CoordinateX = 0;
                CoordinateY = 0;
                Time = 0;
            }
            axis1.PixDraw(CoordinateX, CoordinateY, Color.Red, 1);
            axis1.StatToPic();
            axis1.Refresh();
        }
        private void Button2_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            CoordinateX = 0;
            CoordinateY = 0;
            Time = 0; 
        }
        private void Axis1_Load(object sender, EventArgs e)
        {
            axis1.Axis_Type = 3;
            axis1.x_Name = "Ox";
            axis1.y_Name = "Oy";
            axis1.x_Base = 1000;
            axis1.y_Base = 1000;
            axis1.Pix_Size = 0.001f;
            axis1.AxisDraw();
            axis1.PixDraw(CoordinateX, CoordinateY, Color.Blue, 1);
            axis1.StatToPic();
            axis1.Refresh();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_MouseClick_1(object sender, MouseEventArgs e)
        {
            double.TryParse(textBox2.Text, out Alpfa);
            Alpfa *= Math.PI / 180;
            float.TryParse(textBox1.Text, out VelocityX);
            VelocityX *= (float)Math.Cos(Alpfa);
            VelocityY = (float)(VelocityX * Math.Sin(Alpfa) / Math.Cos(Alpfa));
            if (checkBox1.Checked == true)
            {
                timer2.Interval = 1;
                timer2.Start();
                axis1.Refresh();
            }
            if (checkBox1.Checked == false)
            {
                timer1.Interval = 1;
                timer1.Start();
            }
        }
    }
}
