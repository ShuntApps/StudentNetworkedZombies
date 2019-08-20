using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkZombieAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<SetupPlayers>().CmdChangeHealth(-5);
            gameObject.GetComponentInParent<Animator>().SetTrigger("Bite");
            gameObject.GetComponentInParent<NetworkAnimator>().SetTrigger("Bite");

        }

    }
}
