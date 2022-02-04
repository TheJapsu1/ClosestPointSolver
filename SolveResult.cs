
public class SolveResult
{
    public Point ClosestPointOnLine;
    public double DistanceToClosestPoint;

    public SolveResult(Point closestPointOnLine, double distanceToClosestPoint)
    {
        ClosestPointOnLine = closestPointOnLine;
        DistanceToClosestPoint = distanceToClosestPoint;
    }
}