using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GameManager: Contains some stuff that all objects may need access to
public class GameManager : MonoBehaviour {
    public bool blind;

    void Start() {
        blind = true;
    }

    void Update() {
        
    }

    //later on i'll make it so this function uses its own blind
    //var instead of one from the player and these ptr shenanigans,
    //but this class isn't instantiated in the test game scene and 
    //I haven't gotten around to putting anything in the actual game
    //scene yet
    unsafe public static void set_blind(bool *blind) {
        *blind = !*blind;
        if (*blind) {
            Shader.SetGlobalInt("_Blind", 1); //thanks c#
            RenderSettings.reflectionIntensity = 0.0f;
        }
        else {
            Shader.SetGlobalInt("_Blind", 0);
            RenderSettings.reflectionIntensity = 1.0f;
        }
        GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject light in lights) {
            light.GetComponent<Light>().enabled = !*blind;
        }
        GameObject player_light = GameObject.FindGameObjectWithTag("MainCamera");
        player_light.GetComponent<Light>().enabled = *blind;
        GameObject laser_cylinder = GameObject.FindGameObjectWithTag("Laser");
        laser_cylinder.GetComponent<MeshRenderer>().enabled = !*blind;
    }

    public void toggle_blind() {
        blind = !blind;
        if (blind) {
            Shader.SetGlobalInt("_Blind", 1);
        }
        else {
            Shader.SetGlobalInt("_Blind", 0);
        }
        GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject light in lights) {
            light.GetComponent<Light>().enabled = !blind;
        }
        GameObject player_light = GameObject.FindGameObjectWithTag("MainCamera");
        player_light.GetComponent<Light>().enabled = blind;
        GameObject laser_cylinder = GameObject.FindGameObjectWithTag("Laser");
        laser_cylinder.GetComponent<MeshRenderer>().enabled = !blind;
    }
}
