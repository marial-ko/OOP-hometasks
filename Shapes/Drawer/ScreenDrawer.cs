using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes;


namespace Drawer
{
    public static class ScreenDrawer
    {
        public static void DrawShapes(List<Shape> shapes)
        {
            shapes.Sort(new ShapeComparer());
            
            foreach (var shape in shapes)
                shape.Draw();

        }

    }
}
