using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroSceneControl : MonoBehaviour {

	public Animator logoAnimator;
	public string levelToLoad;
	// Use this for initialization
	void Start () {
		Invoke("Appear",0.5f);
		Invoke("Disappear",2f);
		Invoke("ChargeNextLevel",3.5f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Appear(){
		logoAnimator.SetBool ("isAppear", true);
	}
	void Disappear(){
		logoAnimator.SetBool ("isDisappear", true);
	}
	void ChargeNextLevel(){
		SceneManager.LoadScene (levelToLoad);
	}
}
