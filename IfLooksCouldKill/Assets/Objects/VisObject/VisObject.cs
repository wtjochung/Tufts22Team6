using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisObject : MonoBehaviour {

	public GameObject hitEffect;
	public AudioSource audio_source;
	public Light vis_light;
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
		if (audio_source != null && vis_light != null) {
			
			update_sound_light();
		}
	}

	public void update_sound_light() {
		if (audio_source.isPlaying) {
			vis_light.GetComponent<Light>().enabled = true;
		}
		else {
			vis_light.GetComponent<Light>().enabled = false;
		}
	}

	public virtual void laser_start_hit_event() {

	}

	public virtual void laser_hit_event() {
		Debug.Log("hit in visobject");
	}

	public virtual void laser_end_hit_event() {

	}

	public void HitByLaser() {
		if (!called_start_hit) {
			//Instantiate(hitEffect);
			GameObject particleSys = Instantiate(hitEffect);
			if (audio_source != null && !audio_source.isPlaying) audio_source.Play();
			StartCoroutine(destroyParticles(particleSys));
			laser_start_hit_event();
			called_start_hit = true;
		}
	   
		if (timeToDestroy > 0) {
			laser_hit_event();
			Debug.Log("laser hit event called");
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

	IEnumerator destroyParticles(GameObject pSys)
	{
		yield return new WaitForSeconds(5f);
		Destroy(pSys);
	}

	private void changeColor() {
		var renderer = this.GetComponent<Renderer>();

		altColor.r += (colorChangeStep / 100) * Time.deltaTime;
		renderer.material.color = altColor;
	}
}
