using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class ShapeBase : IShape
    {
        protected int x;
        protected int y;

        public ShapeBase(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract int getArea();

        public virtual string getDescription()
        {
            return "ShapeBase";
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }
    }

}

