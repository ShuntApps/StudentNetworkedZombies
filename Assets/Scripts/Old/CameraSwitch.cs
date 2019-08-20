using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

    public GameObject camera1;
    public GameObject camera2;

    // Use this for initialization
    void Start() {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate() {
        Debug.DrawRay(transform.position, (transform.position + (new Vector3(10, 0, 0))), Color.red);
        if (Physics.Raycast(transform.position, transform.right, 10))
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
        else
        {
            camera2.SetActive(false);
            camera1.SetActive(true);
        }

    }
}


