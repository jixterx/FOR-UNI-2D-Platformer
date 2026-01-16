using UnityEngine;
using TMPro;
using System.Collections;

public class MessageUI : MonoBehaviour
{
    public static MessageUI I;
    public TextMeshProUGUI text;

    void Awake()
    {
        I = this;
        if (text != null) text.text = "";
    }

    public void Show(string message, float time = 1.5f)
    {
        if (text == null) return;
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(message, time));
    }

    IEnumerator ShowRoutine(string msg, float time)
    {
        text.text = msg;
        yield return new WaitForSeconds(time);
        text.text = "";
    }
}
