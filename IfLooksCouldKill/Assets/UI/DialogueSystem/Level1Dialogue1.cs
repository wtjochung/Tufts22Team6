using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Level1Dialogue1 : MonoBehaviour
{
    public static bool allowKey = false;
    public GameObject DialogueBox;
    public Text Char1name;
    public Text Char1speech;

    public GameObject DialogueManager;

    public Text prompt;

    private int primeInt;


    public AudioSource vo;
    public AudioClip[] voClips;

    private int clipToPlay = 0;

    private bool playerKillsNPC = false;
    private bool playerLeft = false;
    private bool nearElevator = false;


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
                Debug.Log("e key logged");
                Debug.Log("prime int = " + primeInt);
                talking();
            }
        }
    }


    public void talking()
    {         // main story function. Players hit next to progress to next int
        primeInt += 1;

        if (primeInt == 1)
        {
            DialogueManager.GetComponent<Level1Dialogue>().endDialogue();
            DialogueBox.SetActive(true);
            Char1speech.color = new Color32(50, 0, 0, 200);

            clipToPlay = 0;
            playAudioClip(clipToPlay);

            Char1speech.text = "Hello? Is someone...there?";
            Debug.Log("prime int " + primeInt + "dialogue");
        }
        else if (primeInt == 2)
        {
            DialogueBox.SetActive(true);

            clipToPlay = 1;
            playAudioClip(clipToPlay);

            Char1speech.text = "Oh my god. You survived. (cough) But why?";
        }
        else if (primeInt == 3)
        {
            //Char1speech.color = new Color32(0, 0, 0, 255);
            DialogueBox.SetActive(true);

            clipToPlay = 2;
            playAudioClip(clipToPlay);
            Char1speech.text = "Listen, I'm not gonna make it. I don't want to ask this. But could you please...end it? With your eyes, I mean. End me?";
            primeInt = 100;
        }
        else if (primeInt > 100 && playerKillsNPC && !playerLeft)
        {
            clipToPlay = 3;
            playAudioClip(clipToPlay);

            Char1speech.color = new Color32(50, 0, 0, 200);
            DialogueBox.SetActive(true);
            Char1speech.text = "AHHHHHH...thank you...";

            primeInt = 200;

        }
        else if (primeInt > 100 && playerLeft && !playerKillsNPC)
        {
            clipToPlay = 4;
            playAudioClip(clipToPlay);

            Char1speech.color = new Color32(50, 0, 0, 255);
            DialogueBox.SetActive(true);
            Char1speech.text = "I understand *cough*...good luck.";

            primeInt = 200;
        }
        else if (primeInt >= 200 && nearElevator)
        {/*
            clipToPlay = 5;
            playAudioClip(clipToPlay);
            Char1speech.color = new Color32(0, 0, 0, 255);
            DialogueBox.SetActive(true);
            Char1speech.text = "Whew, connection's back. Looks like you're near the elevator. Take it up and you'll be one step closer to breaking out.";
        */
        }
        else if (primeInt > 201)
        {
            DialogueBox.SetActive(false);
            Char1speech.text = "";
        }

    }

    public void allowKeyPress(bool allow)
    {
        allowKey = allow;
        Debug.Log("allow key press: " + allow);
    }

    public void endNPCDialogue()
    {
        primeInt = 100;
        hideBox();
    }

    private void hideBox()
    {
        DialogueBox.SetActive(false);
        Char1speech.text = "";
        prompt.text = "";
    }

    public void playAudioClip(int clipNum)
    {
        if (vo.isPlaying)
        {
            vo.Stop();
        }
        if (clipNum <= voClips.Length - 1) vo.PlayOneShot(voClips[clipNum]);
        Debug.Log("clipNum " + clipNum);
        Debug.Log("length " + voClips.Length);
    }

    public void NPCSpared()
    {
        playerLeft = true;
    }

    public void NPCKilled()
    {
        playerKillsNPC = true;
    }

    public void level1Elevator()
    {
        Debug.Log("level1elevator called");
        nearElevator = true;
        clipToPlay = 5;
        playAudioClip(clipToPlay);
        Char1speech.color = new Color32(0, 0, 0, 255);
        DialogueBox.SetActive(true);
        Char1speech.text = "Whew, connection's back. Looks like you're near the elevator. Take it up and you'll be one step closer to breaking out.";

     //   StartCoroutine(Wait(voClips[5].length + 1f));

    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
       
    }
}
