using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ControlMaxInputVelocity : MonoBehaviour {

	private InputField inputVelocity;
	//public float velocityIngress;
	// Use this for initialization
	void Start () {
		inputVelocity = GetComponent<InputField> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void InputVelocity(){
		if (int.Parse (inputVelocity.text) > 200) {
			inputVelocity.text = "200";
		}else if (int.Parse (inputVelocity.text) <100) {//03-07-2017
			inputVelocity.text = "100";//03-07-2017
		}//03-07-2017

		/*
		if (int.Parse (inputVelocity.text) <60) {//03-07-2017
			inputVelocity.text = "60";//03-07-2017
		}//03-07-2017
		*/
	}
}
