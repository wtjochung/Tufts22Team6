using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : VisObject {
    public GameObject DialogueBox;
    public Text speech;

    public Text prompt;

    void Start() {
        
    }

    void Update() {
        
    }

    new void laser_hit_event() {
        DialogueBox.SetActive(true);
        speech.color = new Color32(50, 0, 0, 200);
        speech.text = "ARRRRRR!!!...thank you!";
    }

    new void laser_end_hit_event() {
        DialogueBox.SetActive(false);
        speech.text = "...";
    }
}
