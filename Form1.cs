using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Meta.Numerics;
using ScottPlot.Drawing;

namespace Diffusion_Calculation
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ml = textBox1.Text;
            string n = textBox2.Text;
            string h = textBox3.Text;
            string T = textBox4.Text;
            string kd = textBox5.Text;
            string De = textBox6.Text;
            string ro = textBox7.Text;
            string с = textBox8.Text;
            double ml1 = Convert.ToDouble(ml);
            double n1 = Convert.ToDouble(n);
            double h1 = Convert.ToDouble(h);
            double T1 = Convert.ToDouble(T);
            double kd1 = Convert.ToDouble(kd);
            double De1 = Convert.ToDouble(De);
            double ro1 = Convert.ToDouble(ro);
            double c1 = Convert.ToDouble(с);
            double r1 = 1 + (kd1 * ro1/n1);
            

            Directory.CreateDirectory(@"C:\DiffusionCalc\");
            File.AppendAllText(@"C:\DiffusionCalc\Conc_Length.txt", " " + Environment.NewLine);
            File.AppendAllText(@"C:\DiffusionCalc\Conc_Length.txt", "Time is ");
            File.AppendAllText(@"C:\DiffusionCalc\Conc_Length.txt", T1 + Environment.NewLine);
            File.AppendAllText(@"C:\DiffusionCalc\Conc_Length.txt", "--------------------" + Environment.NewLine);
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.XLabel("Length, m");
            formsPlot1.Plot.YLabel("Concentration, kg/m^3");
            for (int i = 1; i < 1000; i++)
            {
                double G1 = ml1 * i / 1000;
                double k1 = c1 * Math.Exp((n1 * r1 * G1) / h1 + (n1 * n1 * r1 * De1 * T1) / (h1 * h1))* Meta.Numerics.Functions.AdvancedMath.Erfc(G1/(2*Math.Sqrt(De1*T1/r1))+n1*Math.Sqrt(r1*De1*T1)/h1);
                File.AppendAllText(@"C:\DiffusionCalc\Conc_Length.txt", Convert.ToString(G1));
                File.AppendAllText(@"C:\DiffusionCalc\Conc_Length.txt", Convert.ToString(";"));
                File.AppendAllText(@"C:\DiffusionCalc\Conc_Length.txt", k1 + Environment.NewLine);
                double[] dataX = new double[] { G1 };
                double[] dataY = new double[] { k1 };
                formsPlot1.Plot.AddScatter(dataX, dataY);

            }
           

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ml = textBox1.Text;
            string n = textBox2.Text;
            string h = textBox3.Text;
            string T = textBox4.Text;
            string kd = textBox5.Text;
            string De = textBox6.Text;
            string ro = textBox7.Text;
            string с = textBox8.Text;
            double ml1 = Convert.ToDouble(ml);
            double n1 = Convert.ToDouble(n);
            double h1 = Convert.ToDouble(h);
            double T1 = Convert.ToDouble(T);
            double kd1 = Convert.ToDouble(kd);
            double De1 = Convert.ToDouble(De);
            double ro1 = Convert.ToDouble(ro);
            double c1 = Convert.ToDouble(с);
            double r1 = 1 + (kd1 * ro1 / n1);
            Directory.CreateDirectory(@"C:\DiffusionCalc\");
            File.AppendAllText(@"C:\DiffusionCalc\Conc_Time.txt", " " + Environment.NewLine);
            File.AppendAllText(@"C:\DiffusionCalc\Conc_Time.txt", "Distance is ");
            File.AppendAllText(@"C:\DiffusionCalc\Conc_Time.txt", ml1 + Environment.NewLine);
            File.AppendAllText(@"C:\DiffusionCalc\Conc_Time.txt", "--------------------" + Environment.NewLine);
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.XLabel("Time, days");
            formsPlot1.Plot.YLabel("Concentration, kg/m^3");
            for (int i = 0; i < 1000; i++)
            {
                double t1 = T1 * i / 1000;
                double k1 = c1 * Math.Exp((n1 * r1 * ml1) / h1 + (n1 * n1 * r1 * De1 * t1) / (h1 * h1)) * Meta.Numerics.Functions.AdvancedMath.Erfc(ml1 / (2 * Math.Sqrt(De1 * t1 / r1)) + n1 * Math.Sqrt(r1 * De1 * t1) / h1);
                File.AppendAllText(@"C:\DiffusionCalc\Conc_Time.txt", Convert.ToString(t1));
                File.AppendAllText(@"C:\DiffusionCalc\Conc_Time.txt", Convert.ToString(";"));
                File.AppendAllText(@"C:\DiffusionCalc\Conc_Time.txt", k1 + Environment.NewLine);
                double[] dataX = new double[] { t1 };
                double[] dataY = new double[] { k1 };
                formsPlot1.Plot.AddScatter(dataX, dataY);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
