using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

namespace Platformer
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        public Grid GridLevel;
        [SerializeField] private int _widthMap = 100;
        [SerializeField] private int _heightMap = 17;
        [SerializeField] private int _factorSmooth = 1;
        [SerializeField] private int _sideBorders = 13;
        [SerializeField] private int _countWall = 4;
        [SerializeField, Range(0, 50)] private int _randomFillPercent = 35;
        
        [Header("Ground")]
        public Tilemap TileMapGround;
        [SerializeField] private Tile _tileGround;
        [SerializeField] private Tile _tileGrass;
        
        [Header("Water")]
        public Tilemap TileMapWater;
        [SerializeField] private Tile _tileWater;
        [SerializeField] private int _waterLevel = 2;
         
        [Header("Platforms")]
        public Tilemap TileMapPlatforms;
        [SerializeField] private Tile _tileLeftPlatform;
        [SerializeField] private Tile _tileMidlPlatform;
        [SerializeField] private Tile _tileRightPlatform;


        public Tile TileGround => _tileGround;

        public Tile TileGrass => _tileGrass;

        public Tile TileWater => _tileWater;

        public Tile TileLeftPlatform => _tileLeftPlatform;

        public Tile TileMidlPlatform => _tileMidlPlatform;

        public Tile TileRightPlatform => _tileRightPlatform;

        public int WidthMap => _widthMap;

        public int HeightMap => _heightMap;

        public int FactorSmooth => _factorSmooth;

        public int SideBorders => _sideBorders;

        public int CountWall => _countWall;

        public int WaterLevel => _waterLevel;

        public int RandomFillPercent => _randomFillPercent;
    }
}
