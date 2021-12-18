using UnityEngine;

public class CharacterRotation : CharacterComponents
{
    [SerializeField] private float threshold = 0.1f;

    protected override void Awake(){
        base.Awake();
        ResetRotate();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        RotateCharacter();
    }

    private void RotateCharacter()
    {
        if (Mathf.Abs(CharacterController.Movement.normalized.magnitude) > threshold)
        {
            var norm = CharacterController.Movement.normalized;
            CharacterController.Rotation = Quaternion.FromToRotation(Vector3.up, new Vector3(norm.x, norm.y,0));
            Debug.Log("Movement:" + norm);
            Debug.Log("Rotation:" + CharacterController.Rotation);
        }
    }

    private void ResetRotate()
    {
        transform.localRotation = Quaternion.Euler(Vector3Int.zero);
    }
}
