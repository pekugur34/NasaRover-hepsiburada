

namespace NasaRover.RoverControl
{
    // Nasa's rover's functionalities
    public interface IRover
    {
        bool DeployRover();
        string Move();
        void Rotate(string direction);
    }
}