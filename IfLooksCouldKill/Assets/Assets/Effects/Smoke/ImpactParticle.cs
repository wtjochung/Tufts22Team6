using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactParticles : MonoBehaviour
{

    public GameObject hitParticles;
    public Vector3 spwnPoint;

    void OnCollisionEnter2D(Collision2D other)
    {
        
            //get impact location
            spwnPoint = other.contacts[0].point;
            //make particles
            GameObject particleSys = Instantiate(hitParticles, spwnPoint, other.transform.rotation);
            StartCoroutine(destroyParticles(particleSys));
        
    }

    IEnumerator destroyParticles(GameObject pSys)
    {
        yield return new WaitForSeconds(5f);
        Destroy(pSys);
    }
}