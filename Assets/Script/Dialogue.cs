using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public GameObject box;
    public TextMeshProUGUI chara;
    public string nama;
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        chara.text = nama;
        textComponent.text = string.Empty;
        // StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(textComponent.text == lines[index])
            {NextLine();}
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }        
    }

    public void StartDialogue()
   {
    box.SetActive(true);
    index = 0;
    StartCoroutine(TypeLine());
   }

   public void EndDialogue()
   {
    box.SetActive(false);
   }

   void NextLine()
   {
        if(index < lines.Length -1 )
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } 
        else
        {
            box.SetActive(false);            
        }
   }

   IEnumerator TypeLine()
   {
    // Type each character 1 by 1
    foreach(char c in lines[index].ToCharArray())
    {
        textComponent.text+=c;
        yield return new WaitForSeconds(textSpeed);
    }
   }
}
