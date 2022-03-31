using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    interface IShape
    {
        int getX();
        int getY();
        int getArea();
        string getDescription();
    }
}
