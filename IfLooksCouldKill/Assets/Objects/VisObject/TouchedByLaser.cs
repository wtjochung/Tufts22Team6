using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchedByLaser : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
//		if (!GameManager.blind) {
		if (!PlayerControl.temp_blind) {
            if (other.gameObject.tag == "Laser") {
                gameObject.SetActive(false);
            }
        }
    }
}
