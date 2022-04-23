using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : VisObject
{
    // Start is called before the first frame update
    new void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void laser_end_hit_event() {
        GameObject door = base.transform.parent.gameObject;
        door.GetComponent<MoveObject>().OperateDoor();
        FindObjectOfType<Level1Dialogue>().playerOpenedDoor();
    }
}
