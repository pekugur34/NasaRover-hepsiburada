
using System.Collections.Generic;
using NasaRover.Utils;
using Xunit;

namespace NasaRover.Tests
{
    public sealed class Rover
    {
        [Theory]
        [MemberData(nameof(TestData))]
        public void TestExecuteInstructions(int terrainX, int terrainY, int roverX, int roverY, string roverHeading, string instructionSet, int expectedX, int expectedY, string expectedHeading)
        {
            var roverController = new NasaRover.RoverControl.RoverController();

            var rover = new NasaRover.RoverControl.Rover(roverX, roverY, roverHeading, new TerrainInfo(terrainX, terrainY));
            roverController.ExecuteInstructions(rover, instructionSet);

            Assert.Equal(expectedX, rover.CurrentX);
            Assert.Equal(expectedY, rover.CurrentY);
            Assert.Equal(expectedHeading, rover.CurrentHeading);
        }

        public static IEnumerable<object[]> TestData =>
             new List<object[]>
             {
                new object[] { 5, 5, 1, 2, "N", "LMLMLMLMM", 1, 3, "N" }, 
                new object[] { 5, 5, 3, 3, "E", "MMRMMRMRRM", 5, 1, "E" }, 
                new object[] { 3, 2, 1, 1, "N", "MRMMRMMR", 3, 0, "W" }, 
                new object[] { 3, 2, 1, 1, "N", "MMMMMM", 1, 2, "N" } 
             };
    }
}