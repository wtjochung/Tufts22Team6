using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisObject : MonoBehaviour {

    public GameObject hitEffect;
    public bool destroyWhenHit = true;
    public float timeToDestroy = 1f;

    private bool hit = false;

    private Color altColor;
    private float colorChangeStep;

    public bool openDoor = false;

    private void Start()
    {
        altColor = this.GetComponent<Renderer>().material.color;
        colorChangeStep = 1f / timeToDestroy;

    }

    void Update()
    {
        
    }



    public void HitByLaser()
    {
        if (!hit)
        {
            Debug.Log("hit by laser");
            hit = true;
            Instantiate(hitEffect);
        }
       
        if (hit)
        {
            if (timeToDestroy > 0)
            {
                Debug.Log("time to destroy: " + timeToDestroy);
                timeToDestroy -= Time.deltaTime;
                changeColor();
            }
            else if (timeToDestroy <= 0 && altColor.r > 0.7)
            {
                if (destroyWhenHit) this.transform.gameObject.SetActive(false);
                Debug.Log("set inactive");
                if (openDoor)
                {
                    GameObject door = this.transform.parent.gameObject;
                    door.GetComponent<MoveObject>().OperateDoor();
                }
            }
        }
    }

    private void changeColor()
    {
        //TODO delete: the following are test code
        //Get the Renderer component from the new cube
        var renderer = this.GetComponent<Renderer>();

        altColor.r += colorChangeStep / 100;
        Debug.Log("color: " + altColor.r);
        //Assign the changed color to the material. 
        renderer.material.color = altColor;
        //Call SetColor using the shader property name "_Color" and setting the color to red
       // renderer.material.SetColor("_Color", Color.red);
    }
}
