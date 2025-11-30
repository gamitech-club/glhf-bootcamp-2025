using UnityEngine;

public class TriggerExample : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Masuk area trigger: " + collision.gameObject.name);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Masih di area trigger: " + collision.gameObject.name);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Keluar area trigger: " + collision.gameObject.name);
    }
}
