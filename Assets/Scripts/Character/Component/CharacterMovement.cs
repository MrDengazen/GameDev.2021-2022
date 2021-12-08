using UnityEngine;

public class CharacterMovement : CharacterComponents
{

    [SerializeField] private float walkSpeed = 6f;

    private readonly int movingParameter = Animator.StringToHash("Moving");
    private readonly float threshold = 0.1f;

    public float MoveSpeed { get; set; }

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
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        Vector2 movementNormalized = movement.normalized; //нормализуем вектор движения
        Vector2 movementSpeed = movementNormalized * MoveSpeed;
        controller.SetMovement(movementSpeed);
    }

    private void UpdateAnimations()
    {
        if (Mathf.Abs(horizontalInput) > threshold || Mathf.Abs(verticalInput) > threshold)
        {
            animator.SetBool(movingParameter, true);
        } else
        {
            animator.SetBool(movingParameter, false);
        }
    }

    public void ResetSpeed()
    {
        MoveSpeed = walkSpeed;
    }

}
