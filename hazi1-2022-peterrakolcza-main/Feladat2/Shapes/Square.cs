using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    internal class Square: ShapeBase
    {
        int a;

        public Square(int x, int y, int a) : base(x, y)
        {
            this.a = a;
        }

        public override int getArea()
        {
            return (int)(Math.Pow(a, 2));
        }

        public override string getDescription()
        {
            return "Square";
        }
    }
}
