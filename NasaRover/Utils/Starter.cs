
using System.Collections.Generic;
using NasaRover.Input;
using NasaRover.RoverControl;

namespace NasaRover.Utils
{
    public sealed class Starter
    {
        public static void Run()
        {
            var roverList = GetRovers();

            PrintRovers(roverList);
        }

        public static List<Rover> GetRovers()
        {
            var inputController = new InputController();
            var roverController = new RoverController();

            var roverList = new List<Rover>();

            var inputBase = inputController.GetInputBase();

            if(!inputBase.IsValidInput)
            {
                return roverList;
            }

            foreach (var input in inputBase.InputBases)
            {
                var rover = new Rover(input.RoverInput.X, input.RoverInput.Y, input.RoverInput.Heading, new TerrainInfo(input.TerrainInput.X, input.TerrainInput.Y));
                var result = roverController.ExecuteInstructions(rover, input.InstructionInput.InstructionSet);

                roverList.Add(rover);
            }

            return roverList;
        }

        private static void PrintRovers(List<Rover> roverList)
        {
            foreach (var rover in roverList)
            {
                System.Console.WriteLine($"{rover.CurrentX}{" "}{rover.CurrentY}{" "}{rover.CurrentHeading}");
            }
        }
    }
}