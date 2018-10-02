namespace Shapes
{
    public class Square : IShape
    {
        private int v;

        public Square(int v)
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
