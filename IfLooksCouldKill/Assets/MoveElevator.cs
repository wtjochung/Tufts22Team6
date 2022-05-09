using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveElevator : MonoBehaviour
{
    public AudioSource elevatorSounds;
    public AudioClip elevatorMove;

    public float openHeight = 4.5f;
    public float duration = 3f;
   
    Vector3 closePosition;


    private bool playerEntered = false;

    // Start is called before the first frame update
    void Start()
    {
       
        // Sets the first position of the door as it's closed position.
        closePosition = transform.position;
        elevatorSounds = this.GetComponent<AudioSource>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerEntered == false)
        {
            Debug.Log("move elevator trigger called");
            FindObjectOfType<MoveElevatorDoor>().OperateDoor();
            elevatorSounds.Play();
            StartCoroutine(Wait(1f));
            playerEntered = true;
        }
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        elevatorSounds.PlayOneShot(elevatorMove);

        yield return new WaitForSeconds(0.01f);
    }

}
