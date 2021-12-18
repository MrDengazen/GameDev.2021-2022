using UnityEngine;

public class CharacterMovement : CharacterComponents
{

    [SerializeField] private float walkSpeed = 6f;

    private readonly int _movingParameter = Animator.StringToHash("Moving");
    private readonly float _threshold = 0.1f;

    private float MoveSpeed { get; set; }

    protected override void Start()
    {
        base.Start();
        ResetSpeed();
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();
        MoveCharacter();
        UpdateAnimations();
    }

    private void MoveCharacter()
    {
        CharacterController.Movement = new Vector2(HorizontalInput, VerticalInput) * MoveSpeed;
    }

    private void UpdateAnimations()
    {
        if (Mathf.Abs(HorizontalInput) > _threshold || Mathf.Abs(VerticalInput) > _threshold)
        {
            CharacterAnimator.SetBool(_movingParameter, true);
        } else
        {
            CharacterAnimator.SetBool(_movingParameter, false);
        }
    }

    public void ResetSpeed()
    {
        MoveSpeed = walkSpeed;
    }

}
