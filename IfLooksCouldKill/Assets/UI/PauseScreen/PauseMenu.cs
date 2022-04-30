using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;



/// <summary>
/// A class which manages pages of UI elements
/// and the game's UI
/// </summary>
public class PauseMenu : MonoBehaviour
{

    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    private GameObject settingsMenuUI;
    private bool settings;
    public string sceneName;
    string currentSceneName;
    private GameObject player;
 

    void Start()
    {
        pauseMenuUI.SetActive(false);
        var currentScene = SceneManager.GetActiveScene();
        currentSceneName = currentScene.name;

        player = GameObject.FindGameObjectWithTag("Player");
       
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))//Input.GetKeyDown(KeyCode.Escape) || 
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameisPaused = true;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
       // player.SetActive(false);
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
     
        Time.timeScale = 1f;
        GameisPaused = false;

        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        //restart the game:
        SceneManager.LoadScene(currentSceneName);
    }

}
