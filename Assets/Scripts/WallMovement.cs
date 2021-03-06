﻿using UnityEngine;
using System.Collections;

public class WallMovement : MonoBehaviour {

	public Vector2 speed = new Vector2(50,0);
	public int maxSpeed = 10;

	public bool isEnemy = true;
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () {
		if (speed.x < maxSpeed) {
			speed.x += 1;
		}

		rigidbody2D.velocity = speed;
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		//Check if shot
		BulletScript shot = otherCollider.gameObject.GetComponent<BulletScript>();
		
		if (shot != null) {
			//Check if friendly fire
			if (shot.isEnemyShot != isEnemy) {
				speed.x -= shot.damage;
				Destroy (shot.gameObject); //Destroys the buleet
			}
		}
	}
}
