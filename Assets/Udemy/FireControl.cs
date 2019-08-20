using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Mirror;

public class FireControl : NetworkBehaviour {

	public GameObject bulletPrefab;
	public GameObject bulletSpawn;

	// Update is called once per frame
	void Update () 
	{
		if(!isLocalPlayer) return;

		if(Input.GetKeyDown("space"))
		{
			CmdShoot();
		}	
	}

	void CreateBullet()
	{
		GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
		bullet.GetComponent<Rigidbody>().velocity = bulletSpawn.transform.forward*50;
		Destroy(bullet,5.0f);
	}

	[ClientRpc]
	void RpcCreateBullet()
	{
		//if(!isServer)
			CreateBullet();
	}

	[Command]
	void CmdShoot()
	{
		//CreateBullet();
		RpcCreateBullet();
	}

}

