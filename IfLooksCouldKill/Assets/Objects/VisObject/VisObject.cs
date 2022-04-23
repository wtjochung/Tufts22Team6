using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisObject : MonoBehaviour {

	public GameObject hitEffect;
	public bool destroyWhenHit = true;
	public float timeToDestroy = 3f;

	bool called_start_hit = false;
	bool called_end_hit = false;

	private Color altColor;
	private float colorChangeStep;

	public void Start() {
		altColor = this.GetComponent<Renderer>().material.color;
		colorChangeStep = (255 - altColor.r) / timeToDestroy;

	}

	void Update() {
		
	}

	public virtual void laser_start_hit_event() {

	}

	public virtual void laser_hit_event() {

	}

	public virtual void laser_end_hit_event() {

	}

	public void HitByLaser() {
		if (!called_start_hit) {
			Instantiate(hitEffect);
			laser_start_hit_event();
			called_start_hit = true;
		}
	   
		if (timeToDestroy > 0) {
			laser_hit_event();
			timeToDestroy -= Time.deltaTime;
			changeColor();
		}
		else {
			if (!called_end_hit) {
				laser_end_hit_event();
				called_end_hit = true;
			}
			if (destroyWhenHit) {
				this.gameObject.SetActive(false);
			}
		}
	}

	private void changeColor() {
		var renderer = this.GetComponent<Renderer>();

		altColor.r += (colorChangeStep / 100) * Time.deltaTime;
		renderer.material.color = altColor;
	}
}
