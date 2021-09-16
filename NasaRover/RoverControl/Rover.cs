

using System;
using System.Collections.Generic;
using NasaRover.Utils;

namespace NasaRover.RoverControl
{
    public sealed class Rover : IRover
    {
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public string CurrentHeading { get; set; }
        public TerrainInfo TerrainInfo { get; set; }

        public Rover(int currentX, int currentY, string currentHeading, TerrainInfo terrainInfo)
        {
            CurrentX = currentX;
            CurrentY = currentY;
            CurrentHeading = currentHeading;
            TerrainInfo = terrainInfo;
        }

        public bool DeployRover()
        {
            if (!TerrainInfo.IsInTerrain(CurrentX, CurrentY))
            {
                return false;
            }

            return true;
        }

        public string Move()
        {
            switch (CurrentHeading)
            {
                case Heading.North:
                    return MoveNorth();

                case Heading.East:
                    return MoveEast();

                case Heading.South:
                    return MoveSouth();

                case Heading.West:
                    return MoveWest();

                default:
                    return $"An unexpected error occurred!";
            }
        }

        // Rotation Part
        public void Rotate(string direction)
        {
            if (direction == Direction.Left)
            {
                TurnLeft();
            }
            else
            {
                TurnRight();
            }
        }

        private void TurnRight()
        {
            switch (CurrentHeading)
            {
                case Heading.North:
                    CurrentHeading = Heading.East;
                    break;

                case Heading.West:
                    CurrentHeading = Heading.North;
                    break;

                case Heading.South:
                    CurrentHeading = Heading.West;
                    break;

                case Heading.East:
                    CurrentHeading = Heading.South;
                    break;

                default: break;
            }
        }

        private void TurnLeft()
        {
            switch (CurrentHeading)
            {
                case Heading.North:
                    CurrentHeading = Heading.West;
                    break;

                case Heading.West:
                    CurrentHeading = Heading.South;
                    break;

                case Heading.South:
                    CurrentHeading = Heading.East;
                    break;

                case Heading.East:
                    CurrentHeading = Heading.North;
                    break;

                default: break;
            }
        }

        // Movement Part
        private string MoveNorth()
        {
            if (TerrainInfo.IsInTerrain(CurrentX, CurrentY + 1))
            {
                CurrentY++;
                return String.Empty;
            }
            else
            {
                return $"Cannot go any further!(Out of bounds)";
            }
        }

        private string MoveEast()
        {
            if (TerrainInfo.IsInTerrain(CurrentX + 1, CurrentY))
            {
                CurrentX++;
                return String.Empty;
            }
            else
            {
                return $"Cannot go any further!(Out of bounds)";
            }
        }

        private string MoveSouth()
        {
            if (TerrainInfo.IsInTerrain(CurrentX, CurrentY - 1))
            {
                CurrentY--;
                return String.Empty;
            }
            else
            {
                return $"Cannot go any further!(Out of bounds)";

            }
        }

        private string MoveWest()
        {
            if (TerrainInfo.IsInTerrain(CurrentX - 1, CurrentY))
            {
                CurrentX--;
                return String.Empty;
            }
            else
            {
                return $"Cannot go any further!(Out of bounds)";
            }
        }

    }
}