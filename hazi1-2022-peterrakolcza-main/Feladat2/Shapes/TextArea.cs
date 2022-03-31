using System;
using System.Collections.Generic;
using System.Text;
using Controls;

namespace Shapes
{
    internal class TextArea : Textbox, IShape
    {
        public TextArea(int x, int y, int w, int h) : base(x, y, w, h)
        {
        }

        public int getArea()
        {
            return GetWidth() * GetHeight();
        }

        public string getDescription()
        {
            return "TextArea";
        }


        public int getX()
        {
            return GetX();
        }

        public int getY()
        {
            return GetY();
        }
    }
}
