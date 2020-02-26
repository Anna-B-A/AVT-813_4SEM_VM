using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_IM
{
    class Generator
    {
        public Generator(int n, double m, double G)
        {
            this.G = G;
            this.m = m;
            this.n = n;
        }

        public double getCLT()
        {
            double v, z, x, r;

            v = 0;

            for (int i = 0; i < this.n; i++)
            {
                r = rand.NextDouble();
                v += r;
            }

            z = (v - ((double)n / 2)) / Math.Sqrt(((double)n / 12));
            
            x = z * this.G + this.m;

            return x;
        }

        public double getPre()
        {
            double Y;
            double Sum = 0;

            for (int i = 0;i < n;i++)
            {
                Sum += Math.Abs(2 * rand.NextDouble() - 1);
            }

            Y = Math.Sqrt(3 / (n * G * Sum)) + m;

            return Y;
        }

        static Random rand = new Random();
        private int n;
        private double m;
        private double G;

    }
}
