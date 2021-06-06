namespace Backups
{
    class PointException : System.Exception
    {
        public PointException() : base("this is not a real recovery point.") {}
    }
}
