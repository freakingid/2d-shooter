using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer2 : MonoBehaviour
{

	public GameObject bullet;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		// Player movement via arrow keys
		if (Input.GetKey (KeyCode.LeftArrow)) {
			gameObject.transform.Translate (Vector3.left * 0.1f);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			gameObject.transform.Translate (Vector3.right * 0.1f);
		}
		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.transform.Translate (Vector3.up * 0.1f);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.transform.Translate (Vector3.down * 0.1f);
		}

		// Player firing bullet via spacebar
		if (Input.GetKeyDown (KeyCode.Space)) {
			// b is bullet; Adding GameObject with bullet sprite, Player.positon + offset up, WTF is Q.id?
			GameObject b = (GameObject)(Instantiate (bullet, transform.position + transform.up * 1.5f, Quaternion.identity));
			// Propel the bullet in the up direction. Is this relevant to rotation of the Player?
			b.GetComponent<Rigidbody2D> ().AddForce (transform.up * 1000);
		}

		// Position of Player in relation to camera view
		// (transform.position is center of our player)
		Vector3 viewPortPosition = Camera.main.WorldToViewportPoint (transform.position);
		// Half of sprite width, using coordinates relative to camera view
		Vector3 viewPortXDelta = Camera.main.WorldToViewportPoint (transform.position + Vector3.left / 2);
		// Half of sprite height
		Vector3 viewPortYDelta = Camera.main.WorldToViewportPoint (transform.position + Vector3.up / 2);

		// Position change based on our sprite heigh and widht halves figured above
		float deltaX = viewPortPosition.x - viewPortXDelta.x;
		float deltaY = viewPortPosition.y - viewPortYDelta.y;

		// Now set the player's position within the viewport, but clamp it
		viewPortPosition.x = Mathf.Clamp (viewPortPosition.x, 0 + deltaX, 1 - deltaX);
		viewPortPosition.y = Mathf.Clamp (viewPortPosition.y, 0 + deltaY, 1 - deltaY);

		// Finally, we actually need the position set in World coordinates.
		// This is what actually moves the player to the right location.
		transform.position = Camera.main.ViewportToWorldPoint (viewPortPosition);
	}
}
