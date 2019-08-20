using UnityEngine;
using System.Collections;

public class LookY : MonoBehaviour {

    [SerializeField] float sensitivityY;
    public float minimumY = -30F;
    public float maximumY = 30F;
    float rotationY = 0F;

	void Start () {	}
	
	// Update is called once per frame
	void Update () {
        rotationY += Input.GetAxis("MouseY") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
	}
}
