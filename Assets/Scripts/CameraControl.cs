using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Transform camTransform;

	// How long the object should shake for.
	public float shake = 0f;

	// Amplitude of the shake. A larger value shakes the camera harder.
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	public Transform player;
	public float distanceZ;
	public float distanceY;
	public float distanceX;
	public float xRotation;

	Vector3 originalPos;

	public float ShakeTimer;

	private float shakeAmountTmp = 0;

	public bool seeTheAirplane;
	public bool increasingValues;
	public float increaseDistanceZFactor;
	public float increaseDistanceYFactor;
	public float increaseRotationXFactor;

	private float initialDistanceZ;
	private float initialDistanceY;
	private float initialXRotation;

	public float maxDistanceZ;
	public float maxDistanceY;
	public float maxXRotation;

	private bool stopIncreasing;
	public float timeToWait;

	public float effectZRotation;//31-01-2017
	public float zRotationSpeed;//31-01-2017
	private PlayerControl playerControlTmp;//31-01-2017
	private float publicZRotationSpeed;//31-01-2017
	public float maxZRotationValue;//31-01-2017

	//private bool itWasZero = true;
	//private int stop=1;

	//private bool isSetRotationTime;
	//float rotationTime = 0;
	void Awake(){
		if (camTransform == null){
			camTransform = GetComponent(typeof(Transform)) as Transform;
		}
		shakeAmountTmp = shakeAmount;
	}
	void Start(){
		initialDistanceY = distanceY;
		initialDistanceZ = distanceZ;
		initialXRotation = xRotation;

		player = (Transform)GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();

		playerControlTmp = (PlayerControl)GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();//31-01-2017

		publicZRotationSpeed = zRotationSpeed;//31-01-2017
	}
	void OnEnable(){
		originalPos = camTransform.localPosition;
	}

	void Update(){
		
		if (shake > 0) {
			transform.transform.position = originalPos + Random.insideUnitSphere * shakeAmount;

			shake -= Time.deltaTime * decreaseFactor;
		} else {
			shake = 0f;
			camTransform.localPosition = originalPos;
		}
		this.transform.position = new Vector3 (player.position.x + distanceX, player.position.y + distanceY, player.position.z - distanceZ);
		this.transform.eulerAngles = new Vector3(xRotation, transform.rotation.y, (transform.rotation.z + effectZRotation));//31-01-2017

	}
	public void ShakeCamera(float shakePower, float shakeDuration){
		shakeAmount = shakePower;
		shake = shakeDuration;
		Invoke("SetInitialValue",1);
	}
	void SetInitialValue(){
		shakeAmount = shakeAmountTmp;
	}

	public void SeeTheAirPlane(){
		increasingValues = true;
		seeTheAirplane = true;
	}
	void DelayDecreasing(){
		increasingValues = false;
		stopIncreasing = false;
	}
}
