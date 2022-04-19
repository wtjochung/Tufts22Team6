using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

//GameManager: Contains some stuff that all objects may need access to
public class GameManager : MonoBehaviour {
    public static bool blind;
    public static bool toggleAllowed = false;

    private static bool openedEye = false;
    public static GameObject prompt;

    void Start() {

        blind = true;
        set_state(blind);

      //  prompt = GameObject.Find("PressEPrompt_center");
    }

    void Update() {
        
    }

    public static void toggle_blind()
    {
        if (!openedEye)
        {
            openedEye = true;
            if (prompt != null)
            {
            //    prompt.GetComponent<Text>().text = "[E] to continue";
            }
        }

        if (toggleAllowed)
        {
            blind = !blind;
            set_state(blind);
        }
    }

    public static void set_state(bool blind)
    {
        if (blind)
        {
            Shader.SetGlobalInt("_Blind", 1);
            RenderSettings.reflectionIntensity = 0.0f;
        }
        else
        {
            Shader.SetGlobalInt("_Blind", 0);
            RenderSettings.reflectionIntensity = 1.0f;
        }
        GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject light in lights)
        {
            light.GetComponent<Light>().enabled = !blind;
        }
        GameObject player_light = GameObject.FindGameObjectWithTag("MainCamera");
        player_light.GetComponent<Light>().enabled = blind;
        GameObject[] laser_cylinders = GameObject.FindGameObjectsWithTag("Laser");
        foreach (GameObject laser_cylinder in laser_cylinders)
        {
            laser_cylinder.GetComponent<MeshRenderer>().enabled = !blind;
        }
        GameObject pp = GameObject.FindGameObjectWithTag("Post Processor");
        pp.GetComponent<PostProcessVolume>().enabled = !blind;
    }
}

