using static Level.DungeonTiles;

namespace Level
{
    internal class GrassTileManager : TileManager
    {
        public GrassTileManager(int widthMap, int heightMap) : base(widthMap, heightMap)
        {
        }

        public override int[,] ReplaceTiles(int[,] map)
        {
            for (int x = 1; x < WidthMap - 1; x++)
            {
                for (int y = 1; y < HeightMap - 1; y++)
                {
                    if (map[x, y] == (int) Dirt && map[x, y + 1] == (int) Empty)
                        map[x, y] = (int) Grass;
                }
            }

            return map;
        }
    }
}
