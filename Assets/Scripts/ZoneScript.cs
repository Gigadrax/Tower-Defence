using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneScript : MonoBehaviour {

	public ZoneScript next;
	public ZonePointScript ZP1;
	public ZonePointScript ZP2;
	private Vector3 p1;
	private Vector3 p2;

	void Start(){
		p1 = new Vector3 (ZP1.transform.position.x, 0, ZP1.transform.position.z);
		p2 = new Vector3 (ZP2.transform.position.x, 0, ZP2.transform.position.z);
	}

	//Tells the AI how to get to the zone from the AI's location
	public Vector3 ZoneDirection(Vector3 location){
		//North is Z positive and East is X positive for this method anyways
		Vector3 North = Vector3.zero;
		Vector3 East = Vector3.zero;
		//NorthMost point etc.
		float NM;
		float SM;
		float WM;
		float EM;

		if (p1.x > p2.x) {
			EM = p1.x;
			WM = p2.x;
		} else {
			EM = p2.x;
			WM = p1.x;
		}
		if (p1.z > p2.z) {
			NM = p1.z;
			SM = p2.z;
		} else {
			NM = p2.z;
			SM = p1.z;
		}

		if (location.x > EM) {
			East = new Vector3 ((EM - location.x), 0, 0);
		}

		if (location.x < WM) {
			East = new Vector3 ((WM - location.x), 0, 0);
		}

		if (location.z > NM) {
			North = new Vector3 (0, 0, (NM - location.z));
		}
		if (location.z < SM) {
			North = new Vector3 (0, 0, (SM - location.z));
		}

		return North + East;
	}

}
