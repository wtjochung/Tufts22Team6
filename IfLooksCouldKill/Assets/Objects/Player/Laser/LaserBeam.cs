using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LaserManager.instance.AddLaser(this);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
