using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class networkedHealth : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            collision.gameObject.GetComponent<SetupPlayers>().CmdChangeHealth(50);
            IEnumerator coroutineName = hideAndWait(10);

            StartCoroutine(coroutineName);
        }
     
    }

    IEnumerator hideAndWait(int seconds)
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshCollider>().enabled = false;
        yield return new WaitForSeconds(10);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<MeshCollider>().enabled = true;

    }
}
