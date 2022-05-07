using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChangeScene: MonoBehaviour
{
    public string sceneToLoad = "";
    public GameObject item;
    private RawImage a;
    private Color32 endColor;

    public void Start()
    {
        a = item.GetComponent<RawImage>();
        endColor = new Color32(255, 0, 0, 100);
    }

    public void SetScene()
    {
        StartCoroutine(changeOpacity());

        
    }

    public void changeScene(string sceneName)
    {
        Time.timeScale = 1f;
        if (sceneName != "") SceneManager.LoadScene(sceneName);
    }

    private IEnumerator changeOpacity()
    {

        float tick = 0f;
        while (a.color != endColor)
        {
            tick += Time.deltaTime * 0.05f;
            a.color = Color.Lerp(a.color, endColor, tick);
            yield return null;
        }
        if (a.color == endColor)
        {
            changeScene(sceneToLoad);
        }
    }
}