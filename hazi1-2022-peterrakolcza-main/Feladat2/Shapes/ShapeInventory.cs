using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    internal class ShapeInventory
    {

        private List<IShape> shape;

        public ShapeInventory()
        {
            shape = new List<IShape>();
        }

        public void ListAllShape()
        {
            foreach (IShape shp in shape)
            {
                Console.WriteLine($"Alakzat típusa: {shp.getDescription()} \tX: {shp.getX()} \tY:{shp.getY()} \tAlakzat területe: {shp.getArea()}");
            }
        }

        public void AddShape(IShape shp)
        {
            shape.Add(shp);
        }
    }
}
