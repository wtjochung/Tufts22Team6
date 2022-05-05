using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {
    public Material material;
    public RenderTexture render_texture;
    public Transform target;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        material = new Material(Shader.Find("Custom/Blind")); //Create a copy of the provided material
        render_texture = new RenderTexture(1280, 720, 1); //Create a new render texture
        material.SetTexture("_MainTex", render_texture); //Set the material instance to use the texture we wrote to
        GetComponentInParent<Renderer>().material = material; //Set the object to use this instance of the material
    }

    void Update() {
        transform.LookAt(target);
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, render_texture); //Write to the texture
    }
}
