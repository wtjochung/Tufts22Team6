using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTrigger : MonoBehaviour
{
    private bool playerEntered = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerEntered == false)
        {
            FindObjectOfType<Level1Dialogue>().playerPassedBlocks();
            FindObjectOfType<Level1Dialogue>().talking();
            Debug.Log("Player entered block trigger");
            playerEntered = true;
        }
        
    }
}
