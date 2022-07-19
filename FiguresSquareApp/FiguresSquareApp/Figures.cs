using System;
using System.Runtime.InteropServices;

namespace FiguresSquare
{
    //класс прямоугольник
    public class Rectangle
    {
        [DllImport("FiguresSquareSharedLibrary", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr CreateRectangle(double a, double b);

        [DllImport("FiguresSquareSharedLibrary", CallingConvention = CallingConvention.Cdecl)]
        static extern double SquareRectangle(IntPtr rect);
        IntPtr rectangle;

        public Rectangle(double a, double b)
        {
            rectangle = CreateRectangle(a, b);
        }
        //метод для вычисления площади
        public double Square()
        {
            return SquareRectangle(rectangle);
        }
    }


    //класс треугольника
    public class Triangle
    {
        [DllImport("FiguresSquareSharedLibrary", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr CreateTriangle(double a, double h);

        [DllImport("FiguresSquareSharedLibrary", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr CreateTriangleHeron(double a, double b, double c);

        [DllImport("FiguresSquareSharedLibrary", CallingConvention = CallingConvention.Cdecl)]
        static extern double SquareTriangle(IntPtr tr);
        IntPtr triangle;
        public Triangle(double a, double h)
        {
            triangle = CreateTriangle(a, h);
        }
        public Triangle(double a, double b, double c)
        {
            triangle = CreateTriangleHeron(a, b, c);
        }
        //метод для вычисления площади
        public double Square()
        {
            return SquareTriangle(triangle);
        }
    }
}
