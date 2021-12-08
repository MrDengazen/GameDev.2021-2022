using UnityEngine;

public class Dung : MonoBehaviour
{
    public enum DungTypes
    {
        Type1,
        Type2
    }
    
    [SerializeField] private DungTypes dungType;
}
