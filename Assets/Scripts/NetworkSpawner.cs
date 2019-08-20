using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkSpawner : NetworkBehaviour
{
    static int amountKilled;
    static int numSpawned=1;
    static int numToSpawn=10;
    public NetworkStartPosition[] spawnPos;
    public GameObject zombiePrefab;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = GameObject.FindObjectsOfType<NetworkStartPosition>();
        numToSpawn = 10;
        StartCoroutine("spawnTimer");
    }

    IEnumerator spawnTimer()
    {
        yield return new WaitForSeconds(2);
        CmdSpawnZombie();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ClientRpc]
    public void RpcRespawn()
    {
        Debug.Log("RPC called");

        if(amountKilled%10==0)
        {
            numToSpawn +=5;
        }

        if (numSpawned < numToSpawn)
        {
            if (spawnPos != null && spawnPos.Length > 0)
            {
                Debug.Log("respawn called");
                GameObject zombie = Instantiate(zombiePrefab, this.transform.position, Quaternion.identity);
                NetworkServer.Spawn(zombie);
            }
        }
    }


    [Command]
    public void CmdSpawnZombie()
    {
        /**
        if (numSpawned < numToSpawn)
        {
            GameObject zombie = Instantiate(zombiePrefab, this.transform.position, Quaternion.identity);
            NetworkServer.Spawn(zombie);*/
            RpcRespawn();
        //}
    }
}
