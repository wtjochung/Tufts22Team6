using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : VisObject
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    new void laser_end_hit_event() {
        GameObject door = this.transform.parent.gameObject;
        door.GetComponent<MoveObject>().OperateDoor();
        FindObjectOfType<Level1Dialogue>().playerOpenedDoor();
    }
}
