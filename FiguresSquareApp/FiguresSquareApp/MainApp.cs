using System;
using System.Collections.Generic;
using System.Text;
using FiguresSquare;

namespace FiguresSquareApp
{
    internal class MainApp
    {
        static void Main(string[] args)
        {
            char variantMenu;
            do
            {
                double side_1, side_2, side_3, base_tr, height;
                Console.WriteLine("\nВыберите, какую фигуру хотите создать и вычислить для неё площадь:\n" +
                    "1. Прямоугольник\n" +
                    "2. Треугольник\n" +
                    "3. Треугольник с помощью формулы Герона\n" +
                    "4. Выход\n");
                if (!char.TryParse(Console.ReadLine(), out variantMenu))
                {
                    Console.WriteLine("Введенный символ некорректен!\n");
                    continue;
                }

                switch (variantMenu)
                {
                    case '1':   //прямоугольник
                        {
                            Console.Write("\nВведите значение для первой стороны прямоугольника ");
                            if (!double.TryParse(Console.ReadLine(), out side_1))
                            {
                                side_1 = 5.9;
                                Console.WriteLine("Введено некорректное значение для первой стороны прямоугольника,\nустанавлию длину 5,9");
                            }
                            Console.Write("\nВведите значение для второй стороны прямоугольника ");
                            if (!double.TryParse(Console.ReadLine(), out side_2))
                            {
                                side_2 = 10.2;
                                Console.WriteLine("Введено некорректное значение для второй стороны прямоугольника,\nустанавлию длину 10,2");
                            }
                            //IntPtr rectangle = CreateRectangle(side_1, side_2);
                            Rectangle rectangle = new Rectangle(side_1, side_2);
                            Console.WriteLine("\nПлощадь прямоугольника с введенными значениями сторон равна: " + rectangle.Square());
                            break;
                        }
                    case '2':   //треугольник с тривиальным вычислением площади
                        {
                            Console.Write("\nВведите длину основания треугольника ");
                            if (!double.TryParse(Console.ReadLine(), out base_tr))
                            {
                                base_tr = 8.5;
                                Console.WriteLine("Введено некорректное значение длины основания треугольника,\nустанавлию длину 8,5");
                            }
                            Console.Write("\nВведите длину высоты треугольника ");
                            if (!double.TryParse(Console.ReadLine(), out height))
                            {
                                height = 3.7;
                                Console.WriteLine("Введено некорректное значение высоты треугольника,\nустанавлию длину 3,7");
                            }
                            //IntPtr triangle = CreateTriangle(base_tr, height);
                            Triangle triangle = new Triangle(base_tr, height);
                            Console.WriteLine("\nПлощадь треугольника с введенными значениями сторон равна: " + triangle.Square());
                            break;
                        }
                    case '3':   //треугольник с вычислением площади через формулу Герона
                        {
                            Console.Write("\nВведите значение для первой стороны треугольника ");
                            if (!double.TryParse(Console.ReadLine(), out side_1))
                            {
                                side_1 = 2.5;
                                Console.WriteLine("Введено некорректное значение для первой стороны треугольника,\nустанавлию длину 8,5");
                            }
                            Console.Write("\nВведите значение для второй стороны треугольника ");
                            if (!double.TryParse(Console.ReadLine(), out side_2))
                            {
                                side_2 = 4.9;
                                Console.WriteLine("Введено некорректное значение для второй стороны треугольника,\nустанавлию длину 3,7");
                            }
                            Console.Write("\nВведите значение для третьей стороны треугольника ");
                            if (!double.TryParse(Console.ReadLine(), out side_3))
                            {
                                side_3 = 6.3;
                                Console.WriteLine("Введено некорректное значение для третьей стороны треугольника,\nустанавлию длину 3,7");
                            }
                            //IntPtr triangleHeron = CreateTriangleHeron(side_1, side_2, side_3);
                            Triangle triangle = new Triangle(side_1, side_2, side_3);
                            Console.WriteLine("\nПлощадь треугольника с введенными значениями сторон равна: " + triangle.Square());
                            break;
                        }
                    default:
                        {
                            if (variantMenu != '4') Console.WriteLine("Введенный символ некорректен!\n");
                            break;
                        }
                }

            } while (variantMenu != '4');

            Console.Write("\nВы вышли, для закрытия этого окна нажмите любую кнопку...");
            Console.ReadKey();
        }
    }

}
