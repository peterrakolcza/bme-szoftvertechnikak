using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeInventory inventory = new ShapeInventory();

            inventory.AddShape(new Square(1, 4, 2));
            inventory.AddShape(new Circle(3, 1, 8));
            inventory.AddShape(new Circle(0, 0, 2));
            inventory.AddShape(new TextArea(1, 0, 150, 25));

            inventory.ListAllShape();


            Console.ReadKey();
        }
    }
}
