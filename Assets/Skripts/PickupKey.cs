using UnityEngine;

public class PickupKey : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameManager.I == null)
        {
            Debug.LogError("GameManager not found in scene! Add GameObject 'GameManager' with GameManager script.");
            return;
        }

        GameManager.I.GetKey();
        Destroy(gameObject);
    }
}
