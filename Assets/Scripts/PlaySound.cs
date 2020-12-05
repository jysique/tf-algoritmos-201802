using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour {

	private AudioSource sourceTmp;
	public AudioClip clipToPlay;
	// Use this for initialization
	void Start () {
		sourceTmp = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {

	}
	public void PlayClip(){
		sourceTmp.clip = clipToPlay;
		sourceTmp.Play ();
	}
	public void StopSound(){
		if (sourceTmp.isPlaying == true) {
			sourceTmp.Stop ();
		}
	}
}
