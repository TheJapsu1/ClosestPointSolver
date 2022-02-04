using System;

namespace ClosestPointSolver
{
    public class ClosestPointSolver
    {
        public SolveResult SolveLine(Point targetPoint, Point lineStart, Point lineEnd)
        {
            double a = targetPoint.X - lineStart.X;
            double b = targetPoint.Y - lineStart.Y;
            double c = lineEnd.X - lineStart.X;
            double d = lineEnd.Y - lineStart.Y;

            double dot = a * c + b * d;
            double lenSq = c * c + d * d;

            // Do not calculate if the line has a length of 0
            if (lenSq == 0)
            {
                Console.WriteLine($"Line with 0 length at {lineStart}, {lineEnd}");

                return null;
            }

            double param = dot / lenSq;

            double xx, yy;

            if (param < 0)
            {
                xx = lineStart.X;
                yy = lineStart.Y;
            }
            else if (param > 1)
            {
                xx = lineEnd.X;
                yy = lineEnd.Y;
            }
            else
            {
                xx = lineStart.X + param * c;
                yy = lineStart.Y + param * d;
            }

            // Calculate the point position deltas
            double dx = targetPoint.X - xx;
            double dy = targetPoint.Y - yy;

            // Get the closest point on the line
            Point closestPoint = new Point(targetPoint.X - dx, targetPoint.Y - dy);

            // Calculate the distance from the origin point to the closest point on the line
            double distance = Point.Distance(targetPoint, closestPoint);

            // Create instance of the result class and return it
            return new SolveResult(closestPoint, distance);
        }
        
        public SolveResult SolveArc(
            Point targetPoint,
            Point arcCenterPoint,
            Point arcStartPoint,
            Point arcEndPoint,
            double arcRadius)
        {
            // Calculate the point's distance from the circle's edge: https://math.stackexchange.com/a/127615
            
            double squared = Math.Sqrt(
                Math.Pow(targetPoint.X - arcCenterPoint.X, 2) +
                Math.Pow(targetPoint.Y - arcCenterPoint.Y, 2));
            
            double arcPointX = arcCenterPoint.X + arcRadius * ((targetPoint.X - arcCenterPoint.X) / squared);
            
            double arcPointY = arcCenterPoint.Y + arcRadius * ((targetPoint.Y - arcCenterPoint.Y) / squared);
            
            // Create a new instance of the Point-class for the closest point on the circle.
            Point closestPoint = new Point(arcPointX, arcPointY);
            
            // Check all the axis' one by one to see if the resulting position is inside the wanted arc.
            // If not, clamp it to the nearest endpoint on that axis:
            
            // If the point on the arc is left beyond the leftmost point of the arc
            if (closestPoint.X < Math.Min(arcStartPoint.X, arcEndPoint.X))
            {
                closestPoint.X = Math.Min(arcStartPoint.X, arcEndPoint.X);
            }
    
            // If the point on the arc is right beyond the rightmost point of the arc
            if (closestPoint.X > Math.Max(arcStartPoint.X, arcEndPoint.X))
            {
                closestPoint.X = Math.Max(arcStartPoint.X, arcEndPoint.X);
            }
            
            // If the point on the arc is below the lower point of the arc
            if (closestPoint.Y < Math.Min(arcStartPoint.Y, arcEndPoint.Y))
            {
                closestPoint.Y = Math.Min(arcStartPoint.Y, arcEndPoint.Y);
            }
    
            // If the point on the arc is above the upper point of the arc
            if (closestPoint.Y > Math.Max(arcStartPoint.Y, arcEndPoint.Y))
            {
                closestPoint.Y = Math.Max(arcStartPoint.Y, arcEndPoint.Y);
            }
    
            // Calculate the distance from the origin point to the closest point on the arc
            double distance = Point.Distance(targetPoint, closestPoint);
            
            // Create instance of the result class and return it
            return new SolveResult(closestPoint, distance);
        }
    }
}