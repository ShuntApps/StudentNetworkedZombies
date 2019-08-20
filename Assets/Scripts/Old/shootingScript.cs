using UnityEngine;
using System.Collections;

public class shootingScript : MonoBehaviour {

	[SerializeField] int damageDealt=20;
    [SerializeField] LayerMask layermask;
    Animator anim;
    [SerializeField] GameObject bloodHit;
    AudioSource audioSrc;
    [SerializeField] AudioClip shootclip;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        audioSrc=GetComponent<AudioSource>();
		Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible = false;
        layermask |= Physics.IgnoreRaycastLayer;
        layermask = ~layermask;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
		}
		if (Input.GetButtonDown ("Fire1")) {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Ray mouseRay = GetComponentInChildren<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;
            anim.SetTrigger("Fire");
            audioSrc.clip = shootclip;
            audioSrc.Play();
            GetComponentInChildren<ParticleSystem>().Play();
			//Send the raycast and if the raycast hit something check to see if it has health
			if (Physics.Raycast (mouseRay, out hitInfo,100,layermask)) {
                Health enemyHealth = hitInfo.transform.GetComponent<Health>();
				if(enemyHealth !=null)
				{
					enemyHealth.Damage(damageDealt);
                    Vector3 bloodHitPos = hitInfo.point;
                    Quaternion bloodHitRot = Quaternion.FromToRotation(Vector3.forward,hitInfo.normal);
                    Instantiate(bloodHit, bloodHitPos,bloodHitRot);
                }
                
			}
		}
	}
}
