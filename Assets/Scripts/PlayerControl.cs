using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
public class PlayerControl : MonoBehaviour {

	private Rigidbody rbPlayer;
	public float speedZ;
	public float distanceBetweenObjects;
	public float initialSpeed;
	public GameObject otherCar;
	public GameManagerControl gmTmp;
	public float forceBreak = 0;

	private float initialDistance;

	private float minXImpulse = 4;
	private float maxXImpulse = 6;
	private float minYImpulse = 4;
	private float maxYImpulse = 8;

	private bool cantMove;

	private float varDependSpeed;

	public MotionBlur motionCamera;//03-07-2017
	// Use this for initialization
	void Start () {
		rbPlayer = GetComponent<Rigidbody> ();
		DetectPosition ();
		initialDistance = distanceBetweenObjects;
	}
	
	// Update is called once per frame
	void Update(){
		if (cantMove == false) {
			DetectPosition ();
			if (gmTmp.isDiffuseLogic == false) {
				TraditionalLogicBrake ();
			} else if (gmTmp.isDiffuseLogic == true) {
				DiffuseLogicBrake ();
			}
		}
	}
	void FixedUpdate () {
		rbPlayer.velocity = new Vector3 (rbPlayer.velocity.x, rbPlayer.velocity.y,(speedZ * Time.deltaTime*50/3.6f));
	}

	void DetectPosition(){
		distanceBetweenObjects = (otherCar.transform.position.z - this.transform.position.z)/1000;
		if (distanceBetweenObjects <= 0) {
			distanceBetweenObjects = 0f;
		}
	}
	void TraditionalLogicBrake(){
		if (distanceBetweenObjects <= 0.1) {
	//		print (distanceBetweenObjects);
			if (speedZ > 0) {
				speedZ -= forceBreak * Time.deltaTime;
			} else if (speedZ <= 0) {
				speedZ = 0;
			}
		}
	}
	void DiffuseLogicBrake(){
		if (initialSpeed <= 100) {
			varDependSpeed = 0.5f;
		} else if (initialSpeed > 100 && initialSpeed <= 150) {
			varDependSpeed = 0.7f;
		} else if (initialSpeed > 150) {
			varDependSpeed = 1;
		} 
		float valueToUse = initialDistance - distanceBetweenObjects;
	//	print (valueToUse);
		if (speedZ > 0) {
			forceBreak = initialSpeed * valueToUse * varDependSpeed;
			/*
			if (valueToUse >= 0 && valueToUse <= 0.025) {
				forceBreak = initialSpeed / 50;
			} else if (valueToUse > 0.025 && valueToUse <= 0.05) {
				forceBreak = initialSpeed / 40;
			} else if (valueToUse > 0.05 && valueToUse <= 0.1) {
				forceBreak = initialSpeed / 30;
			} else if (valueToUse > 0.1 && valueToUse <= 0.15) {
				forceBreak = initialSpeed / 20;
			} else if (valueToUse > 0.15 && valueToUse <= 0.2) {
				forceBreak = initialSpeed / 10;
			} else if (valueToUse > 0.2 && valueToUse <= 0.25f) {
				forceBreak = initialSpeed / 5;
			} else if (valueToUse >= 0.25f) {
				forceBreak = initialSpeed;
			}
			*/
			/*
			if (valueToUse >= 0 && valueToUse <= 5) {
				forceBreak = initialSpeed / 50;
			} else if (valueToUse > 5 && valueToUse <= 10) {
				forceBreak = initialSpeed / 40;
			} else if (valueToUse > 10 && valueToUse <= 15) {
				forceBreak = initialSpeed / 30;
			} else if (valueToUse > 15 && valueToUse <= 20) {
				forceBreak = initialSpeed / 20;
			} else if (valueToUse > 20 && valueToUse <= 30) {
				forceBreak = initialSpeed / 10;
			} else if (valueToUse > 30 && valueToUse <= 40) {
				forceBreak = initialSpeed / 5;
			} else if (valueToUse >= 40) {
				forceBreak = initialSpeed;
			}
			*/
		} else {
			forceBreak = 0;
			speedZ = 0;
		}
		speedZ -= forceBreak * Time.deltaTime;
		if (initialSpeed > 150 && speedZ < initialSpeed - 50) {//03-07-2017
			motionCamera.blurAmount = motionCamera.blurAmount - 1 * Time.deltaTime;//03-07-2017
			if (motionCamera.blurAmount <= 0) {//03-07-2017
				motionCamera.blurAmount = 0;//03-07-2017
			}//03-07-2017
		}//03-07-2017
	}

	void OnCollisionEnter(Collision obj){
		if (obj.gameObject.tag == "Car") {
			this.gameObject.layer = LayerMask.NameToLayer ("Ghost");
			cantMove = true;

			float randomXImpulse = Random.Range(minXImpulse,maxXImpulse);
			float randomYImpulse = Random.Range (minYImpulse, maxYImpulse);
			rbPlayer.velocity = new Vector3(0,0,0);
			rbPlayer.AddRelativeForce (new Vector3(-randomXImpulse,randomYImpulse) , ForceMode.Impulse);

			gmTmp.SetGameOver ();
		}
	}

}
