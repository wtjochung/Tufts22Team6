using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour {
	static public LaserManager instance;

	float maxStepDistance = 20;

	public GameObject LinePrefab;
	List<LaserBeam> lasers = new List<LaserBeam>();
	List<GameObject> lines = new List<GameObject>();

	//public GameObject hitEffect;

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
	}

	void Update() {
		int linesCount = 0;
		if (!GameManager.blind) {
			foreach (LaserBeam laser in lasers) {
				linesCount += CalcLaserLine(laser.transform.position + laser.transform.forward * 0.6f, laser.transform.forward, linesCount);
			}
		}
		RemoveOldLines(linesCount);
	}

	int CalcLaserLine(Vector3 startPosition, Vector3 direction, int index) {
		int result = 1;
		RaycastHit hit;
		Ray ray = new Ray(startPosition, direction);
		bool intersect = Physics.Raycast(ray, out hit, maxStepDistance);		

		Vector3 hitposition = hit.point;
		if (!intersect) { 
			hitposition = startPosition + direction * maxStepDistance; 
		}

		DrawLine(startPosition, hitposition, index);
		
		if (intersect) {
			if (hit.transform.gameObject.CompareTag("Interactable")) {
				/*Instantiate(hitEffect);
				hit.transform.gameObject.SetActive(false);
				*/
				hit.transform.gameObject.GetComponent<VisObject>().HitByLaser();
			}
			else {
				result += CalcLaserLine(hitposition, Vector3.Reflect(direction, hit.normal), index + result);
			}
		}
		return result;
	}

	void DrawLine(Vector3 startPosition, Vector3 finishPosition, int index) {
		LineRenderer line = null;
		if (index < lines.Count) {
			line = lines[index].GetComponent<LineRenderer>();
		} 
		else {
			GameObject go = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
			line = go.GetComponent<LineRenderer>();
			lines.Add(go);
		}

		line.SetPosition(0, startPosition);
		line.SetPosition(1, finishPosition);
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
			