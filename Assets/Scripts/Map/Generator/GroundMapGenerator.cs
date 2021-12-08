using UnityEngine;
using UnityEngine.Tilemaps;

public class GroundMapGenerator : MonoBehaviour
{
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tile groundTile;

    public void Generate(Vector2Int mapSize){
        ground.size = new Vector3Int(mapSize.x, mapSize.y,0);
        for (var x = 0; x < mapSize.x; x++)
        {
            for (var y = 0; y < mapSize.y; y++)
            {
                ground.SetTile(new Vector3Int(x,y, 0), groundTile);
            }
            
        }
    }
}
