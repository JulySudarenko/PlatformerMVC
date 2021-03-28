using static Level.DungeonTiles;

namespace Level
{
    internal class WaterTileManager : TileManager
    {
        private readonly int _waterLevel;

        public WaterTileManager(int widthMap, int heightMap, int waterLevel) : base(widthMap, heightMap)
        {
            _waterLevel = waterLevel - 1;
        }

        public override int[,] ReplaceTiles(int[,] map)
        {
            for (int x = 1; x < WidthMap - 1; x++)
            {
                if (map[x, _waterLevel] == (int) Empty)
                    map[x, _waterLevel] = (int) Water;
            }

            return map;
        }
    }
}
