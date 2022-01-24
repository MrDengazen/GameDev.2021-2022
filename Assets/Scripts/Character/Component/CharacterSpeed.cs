using UnityEngine;

namespace Characters.Component
{
    [CreateAssetMenu(fileName = "New SwordData", menuName = "BugGame/Player/Settings", order = 51)]
    public class CharacterSpeed : ScriptableObject
    {
        public float walkSpeed = 6f;
    }
}
