using Platformer;
using UnityEngine;
using static Level.DungeonTiles;

namespace Level
{
    internal class MapGenerator
    {
        private readonly int _sideBorders;
        private readonly int _widthMap;
        private readonly int _heightMap;
        private readonly int _factorSmooth;
        private readonly int _countWall;
        private readonly int _randomFillPercent;

        private readonly int[,] _map;

        public MapGenerator(LevelConfig config, int [,] map)
        {
            _widthMap = config.WidthMap;
            _heightMap = config.HeightMap;
            _factorSmooth = config.FactorSmooth;
            _randomFillPercent = config.RandomFillPercent;
            _sideBorders = config.SideBorders;
            _countWall = config.CountWall;
            _map = map;

        }

        public int [,] GenerateLevel()
        {
            RandomFillLevel();

            for (int i = 0; i < _factorSmooth; i++)
            {
                SmoothMap();
            }

            return _map;
        }

        private void RandomFillLevel()
        {
            var seed = Time.time.ToString();
            var pseudoRandom = new System.Random(seed.GetHashCode());

            for (var x = 0; x < _widthMap; x++)
            {
                for (var y = 0; y < _heightMap; y++)
                {
                    if (x <= 0 + _sideBorders || x >= _widthMap - _sideBorders || y == 0 || y == _heightMap - 1)
                        _map[x, y] = (int) Dirt;
                    else
                    {
                        _map[x, y] = (int) (pseudoRandom.Next(0, 100) < _randomFillPercent ? Dirt : Empty);
                    }
                }
            }
        }

        private void SmoothMap()
        {
            for (var x = 0; x < _widthMap; x++)
            {
                for (var y = 0; y < _heightMap; y++)
                {
                    var neighbourWallTiles = GetSurroundingWallCount(x, y);

                    if (neighbourWallTiles > _countWall)
                        _map[x, y] = (int) Dirt;
                    else if (neighbourWallTiles < _countWall)
                        _map[x, y] = (int) Empty;
                }
            }
        }

        private int GetSurroundingWallCount(int gridX, int gridY)
        {
            var wallCount = 0;
            for (var neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++)
            {
                for (var neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++)
                {
                    if (neighbourX >= 0 && neighbourX < _widthMap && neighbourY >= 0 && neighbourY < _heightMap)
                    {
                        if (neighbourX != gridX || neighbourY != gridY)
                            wallCount += _map[neighbourX, neighbourY];
                    }
                    else
                    {
                        wallCount++;
                    }
                }
            }

            return wallCount;
        }
    }
}
