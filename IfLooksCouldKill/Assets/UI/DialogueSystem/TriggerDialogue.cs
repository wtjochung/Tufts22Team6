using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class TriggerDialogue : MonoBehaviour
{
    public Text prompt;
    /*
    [Serializable]
    public class OnTrigger : UnityEvent { }

    [FormerlySerializedAs("onTrigger")]
    [SerializeField]
    public OnTrigger OnEvent;
    */
    // Start is called before the first frame update
    void Start()
    {

        //canvas.GetComponent<NPC1Dialogue>().allowKeyPress(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //  canvas.GetComponent<NPC1Dialogue>().allowKeyPress(true);
            prompt.text = "[E] to interact";
            Debug.Log("player trigger");
            Level1Dialogue1 dialogueScript = GetComponent<Level1Dialogue1>();
            dialogueScript.allowKeyPress(true);
           // OnTrigger.Invoke();
        }
    }

    
}
