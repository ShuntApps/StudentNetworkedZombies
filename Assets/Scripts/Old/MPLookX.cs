 using UnityEngine;
using System.Collections;

public class MPLookX : MonoBehaviour {

	[SerializeField] float sensitivity = 5.0f;
    public int player;

	void Start () { }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Input.GetAxis("MouseX"+player) * sensitivity, 0);
	}
}
