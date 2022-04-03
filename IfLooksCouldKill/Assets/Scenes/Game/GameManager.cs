using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

//GameManager: Contains some stuff that all objects may need access to
public class GameManager : MonoBehaviour {
    public static bool blind;

    void Start() {
        blind = true;
    }

    void Update() {
        
    }

    public static void toggle_blind() {
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
        GameObject pp = GameObject.FindGameObjectWithTag("Post Processor");
        pp.GetComponent<PostProcessVolume>().enabled = !blind;
    }
}
