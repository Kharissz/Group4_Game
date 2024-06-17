using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPosition : MonoBehaviour
{
    public Transform playerTransform;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Mengikuti posisi player
        rectTransform.position = Camera.main.WorldToScreenPoint(playerTransform.position + Vector3.up * 3.5f);
    }
}
