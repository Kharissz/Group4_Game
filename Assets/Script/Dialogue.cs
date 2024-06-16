using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Data;

public class Dialogue : MonoBehaviour
{
    public GameObject box;
    public TextMeshProUGUI chara;
    public TextMeshProUGUI textComponent;
    [SerializeField] private GameObject buttonUI;
    private GameObject player;
    private Rigidbody2D control;
    public string nama;
    public string[] lines;
    public float textSpeed;
    private bool comm;
    private bool dial;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        chara.text = nama;
        textComponent.text = string.Empty;
        
        player = GameObject.FindGameObjectWithTag("Player");
        control = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && comm)
        {
            StartDialogue();
            comm = false;
        }
        if(Input.GetMouseButtonDown(0) && dial)
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
        dial = true;
        index = 0;
        StartCoroutine(TypeLine());
        control.constraints = RigidbodyConstraints2D.FreezeAll;
   }

   public void EndDialogue()
   {
        box.SetActive(false);
        dial = false;
        control.constraints = RigidbodyConstraints2D.FreezeRotation;
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
            EndDialogue();            
        }
   }

   void OnTriggerEnter2D(Collider2D coll)
   {
        if(coll.CompareTag("Player"))
        {
            buttonUI.SetActive(true);
            comm = true;
        }
   }

    void OnTriggerExit2D(Collider2D coll)
   {
        if(coll.CompareTag("Player"))
        {
            buttonUI.SetActive(false);
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
