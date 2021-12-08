using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] public Vector2Int mapSize;
    private MapGenerator mapGenerator;
    private GroundMapGenerator groundMapGenerator;

    protected override void Awake()
    {
        mapGenerator = GetComponent<MapGenerator>();
        groundMapGenerator = GetComponent<GroundMapGenerator>();
        groundMapGenerator.Generate(mapSize);
    }
}
