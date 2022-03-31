using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    internal class Circle : ShapeBase
    {
        int r;
        public Circle(int x, int y, int r) : base(x, y)
        {
            this.r = r;
        }

        public override int getArea()
        {
            return (int)(Math.Pow(r, 2) * Math.PI);
        }

        public override string getDescription()
        {
            return "Circle";
        }

    }
}
