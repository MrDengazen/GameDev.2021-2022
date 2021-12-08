using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemDefaultSpawner : MonoBehaviour
{
  private Tilemap itemsLayer;
  [SerializeField] private List<Item> items;
  private void Awake()
  {
    itemsLayer = GetComponent<Tilemap>();
    Generate(MapManager.Instance.mapSize);
  }
  public void Generate(Vector2Int mapSize){
      itemsLayer.size = new Vector3Int(mapSize.x, mapSize.y,0);
      var items_count = items.Count;
      for (var x = 0; x < mapSize.x; x++)
      {
          for (var y = 0; y < mapSize.y; y++)
          {
            if (Random.Range(1,101) < 5){
              Item i = items[Random.Range(0, items_count)];
              i.tile.gameObject = i.logic;
              itemsLayer.SetTile(new Vector3Int(x,y, 0), i.tile);
            }
          }
          
      }
  }
}
