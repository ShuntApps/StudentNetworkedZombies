using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    Transform playerModel;
    CharacterController controller;
    [SerializeField] float moveSpeed;

	// Use this for initialization
	void Start () {
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerModel = playerGameObject.transform;
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        //print((playerModel.position - transform.position).magnitude);
        if ((playerModel.position - transform.position).magnitude > 2)
        {
            Vector3 direction = (playerModel.position - (new Vector3(0, 0, -1)) - transform.position);
            controller.Move(direction * Time.deltaTime * moveSpeed);
        }
        
	}
}
