using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharacterTypes
    {
        Player,
        AI
    }
    
    [SerializeField] private CharacterTypes characterType;
}
