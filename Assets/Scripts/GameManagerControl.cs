using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.ImageEffects;
public class GameManagerControl : MonoBehaviour {

	private string velocityIngress;
	private float velocityToSend;
	public InputField inputyVelocity;
	public bool startSimulate;
	public PlayerControl playerTmp;
	public Text distanceTxt;

	public Dropdown slideLogic;
	public bool isDiffuseLogic;
	public Text forceBreakTxt;
	public Text speedCarTxt;

	public GameObject mainCamera;
	public GameObject playerCamera;
	public GameObject pantallaRota;

	public AudioSource audioSour;
	public AudioClip motoClip;
	public AudioClip choqueClip;

	public MotionBlur motionCamera;//03-07-2017
	// Use this for initialization
	void Start () {
		audioSour = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		distanceTxt.text = "DISTANCIA ENTRE AUTOS: " + playerTmp.distanceBetweenObjects.ToString ();
		forceBreakTxt.text = "FUERZA FRENO: " + playerTmp.forceBreak.ToString ();
		speedCarTxt.text = "VELOCIDAD AUTO: " + playerTmp.speedZ.ToString () + " KM/H";
		if (slideLogic.captionText.text == "Lógica Tradicional") {
			isDiffuseLogic = false;
		} else if (slideLogic.captionText.text == "Lógica Difusa") {
			isDiffuseLogic = true;
		}
	}
	public void SetInitialVelocity(){
		velocityIngress = inputyVelocity.text;
		float result = 0;
		float.TryParse( velocityIngress,out result);
		velocityToSend = result;
	}
	public void SendVelocity(){
		playerTmp.speedZ = velocityToSend;
		playerTmp.initialSpeed = velocityToSend;
		audioSour.clip = motoClip;
		audioSour.Play ();
		if (velocityToSend < 150) {//03-07-2017
			motionCamera.blurAmount = 0;//03-07-2017
		} else {//03-07-2017
			motionCamera.blurAmount = 0.92f;//03-07-2017
		}//03-07-2017
	}
	/*
	public void ChangeDiffuseBool(){
		bool logicTmp;
		if (isDiffuseLogic == true) {
			logicTmp = false;
		} else {
			logicTmp = true;
		}
		isDiffuseLogic = logicTmp;
	}
	*/
	public void Restart(){
		SceneManager.LoadScene("Test");
	}
	public void SetGameOver(){
		mainCamera.SetActive (false);
		playerCamera.SetActive (true);
		pantallaRota.SetActive (true);
		audioSour.loop = false;
		audioSour.clip = choqueClip;
		audioSour.Play ();
	}
}
