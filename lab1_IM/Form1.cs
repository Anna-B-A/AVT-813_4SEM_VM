using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab1_IM
{
    public partial class Gen : Form
    {
        private Sequence sample;

        private double d;
        private double m;
        private int nn;
        private int nr;
        private int inter;

        public Gen()
        {
            InitializeComponent();
        }

        private void init()
        {
             d = Convert.ToDouble(this.textBox1.Text);
             m = Convert.ToDouble(this.textBox2.Text);
             nn = Convert.ToInt32(this.textBox3.Text);
             nr = Convert.ToInt32(this.textBox4.Text);
             inter = Convert.ToInt32(this.textBox5.Text);

             sample = new Sequence(nn, nr, inter);
        }

        private void DrawGist()
        {
            this.chart1.Series["point"].Points.Clear();

            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    sample.initCLT(m, Math.Sqrt(d));
                    break;
                case 1:
                    sample.initPre(m, Math.Sqrt(d));
                    break;
                default:
                    sample.initCLT(m, Math.Sqrt(d));
                    break;
            }

            double[] mid = sample.getMid();

            double[] fre = sample.getFreque();

            for (int i = 0; i < inter; ++i)
            {
                this.chart1.Series["point"].Points.AddXY(mid[i], fre[i] / nn);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            init();
            DrawGist();
        }
    }
}
