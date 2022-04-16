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
		
		fireHitPosition = this.transform.position;
	}

	void Update() {
		int linesCount = 0;
		if (!GameManager.blind) {
			foreach (LaserBeam laser in lasers) {
				linesCount += CalcLaserLine(laser.transform.position + laser.transform.forward * 0.6f, laser.transform.forward, linesCount);
			}
		}
		RemoveOldLines(linesCount);

		//moveParticleSystem(fireHitPosition);
	}

	

	Vector3 getFireHitPosition()
    {
		return fireHitPosition;
    }

	int CalcLaserLine(Vector3 startPosition, Vector3 direction, int index) {
		RaycastHit hit;
		Ray ray = new Ray(startPosition, direction);
		bool intersect = Physics.Raycast(ray, out hit, maxStepDistance);		

		if (!intersect) { 
			hit.point = startPosition + direction * maxStepDistance;
			fire.GetComponent<moveParticleSystem>().setParticle(false);
			fireActive = false;
		}

		unsafe {
			DrawLine(&startPosition, &hit, index);
		}
		
		if (intersect) {
			if (hit.transform.gameObject.CompareTag("Interactable")) {
				/*Instantiate(hitEffect);
				hit.transform.gameObject.SetActive(false);
				*/
				//fire.transform = hit.transform;
				//p_system.Play(includeChildren);

				if (!fireActive)
                {
					fireActive = true;
					fire.GetComponent<moveParticleSystem>().setParticle(true);

				}
				

				hit.transform.gameObject.GetComponent<VisObject>().HitByLaser();

				fireHitPosition = hit.point;
				fire.GetComponent<moveParticleSystem>().setDestination(fireHitPosition);
				//p_system.transform = Vector3.MoveTowards(p_system, hit.transform, Time.deltaTime * 1f);
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
			GameObject go = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
			line = go.GetComponent<LineRenderer>();
			lines.Add(go);
		}

		line.SetPosition(0, *startPosition);
		line.SetPosition(1, finishPosition->point);
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
			