using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPanelOpenTrigger : MonoBehaviour
{
    private bool panelEntered = false;
    private void OnTriggerStay(Collider other)
    {
        if (!panelEntered && other.CompareTag("Interactable"))
        {

            FindObjectOfType<Level1Dialogue>().doorMoved();
            FindObjectOfType<Level1Dialogue>().talking();
            Debug.Log("Panel move trigger");
            panelEntered = true;
        }

    }

}
