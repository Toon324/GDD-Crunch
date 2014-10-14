using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {

	public Vector2 speed = new Vector2(50,0);
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		rigidbody2D.velocity = speed;
	}
}
