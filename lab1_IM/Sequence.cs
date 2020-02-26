﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_IM
{
    public class Sequence
    {
        private double[] sequence;
        private double[] frequency;
        private int size;
        private int n;
        private int interval;

        public Sequence(int size, int n, int interval)
        {
            sequence = new double[size];
            frequency = new double[interval];

            this.size = size;

            this.n = n;

            this.interval = interval;

        }

        public void initCLT(double m, double G)
        {
            Generator gen = new Generator(this.n, m, G);

            for(int i = 0;i < size;++i)
            {
                sequence[i] = gen.getCLT();
            }

            double Xmin, Xmax;
            double step;

            Xmin = sequence.Min();

            Xmax = sequence.Max();

            step = (Xmax - Xmin) / interval;

            for (int i = 0;i < interval; ++i)
            {
                frequency[i] = AddDate(sequence, Xmin + i * step, Xmin + (i + 1) * step);
            }
            
        }

        private int AddDate(double[] arr, double start, double end)
        {
            int count = 0;
            foreach (var x in arr)
            {
                if (x > start && x < end)
                {
                    count++;
                }
            }
            return count;
        }

        public void initPre(double m, double G)
        {
            Generator gen = new Generator(this.n, m, G);

            for (int i = 0; i < size; ++i)
            {
                sequence[i] = gen.getPre();
            }

            double Xmin, Xmax;
            double step;

            Xmin = sequence.Min();

            Xmax = sequence.Max();

            step = (Xmax - Xmin) / interval;

            for (int i = 0; i < interval; ++i)
            {
                frequency[i] = AddDate(sequence, Xmin + i * step, Xmin + (i + 1) * step);
            }

        }

        public double[] getFreque()
        {
            return this.frequency;
        }

        public double[] getMid()
        {
            double[] midX = new double[interval];
            
            double Xmin, Xmax;
            double step;
            
            Xmin = sequence.Min();
            Xmax = sequence.Max();
            
            step = (Xmax - Xmin) / interval;

            for (int i = 0;i < interval;++i)
            {
                midX[i] = Xmin + (i + 0.5) * step;
            }
            
            return midX;
        }

    }
}
