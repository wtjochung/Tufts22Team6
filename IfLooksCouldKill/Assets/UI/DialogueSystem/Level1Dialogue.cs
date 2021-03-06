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

    public AudioSource vo;
    public AudioClip[] voClips;

    public bool allowKey = false;

    public Image blackScreen;
    public Canvas canvas;

    private int primeInt = 0;

    private bool playerOpensEye = false;
    private bool woodDestroyed = false;
    private bool finalLine = false;
    private bool end = false;
    private int clipToPlay = 0;
    private bool passedBlocks = false;//todo set trigger
    private bool passedSolar = false;//todo set false, set trigger

    private bool doorMove = false;

    //TODO: autoplay, integration of more voice clips
    

    // Start is called before the first frame update
    void Start()
    {
        blackScreen.color = new Color32(0, 0, 0, 255);
        DialogueBox.SetActive(true);

        Char1name.text = "";
        Char1speech.text = "Hello? Wake up? Would you please wake up?";

        prompt.text = "[E] to continue";

        allowKey = true;
       
    }

    public void talking()
    {         // main story function. Players hit next to progress to next int
        primeInt = primeInt + 1;

        if (!passedBlocks && !passedSolar)
        {
            if (primeInt == 1)
            {
                blackScreen.color = new Color32(0, 0, 0, 0);
            }
            else if (primeInt == 2)
            {
                clipToPlay = 0;
                playAudioClip(clipToPlay);

                Char1speech.text = "Thank god you're alive. We don't have much time. Could you incinerate that wood?";
            }
            else if (primeInt == 3)
            {
                clipToPlay = 1;
                playAudioClip(clipToPlay);

                Char1speech.text = "Oh. They blocked your vision.";
            }
            else if (primeInt == 4)
            {
                clipToPlay = 2;
                playAudioClip(clipToPlay);

                Char1speech.text = "There should be a switch on the side of your googles. Can you feel it?";
                prompt.text = "Click to disable goggles";
                GameManager.toggleAllowed = true;
            }
            else if (primeInt > 4 && primeInt < 100 && GameManager.blind == false && !woodDestroyed)
            {
                clipToPlay = 3;
                playAudioClip(clipToPlay);

                playerOpensEye = true;

                allowKey = true;

                prompt.text = "[E] to continue";

                Char1speech.color = new Color32(0, 0, 0, 255);
                Char1speech.text = "Be careful with that laser, you could kill someone if you aren't careful. Kill that wood while you??re at it.";

                primeInt = 100;

            }
            else if (primeInt > 100 && primeInt < 200 && playerOpensEye && woodDestroyed)
            {

                clipToPlay = 4;
                playAudioClip(clipToPlay);

                DialogueBox.SetActive(true);
                Char1speech.color = new Color32(0, 0, 0, 255);
                Char1speech.text = "Now turn off your beam. You should use your laser only when necessary.";
                primeInt = 200;

            }
            else if (primeInt > 200 && !finalLine)
            {

                clipToPlay = 5;
                playAudioClip(clipToPlay);
                clipToPlay = 10;

                DialogueBox.SetActive(true);
                Char1speech.color = new Color32(0, 0, 0, 255);
                Char1speech.text = "See those blocks? They're made of pure aluminum-grade iron. Not to worry, your eyes should melt right through them.";
                finalLine = true;
            }
            else if (primeInt > 200 && finalLine && !end)
            {

                hideBox();
                end = true;
                
            }
        } else if (passedBlocks && !passedSolar)
        {
            DialogueBox.SetActive(true);
            Debug.Log("Dialogue: passed blocks");
            if (primeInt == 1)
            {
                DialogueBox.SetActive(true);
                Debug.Log("solar 1");
                clipToPlay = 6;
                playAudioClip(clipToPlay);

                Char1speech.text = "That solar panel needs 12 volts of energy. Your eyes produce quite a lot more. Charge it up. Hopefully it won't explode.";
            }
            else if (primeInt == 2 && doorMove)
            {
                DialogueBox.SetActive(true);
                Debug.Log("solar 2");
                clipToPlay = 7;
                playAudioClip(clipToPlay);

                Char1speech.text = "Don't explode don't explode......";
            }
            else if (primeInt > 2 && primeInt < 100 )
            {
                Debug.Log("solar 3");
                clipToPlay = 8;
                playAudioClip(clipToPlay);

                Char1speech.text = "Okay, we're clear. Let's get a move on.";

                primeInt = 100;
                finalLine = true;
            }
            else if (primeInt > 100 && finalLine && !end)
            {
                hideBox();
                end = true;
            }
        } else if (passedSolar)
        {
            
            if (primeInt == 1)
            {
                DialogueBox.SetActive(true);
                clipToPlay = 9;
                playAudioClip(clipToPlay);

                Char1speech.text = "That thing's called a mirror. It reflects photons by inverting their angle of incidenc - oh, you already know how mirrors work? I'll leave you to it.";
            }
            else if (primeInt == 2)
            {
             
                clipToPlay = 10;
                playAudioClip(clipToPlay);

                Char1speech.text = "Amazing. Just a few more rooms and you should - *static*";
                primeInt = 300;
            } else if (primeInt >= 300 && !end)
            {
                hideBox();
                end = true;
            }
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

    public void playerDestroyedWood()
    {
        woodDestroyed = true;
        finalLine = false;
        end = false;
    }

    public void playerPassedBlocks()
    {
        if (!passedBlocks) primeInt = 0;
        passedBlocks = true;
        finalLine = false;
        end = false;
    }

    public void playerPassedSolar()
    {
        if (!passedSolar) primeInt = 0;
        passedSolar = true;
        finalLine = false;
        end = false;
    }

    public void doorMoved()
    {
        doorMove = true;
    }

    public void endDialogue()
    {
        primeInt = 500;
        playerOpensEye = true;
        woodDestroyed = true;
        finalLine = true;
        end = true;

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
        if (clipNum < voClips.Length) vo.PlayOneShot(voClips[clipNum]);
    }

}
