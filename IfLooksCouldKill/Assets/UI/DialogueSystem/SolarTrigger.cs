using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarTrigger : MonoBehaviour
{
    private bool playerEntered = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerEntered == false)
        {
            FindObjectOfType<Level1Dialogue>().playerPassedSolar();
            FindObjectOfType<Level1Dialogue>().talking();
            Debug.Log("Player entered solartrigger");
            playerEntered = true;
        }
        
    }
}
