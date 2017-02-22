using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingAreaDetector : MonoBehaviour {

	public float timeSinceLastTrigger = 0f;

	private bool foundClearArea = false;
	
	// Update is called once per frame
	void Update () {
		timeSinceLastTrigger += Time.deltaTime;

		if (timeSinceLastTrigger > 2f && Time.realtimeSinceStartup > 10f && !foundClearArea && Input.GetButtonDown("CallHelicopter")) {
			SendMessageUpwards("OnFindClearArea");
			foundClearArea = true;
		}

		if (timeSinceLastTrigger < 2f && Time.realtimeSinceStartup > 10f && !foundClearArea && Input.GetButtonDown("CallHelicopter")) {
			SendMessageUpwards("OnNichtGenugPlatz");
		}


	}

	void OnTriggerStay (Collider collider) {

		if (collider.tag != "Player") {
			timeSinceLastTrigger = 0f;
		}

	}
}
