using UnityEngine;

public class DungController : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
  private bool isSpawned = false;
  private Vector3 currentPosition;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        currentPosition = myRigidBody.position;
    }

    private void FixedUpdate()
    {
        if (!isSpawned){
            transform.position = currentPosition;
            myRigidBody.velocity = Vector2.zero;
            isSpawned = true;
        }
    }

    internal void Spawn(Vector3 position)
    {
        isSpawned = false;
        currentPosition = position;
    }
}
