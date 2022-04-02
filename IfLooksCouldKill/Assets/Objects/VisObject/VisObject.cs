using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisObject : MonoBehaviour {

    public GameObject hitEffect;
    public bool destroyWhenHit = true;
    public float timeToDestroy = 1f;

    private bool hit = false;

    void Update()
    {
        if (hit)
        {
            if (timeToDestroy > 0)
            {
                timeToDestroy -= Time.deltaTime;
            } else if (timeToDestroy <= 0)
            {
                this.transform.gameObject.SetActive(false);
            }
        }
    }



    public void HitByLaser()
    {
        hit = true;
        Instantiate(hitEffect);

        changeColor();
        
    }

    private void changeColor()
    {
        //TODO delete: the following are test code
        //Get the Renderer component from the new cube
        var renderer = this.GetComponent<Renderer>();

        //Call SetColor using the shader property name "_Color" and setting the color to red
        renderer.material.SetColor("_Color", Color.red);
    }
}
