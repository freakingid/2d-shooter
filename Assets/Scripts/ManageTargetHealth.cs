using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageTargetHealth : MonoBehaviour {
	public bool isBlinking = false;
	public float timer;
	public Color previousColor;
	public GameObject explosion;
	public int health, type;
	public static int TARGET_BOULDER=0;
	public static int TARGET_BOULDER_MEDIUM=1;
	public static int TARGET_BOULDER_LARGE=2;

	// Use this for initialization
	void Start () {
		// Set health based on the type of target
		switch (type) {
		case 0:
			health = 20;
			gameObject.GetComponent<SpriteRenderer> ().material.color = Color.red;
			break;
		case 1:
			health = 30;
			gameObject.GetComponent<SpriteRenderer> ().material.color = Color.green;
			break;
		case 2:
			health = 40;
			gameObject.GetComponent<SpriteRenderer> ().material.color = Color.yellow;
			break;
		default:
			health = 20;
			gameObject.GetComponent<SpriteRenderer> ().material.color = Color.white;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (isBlinking) {
			// we are showing the hit color right now
			timer += Time.deltaTime;
			if (timer >= 0.2) {
				// finish blinking and change back to normal color
				isBlinking = false;
				GetComponent<SpriteRenderer> ().color = previousColor;
				timer = 0;
			}
		}
	}

	public void gotHit(int damage){
		health -= damage;
		if (health <= 0) {
			destroyTarget ();
		}
		previousColor = GetComponent<SpriteRenderer> ().color;
		// TODO But why is it not turning blue? I think it is adding blue on top of the existing color?
		GetComponent<SpriteRenderer> ().color = Color.blue;
		isBlinking = true;
	}

	public void destroyTarget(){
		// make an explosion
		GameObject exp = (GameObject)(Instantiate(explosion, transform.position, Quaternion.identity));
		Destroy (exp, 0.5f);
		// destroy the object linked to this script (like 'self')
		Destroy (gameObject);
	}
}
