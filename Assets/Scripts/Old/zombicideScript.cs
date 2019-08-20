using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombicideScript : MonoBehaviour {

    private void OnTriggerEnter(Collider collider)
    {
        print("bang");
        EventManager.TriggerEvent("zombicide");
    }
}
