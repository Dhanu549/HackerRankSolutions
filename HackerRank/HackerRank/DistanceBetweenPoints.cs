using System;

namespace HackerRank
{
    public class DistanceBetweenPoints
    {
    }
    public class Point2D
    {
        public double x, y;
        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double dist2D(Point2D p)
        {
            return Math.Sqrt((p.x - x) * (p.x - x) + (p.y - y) * (p.y - y));
        }

        public virtual void printDistance(double d)
        {
            Console.WriteLine("2D distance = " + (int)Math.Ceiling(d));
        }
    }
    public class Point3D : Point2D
    {
        public double z;
        public Point3D(int x, int y, int z) : base(x, y)
        {
            this.z = z;
        }

        public double dist3D(Point3D p)
        {
            return Math.Sqrt((p.x - x) * (p.x - x) + (p.y - y) * (p.y - y) + (p.z - z) * (p.z - z));
        }

        public override void printDistance(double d)
        {
            Console.WriteLine("3D distance = " + (int)Math.Ceiling(d));
        }
    }
}
