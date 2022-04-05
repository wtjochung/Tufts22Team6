using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
//using TMPro;

public class NPC1Dialogue : MonoBehaviour
{
    public int primeInt = 1;         // This integer drives game progress!
    public Text Char1name;
    public Text Char1speech;
    public Text Char2name;
    public Text Char2speech;
    //public Text Char3name;
    //public Text Char3speech;
    public GameObject DialogueDisplay;
  //  public GameObject ArtChar1;
    //public GameObject ArtChar2;
    public GameObject ArtBG1;
    public GameObject Choice1a;
    public GameObject Choice1b;
   // public GameObject NextScene1Button;
   // public GameObject NextScene2Button;
   // public GameObject nextButton;
    //public GameHandler gameHandler;
    //public AudioSource audioSource;
    public bool allowEKey = false;
    

    void Start()
    {         // initial visibility settings
        DialogueDisplay.SetActive(false);
      //  ArtChar1.SetActive(false);
        ArtBG1.SetActive(true);
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
        /*
        NextScene1Button.SetActive(false);
        NextScene2Button.SetActive(false);
        nextButton.SetActive(true);
        */
    }

    void Update()
    {         // use spacebar as Next button
        if (allowEKey == true)
        {
            if (Input.GetKeyDown("e"))
            {
                talking();
            }
        }
    }

    public void allowKeyPress(bool b)
    {
        allowEKey = b;
    }

    //Story Units:
    public void talking()
    {         // main story function. Players hit next to progress to next int
        primeInt = primeInt + 1;
        if (primeInt == 1)
        {
            // AudioSource.Play();
        }
        else if (primeInt == 2)
        {
          //  ArtChar1.SetActive(true);
            DialogueDisplay.SetActive(true);
            Char1name.text = "???";
            Char1speech.text = "Thank god you¡¯re finally awake!";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 3)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "You";
            Char2speech.text = "Wuh..? What happened?";
            //gameHandler.AddPlayerStat(1);
        }
        else if (primeInt == 4)
        {
            Char1name.text = "???";
            Char1speech.text = " They trapped us in here. Do you think you can get us out?";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 5)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "You";
            Char2speech.text = "How?";
            //gameHandler.AddPlayerStat(1);
        }
        else if (primeInt == 6)
        {
            Char1name.text = "???";
            Char1speech.text = "You don¡¯t remember how to use your laser vision?";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 7)
        {
            Char1name.text = "???";
            Char1speech.text = "Open the slot on your headset. Look at the lock.";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 8)
        {
            Char1name.text = "???";
            Char1speech.text = "I've heard them telling you to 'click,' whatever that means.";
            Char2name.text = "";
            Char2speech.text = "";
          

            // Turn off "Next" button, turn on "Choice" buttons
            //  nextButton.SetActive(false);
            //  allowEKey = false;
            //  Choice1a.SetActive(true); // function Choice1aFunct()
            // Choice1b.SetActive(true); // function Choice1bFunct()
        }
        else if (primeInt == 9)
        {
            DialogueDisplay.SetActive(false);
            allowEKey = false;
        }


        // ENCOUNTER AFTER CHOICE #1
        else if (primeInt == 100)
        {
            Char1name.text = "???";
            Char1speech.text = "Then you are no use to me, and must be silenced.";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 101)
        {
            Char1name.text = "???";
            Char1speech.text = "Come back here! Do not think you can hide from me!";
            Char2name.text = "";
            Char2speech.text = "";
           // nextButton.SetActive(false);
          //  allowEKey = false;
           // NextScene1Button.SetActive(true);
        }

        else if (primeInt == 200)
        {
            Char1name.text = "???";
            Char1speech.text = "Do not think you can fool me, human. Where will we find him?";
            Char2name.text = "";
            Char2speech.text = "";
        }
        else if (primeInt == 201)
        {
            Char1name.text = "";
            Char1speech.text = "";
            Char2name.text = "You";
            Char2speech.text = "Ragu hangs out in a rough part of town. I'll take you now.";
            // nextButton.SetActive(false);
            DialogueDisplay.SetActive(false);
            allowEKey = false;
           // NextScene2Button.SetActive(true);

        }
    }

    // FUNCTIONS FOR BUTTONS TO ACCESS (Choice #1 and switch scenes)
    public void Choice1aFunct()
    {
        Char1name.text = "";
        Char1speech.text = "";
        Char2name.text = "You";
        Char2speech.text = "I don't know what you're talking about!";
        primeInt = 99;
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
      //  nextButton.SetActive(true);
        allowEKey = true;
    }
    public void Choice1bFunct()
    {
        Char1name.text = "";
        Char1speech.text = "";
        Char2name.text = "You";
        Char2speech.text = "Sure, anything you want... just lay off the club.";
        primeInt = 199;
        Choice1a.SetActive(false);
        Choice1b.SetActive(false);
       // nextButton.SetActive(true);
        allowEKey = true;
    }

    public void SceneChange1()
    {
        SceneManager.LoadScene("Scene2a");
    }
    public void SceneChange2()
    {
        SceneManager.LoadScene("Scene2b");
    }

}