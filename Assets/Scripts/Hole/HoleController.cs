using UnityEngine;

public class HoleController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "dung"){
            Debug.Log(other);
            DungManager.Instance.DungSpawn(other.gameObject.GetComponent<DungController>());
            UIManager.Instance.AddDungs();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "dung")
        {
            Debug.Log("Collision: Dung inside");
        }
    }
}
