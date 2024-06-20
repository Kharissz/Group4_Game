using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class PopupText : MonoBehaviour
{
    public TextMeshProUGUI popupText;
    public float displayTime = 2f;
    public float moveSpeed = 2f;
    public float fadeSpeed = 2f;
    bool pop = false;
    public string teks;

    private void Start()
    {
        popupText.enabled = false;
    }

    void Update()
    {
        if(pop)
        StartCoroutine(AnimatePopup(teks,popupText.transform.position));
        
    }

    public void ShowPopup(string message, Vector3 position)
    {
        StartCoroutine(AnimatePopup(message, position));
    }

    private IEnumerator AnimatePopup(string message, Vector3 position)
    {
        popupText.text = message;
        popupText.transform.position = position;
        popupText.enabled = true;

        float timer = 0f;

        // Animation loop
        while (timer < displayTime)
        {
            // Move the text upwards
            Vector3 newPos = popupText.transform.position;
            newPos.y += moveSpeed * Time.deltaTime;
            popupText.transform.position = newPos;

            // Fade out the text
            Color textColor = popupText.color;
            textColor.a = Mathf.Lerp(1f, 0f, timer / displayTime);
            popupText.color = textColor;

            timer += Time.deltaTime;
            yield return null;
        }

        popupText.enabled = false;

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.CompareTag("Player"))
        {
            pop =true;
        }
    }
}