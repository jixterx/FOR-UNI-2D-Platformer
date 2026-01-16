using UnityEngine;

public class Door : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameManager.I.hasKey)
        {
            GameManager.I.NextLevel();
        }
        else
        {
            if (MessageUI.I != null)
                MessageUI.I.Show("Need a key!", 1.5f);
            else
                Debug.Log("Need a key! (MessageUI missing)");
        }
    }
}
