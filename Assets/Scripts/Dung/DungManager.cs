using System.Collections;
using UnityEngine;

public class DungManager : Singleton<DungManager>
{
    [Tooltip("Count of dungs on scene")]
    [SerializeField] private int maxDungs;
    [Tooltip("Dung prefab")]
    [SerializeField] private DungController dung;

    private ArrayList poolOfDungs;
    private int currentDungs;

    private Vector3 gameFieldSize;

    protected override void Awake()
    {
        currentDungs = 0;
        poolOfDungs = new ArrayList();
        gameFieldSize = new Vector3(
                    MapManager.Instance.mapSize.x,
                    MapManager.Instance.mapSize.y,
                    0);
        DungSpawn();
    }

/// <summary>
/// Spawn the dungs on scene
/// </summary>
/// <param name="count">Count of the dungs</param>
    private void DungSpawn() {
        var count = maxDungs - poolOfDungs.Count;
        for (var i = 0; i < count ; i++)
        {
            var theDung = Instantiate(dung, Vector3.zero, Quaternion.identity);
            theDung.transform.SetParent(transform);
            poolOfDungs.Add(theDung);
            DungSpawn(theDung);
        }
    }

    public void DungSpawn(DungController dung){
        var position = new Vector3(
                    Random.Range(0, gameFieldSize.x),
                    Random.Range(0, gameFieldSize.y),
                    0);
        dung.Spawn(position);
    }

}
