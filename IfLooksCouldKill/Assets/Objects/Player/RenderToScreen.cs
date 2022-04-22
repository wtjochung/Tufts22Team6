using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderToScreen : MonoBehaviour {
    public Material material;
    void Start() {
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest) {
        if (GameManager.blind) {
            Graphics.Blit(src, dest);
        }
        else {
            Graphics.Blit(src, dest, material);
        }
    }
}
