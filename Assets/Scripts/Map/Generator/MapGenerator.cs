using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{
    [Range(0,100)]
    public int iniChance;

    [Range(1,8)]
    public int birthLimit;
    
    [Range(1,8)]
    public int deathLimit;

    [Range(1,10)]
    public int numR;

    private int count = 0;

    private int [,] terrainMap;
    public Vector2Int mapSize;

    public Tilemap botMap;

    public RuleTile botTile;

    int width;
    int height;

    public void doSim(int numR){
        clearMap(false);
        width = mapSize.x;
        height = mapSize.y;
        if (terrainMap == null){
            terrainMap = new int[width, height];
            initPos();
        }

        for (int i = 0; i < numR; i++)
        {
            terrainMap = genTilePos(terrainMap);
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (terrainMap[x,y] == 1){
                    botMap.SetTile(new Vector3Int(-x + width/2, -y + height/2, 0), botTile);
                }
            }
        }
    }

  private int[,] genTilePos(int[,] oldMap)
  {
    int[,] newMap = new int[width, height];
    int neighb = 0;
    BoundsInt myB = new BoundsInt(-1,-1,0,3,3,1);

    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            neighb = 0;
            foreach (var e in myB.allPositionsWithin)
            {
                if(e.x==1&&e.y==0) continue;
                if(x+e.x >=0 && x+e.x<width && y+e.y >=0 && y+e.y<height){
                    neighb += oldMap[x+e.x, y+e.y];
                }else{
                    neighb++;
                }
            }
            if(oldMap[x,y] == 1){
                if(neighb<deathLimit) 
                {
                    newMap[x,y] = 0;
                } else {
                    newMap[x,y] = 1;
                }
            } else { //==0
                if (neighb > birthLimit){
                    newMap[x,y] = 1;
                }else{
                    newMap[x,y] = 0;
                }

            }
        }
    }
    return newMap;
  }

  private void initPos()
  {
    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            terrainMap[x,y] = Random.Range(1,101) < iniChance ? 1:0;
        }
    }
  }

  private void clearMap(bool complete)
  {
    botMap.ClearAllTiles();
    if(complete){
        terrainMap = null;
    }
  }
  public void SaveAssetMap()
    {
        string saveName = "tmapXY_" + count;
        var mf = GameObject.Find("Grid");

     
#if UNITY_EDITOR
        if (mf)
        {
            var savePath = "Assets/" + saveName + ".prefab";
            bool success;
            PrefabUtility.SaveAsPrefabAsset(mf, savePath, out success);

            if (success)
            {
                EditorUtility.DisplayDialog("Tilemap saved", "Your Tilemap was saved under" + savePath, "Continue");
            }
            else
            {
                EditorUtility.DisplayDialog("Tilemap NOT saved", "An ERROR occured while trying to saveTilemap under" + savePath, "Continue");
            }
        }
#endif

    }

}
