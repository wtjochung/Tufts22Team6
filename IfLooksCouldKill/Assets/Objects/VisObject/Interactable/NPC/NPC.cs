using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : VisObject {
    public GameObject DialogueBox;
    public Text speech;
    public Text prompt;



    new void Start() {
        base.Start();
    }

    void Update() {
        
    }

    public override void laser_hit_event() {
        Debug.Log("hit in npc");
        DialogueBox.SetActive(true);
        speech.color = new Color32(50, 0, 0, 200);
        speech.text = "ARRRRRR!!!...thank you!";

        FindObjectOfType<Level1Dialogue1>().playAudioClip(3);

    }

    public override void laser_end_hit_event() {
        DialogueBox.SetActive(false);
        speech.text = "...";
    }
}
