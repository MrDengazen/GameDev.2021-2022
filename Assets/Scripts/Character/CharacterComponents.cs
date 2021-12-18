using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterComponents : MonoBehaviour
{
    protected float HorizontalInput;
    protected float VerticalInput;

    protected CharacterController CharacterController;
    protected Animator CharacterAnimator;

    private @Rogue _inputPlayer;

    protected virtual void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
        CharacterAnimator = GetComponent<Animator>();
        _inputPlayer = new @Rogue();
    }

    protected virtual void Start() {

    }

    private void OnEnable()
    {
        _inputPlayer.Enable();
    }

    private void OnDisable()
    {
        _inputPlayer.Disable();
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
        Vector2 movementInput = _inputPlayer.Player.Move.ReadValue<Vector2>();
        HorizontalInput = movementInput.x;
        VerticalInput = movementInput.y;
    }
}

