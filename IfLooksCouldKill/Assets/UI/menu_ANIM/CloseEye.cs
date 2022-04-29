using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseEye : MonoBehaviour {
    bool rev;
    void Start() {
        
    }

    void FixedUpdate() {
        if (rev) {
            if (frame < 22) {
                frame++;
            }
        }
        else {
            if (frame >= 0) {
                frame--;
            }
        }
    }

    float frame;

    public static void set_state(bool state) {

    }
}
