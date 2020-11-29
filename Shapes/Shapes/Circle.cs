using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        Point center;
        double radius;

        public Circle(Point center, double radius)
        {
            this.center = center;
            this.radius = radius;
        }

        public override void Draw()
        {
            // code from screenDrawer circle
            throw new NotImplementedException();
        }
    }
}
