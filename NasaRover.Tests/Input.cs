
using System.Collections.Generic;
using NasaRover.Input;
using Xunit;

namespace NasaRover.Tests
{
    public sealed class Input
    {
        [Theory]
        [MemberData(nameof(RoverTestData))]
        public void TestRoverInput(string roverHeading, bool expectedHeading)
        {
            var actualHeading = InputController.IsValidRoverInput(roverHeading);

            Assert.Equal(expectedHeading, actualHeading);

        }

        [Theory]
        [MemberData(nameof(InstructionTestData))]
        public void TestInstructionInput(string instructionSet, bool expectedInstructionSet)
        {
            var actualHeading = InputController.IsValidInstructions(instructionSet);

            Assert.Equal(expectedInstructionSet, actualHeading);

        }

        public static IEnumerable<object[]> RoverTestData =>
             new List<object[]>
             {
                new object[] { "N", true },
                new object[] { "S", true },
                new object[] { "W", true },
                new object[] { "E", true },
                new object[] { " ", false },
                new object[] { "", false },
                new object[] { "ERT", false },
                new object[] { "11 2", false }
             };

        public static IEnumerable<object[]> InstructionTestData =>
             new List<object[]>
             {
                new object[] { "MMRLRRRM", true },
                new object[] { "L", true },
                new object[] { "RM", true },
                new object[] { "R", true },
                new object[] { "M", true },
                new object[] { " ", false },
                new object[] { "", false },
                new object[] { "MMRLT", false },
                new object[] { "1 5 2", false },
                new object[] { "!!2", false },
            };
    }
}