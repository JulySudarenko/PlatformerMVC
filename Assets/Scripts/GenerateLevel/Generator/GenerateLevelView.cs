using UnityEngine;
using UnityEngine.Tilemaps;

namespace Level
{
    public class GenerateLevelView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMapGround;
        [SerializeField] private Tilemap _tileMapWater;
        [SerializeField] private Tilemap _tileMapPlatforms;
        [SerializeField] private Tile _tileGround;
        [SerializeField] private Tile _tileGrass;
        [SerializeField] private Tile _tileWater;
        [SerializeField] private Tile _tileLeftPlatform;
        [SerializeField] private Tile _tileMidlPlatform;
        [SerializeField] private Tile _tileRightPlatform;
        [SerializeField] private int _widthMap;
        [SerializeField] private int _heightMap;
        [SerializeField] private int _factorSmooth;
        [SerializeField, Range(0, 50)] private int _randomFillPercent;

        public Tilemap TileMapGround => _tileMapGround;

        public Tilemap TileMapWater => _tileMapWater;

        public Tilemap TileMapPlatforms => _tileMapPlatforms;

        public Tile TileGround => _tileGround;

        public Tile TileGrass => _tileGrass;

        public Tile TileWater => _tileWater;

        public Tile TileLeftPlatform => _tileLeftPlatform;

        public Tile TileMidlPlatform => _tileMidlPlatform;

        public Tile TileRightPlatform => _tileRightPlatform;

        public int WidthMap => _widthMap;

        public int HeightMap => _heightMap;

        public int FactorSmooth => _factorSmooth;

        public int RandomFillPercent => _randomFillPercent;
    }
}
