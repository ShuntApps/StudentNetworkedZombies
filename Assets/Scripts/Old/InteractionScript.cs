using UnityEngine;
using System.Collections;

public class InteractionScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                DoorOpenScript door = hitInfo.transform.GetComponent<DoorOpenScript>();
                if (door)
                {
                    door.enabled = true;
                }
            }
        }
    }
}
    
