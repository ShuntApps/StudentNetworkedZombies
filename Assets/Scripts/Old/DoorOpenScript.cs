using UnityEngine;
using System.Collections;

public class DoorOpenScript : MonoBehaviour {

    void OnEnable()
    {
        this.transform.position = 
            new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
    }
    void OnDisable()
    {
        this.transform.position =
            new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
    }
}
