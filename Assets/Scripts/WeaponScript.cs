using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {

	//What we shoot
	public Transform shotPrefab;

	//How fast we can shoot
	public float shootingRate = .25f;

	private float shotCooldown;

	// Use this for initialization
	void Start () {
		shotCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shotCooldown > 0) {
			shotCooldown -= Time.deltaTime;
		}
	}

	public void Attack(bool isEnemy) {
		if (CanAttack) {
			shotCooldown = shootingRate;

			//Create a new shot
			var shotTransform = Instantiate(shotPrefab) as Transform;

			//Give position
			shotTransform.position = transform.position;

			BulletScript shot = shotTransform.gameObject.GetComponent<BulletScript>();

			if (shot != null) {
				shot.isEnemyShot = isEnemy;
			}

			BulletMovement move = shotTransform.gameObject.GetComponent<BulletMovement>();
			if (move != null) {
				//move.direction = this.transform.right;
			}
		}
	}

	public bool CanAttack {
		get{
			return shotCooldown <= 0f;
		}
	}
}
