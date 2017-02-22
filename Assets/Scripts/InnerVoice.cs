using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerVoice : MonoBehaviour {

	public AudioClip whatHappenend;
	public AudioClip nichtGenugPlatz;
	public AudioClip dasSiehtGutAus;

	private AudioSource audioSource;
	
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = whatHappenend;
		audioSource.Play();
	}
	
	void OnFindClearArea() {
		print(name + "OnFindClearArea");
		audioSource.clip = dasSiehtGutAus;
		audioSource.Play();

		Invoke("CallHeli", dasSiehtGutAus.length + 1f);
	}

	void OnNichtGenugPlatz() {
		print(name + "OnNichtGenugPlatz");
		audioSource.clip = nichtGenugPlatz;
		audioSource.Play();
	}

	void CallHeli() {
		SendMessageUpwards("OnMakeInitialHeliCall");
	}
}
