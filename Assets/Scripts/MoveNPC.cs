using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{
	public GameObject bullet;
	public float direction = 1.0f;
	public float timer;
	public bool startShootingTimer = false;
	public bool canShoot = true;
	public float shootingTimer;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		shootingTimer += Time.deltaTime;
		if (shootingTimer >= 1) {
			startShootingTimer = false;
			canShoot = true;
			shootingTimer = 0;
		}
		timer += Time.deltaTime;
		transform.Translate (Vector3.left * direction * Time.deltaTime * 2);
		if (timer >= 3) {
			direction *= -1;
			timer = 0;
		}
		detectPlayer ();
	}

	void detectPlayer ()
	{
		// where is the player horizontally?
		float playerXPosition = GameObject.Find ("Player").transform.position.x;
		if (transform.position.x < (playerXPosition + 1) && transform.position.x > (playerXPosition - 1)) {
			Shoot ();
		}
	}

	void Shoot ()
	{
		if (canShoot) {
			GameObject b = (GameObject)(Instantiate (bullet, transform.position + transform.up * 1.5f, Quaternion.identity));
			b.GetComponent<Rigidbody2D> ().AddForce (Vector3.down * 1000);
			canShoot = false;
			startShootingTimer = true;
		}
	}
}
