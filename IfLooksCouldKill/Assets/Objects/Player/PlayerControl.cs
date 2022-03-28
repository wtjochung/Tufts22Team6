using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour {
    private Rigidbody rb;
    public float speed = 0;
    private float movementX, movementY;
    public static bool temp_blind;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    /*
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    */

    void FixedUpdate() {


        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        //todo see first person tutorial and change
        rb.AddForce(movement * speed);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            unsafe {
                //maybe people wouldn't be so scared of pointers if 
                //i didn't have to do whatever the hell this is and
                //change multiple compiler settings to even allow 
                //them
                fixed(bool* temp_blind_ptr = &temp_blind)
                GameManager.set_blind(temp_blind_ptr);
            }
        }
    }
}