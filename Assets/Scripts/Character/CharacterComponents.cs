using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterComponents : MonoBehaviour
{
    protected float horizontalInput;
    protected float verticalInput;

    protected CharacterController controller;
    protected CharacterMovement characterMovement;
    protected CharacterRotation characterRotation;
    protected Animator animator;

    protected @Rogue inputPlayer;

    protected virtual void Awake()
    {
        controller = GetComponent<CharacterController>();
        characterMovement = GetComponent<CharacterMovement>();
        animator = GetComponent<Animator>();
        inputPlayer = new @Rogue();
    }

    protected virtual void Start() {
        
    }

    private void OnEnable()
    {
        inputPlayer.Enable();
    }

    private void OnDisable()
    {
        inputPlayer.Disable();
    }

    protected virtual void Update()
    {
        HandleAbility();
    }

    /// <summary>
    /// Here we put the logic of each ability
    /// </summary>
    protected virtual void HandleAbility()
    {
        InternalInput();
        HandleInput();
    }

    /// <summary>
    /// Perform our action
    /// </summary>
    protected virtual void HandleInput()
    {

    }

    /// <summary>
    /// Control our character
    /// </summary>
    protected virtual void InternalInput()
    {
        Vector2 movementInput = inputPlayer.Player.Move.ReadValue<Vector2>();
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
    }

/*
    public void OnMove(InputValue value)
    {
        var  = value.Get<Vector2>();
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
    }
*/
}

