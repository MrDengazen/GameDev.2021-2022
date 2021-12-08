using UnityEngine;

public class CharacterRotation : CharacterComponents
{
    [SerializeField] private float threshold = 0.1f;

    protected override void Start()
    {
        base.Start();
        ResetRotate();
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        RotateCharacter();
    }

    private void RotateCharacter()
    {
        if (controller.CurrentMovement.normalized.magnitude > threshold)
        {
            if (controller.CurrentMovement.normalized.x > 0) //right
            {
                transform.localRotation = Quaternion.Euler(90 * Vector3Int.back);
            }
            else if (controller.CurrentMovement.normalized.x < 0)
            {
                transform.localRotation = Quaternion.Euler(90 * Vector3Int.forward);
            }

            if (controller.CurrentMovement.normalized.y > 0) //down
            {
                transform.localRotation = Quaternion.Euler(Vector3Int.zero);
            }
            else if (controller.CurrentMovement.normalized.y < 0)
            {
                transform.localRotation = Quaternion.Euler(180 * Vector3Int.back);
            }
        }
    }

    private void ResetRotate()
    {
        transform.localRotation = Quaternion.Euler(Vector3Int.zero);
    }
}
