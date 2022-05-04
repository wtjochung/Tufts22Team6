using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {
    public Material material;
    public RenderTexture render_texture;

    void Start() {
        material = new Material(material); //Create a copy of the provided material
        GetComponent<MeshRenderer>().material = material; //Set the object to use this instance of the material
        render_texture = new RenderTexture(1280, 720, 1000); //Create a new render texture
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, render_texture); //Write to the texture
        if (!GameManager.blind) {
            material.SetTexture("Texture", render_texture); //Set the material instance to use the texture we wrote to
        }
    }
}
