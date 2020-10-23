using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEnhancer
{
    class ContrastFilter : PixelFilter
    {
       public ContrastFilter(): base (new ContrastParameters()) { }

        public override string ToString()
        {
            return "Контраст";
        }

        public override Pixel ProcessPixel(Pixel originalPixel, IParameters parameters)
        {
           
            var chanelR = Trim((parameters as ContrastParameters).Cofficient * (originalPixel.R - 0.5) + 0.5);
            var chanelG = Trim((parameters as ContrastParameters).Cofficient * (originalPixel.G - 0.5) + 0.5);
            var chanelB = Trim((parameters as ContrastParameters).Cofficient * (originalPixel.B - 0.5) + 0.5);

            double Trim(double chanel)
            {
                if (chanel > 1)
                    return 1;
                else if (chanel < 0)
                    return 0;

                return chanel;
            }

            return new Pixel(chanelR, chanelG, chanelB);
        }
    }
}
