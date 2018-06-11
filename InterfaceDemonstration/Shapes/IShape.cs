namespace Shapes
{
    public interface IShape
    {
        double Perimeter();
        double Area(); 
        int Sides { get; }
    }
}
