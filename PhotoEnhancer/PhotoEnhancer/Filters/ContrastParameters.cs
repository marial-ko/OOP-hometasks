﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class ContrastParameters: IParameters
    {
        public double Coefficient { get; set; }

        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo() {
                    Name = "Коэффициент",
                    MinValue = 0,
                    MaxValue = 10,
                    DefailtValue = 1,
                    Increment = 0.05
                    }
            };
        }

        public void SetValues(double[] values)
        {
            Coefficient = values[0];
        }
    }
}
