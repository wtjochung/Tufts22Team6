using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EKeyInteraction : MonoBehaviour
{

    public bool allowEKey = false;
    public Text eKeyPrompt;
    public string defaultPrompt = "[E] to interact";
    

    // Start is called before the first frame update
    void Start()
    {
       // eKeyPrompt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void allowKeyPress(bool b, string prompt)
    {
        allowEKey = b;
        if (prompt == "")
        {
            prompt = defaultPrompt;
        }

        if (allowEKey)
        {
            eKeyPrompt.text = prompt;
        } else
        {
            eKeyPrompt.text = "";
        }
    }

    
}
