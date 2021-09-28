using System;
using System.Collections.Generic;

namespace Midterm
{    
    class Program
    {
        static void Main(string[] args)
        {
            Circle c1 = new Circle(4);
            Circle c2 = new Circle(5);

            Rectangle r = new Rectangle(3, 2);
            
            ICompareShape<Circle> compareShape = new CompareShape<Shape>();
            Console.WriteLine(compareShape.CompareArea(c2, c1));

            //
            var myCars = new List<Automobile>
            {
                new Honda(),
                new Ford()
            };
            Automobile.PrintCars(myCars);
        }
    }

    public abstract class Automobile
    {
        public static void PrintCars(IList<Automobile> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }

    public class Honda : Automobile
    {
        public override string ToString()
        {
            return "Hi, Im a Honda";
        }
    }

    public class Ford : Automobile
    {
        public override string ToString()
        {
            return "Hi, Im a Ford";
        }
    }

    public class Shape
    {
        public virtual double Area{get{return 0;}}

        public override bool Equals(object obj)
	    {
            Shape s = obj as Shape;
            if (s == null)
                return false;
            else
                return Area == s.Area;
        }

        public override int GetHashCode() 
	    {
		    return (int)Area;
	    }
	}
 
    public class Circle:Shape
    {
        private double radius;
        public Circle(double radius){this.radius=radius;}
        public double Radius{get{return radius;}}
        public override double Area{get{return Math.PI * radius * radius;}}
    }

    public class Rectangle:Shape
    {
        private double width;
        private double length;
        public Rectangle(double width, double length)
        {
            this.width = width;
            this.length = length;
        }
        public double Width{get{return width;}}
        public double Length{get{return length;}}
        public override double Area{get{return this.width * this.length;}}
    }

    interface ICompareShape<in T>
    {
        bool CompareArea(T t1, T t2);
    }

    public class CompareShape<T>:ICompareShape<T>
    {
        public bool CompareArea(T t1, T t2) 
        {               
            return t1.Equals(t2);
        }
    }

}
