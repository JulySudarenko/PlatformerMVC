namespace Level
{
    internal abstract class TileManager
    {
        protected readonly int WidthMap;
        protected readonly int HeightMap;

        protected TileManager(int widthMap, int heightMap)
        {
            WidthMap = widthMap;
            HeightMap = heightMap;
        }

        public abstract int[,] ReplaceTiles(int[,] map);
    }
}
