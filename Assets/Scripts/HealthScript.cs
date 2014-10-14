using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public int health = 1;

	public bool isEnemy = true;

	public void Damage(int damageCount) {
		health -= damageCount;

		if (health <= 0) {
			//Object is dead
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter2D(Collider2D otherCollider) {
		//Check if shot
		BulletScript shot = otherCollider.gameObject.GetComponent<BulletScript>();

		if (shot != null) {
			//Check if friendly fire
			if (shot.isEnemyShot != isEnemy) {
				Damage(shot.damage); //Damages the object
				Destroy (shot.gameObject); //Destroys the buleet
			}
		}
	}
}
