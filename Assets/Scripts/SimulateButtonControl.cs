using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SimulateButtonControl : MonoBehaviour {

	public InputField inputVelocity;
	public GameManagerControl gmTmp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void StartSimulate(){
		if (gmTmp.startSimulate == false) {
			gmTmp.startSimulate = true;
			inputVelocity.interactable = false;
			gmTmp.SendVelocity ();
		}
	}
	public void Quit(){
		Application.Quit ();
	}
	public void Restart(){
		SceneManager.LoadScene ("FrenadoAutomatico");
	}
}
