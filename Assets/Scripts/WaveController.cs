using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {
	
	public Robot[] robo_library;
	public Waypoint startPoint;
	public float spawnRate = 1;
	public int wave;
	public int round;

	public int playerHealth = 500;
	public bool playing = false;
	float timeSince;
	public int waveHeat;
	// Use this for initialization
	void Start () {
		wave = 0;
		round = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (playing) {
			timeSince += Time.fixedDeltaTime;
			if (timeSince >= spawnRate) {
				spawnRobots ();
				timeSince = 0;
				if (waveHeat > getMaxWaveHeat ()) {
					if (wave >= 10) {
						endRound ();
					} else
						nextWave ();
				
				}
			}
		}
		Debug.Log (1/Time.deltaTime);
	}
	//To change the initial rotation of the robots you need to adjust the rotation of the WaveController
	void spawnRobots(){
		float offset = Random.value;
		Robot rb = Instantiate(robo_library [Random.Range (0, robo_library.Length)], startPoint.findWay (offset), transform.rotation);
		rb.offset = offset;
		rb.wp = startPoint.next;
		rb.wc = this;
		waveHeat += rb.damage;
	}

	void nextRound(){
		round++;
		wave = 1;
		playing = true;
	}

	void endRound(){
		wave = 0;
		playing = false;
	}

	void nextWave(){
		wave++;
		waveHeat = 0;
	}

	public int getPlayerHealth(){
		return playerHealth;
	}

	public void damagePlayer(int damage){
		playerHealth -= damage;
	}

	int getMaxWaveHeat(){
		return 200;
	}
}
