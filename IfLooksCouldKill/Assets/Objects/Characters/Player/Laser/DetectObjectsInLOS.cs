using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectObjectsInLOS : MonoBehaviour
{
    public GameObject LinePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = Instantiate(LinePrefab, Vector3.zero, Quaternion.identity);
    }
}
