

namespace NasaRover.Utils
{
    public sealed class TerrainInfo
    {

        public int XTop { get; set; }
        public int YTop { get; set; }

        public TerrainInfo(int xTop, int yTop)
        {
            XTop = xTop;
            YTop = yTop;    
        }
        public bool IsInTerrain(int x, int y)
        {
            if(x < 0 || x > XTop) return false;
            if(y < 0 || y > YTop) return false;

            return true;
        }
    }
}