using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints;
	public GameObject LandingAreaPrefab;
	public float landingAreaXPosition;
	public float landingAreaYPosition;
	public float landingAreaZPosition;

	private bool reSpawn = false;
	private Transform[] spawnPoints;
	private bool lastRespawnToggle = false;

    void Start()  {
    	spawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform>();		
    }
	
	// Update is called once per frame
	void Update () {
		if (lastRespawnToggle != reSpawn) {
			ReSpawn();
			reSpawn = false;
		} else {
			lastRespawnToggle = reSpawn;
		}
	}

	private void ReSpawn() {
		int i = Random.Range(1, spawnPoints.Length);
		transform.position = spawnPoints[i].transform.position;
	}

	void OnFindClearArea() {
		Invoke("DropFlare", 3f);
	}

	void DropFlare() {
		Instantiate(LandingAreaPrefab, transform.position, transform.rotation);
		landingAreaXPosition = transform.position.x;
		landingAreaYPosition = transform.position.y;
		landingAreaZPosition = transform.position.z;

		Debug.Log(landingAreaXPosition+ " " + landingAreaYPosition+ " " + landingAreaZPosition);
	}
}
