using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisObject : MonoBehaviour {
    public Material material;
    public Material base_material;

    void Start() {
        material = GetComponent<Material>();
        base_material = material;
    }

    void Update() {
        set_render_material();
    }

    void set_render_material() {
        if (GameManager.blind) {
            material = utils.blind_material;
        }
        else {
            material = base_material;
        }
    }
}
