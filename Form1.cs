using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using info.lundin.math;

namespace GraficadorV1_P20
{
    public partial class Form1 : Form
    {
        double xi,x,y,y2, xf;
        string fx,fx2;

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        int n;

        private void firmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("WFRuizSJ.exe");
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btGP_Click(object sender, EventArgs e)
        {
            double h;
            double a, r;

            Entrada();
            n = chart3.Width;
            h = (xf - xi) / n;
            chart3.Series["Series1"].Points.Clear();
            listBoxSalida.Items.Clear();
            for (int k = 0; k <= n; k++)
            {
                a = xi + k * h;
                r = fu(a, fx);
                x = r * Math.Cos(a);
                y = r * Math.Sin(a);
                chart3.Series["Series1"].Points.AddXY(x, y);
                listBoxSalida.Items.Add(x + " \t " + y);
            }
        }

        private void BTGParametricas_Click(object sender, EventArgs e)
        {
            //Funciones Paramétricas
            double h,t;
            Entrada();
            n = chart4.Width;
            h = (xf - xi) / n;
            chart4.Series["Series1"].Points.Clear();
            listBoxSalida.Items.Clear();
            for (int k = 0; k <= n; k++)
            {
                t = xi + k * h;
                x = Math.Sin(t); //x = fu(t, fx);
                y = Math.Cos(t); //y = fu(t, fx2);
                chart4.Series["Series1"].Points.AddXY(x, y);
                listBoxSalida.Items.Add(x + " \t " + y);
            }
        }

        private void btLissajius_Click(object sender, EventArgs e)
        {
            //Funciones de LISSAJIUS
            double h, w1, w2, A, B,t;
            Entrada();
            n = chart4.Width;
            h = (xf - xi) / n;
            chart4.Series["Series1"].Points.Clear();
            A = B = 5;
            w2 = 3.14;
            w1 = 4 * w2;
            listBoxSalida.Items.Clear();
            for (int k = 0; k <= n; k++)
            {
                t = xi + k * h;
                x = A * Math.Sin(w1 * t); //x = fu(t, fx);
                y = B * Math.Sin(w2 * t); //y = fu(t, fx2);
                chart4.Series["Series1"].Points.AddXY(x, y);
                listBoxSalida.Items.Add(x + " \t " + y);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btGY1Y2_Click(object sender, EventArgs e)
        {
            //Multifuncion
             try{ 
            double h;
            Entrada();
            n = chart1.Width;
            h = (xf - xi) / n;
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series2"].Points.Clear();
            listBoxSalida.Items.Clear();
            listBoxSalida2.Items.Clear();
                for (int k = 0; k <= n; k++)
            {
                x = xi + k * h;
                y = fu(x, fx);
                y2 = fu(x, fx2);
                chart1.Series["Series1"].Points.AddXY(x, y);
                chart1.Series["Series2"].Points.AddXY(x, y2);
                listBoxSalida.Items.Add(x + " \t " + y);
                listBoxSalida2.Items.Add(x + " \t " + y2);
            }
            }
              catch
             {
               MessageBox.Show("Error");
            }

        }

        private void buttonGraficar_Click(object sender, EventArgs e)
        {
            double h;
            xi=double.Parse(textBoxxi.Text);
            xf=double.Parse(textBoxxf.Text);
            fx=textBoxfx.Text;
            n = chart2.Width;
            h = (xf - xi) / n;
            chart2.Series["Series1"].Points.Clear();
            listBoxSalida.Items.Clear();
            for (int k=0; k<n; k++)
            {
                x = xi + k * h;
                y = fu(x, fx);
                chart2.Series["Series1"].Points.AddXY(x,y);
                listBoxSalida.Items.Add(x+" \t "+y);
            }
        }
        public double fu(double x, string fx)
        {
           
            ExpressionParser parser1=new ExpressionParser();
            parser1.Values.Add("x", x);
            return(parser1.Parse(fx));
          
        }
        public void Entrada()
        {
            xi = double.Parse(textBoxxi.Text);
            xf = double.Parse(textBoxxf.Text);
            fx = textBoxfx.Text;
            fx2 = textBoxf2x.Text;

        }
    }
}
