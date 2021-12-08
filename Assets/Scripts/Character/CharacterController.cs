using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D myRigidBody;

    public Vector2 CurrentMovement { get; set; }

    // Start is called before the first frame update
    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector2 currentMove = myRigidBody.position + CurrentMovement * Time.fixedDeltaTime;
        myRigidBody.MovePosition(currentMove);
    }

    public void SetMovement(Vector2 newPosition)
    {
        CurrentMovement = newPosition;
    }
}
