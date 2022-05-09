using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterChasmTrigger : MonoBehaviour
{
    private bool playerEntered = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerEntered == false)
        {
            FindObjectOfType<Level2Dialogue>().playerPassedChasm();
            FindObjectOfType<Level2Dialogue>().talking();

            Debug.Log("Player at chasm trigger");
            playerEntered = true;
        }

    }
}
