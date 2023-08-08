public class Point
{
    public double X
    {
        get;
        set;
    }
    public double Y
    {
        get;
        set;
    }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}

public abstract class Triangle
{
    protected Point PointA
    {
        get;
        set;
    }
    protected Point PointB
    {
        get;
        set;
    }
    protected Point PointC
    {
        get;
        set;
    }

    public Triangle(Point pointA, Point pointB, Point pointC)
    {
        PointA = pointA;
        PointB = pointB;
        PointC = pointC;
    }

    public abstract double CalculateArea();

    private bool IsPythagorean(double side1, double side2, double hypotenuse)
    {
        return Math.Abs(Math.Pow(side1, 2) + Math.Pow(side2, 2) - Math.Pow(hypotenuse, 2)) == 0;
    }
    public bool IsRightTriangle()
    {
        double sideAB = Math.Sqrt(Math.Pow(PointB.X - PointA.X, 2) + Math.Pow(PointB.Y - PointA.Y, 2));
        double sideBC = Math.Sqrt(Math.Pow(PointC.X - PointB.X, 2) + Math.Pow(PointC.Y - PointB.Y, 2));
        double sideCA = Math.Sqrt(Math.Pow(PointA.X - PointC.X, 2) + Math.Pow(PointA.Y - PointC.Y, 2));

        return IsPythagorean(sideAB, sideBC, sideCA) || IsPythagorean(sideBC, sideCA, sideAB) || IsPythagorean(sideCA, sideAB, sideBC);
    }

    public bool IsEquilateralTriangle()
    {
        double sideAB = Math.Sqrt(Math.Pow(PointB.X - PointA.X, 2) + Math.Pow(PointB.Y - PointA.Y, 2));
        double sideBC = Math.Sqrt(Math.Pow(PointC.X - PointB.X, 2) + Math.Pow(PointC.Y - PointB.Y, 2));
        double sideCA = Math.Sqrt(Math.Pow(PointA.X - PointC.X, 2) + Math.Pow(PointA.Y - PointC.Y, 2));

        return Math.Abs(sideAB - sideBC) < 0.0001 && Math.Abs(sideBC - sideCA) < 0.0001;
        //return sideAB == sideBC && sideBC == sideCA;
    }

    public bool IsIsoscelesTriangle()
    {
        double sideAB = Math.Sqrt(Math.Pow(PointB.X - PointA.X, 2) + Math.Pow(PointB.Y - PointA.Y, 2));
        double sideBC = Math.Sqrt(Math.Pow(PointC.X - PointB.X, 2) + Math.Pow(PointC.Y - PointB.Y, 2));
        double sideCA = Math.Sqrt(Math.Pow(PointA.X - PointC.X, 2) + Math.Pow(PointA.Y - PointC.Y, 2));

        return sideAB == sideBC || sideBC == sideCA || sideCA == sideAB;
    }
}

public class RightTriangle : Triangle
{
    public RightTriangle(Point pointA, Point pointB, Point pointC) : base(pointA, pointB, pointC)
    {
        if (!IsRightTriangle())
        {
            throw new ArgumentException("It's not a right triangle");
        }
    }

    public override double CalculateArea()
    {
        double sideAB = Math.Sqrt(Math.Pow(PointB.X - PointA.X, 2) + Math.Pow(PointB.Y - PointA.Y, 2));
        double sideBC = Math.Sqrt(Math.Pow(PointC.X - PointB.X, 2) + Math.Pow(PointC.Y - PointB.Y, 2));
        double sideCA = Math.Sqrt(Math.Pow(PointA.X - PointC.X, 2) + Math.Pow(PointA.Y - PointC.Y, 2));

        double area = 0.5 * sideAB * sideBC;
        return area;
    }
}

public class EquilateralTriangle : Triangle
{
    public EquilateralTriangle(Point pointA, Point pointB, Point pointC) : base(pointA, pointB, pointC)
    {
        if (!IsEquilateralTriangle())
        {
            throw new ArgumentException("It's not an equilateral triangle");
        }
    }

    public override double CalculateArea()
    {
        double sideAB = Math.Sqrt(Math.Pow(PointB.X - PointA.X, 2) + Math.Pow(PointB.Y - PointA.Y, 2));

        double area = (Math.Sqrt(3) / 4) * Math.Pow(sideAB, 2);
        return area;
    }
}

public class IsoscelesTriangle : Triangle
{
    public IsoscelesTriangle(Point pointA, Point pointB, Point pointC) : base(pointA, pointB, pointC)
    {
        if (!IsIsoscelesTriangle())
        {
            throw new ArgumentException("It's not an isosceles triangle");
        }
    }

    public override double CalculateArea()
    {
        double sideAB = Math.Sqrt(Math.Pow(PointB.X - PointA.X, 2) + Math.Pow(PointB.Y - PointA.Y, 2));
        double sideBC = Math.Sqrt(Math.Pow(PointC.X - PointB.X, 2) + Math.Pow(PointC.Y - PointB.Y, 2));
        double sideCA = Math.Sqrt(Math.Pow(PointA.X - PointC.X, 2) + Math.Pow(PointA.Y - PointC.Y, 2));

        double height = Math.Sqrt(Math.Pow(sideCA, 2) - Math.Pow(sideAB / 2, 2));
        double area = 0.5 * sideAB * height;
        return area;
    }
}

public class ArbitraryTriangle : Triangle
{
    public ArbitraryTriangle(Point pointA, Point pointB, Point pointC) : base(pointA, pointB, pointC)
    {
    }

    public override double CalculateArea()
    {
        double sideAB = Math.Sqrt(Math.Pow(PointB.X - PointA.X, 2) + Math.Pow(PointB.Y - PointA.Y, 2));
        double sideBC = Math.Sqrt(Math.Pow(PointC.X - PointB.X, 2) + Math.Pow(PointC.Y - PointB.Y, 2));
        double sideCA = Math.Sqrt(Math.Pow(PointA.X - PointC.X, 2) + Math.Pow(PointA.Y - PointC.Y, 2));

        //Формула Герона
        double semiperimeter = (sideAB + sideBC + sideCA) / 2;
        double area = Math.Sqrt(semiperimeter * (semiperimeter - sideAB) * (semiperimeter - sideBC) * (semiperimeter - sideCA));

        return area;
    }
}

class Program
{
    static void Main()
    {
        // Создание треугольников разных типов
        Triangle[] triangles = new Triangle[]
        {
            new RightTriangle(new Point(3, 0), new Point(0, 0), new Point(0, 4)),
            new EquilateralTriangle(new Point(0, 0), new Point(1, 0), new Point(0.5, Math.Sqrt(3) / 2)),
            new IsoscelesTriangle(new Point(0, 0), new Point(4, 0), new Point(2, 3)),
            new ArbitraryTriangle(new Point(0, 0), new Point(3, 0), new Point(1, 4))
        };

        // Вычисление общей площади всех треугольников
        double totalArea = CalculateTotalArea(triangles);
        Console.WriteLine($"Общая площадь всех треугольников: {totalArea}");

    }

    static double CalculateTotalArea(Triangle[] triangles)
    {
        double totalArea = 0;

        foreach (Triangle triangle in triangles)
        {
            totalArea += triangle.CalculateArea();
        }

        return totalArea;
    }
}