using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisObject : MonoBehaviour {

    public GameObject hitEffect;
    public bool destroyWhenHit = true;
    public float timeToDestroy = 3f;

    private bool hit = false;

    private Color altColor;
    private float colorChangeStep;

    private void Start() {
        altColor = this.GetComponent<Renderer>().material.color;
        colorChangeStep = (255 - altColor.r) / timeToDestroy;

    }

    void Update() {
        
    }

    public void laser_start_hit_event() {

    }

    public void laser_hit_event() {

    }

    public void laser_end_hit_event() {

    }

    public void HitByLaser() {
        if (!hit) {
            hit = true;
            Instantiate(hitEffect);
            laser_start_hit_event();
        }
       
        if (hit) {
            if (timeToDestroy > 0) {
                laser_hit_event();

                timeToDestroy -= Time.deltaTime;
                changeColor();
            }
            else if (timeToDestroy <= 0 && altColor.r > 0.7) {
                laser_end_hit_event();
                if (destroyWhenHit) this.transform.gameObject.SetActive(false);
            }
        }
    }

    private void changeColor() {
        var renderer = this.GetComponent<Renderer>();

        altColor.r += (colorChangeStep / 100) * Time.deltaTime;
        renderer.material.color = altColor;
    }
}
