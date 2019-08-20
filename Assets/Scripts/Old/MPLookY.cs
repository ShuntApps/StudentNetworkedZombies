using UnityEngine;
using System.Collections;

public class MPLookY : MonoBehaviour {

    [SerializeField] float sensitivityY;
    public float minimumY = -30F;
    public float maximumY = 30F;
    float rotationY = 0F;
    public int player;

	void Start () {	}
	
	// Update is called once per frame
	void Update () {
        rotationY += Input.GetAxis("MouseY"+player) * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
	}
}
