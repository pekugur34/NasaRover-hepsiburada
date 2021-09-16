

using System;
using System.Text.RegularExpressions;
using NasaRover.Utils;

namespace NasaRover.RoverControl
{
    public sealed class RoverController
    {
        private static readonly Regex Validator = new Regex(@"^[lLrRmM]+$");
        private const string Move = "M";

        public RoverController()
        {

        }

        public string ExecuteInstructions(Rover rover, string instructions)
        {
            var controlResult = ControlRoverAndInstructions(rover, instructions);

            if (controlResult != String.Empty)
            {
                return controlResult;
            }

            return DoInstructions(rover, instructions);
        }

        private string DoInstructions(Rover rover, string instructions)
        {
            var instructionString = "";

            foreach (var instruction in instructions)
            {
                instructionString = instruction.ToString();

                if (instructionString == Direction.Left || instructionString == Direction.Right)
                {
                    rover.Rotate(instructionString);
                }

                var moveResult = ControlRoverMove(rover, instructionString);

                if(moveResult != String.Empty)
                {
                    return moveResult;
                }
            }

            return String.Empty;
        }

        private string ControlRoverMove(Rover rover, string instructionString)
        {

            if (instructionString == Move)
            {
                var moveResult = rover.Move();

                if (moveResult != String.Empty)
                {
                    return moveResult;
                }

                return String.Empty;
            }

            return String.Empty;
        }

        private string ControlRoverAndInstructions(Rover rover, string instructions)
        {
            if (!rover.DeployRover())
            {
                return "Give valid coordinates!";
            }

            if (!IsValidInstructions(instructions))
            {
                return "Give a valid instruction set!";
            }

            return String.Empty;
        }

        private static bool IsValidInstructions(string str)
        {
            return Validator.IsMatch(str);
        }
    }
}