using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveParticleSystem : MonoBehaviour
{
    
    public float fireFollowSpeed = 10f;
    public Vector3 moveTo;

    ParticleSystem system
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }
    private ParticleSystem _CachedSystem;

    public bool includeChildren = true;

    public void setDestination(Vector3 location)
    {
        moveTo = location;
    }

    public void moveTowards(Vector3 targetPosition)
    {

        this.transform.position = Vector3.MoveTowards(transform.position, moveTo, fireFollowSpeed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
      //  moveTo = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        moveTowards(moveTo);
    }

   public void setParticle(bool on)
    {
        if (on)
        {
            system.Play(includeChildren);
        } else
        {
            system.Stop(includeChildren);
        }
        
    }
}
