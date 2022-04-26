using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Dialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text Char1name;
    public Text Char1speech;

    public Text prompt;

    public bool allowKey = false;

    public Image blackScreen;
    public Canvas canvas;

    private int primeInt = 0;

    private bool playerOpensEye = false;
    private bool doorOpened = false;
    private bool finalLine = false;
    private bool end = false;

    // Start is called before the first frame update
    void Start()
    {
        blackScreen.color = new Color32(0, 0, 0, 255);
        DialogueBox.SetActive(true);

        Char1name.text = "";
        Char1speech.text = "Hello? Wake up? Would you please wake up?";

        prompt.text = "[E] to continue";

        allowKey = true;
      //  canvas.GetComponent<EKeyInteraction>().allowKeyPress(allowKey, "[E] to continue");
       
    }

    public void talking()
    {         // main story function. Players hit next to progress to next int
        primeInt = primeInt + 1;

        if (primeInt == 1)
        {
            blackScreen.color = new Color32(0, 0, 0, 0);
        }
        else if (primeInt == 2)
        {
            Char1speech.text = "Oh, thank god. You¡¯re alive. Listen, we don¡¯t have much time.";
        }
        else if (primeInt == 3)
        {
            Char1speech.text = "I mean this in the kindest possible way: Could you please melt the control panel and get us the bloody flipping heck out of here?";
        }
        else if (primeInt == 4)
        {
            Char1speech.text = "The panel? Right next to you?";
        }
        else if (primeInt == 5)
        {
            Char1speech.text = "Oh. They put on your goggles again. Alright, we¡¯re gonna have to take this one step at a time.";
        }
        else if (primeInt == 6)
        {
            Char1speech.color = new Color32(0, 0, 0, 255);
            Char1speech.text = "There should be a switch on the side of your googles. Can you feel it?";
            prompt.text = "Click to disable goggles";
            GameManager.toggleAllowed = true;
        }
        else if (primeInt > 6 && primeInt < 100 && GameManager.blind == false)
        {
            playerOpensEye = true;

            allowKey = true;
          //  canvas.GetComponent<EKeyInteraction>().allowKeyPress(false, "");

            prompt.text = "[E] to continue";

            Char1speech.color = new Color32(0, 0, 0, 255);
            Char1speech.text = "Bloody genial! Be careful where you point that laser.";

            primeInt = 100;

        }
        else if (primeInt > 100 && playerOpensEye && !doorOpened)
        {
            Char1speech.color = new Color32(0, 0, 0, 255);
            Char1speech.text = "You could kill someone if you aren¡¯t careful. Let¡¯s kill the door.";
           

        } else if (primeInt > 100 && doorOpened && !finalLine) {
            Char1speech.color = new Color32(0, 0, 0, 255);
            Char1speech.text = "Beautiful. Let¡¯s break you out of this piehole--";
            finalLine = true;
        }
        else if (primeInt > 100 && doorOpened && finalLine && !end)
        {
            DialogueBox.SetActive(false);
            Char1speech.text = "";
            prompt.text = "";
            end = true;
        } 
    }

        void Update()
    {         // use e as Next button
        if (allowKey == true)
        {
            if (Input.GetKeyDown("e"))
            {
                talking();
            }
        }
    }

    public void playerOpenedDoor()
    {
        doorOpened = true;
    }

    public void endDialogue()
    {
        primeInt = 200;
        playerOpensEye = true;
        doorOpened = true;
        finalLine = true;
        end = true;

        DialogueBox.SetActive(false);
        Char1speech.text = "";
    }
}
