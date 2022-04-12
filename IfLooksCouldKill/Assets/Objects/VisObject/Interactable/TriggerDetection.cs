using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetection : MonoBehaviour
{

    public Canvas canvas;
    private bool triggerStay = false;
    private bool isColliding = false;
    private bool pressed = false;

    public bool openDoor = true;
    public bool destroyWhenPressed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown("e") && isColliding)
        {
            Debug.Log("E pressed");

            if (!pressed)
            {
                pressed = true;

                //Note: replace with whatever action when pressed
                Vector3 scaleChange = new Vector3(0, -0.1f, 0);
                this.transform.parent.localScale += scaleChange;

                if (openDoor)
                {
                    if (destroyWhenPressed) this.transform.gameObject.SetActive(false);
                    GameObject door = this.transform.parent.parent.gameObject;
                    door.GetComponent<MoveObject>().OperateDoor();
                }
            }

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (triggerStay)
        {
            isColliding = true;
            triggerStay = false;
           
        }
        else
        {
            isColliding = false;
            canvas.GetComponent<EKeyInteraction>().allowKeyPress(false);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerStay = true;
            canvas.GetComponent<EKeyInteraction>().allowKeyPress(true);
          //  Debug.Log("player trigger enter button");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerStay = true;
          //  Debug.Log("player trigger stay button");
        }
    }
    
}
