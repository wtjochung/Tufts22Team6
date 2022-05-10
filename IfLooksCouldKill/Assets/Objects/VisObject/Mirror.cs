using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour {
    public Material material;

    void Start() {
        Renderer renderer = GetComponentInParent<Renderer>();
        material = new Material(Shader.Find("Custom/Blind"));
        renderer.material = material;
    }

    void Update() {

    }
}
