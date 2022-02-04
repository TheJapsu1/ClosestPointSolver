using System;

namespace ClosestPointSolver
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ClosestPointSolver solver = new ClosestPointSolver();

            SolveResult lineResult = solver.SolveLine(
                new Point(123.456, 321.654),
                new Point(21.425, -425.645),
                new Point(-254.536, 105.425));

            SolveResult arcResult = solver.SolveArc(
                new Point(123.456, 321.654),
                new Point(21.425, -425.645),
                new Point(-254.536, 105.425),
                new Point(21.425, -425.645), 
                100);
            
            Console.WriteLine($"Closest point on line: {lineResult.ClosestPointOnLine}, Distance to closest point on line: {lineResult.DistanceToClosestPoint}");
            Console.WriteLine($"Closest point on arc: {arcResult.ClosestPointOnLine}, Distance to closest point on arc: {arcResult.DistanceToClosestPoint}");
        }
    }
}