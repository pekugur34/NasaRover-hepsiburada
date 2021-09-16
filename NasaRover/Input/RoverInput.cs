
namespace NasaRover.Input
{
    public sealed class RoverInput
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Heading { get; set; }
        public bool IsInputEnded { get; set; }
    }
}