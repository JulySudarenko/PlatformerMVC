using System;
using Platformer;
using UnityEngine;
using UnityEngine.Tilemaps;
using static Level.DungeonTiles;
using Object = UnityEngine.Object;

namespace Level
{
    internal class DrawTilesManager
    {
        private readonly LevelConfig _config;
        private readonly Tile _tileGround;
        private readonly Tile _tileGrass;
        private readonly Tile _tileWater;
        private readonly Tile _tileLeftPlatform;
        private readonly Tile _tileMidlPlatform;
        private readonly Tile _tileRightPlatform;
        private readonly Vector3 _playerStartPosition;
        private readonly int _deltaPositionX = -5;
        private readonly int _deltaPositionY = -5;
        private readonly int _sideBorders;
        private readonly int _widthMap;
        private readonly int _heightMap;
        
        private Grid _grid;
        private Tilemap _tileMapGround;
        private Tilemap _tileMapWater;
        private Tilemap _tileMapPlatforms;

        public DrawTilesManager(LevelConfig config, Vector3 playerStartPoint)
        {
            _config = config  != null ? config : throw new ArgumentException(nameof(config));
            _tileMapGround = config.TileMapGround;
            _tileGround = config.TileGround;
            _tileMapPlatforms = config.TileMapPlatforms;
            _tileMapWater = config.TileMapWater;
            _tileGrass = config.TileGrass;
            _tileWater = config.TileWater;
            _tileLeftPlatform = config.TileLeftPlatform;
            _tileMidlPlatform = config.TileMidlPlatform;
            _tileRightPlatform = config.TileRightPlatform;
            _widthMap = config.WidthMap;
            _heightMap = config.HeightMap;
            _sideBorders = config.SideBorders;

            _playerStartPosition = playerStartPoint != null
                ? playerStartPoint
                : throw new ArgumentException(nameof(playerStartPoint));
        }

        public void Initialize()
        {
            _grid = Object.Instantiate(_config.GridLevel);
            _tileMapGround = Object.Instantiate(_config.TileMapGround, _grid.transform);
            _tileMapWater = Object.Instantiate(_config.TileMapWater, _grid.transform);
            _tileMapPlatforms = Object.Instantiate(_config.TileMapPlatforms, _grid.transform);
        }

        public void DrawTilesOnMap(int[,] map)
        {
            if (map == null)
                return;
            for (int x = 0; x < _widthMap; x++)
            {
                for (int y = 0; y < _heightMap; y++)
                {
                    var positionTile = new Vector3Int(x + (int) _playerStartPosition.x + _deltaPositionX - _sideBorders,
                        y + (int) _playerStartPosition.y + _deltaPositionY, 0);
                    if (GetPlaceOnStartPosition(positionTile))
                        map[x, y] = (int) Empty;

                    switch (map[x, y])
                    {
                        case (int) Empty:
                            break;
                        case (int) Dirt:
                            _tileMapGround.SetTile(positionTile, _tileGround);
                            break;
                        case (int) Water:
                            _tileMapWater.SetTile(positionTile, _tileWater);
                            break;
                        case (int) Grass:
                            _tileMapGround.SetTile(positionTile, _tileGrass);
                            break;
                        case (int) LeftPlatform:
                            _tileMapPlatforms.SetTile(positionTile, _tileLeftPlatform);
                            break;
                        case (int) MidlPlatform:
                            _tileMapPlatforms.SetTile(positionTile, _tileMidlPlatform);
                            break;
                        case (int) RightPlatform:
                            _tileMapPlatforms.SetTile(positionTile, _tileRightPlatform);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException(nameof(DungeonTiles), map[x, y], 
                                "Not included in the program");
                    }
                }
            }
        }

        private bool GetPlaceOnStartPosition(Vector3 positionTile)
        {
            return positionTile.x < _playerStartPosition.x + 1 &&
                   positionTile.x > _playerStartPosition.x - 3 &&
                   positionTile.y > -3 &&
                   positionTile.y < _playerStartPosition.y + 5;
        }
    }
}
