using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveElevatorTrigger : MonoBehaviour
{
    private bool playerEntered = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerEntered == false)
        {
            FindObjectOfType<Level2Dialogue>().talking();
          
            Debug.Log("Player at elevator trigger");
            playerEntered = true;
        }

    }
}
