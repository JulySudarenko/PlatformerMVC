using Platformer;
using UnityEngine;

namespace Level
{
    public class GeneratorLevelController : IInitialize
    {
        private readonly MapGenerator _mapGenerator;
        private readonly DrawTilesManager _drawTilesManager;
        private readonly TileManager _waterTileManager;
        private readonly TileManager _grassTileManager;
        private readonly TileManager _platformTileManager;

        private int[,] _map;

        public GeneratorLevelController(LevelConfig config, Vector3 playerStartPoint)
        {
            _map = new int[config.WidthMap, config.HeightMap];
            
            _mapGenerator = new MapGenerator(config, _map);
            _drawTilesManager = new DrawTilesManager(config, playerStartPoint);
            _waterTileManager = new WaterTileManager(config.WidthMap, config.HeightMap, config.WaterLevel);
            _grassTileManager = new GrassTileManager(config.WidthMap, config.HeightMap);
            _platformTileManager = new PlatformTileManager(config.WidthMap, config.HeightMap, config.WaterLevel);
        }

        public void Initialize()
        {
            _map = _mapGenerator.GenerateLevel();
            _map = _waterTileManager.ReplaceTiles(_map);
            _map = _grassTileManager.ReplaceTiles(_map);
            _map = _platformTileManager.ReplaceTiles(_map);

            _drawTilesManager.Initialize();
            _drawTilesManager.DrawTilesOnMap(_map);
        }

    }
}
