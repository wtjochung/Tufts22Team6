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
        transform.LookAt(target); //Look at the player. This isn't actually how mirrors work, so we're not done :(
        float x_coord = transform.localRotation.eulerAngles.x; //Calculate the x and y coords. Unity will "correct" negative numbers
        //to be overflowing, but we actually like negative numbers and the rotation should never go above 180 anyway, so it's pretty
        //easy to correct for that
        if (x_coord > 180.0f) {
            x_coord -= 360.0f;
        }
        float y_coord = transform.localRotation.eulerAngles.y;
        if (y_coord > 180.0f) {
            y_coord -= 360.0f;
        }
        //We don't need to do this for z because it'll always be 0
        transform.Rotate(x_coord * -2.0f, y_coord * -2.0f, 0.0f); //Invert the y coord so it was a reflection based on the angle
        //the player looked at it from
        transform.SetPositionAndRotation(transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f));
        //And then do some weird bullshit because the previous call actually did rotate z when it wasn't supposed to lol
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        Graphics.Blit(src, render_texture); //Write to the texture
    }
}
