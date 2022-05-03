using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpareTrigger : MonoBehaviour
{
    private bool playerEntered = false;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerEntered == false)
        {
            FindObjectOfType<Level1Dialogue1>().NPCSpared();
            FindObjectOfType<Level1Dialogue1>().talking();
            Debug.Log("Player spared npc");
            playerEntered = true;
        }

    }
}
