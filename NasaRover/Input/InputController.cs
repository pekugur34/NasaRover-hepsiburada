using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NasaRover.ViewModel;

namespace NasaRover.Input
{
    public sealed class InputController
    {
        private static readonly Regex HeadingValidator = new Regex(@"^[eEwWnNsS]+$");
        private static readonly Regex InstructionValidator = new Regex(@"^[lLrRmM]+$");

        public InputController()
        { }

        public InputBaseReturnViewModel GetInputBase()
        {
            var viewModel = new InputBaseReturnViewModel();

            var inputList = new List<InputBase>();

            var terrainInput = GetTerrainInput();

            if (terrainInput == null)
            {
                System.Console.WriteLine("Not valid values! Closing...");
                return viewModel;
            }

            while (true)
            {

                var roverInput = GetRoverInput();

                if(roverInput == null)
                {
                    System.Console.WriteLine("Not valid values! Closing...");
                    return viewModel;
                }

                if(roverInput.IsInputEnded)
                {
                    break;
                }

                var instructionInput = GetInstructionInput();

                if (instructionInput == null)
                {
                    System.Console.WriteLine("Not valid values! Closing...");
                    return viewModel;
                }
                

                inputList.Add(new InputBase
                {
                    InstructionInput = instructionInput,
                    RoverInput = roverInput,
                    TerrainInput = terrainInput
                });
            }

            viewModel.InputBases = inputList;
            viewModel.IsValidInput  = true;

            return viewModel;
        }

        private RoverInput GetRoverInput()
        {
            // System.Console.WriteLine("Enter rover values: (2 4 E etc.)");
            var roverInput = Console.ReadLine();

            if(String.IsNullOrEmpty(roverInput))
            {
                return new RoverInput
                {
                    IsInputEnded = true
                };
            }

            var roverInputSplitted = roverInput.Split(" ");

            if (roverInputSplitted.Length != 3
                            || !Int32.TryParse(roverInputSplitted[0], out var roverX)
                            || !Int32.TryParse(roverInputSplitted[1], out var roverY)
                            || !IsValidRoverInput(roverInputSplitted[2])
                            )
            {
                return null;
            }


            return new RoverInput
            {
                Heading = roverInputSplitted[2],
                X = roverX,
                Y = roverY
            };
        }

        private TerrainInput GetTerrainInput()
        {
            // System.Console.WriteLine("Enter terrain values: (4 6 etc.)");

            var terrainInput = Console.ReadLine();

            var terrainInputSplitted = terrainInput.Split(" ");

            if (terrainInputSplitted.Length != 2 || !Int32.TryParse(terrainInputSplitted[0], out var terrrainX)
                    || !Int32.TryParse(terrainInputSplitted[1], out var terrainY))
            {
                return null;
            }

            return new TerrainInput
            {
                X = terrrainX,
                Y = terrainY
            };
        }

        private InstructionInput GetInstructionInput()
        {
            // System.Console.WriteLine("Enter instruction set: (MMMRM etc.)");

            var instructionInput = Console.ReadLine().Trim();

            if (!IsValidInstructions(instructionInput))
            {
                return null;
            }

            return new InstructionInput
            {
                InstructionSet = instructionInput
            };
        }

        public static bool IsValidRoverInput(string str)
        {
            return HeadingValidator.IsMatch(str);
        }

        public static bool IsValidInstructions(string str)
        {
            return InstructionValidator.IsMatch(str);
        }
    }
}