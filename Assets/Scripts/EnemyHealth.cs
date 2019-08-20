using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.AI;

public class EnemyHealth : NetworkBehaviour
{


    [SyncVar(hook = "OnChangeHealth")]
    public int healthValue = 1;

    public GameObject bloodPrefab;

    public NetworkStartPosition[] spawnPos;

    void OnChangeHealth(int n)
    {
        healthValue = n;
    }

    [ClientRpc]
    public void RpcRespawn()
    {
        Debug.Log("RPC called");

        if(spawnPos !=null && spawnPos.Length>0)
        {
            Debug.Log("move called");
            this.transform.position = spawnPos[Random.Range(0, spawnPos.Length)].transform.position;
        }
    }


    [Command]
    public void CmdChangeHealth(int amount)
    {
        healthValue = healthValue + amount;
        //healthBar.value = healthValue;

        if(healthValue<=0)
        {
            GameObject go = Instantiate(bloodPrefab, this.transform.position, Quaternion.identity);
            NetworkServer.Spawn(go);
            this.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            this.GetComponent<NavMeshAgent>().isStopped = true;
            this.GetComponent<EnemyNavMovement>().target = null;
            RpcRespawn();
            healthValue = 100;
        }
    }

    IEnumerator waitAndRespawn()
    {
        yield return new WaitForSeconds(2);
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log(collision.gameObject.GetComponent<Animator>().GetBool("Attacking"));
            if (collision.gameObject.GetComponent<Animator>().GetBool("Attacking"))
            {
                CmdChangeHealth(-10);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = GameObject.FindObjectsOfType<NetworkStartPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
