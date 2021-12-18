using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody2D _myRigidBody;

    public Vector2 Movement {set; get; }
    public Quaternion Rotation {set; get; }

    // Start is called before the first frame update
    private void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector2 currentMove = _myRigidBody.position + Movement * Time.fixedDeltaTime;
        _myRigidBody.MovePosition(currentMove);
        _myRigidBody.MoveRotation(Rotation);
    }
}
