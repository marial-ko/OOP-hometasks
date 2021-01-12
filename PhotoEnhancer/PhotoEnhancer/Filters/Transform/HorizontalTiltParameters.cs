using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    public class HorizontalTiltParameters: IParameters
    {
        [ParameterInfo(Name = "Угол поворота в °", MinValue = -85,
            MaxValue = 85, DefailtValue = 0, Increment = 5)]
        public double AngleInDegrees { get; set; }
    }
}
