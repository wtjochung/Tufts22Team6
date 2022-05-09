using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    private bool playerEntered = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerEntered == false)
        {
            FindObjectOfType<Level1Dialogue1>().level1Elevator();
           // FindObjectOfType<Level1Dialogue1>().talking();
            Debug.Log("elevator");
            playerEntered = true;

        }

    }
}
