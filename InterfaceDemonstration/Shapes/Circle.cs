namespace Shapes
{
    public class Circle : IShape
    {
        private int v;

        public Circle(int v)
        {
            this.v = v;
        }

        public int Sides => throw new System.NotImplementedException();

        public double Area()
        {
            throw new System.NotImplementedException();
        }

        public int CompareTo(IShape other)
        {
            throw new System.NotImplementedException();
        }

        public double Perimeter()
        {
            throw new System.NotImplementedException();
        }
    }
}
