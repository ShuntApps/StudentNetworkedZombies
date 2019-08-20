using UnityEngine;
using System.Collections;

public class RifleWeapon : MonoBehaviour {

	[SerializeField] int damageDealt=20;
	[SerializeField] int damageHealt=-20;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Escape)) {
			Screen.lockCursor=false;
		}

		if (Input.GetButtonDown ("Fire1")) {
			//Make a raycast with the line starting from center of camera
			//Screen.lockCursor=true;
			//Ray mouseRay = Camera.main.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0));
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
			//Send the raycast and if the raycast hit something, print out the name to console
			if (Physics.Raycast (mouseRay, out hitInfo)) {
                print(hitInfo.transform.tag);
                Debug.DrawLine(transform.position, hitInfo.point,Color.red,5.0f);

                print(hitInfo.transform.gameObject.name);
				Health enemyHealth = hitInfo.transform.GetComponent<Health>();
				if(enemyHealth !=null)
				{
					enemyHealth.Damage(damageDealt);
				}
			}
	
		}
	}
}
