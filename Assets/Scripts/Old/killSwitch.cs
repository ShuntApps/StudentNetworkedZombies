using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killSwitch : MonoBehaviour {

    void OnEnable()
    {
        EventManager.StartListening("zombicide", kill);
    }

    void OnDisable()
    {
        EventManager.StopListening("zombicide", kill);
    }

    void kill()
    {
        Destroy(gameObject);
    }
}
