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


        public void button1_Click(object sender, EventArgs e)
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
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.XLabel("Length, m");
            formsPlot1.Plot.YLabel("Concentration, kg/m^3");
            for (int i = 1; i < 1000; i++)
            {
                double G1 = ml1 * i / 1000;
                double k1 = c1 * Math.Exp((n1 * r1 * G1) / h1 + (n1 * n1 * r1 * De1 * T1) / (h1 * h1))* Meta.Numerics.Functions.AdvancedMath.Erfc(G1/(2*Math.Sqrt(De1*T1/r1))+n1*Math.Sqrt(r1*De1*T1)/h1);
                double[] dataX = new double[] { G1 };
                double[] dataY = new double[] { k1 };
                formsPlot1.Plot.AddScatter(dataX, dataY);
            }
           

        }

        public void label4_Click(object sender, EventArgs e)
        {

        }

        public void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        public void button2_Click(object sender, EventArgs e)
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
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.XLabel("Time, days");
            formsPlot1.Plot.YLabel("Concentration, kg/m^3");
            double[] arrt = new double[1000];
            for (int i = 0; i < 1000; i++)
            {
                double t1 = T1 * i / 1000;
                double k1 = c1 * Math.Exp((n1 * r1 * ml1) / h1 + (n1 * n1 * r1 * De1 * t1) / (h1 * h1)) * Meta.Numerics.Functions.AdvancedMath.Erfc(ml1 / (2 * Math.Sqrt(De1 * t1 / r1)) + n1 * Math.Sqrt(r1 * De1 * t1) / h1);
                double[] dataX = new double[] { t1 };
                double[] dataY = new double[] { k1 };
                formsPlot1.Plot.AddScatter(dataX, dataY);
                arrt [i] = t1;
            }                        
        }

        public void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        public void button4_Click(object sender, EventArgs e)
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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = sfd.FileName;
            for (int i = 0; i < 1000; i++)
            {
                double t1 = T1 * i / 1000;
                double k1 = c1 * Math.Exp((n1 * r1 * ml1) / h1 + (n1 * n1 * r1 * De1 * t1) / (h1 * h1)) * Meta.Numerics.Functions.AdvancedMath.Erfc(ml1 / (2 * Math.Sqrt(De1 * t1 / r1)) + n1 * Math.Sqrt(r1 * De1 * t1) / h1);
                File.AppendAllText(filename, Convert.ToString(t1));
                File.AppendAllText(filename, Convert.ToString(";"));
                File.AppendAllText(filename, Convert.ToString(k1)+Environment.NewLine);
            }
            // сохраняем текст в файл
            MessageBox.Show("File Saved");
        }

        public void button5_Click(object sender, EventArgs e)
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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = sfd.FileName;
            for (int i = 0; i < 1000; i++)
            {
                double G1 = ml1 * i / 1000;
                double k1 = c1 * Math.Exp((n1 * r1 * G1) / h1 + (n1 * n1 * r1 * De1 * T1) / (h1 * h1)) * Meta.Numerics.Functions.AdvancedMath.Erfc(G1 / (2 * Math.Sqrt(De1 * T1 / r1)) + n1 * Math.Sqrt(r1 * De1 * T1) / h1);
                File.AppendAllText(filename, Convert.ToString(G1));
                File.AppendAllText(filename, Convert.ToString(";"));
                File.AppendAllText(filename, Convert.ToString(k1) + Environment.NewLine);
            }
            // сохраняем текст в файл
            MessageBox.Show("File Saved");
        }

        public void button6_Click(object sender, EventArgs e)
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
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.XLabel("Time, days");
            formsPlot1.Plot.YLabel("Rate, kg/m^3*day");
            double[] arrt = new double[1000];
            for (int i = 0; i < 1000; i++)
            {
                double t1 = T1 * i / 1000;
                double k1 = c1 * Math.Exp((n1 * r1 * ml1) / h1 + (n1 * n1 * r1 * De1 * t1) / (h1 * h1)) * Meta.Numerics.Functions.AdvancedMath.Erfc(ml1 / (2 * Math.Sqrt(De1 * t1 / r1)) + n1 * Math.Sqrt(r1 * De1 * t1) / h1);
                double t2 = T1 * (i + 1) / 1000;
                double k2 = c1 * Math.Exp((n1 * r1 * ml1) / h1 + (n1 * n1 * r1 * De1 * t2) / (h1 * h1)) * Meta.Numerics.Functions.AdvancedMath.Erfc(ml1 / (2 * Math.Sqrt(De1 * t2/ r1)) + n1 * Math.Sqrt(r1 * De1 * t2) / h1);
                double rate = (k2 - k1) / (t2 - t1);
                double[] dataX = new double[] { (t1 + t2) / 2 };
                double[] dataY = new double[] { rate };
                formsPlot1.Plot.AddScatter(dataX, dataY);                
            }
        }

        private void Button_SaveRate_Click(object sender, EventArgs e)
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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = sfd.FileName;
            for (int i = 0; i < 1000; i++)
            {
                double t1 = T1 * i / 1000;
                double k1 = c1 * Math.Exp((n1 * r1 * ml1) / h1 + (n1 * n1 * r1 * De1 * t1) / (h1 * h1)) * Meta.Numerics.Functions.AdvancedMath.Erfc(ml1 / (2 * Math.Sqrt(De1 * t1 / r1)) + n1 * Math.Sqrt(r1 * De1 * t1) / h1);
                double t2 = T1 * (i + 1) / 1000;
                double k2 = c1 * Math.Exp((n1 * r1 * ml1) / h1 + (n1 * n1 * r1 * De1 * t2) / (h1 * h1)) * Meta.Numerics.Functions.AdvancedMath.Erfc(ml1 / (2 * Math.Sqrt(De1 * t2 / r1)) + n1 * Math.Sqrt(r1 * De1 * t2) / h1);
                double rate = (k2 - k1) / (t2 - t1);
                File.AppendAllText(filename, Convert.ToString((t1 + t2) / 2));
                File.AppendAllText(filename, Convert.ToString(";"));
                File.AppendAllText(filename, Convert.ToString(rate) + Environment.NewLine);
            }
            // сохраняем текст в файл
            MessageBox.Show("File Saved");
        }
    }
}
