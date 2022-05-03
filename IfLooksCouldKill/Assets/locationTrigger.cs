using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationTrigger : MonoBehaviour
{
    private bool playerEntered = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerEntered == false)
        {
            FindObjectOfType<Level1Dialogue>().playerDestroyedWood();
            FindObjectOfType<Level1Dialogue>().talking();
            Debug.Log("Player entered wood trigger");
            playerEntered = true;
        }
        
    }
}
