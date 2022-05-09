using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveElevatorDoor : MonoBehaviour
{
    
    public float openHeight = 8f;
    public float duration = 3.5f;
    bool doorOpen;
    Vector3 closePosition;

    private void Start()
    {
        closePosition = this.transform.position;
    }

    public void OperateDoor()
    {
        Debug.Log("move elevator door called");
        StopAllCoroutines();
        if (!doorOpen)
        {
            Vector3 openPosition = closePosition + Vector3.down * openHeight;
            StartCoroutine(MoveDoor(openPosition));

            StartCoroutine(Wait(7f));
            
        }
        else
        {
            //StartCoroutine(MoveDoor(closePosition));
        }
        doorOpen = !doorOpen;
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("load scene");
        SceneManager.LoadSceneAsync("LEVEL2");

        yield return new WaitForSeconds(0.01f);
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = this.transform.position;
        while (timeElapsed < duration)
        {
            //  player.transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed / duration);

            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        // player.transform.position = targetPosition;
    }

}
