using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {

	public WaveController wc;
	public Waypoint wp;
	public float startHealth;
	public float speed;
	public float regeneration;
	public int damage;
	public float offset;
	float sqrDistance = float.MaxValue;
	float health;

	// Use this for initialization
	void Start () {
		if (offset >= 0 || offset >1) offset = Random.value;
		health = startHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if(health < startHealth)health += regeneration*Time.fixedDeltaTime;

		Vector3 direction = wp.findWay (transform.position, offset);

		sqrDistance = direction.sqrMagnitude;

		if (sqrDistance < 0.075f) {
			//If we get to the last node damage the player and remove the robot
			if (wp.next == null) {
				wc.damagePlayer (damage);
				delete ();
			}else wp = wp.next;
		} 
		Debug.DrawLine (transform.position, transform.position + direction);

		transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, direction, 10 * Time.deltaTime, 0.0f));

		moveForward ();
	}

	public void moveForward(){
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	public void DealDamage(float dmg){
		health -= dmg;
	}

	public void die(){
		//Do Dying animation
		Destroy (gameObject);
	}

	public void delete(){
		//No special effects, simply removes it from the game
		Destroy (gameObject);
	}

	public float getDistance(){
		return Mathf.Sqrt (sqrDistance);
	}
}
