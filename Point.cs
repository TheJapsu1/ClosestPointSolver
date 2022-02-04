using System;

public class Point
{
    public double X;
    public double Y;
    
    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
            
    /// <summary>
    /// Returns the distance between a and b.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    public static double Distance(Point a, Point b)
    {
        double num1 = a.X - b.X;
        double num2 = a.Y - b.Y;
        return Math.Sqrt(num1 * num1 + num2 * num2);
    }
}