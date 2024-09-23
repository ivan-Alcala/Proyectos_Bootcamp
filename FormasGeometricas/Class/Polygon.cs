namespace Figuras2D.Class
{
    public abstract class Polygon : Shape2D
    {
        public int NumberOfSides { get; set; }

        public Polygon(int numberOfSides)
            : base()
        {
            NumberOfSides = numberOfSides;
        }
    }
}
