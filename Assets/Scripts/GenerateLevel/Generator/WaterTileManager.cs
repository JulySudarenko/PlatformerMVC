using static Level.DungeonTiles;

namespace Level
{
    internal class WaterTileManager : TileManager
     {
        private readonly int _waterLevel;

        public WaterTileManager(int widthMap, int heightMap, int waterLevel) : base(widthMap, heightMap)
        {
            _waterLevel = waterLevel;
        }
        
        public override int[,] ReplaceTiles(int[,] map)
        {
            for (int x = 1; x < WidthMap - 1; x++)
            {
                for (int y = _waterLevel - 1; y < _waterLevel; y++)
                {
                    if (map[x, y] == (int) Empty)
                        map[x, y] = (int) Water;
                }
            }

            return map;
        }
    }
}
