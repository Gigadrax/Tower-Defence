using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

	public Waypoint next;
	public WaypointEnd WPend;

	float length;

	void Start (){

		length = determineLength ();
	}


	void Update(){
		Debug.DrawLine (transform.position, WPend.gameObject.transform.position, Color.blue);

	}


	//just gives the location of the waypoint
	public Vector3 findWay(float offset){

		Vector3 end = WPend.gameObject.transform.position;

		if (offset > 1 || offset < 0) {
			offset = 0.5f;
		}

		return (offset * (end - transform.position) + transform.position);
	}

	//Tells the AI how to get to the waypoint from the AI's location
	public Vector3 findWay(Vector3 location, float offset){

		Vector3 end = WPend.gameObject.transform.position;

		if (offset > 1 || offset < 0) {
			offset = 0.5f;
		}

		Vector3 way = ((offset * (end-transform.position) + transform.position)-location);
		way.y = 0;
		return way;


	}
	//BE CAREFUL WITH THIS IT'S RECURSIVE AND WILL EXPLODE VIOLENTLY IF THERE'S A LOOP IN THE WAYPOINTS
	private float determineLength(){
		if (next == null) {
			return 0;
		}

		return (transform.position - next.transform.position).magnitude + next.determineLength();
	}

	public float getLength(){
		return length;
	}

}
