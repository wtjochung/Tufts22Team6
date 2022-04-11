using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EKeyInteraction : MonoBehaviour
{

    public bool allowEKey = false;
    public Text eKeyPrompt;

    

    // Start is called before the first frame update
    void Start()
    {
        eKeyPrompt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void allowKeyPress(bool b)
    {
        allowEKey = b;
        if (allowEKey)
        {
            eKeyPrompt.text = "Press E to Interact";
        } else
        {
            eKeyPrompt.text = "";
        }
    }

    
}
