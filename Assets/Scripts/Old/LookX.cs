 using UnityEngine;
using System.Collections;

public class LookX : MonoBehaviour {

	[SerializeField] float sensitivity = 5.0f;

	void Start () { }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, Input.GetAxis("MouseX") * sensitivity, 0);
	}
}
