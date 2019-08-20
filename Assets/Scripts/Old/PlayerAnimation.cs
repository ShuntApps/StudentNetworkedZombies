using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float v = Input.GetAxis("Vertical");
       // if(v>0)

	}
}
