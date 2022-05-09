using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

//GameManager: Contains some stuff that all objects may need access to
public class GameManager : MonoBehaviour {
    public static bool blind;
    public static bool toggleAllowed = false;

    float closed_frames;

    public static GameObject prompt;
    public Material default_skybox_public;
    public Material blank_skybox_public;
    public static Material default_skybox;
    public static Material blank_skybox;

    public static LaserManager laser;

    void Start()
    {
        blind = true;
        closed_frames = 0;
        default_skybox = default_skybox_public;
        blank_skybox = blank_skybox_public;
        set_state(blind);
        laser = FindObjectOfType<LaserManager>();
    }

    void FixedUpdate() {
        if (blind) {
            if (closed_frames < 120) {
                closed_frames++;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Light>().intensity = ((closed_frames - 60f) / 60f) * 6f;
            }
        }
        else {
            closed_frames = 0;
        }
    }

    public static void toggle_blind() {
        if (toggleAllowed) {
            blind = !blind;
            set_state(blind);
        }
    }

    public static void set_state(bool blind) {
        if (blind) {
            Shader.SetGlobalInt("_Blind", 1);
            RenderSettings.skybox = blank_skybox;
            RenderSettings.reflectionIntensity = 0.0f;
            
        }
        else {
            Shader.SetGlobalInt("_Blind", 0);
            RenderSettings.skybox = default_skybox;
            RenderSettings.reflectionIntensity = 1.0f;
            
        }
        GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject light in lights) {
            light.GetComponent<Light>().enabled = !blind;
        }
        GameObject player_light = GameObject.FindGameObjectWithTag("MainCamera");
        player_light.GetComponent<Light>().enabled = blind;
        GameObject[] laser_cylinders = GameObject.FindGameObjectsWithTag("Laser");
        foreach (GameObject laser_cylinder in laser_cylinders) {
            laser_cylinder.GetComponent<MeshRenderer>().enabled = !blind;
        }
        GameObject pp = GameObject.FindGameObjectWithTag("Post Processor");
        pp.GetComponent<PostProcessVolume>().enabled = !blind;
    }
}

