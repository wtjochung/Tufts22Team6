using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour {
	static public LaserManager instance;

	float maxStepDistance = 20;

	public GameObject LinePrefab;
	List<LaserBeam> lasers = new List<LaserBeam>();
	List<GameObject> lines = new List<GameObject>();

	GameObject fire;

	public GameObject hitEffect;

	private Vector3 fireHitPosition;
	private bool fireActive = false;

	

	public bool includeChildren = true;

	public void AddLaser(LaserBeam laser) { 
		lasers.Add(laser); 
	}

	public void RemoveLaser(LaserBeam laser) { 
		lasers.Remove(laser); 
	}

	void RemoveOldLines(int linesCount) {
		if (linesCount < lines.Count) {
			Destroy(lines[lines.Count - 1]);
			lines.RemoveAt(lines.Count - 1);
			RemoveOldLines(linesCount);
		}
	}

	void Awake() {
		instance = this;
		fire = GameObject.FindGameObjectWithTag("Fire");

		Vector3 bottom = new Vector3(transform.position.x, transform.position.x - 10, transform.position.z);
		fireHitPosition = bottom;
		fire.SetActive(false);
	}

	void FixedUpdate() { //Changing this to FixedUpdate lets weaker computers catch a break
		int linesCount = 0;
		if (!GameManager.blind) {
			for (int i = 0; i < lasers.Count; i++) { //faster, doesn't need to allocate duplicate vars
				linesCount += CalcLaserLine(lasers[i].transform.position + lasers[i].transform.forward * 0.6f, lasers[i].transform.forward, linesCount);
			}
		}
		RemoveOldLines(linesCount);

		//moveParticleSystem(fireHitPosition);
	}

	

	Vector3 getFireHitPosition() {
		return fireHitPosition;
    }

	int CalcLaserLine(Vector3 startPosition, Vector3 direction, int index) {
		RaycastHit hit;
		Ray ray = new Ray(startPosition, direction); //I'm really surprised there isn't a better way to do this
		bool intersect = Physics.Raycast(ray, out hit, maxStepDistance);		

		if (!intersect) { 
			hit.point = startPosition + direction * maxStepDistance;
			//fire.SetActive(false);
			fire.GetComponent<moveParticleSystem>().setParticle(false);
			fireActive = false;
		}

		unsafe {
			DrawLine(&startPosition, &hit, index);
		}
		
		if (intersect) {
			if (hit.transform.gameObject.CompareTag("Interactable")) {

				//activate the fire particle system
				if (!fireActive)
                {
					fire.SetActive(true);
					fireActive = true;
					fire.GetComponent<moveParticleSystem>().setParticle(true);

				}

				hit.transform.gameObject.GetComponent<VisObject>().HitByLaser();

				//move the fire particle system to the hit point
				fireHitPosition = hit.point;
				fire.GetComponent<moveParticleSystem>().setDestination(fireHitPosition);
			}
			else {
				return 1 + CalcLaserLine(hit.point, Vector3.Reflect(direction, hit.normal), index + 1);
			}
		}
		return 1;
	}

	
	unsafe void DrawLine(Vector3 *startPosition, RaycastHit *finishPosition, int index) {
		LineRenderer line = null;
		if (index < lines.Count) {
			line = lines[index].GetComponent<LineRenderer>();
		} 
		else {
			GameObject go = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity); //Feel like there might be a better way to
			//do this
			line = go.GetComponent<LineRenderer>();
			lines.Add(go);
		}

		line.SetPosition(0, *startPosition);
		line.SetPosition(1, finishPosition->point);
	}

	public void setFireActive(bool active)
    {
		fire.SetActive(active);
	}

	/*

	void CalcLaserLine(Vector3 startPosition, Vector3 direction)
	{
		RaycastHit hit;
		Ray ray = new Ray(startPosition, direction);
		bool intersect = Physics.Raycast(ray, out hit, maxStepDistance);

		Vector3 hitPosition = hit.point;
		if (!intersect)
		{
			hitPosition = startPosition + direction * maxStepDistance;
		}

		DrawLine(startPosition, hitPosition);

		if (intersect)
		{
			CalcLaserLine(hitPosition, Vector3.Reflect(direction, hit.normal));
		}



	}
	*/




}
			