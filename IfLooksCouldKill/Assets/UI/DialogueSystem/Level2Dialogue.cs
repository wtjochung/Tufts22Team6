using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Dialogue : MonoBehaviour
{
    public GameObject DialogueBox;
    public Text Char1name;
    public Text Char1speech;

    public Text prompt;

    public AudioSource vo;
    public AudioClip[] voClips;

    public bool allowKey = true;

    public Canvas canvas;

    private int primeInt = 0;

    private bool finalLine = false;
    private bool end = false;
    private int clipToPlay = 0;
   
    private bool passedChasm = false;//todo set false, set trigger

    //TODO: autoplay, integration of more voice clips


    // Start is called before the first frame update
    void Start()
    {
        //DialogueBox.SetActive(true);

        Char1name.text = "";
        Char1speech.text = "Just go down this hallway and the exit should be - oh my god. Why is there a chasm???";

        prompt.text = "Press [e] to continue";

        clipToPlay = 0;
        playAudioClip(clipToPlay);

        allowKey = true;
        GameManager.toggleAllowed = true;

    }

    public void talking()
    {         // main story function. Players hit next to progress to next int
        primeInt = primeInt + 1;

        if (primeInt >= 1 && primeInt < 100)
        {
            clipToPlay = 1;
            playAudioClip(clipToPlay);

            Char1speech.text = "I know you're tempted to open your vision but...be careful? You don't wanna accidentally dissolve any platforms.";

            primeInt = 100;
        } else if (primeInt >= 100 && !passedChasm)
        {
            hideBox();
        }
        else if (primeInt >= 100 && passedChasm && !finalLine)
        {
            clipToPlay = 2;
            playAudioClip(clipToPlay);

            DialogueBox.SetActive(true);

            prompt.text = "Press [e] to continue";

            Char1speech.text = "Thank god.";
            finalLine = true;

        } else if (!end && finalLine) { 
            hideBox();
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

    public void playerPassedChasm()
    {
        passedChasm = true;
      
    }

   

    public void endDialogue()
    {
        primeInt = 500;
        passedChasm = true;
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
