using UnityEngine;
using static Level.DungeonTiles;

namespace Level
{
    internal class PlatformTileManager : TileManager
    {
        private readonly int _waterLevel;
        private readonly int _cleanSize = 2;
        private readonly int _maxJumpPlace = 4;
        private int _obstacleCounter;

        private int[,] _map;

        public PlatformTileManager(int widthMap, int heightMap, int waterLevel) : base(widthMap, heightMap)
        {
            _waterLevel = waterLevel - 1;
        }

        public override int[,] ReplaceTiles(int[,] map)
        {
            _map = map;
            _obstacleCounter = 0;
            for (int x = 1; x < WidthMap - 1; x++)
            {
                if (_map[x, _waterLevel] == (int) Water && _map[x + 1, _waterLevel] == (int) Water)
                {
                    if (_map[x - 1, _waterLevel] == (int) Dirt || _map[x - 1, _waterLevel] == (int) Grass)
                    {
                        AddPlatform(x);
                    }
                    else
                    {
                        _obstacleCounter++;
                        if (_obstacleCounter > _maxJumpPlace)
                        {
                            _obstacleCounter -= _maxJumpPlace;
                            AddPlatform(x);
                        }
                    }
                }
                
                if (_map[x, _waterLevel] == (int) Water && _map[x + 1, _waterLevel] != (int) Water)
                {
                    _obstacleCounter = 0;
                }
            }

            return _map;
        }

        private void AddPlatform(int x)
        {
            int newX = x + Random.Range(0, 2);
            int newY = _waterLevel + Random.Range(3, 5);
            var size = Random.Range(2, 5);

            _obstacleCounter -= size + 1;

            _map[newX, newY] = (int) LeftPlatform;
            _map[newX + size, newY] = (int) RightPlatform;
            for (int i = newX + 1; i < newX + size; i++)
            {
                _map[i, newY] = (int) MidlPlatform;
            }

            CleanPlatformPlace(newX, newY, size);
        }

        private void CleanPlatformPlace(int startPosition, int heightLocation, int size)
        {
            for (int x = startPosition - _cleanSize; x < startPosition + size + _cleanSize; x++)
            {
                for (int y = heightLocation - _cleanSize; y < heightLocation + _cleanSize + 1; y++)
                {
                    if (_map[x, y] == (int) Dirt)
                        _map[x, y] = (int) Empty;
                }
            }
        }
    }
}
