#include <math.h>

#define DLLTESTWITHEXPORT_API __declspec(dllexport)


// Этот класс прямоугольника экспортирован из библиотеки DLL
class Rectangle {
public:
	Rectangle(double a, double b)	//создание прямоугольника, зная длину 2-х сторон
	{		
		side_1 = a;
		side_2 = b;
		square = side_1 * side_2;
	}
	double Square()
	{
		return square;
	}
private:
	double side_1, side_2, square;
};

extern "C" DLLTESTWITHEXPORT_API void* CreateRectangle(double a, double b)
{
	return (void*) new Rectangle(a,b);
}

extern "C" DLLTESTWITHEXPORT_API double SquareRectangle(Rectangle* rect)
{
	return rect->Square();
}


// Этот класс треугольника экспортирован из библиотеки DLL
class Triangle {
public:
	Triangle(double a, double h)    //создание треугольника, зная ширину основания и высоту
	{
		base = a;
		height = h;
		square = base * height / 2;
		side_1 = 0;
		side_2 = 0;
		side_3 = 0;
		semiperimeter = 0;
	}
	Triangle(double a, double b, double c)    //создание треугольника, зная длину всех 3-х сторон
	{
		side_1 = a;
		side_2 = b;
		side_3 = c;
		semiperimeter = (a + b + c)/2;
		square = sqrt(semiperimeter * (semiperimeter - side_1) * (semiperimeter - side_2) * (semiperimeter - side_3));
		base = 0;
		height = 0;
	}
	double Square()
	{
		return square;
	}
private:
	double side_1, side_2, side_3, base, height, semiperimeter, square;
};

extern "C" DLLTESTWITHEXPORT_API void* CreateTriangle(double a, double h)
{
	return (void*) new Triangle(a, h);
}

extern "C" DLLTESTWITHEXPORT_API void* CreateTriangleHeron(double a, double b, double c)
{
	return (void*) new Triangle(a, b, c);
}

extern "C" DLLTESTWITHEXPORT_API double SquareTriangle(Triangle* tr)
{
	return tr->Square();
}


