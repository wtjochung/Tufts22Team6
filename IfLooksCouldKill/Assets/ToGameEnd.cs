using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToGameEnd : MonoBehaviour
{

    public string sceneName = "";
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            changeScene();
        }
    }
    public void changeScene()
    {
        Time.timeScale = 0.0001f;
        if (sceneName != "") SceneManager.LoadScene(sceneName);
    }
}
