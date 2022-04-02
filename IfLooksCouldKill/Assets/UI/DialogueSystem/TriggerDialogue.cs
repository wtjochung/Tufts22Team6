using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public Canvas canvas;


    // Start is called before the first frame update
    void Start()
    {

        canvas.GetComponent<NPC1Dialogue>().allowKeyPress(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.GetComponent<NPC1Dialogue>().allowKeyPress(true);
            Debug.Log("player trigger");
        }
    }

    
}
