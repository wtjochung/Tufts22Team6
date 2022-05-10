using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour {
    private Rigidbody rb;
    public float speed = 0;
    private float movementX, movementY;

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
        if (Input.GetMouseButtonDown(0) && !PauseMenu.GameisPaused) {
            GameManager.toggle_blind();
        }
        if (GetComponent<Transform>().position.y < -17) {
            die();
        }
    }

    public void die() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }
}
