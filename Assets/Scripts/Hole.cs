using UnityEngine;

public class Hole : MonoBehaviour
{
    public enum HoleTypes
    {
        Type1,
        Type2
    }
    
    [SerializeField] private HoleTypes holeType;
}
