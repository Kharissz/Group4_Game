using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject lentera;
    bool dekat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && dekat)
        {
            Interact();
            Destroy(this.gameObject);
        }      
    }

    void Interact()
    {
        lentera.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            dekat = true;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.tag == "Player")
        {
            dekat = false;
        }
    }
}
