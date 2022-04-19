using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Dialogue1 : MonoBehaviour
{
    public static bool allowKey = false;
    public GameObject DialogueBox;
    public Text Char1name;
    public Text Char1speech;

    public Text prompt;

    private int primeInt;


    // Start is called before the first frame update
    void Start()
    {
        primeInt = 0;
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


    public void talking()
    {         // main story function. Players hit next to progress to next int
        primeInt = primeInt + 1;

        if (primeInt == 1)
        {
            DialogueBox.SetActive(true);
            Char1speech.color = new Color32(50, 0, 0, 200);
            Char1speech.text = "Hello? Is someone¡­there?";
        }
        else if (primeInt == 2)
        {
            DialogueBox.SetActive(true);
            Char1speech.text = "Oh my god. You survived. (cough) But why?";
        }
        else if (primeInt == 3)
        {
            Char1speech.color = new Color32(0, 0, 0, 255);
            DialogueBox.SetActive(true);
            Char1speech.text = "Hello? Can you hear¡ª";
        }
        else if (primeInt == 4)
        {
            Char1speech.color = new Color32(50, 0, 0, 200);
            DialogueBox.SetActive(true);
            Char1speech.text = "Is that¡­Artie? Oh no. (cough) ";
        }
        else if (primeInt == 5)
        {
           // Char1speech.color = new Color32(0, 0, 0, 255);
            DialogueBox.SetActive(true);
            Char1speech.text = "What I mean is¡­keep your wits about you, friend. Uncle Artie doesn¡¯t usually take this kindly to people like you.";
        }
        else if (primeInt == 6)
        {
           // Char1speech.color = new Color32(0, 0, 0, 255);
            DialogueBox.SetActive(true);
            Char1speech.text = "Listen, I¡¯m not gonna make it. I don¡¯t want to ask this. But could you please¡­end it?";
        }
        else if (primeInt == 7)
        {
           // Char1speech.color = new Color32(0, 0, 0, 255);
            DialogueBox.SetActive(true);
            Char1speech.text = "With your eyes, I mean. End me?";
        }

    }

    public void allowKeyPress(bool allow)
    {
        allowKey = allow;
    }
}
