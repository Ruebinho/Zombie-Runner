using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour {

	public float helispeed = -50f;

	private bool heliCalled;
	private Rigidbody rigidbody;
	private bool xLandungErreicht = false;
	private bool yLandungErreicht = false;
	private bool zLandungErreicht = false;
	private Player player;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		player = FindObjectOfType<Player>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!zLandungErreicht && transform.position.z <= player.landingAreaZPosition) {
			FliegeZuPlayspace ();
		}

		if (zLandungErreicht && transform.position.x >= player.landingAreaXPosition) {
			FliegeZuLandingArea ();
		}

		if (zLandungErreicht && xLandungErreicht) {
			Landung();
		}


	}

	public void OnDispatchHelicopter() {
			Debug.Log("Helicopter called");
			//move heli
			rigidbody.velocity = new Vector3(0f,0f,helispeed);
			heliCalled = true;
	}

	public void Landung() {
		float yPosLandingAreaPlusMeter = player.landingAreaYPosition+1f;
		bool LandungErreicht = false;

			rigidbody.velocity = new Vector3(0f,-10f,0f);
			Debug.Log("Landung erreicht von Heli");
	}

	void FliegeZuPlayspace ()
	{
		zLandungErreicht = true;
		rigidbody.velocity = new Vector3 (50f, 0f, 0f);
		setKurvenflugTrigger();

		Debug.Log ("Z erreicht von Heli");
	}

	void FliegeZuLandingArea ()
	{
		xLandungErreicht = true;
		rigidbody.velocity = Vector3.zero;
		Debug.Log ("X erreicht von Heli");
	}

	void setKurvenflugTrigger () {
		anim.SetTrigger("fliegeKurveTrigger");
		Invoke("transform.Rotate(0f, 0f, 90f)", 1f);
	}
	}

