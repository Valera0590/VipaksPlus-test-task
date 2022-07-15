using System;
using System.Runtime.InteropServices;

namespace FiguresSquareLibrary
{
        //класс прямоугольник
    public class Rectangle
    {
        IRectangleMethods rectangleMethods;
        public Rectangle(double a, double b)
        {
                //в зависимости от операционной системы выбираем файл с динамической библиотекой
            if(Environment.OSVersion.Platform.ToString().ToUpper().Contains("WIN"))
            {
                rectangleMethods = new RectangleWin(a, b);
            }
            else
            {
                rectangleMethods = new RectangleLinux(a, b);
            }
        }
            //метод для вычисления площади
        public double Square()
        {
            return rectangleMethods.Square();
        }
    }

        //внутренний класс для прямоугольника под ОС Windows
    internal class RectangleWin:IRectangleMethods
    {
        [DllImport("FiguresSquareDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr CreateRectangle(double a, double b);

        [DllImport("FiguresSquareDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double SquareRectangle(IntPtr rect);
        IntPtr rectangle;

        public RectangleWin(double a, double b)
        {
            Create(a, b);
        }
        public void Create(double a, double b)
        {
            rectangle = CreateRectangle(a, b);
        }
            //метод для вычисления площади
        public double Square()
        {
            return SquareRectangle(rectangle);
        }
    }

        //внутренний класс для прямоугольника под ОС Linux
    internal class RectangleLinux:IRectangleMethods
    {
        [DllImport("libCMakeFiguresSquareSO.so", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr CreateRectangle(double a, double b);

        [DllImport("libCMakeFiguresSquareSO.so", CallingConvention = CallingConvention.Cdecl)]
        static extern double SquareRectangle(IntPtr rect);
        IntPtr rectangle;
        public RectangleLinux(double a, double b)
        {
            Create(a, b);
        }
        public void Create(double a, double b)
        {
            rectangle = CreateRectangle(a, b);
        }
            //метод для вычисления площади
        public double Square()
        {
            return SquareRectangle(rectangle);
        }
    }

        //интерфейс для использования методов определенного внутреннего класса
    internal interface IRectangleMethods
    {
        void Create(double a, double b);
        double Square();
    }

        //класс треугольника
    public class Triangle
    {
        ITriangleMethods triangleMethods;
        public Triangle(double a, double h)
        {
                //в зависимости от операционной системы выбираем файл с динамической библиотекой
            if (Environment.OSVersion.Platform.ToString().ToUpper().Contains("WIN"))
            {
                triangleMethods = new TriangleWin(a, h);
            }
            else
            {
                triangleMethods = new TriangleLinux(a, h);
            }
        }
        public Triangle(double a, double b, double c)
        {
                //в зависимости от операционной системы выбираем файл с динамической библиотекой
            if (Environment.OSVersion.Platform.ToString().ToUpper().Contains("WIN"))
            {
                triangleMethods = new TriangleWin(a, b, c);
            }
            else
            {
                triangleMethods = new TriangleLinux(a, b, c);
            }
        }
            //метод для вычисления площади
        public double Square()
        {
            return triangleMethods.Square();
        }
    }

        //внутренний класс для треугольника под ОС Windows
    internal class TriangleWin:ITriangleMethods
    {
        [DllImport("FiguresSquareDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr CreateTriangle(double a, double h);

        [DllImport("FiguresSquareDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr CreateTriangleHeron(double a, double b, double c);

        [DllImport("FiguresSquareDLL.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double SquareTriangle(IntPtr tr);
        IntPtr triangle;
        public TriangleWin(double a, double h)
        {
            Create(a, h);
        }
        public TriangleWin(double a, double b, double c)
        {
            Create(a, b, c);
        }
        public void Create(double a, double h)
        {
            triangle = CreateTriangle(a, h);
        }
        public void Create(double a, double b, double c)
        {
            triangle = CreateTriangleHeron(a, b, c);
        }
            //метод для вычисления площади
        public double Square()
        {
            return SquareTriangle(triangle);
        }
    }

        //внутренний класс для треугольника под ОС Linux
    internal class TriangleLinux:ITriangleMethods
    {
        [DllImport("libCMakeFiguresSquareSO.so", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr CreateTriangle(double a, double h);

        [DllImport("libCMakeFiguresSquareSO.so", CallingConvention = CallingConvention.Cdecl)]
        static extern IntPtr CreateTriangleHeron(double a, double b, double c);

        [DllImport("libCMakeFiguresSquareSO.so", CallingConvention = CallingConvention.Cdecl)]
        static extern double SquareTriangle(IntPtr tr);
        IntPtr triangle;
        public TriangleLinux(double a, double h)
        {
            Create(a, h);
        }
        public TriangleLinux(double a, double b, double c)
        {
            Create(a, b, c);
        }
        public void Create(double a, double h)
        {
            triangle = CreateTriangle(a, h);
        }
        public void Create(double a, double b, double c)
        {
            triangle = CreateTriangleHeron(a, b, c);
        }
            //метод для вычисления площади
        public double Square()
        {
            return SquareTriangle(triangle);
        }
    }

        //интерфейс для использования методов определенного внутреннего класса
    internal interface ITriangleMethods
    {
        void Create(double a, double b);
        void Create(double a, double b, double c);
        double Square();
    }
}
