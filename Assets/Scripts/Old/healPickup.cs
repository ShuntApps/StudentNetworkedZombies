using UnityEngine;
using System.Collections;

public class healPickup : MonoBehaviour {

    float timeOfNextPickup = 0;
    float timeBetweenpickups = 10;
    bool canPickup = true;

    void OnTriggerEnter(Collider collider)
    {
        //print("pick up");
        Health health = collider.GetComponent<Health>();
        if (health != null&&collider.tag=="Player")
        {
            GetComponent<MeshRenderer>().enabled = false;
            health.Damage(-50);
        }
    }

    void Update()
    {
        if(Time.time>timeOfNextPickup)
        {
            canPickup = true;
            GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
