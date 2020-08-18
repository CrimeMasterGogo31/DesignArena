using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory shapeFactory = new ShapeFactory();
            var circleObj = shapeFactory.GetData((int)Shape.Circle).DataItem as Circle;
            circleObj.GetInfo();

        }
    }

    interface IFactory
    {
        FactoryItem GetData(int type);
    }

    class FactoryItem
    {
        public FactoryItem(object dataItem)
        {
            this._dataItem = dataItem;
        }
        private object _dataItem;
        public object DataItem { get { return _dataItem; } }
    }

    abstract class AbstractFactory : IFactory
    {
        public abstract FactoryItem GetData(int type);

    }

    class ShapeFactory : AbstractFactory
    {
        public override FactoryItem GetData(int type)
        {
            FactoryItem factoryItem = null;
            switch ((Shape)type)
            {
                case Shape.Circle:
                    factoryItem = new FactoryItem(new Circle());
                    break;
            }

            return factoryItem;
        }
    }

    enum Shape
    {
        Circle = 1,
        Square = 2,
    }

    public class Circle
    {
        public void GetInfo()
        {
            Console.WriteLine(" Circle CLass");
        }
    }

    enum Color
    {
        Circle = 1,
        Square = 2,
    }

    public class Red
    {
        public void GetInfo()
        {
            Console.WriteLine(" Red CLass");
        }
    }
}
