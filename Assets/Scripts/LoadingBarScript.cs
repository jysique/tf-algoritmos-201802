using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadingBarScript : MonoBehaviour {

	AsyncOperation operationAsync;
	public string levelToLoad;
	public GameObject canvasLoading;
	public Image barFillImage;
	public Text loadinTxt;

	public Animator loadingAnimator;

	void Start () {
		barFillImage.fillAmount = 1f;
		Invoke ("StayIdle", 1f);
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void StayIdle (){
		loadingAnimator.SetBool ("isAppear", false);
		loadingAnimator.SetBool ("isDisappear", false);
		barFillImage.fillAmount = 0f;
	}
	public void ActivateLoadingCanvas(){
		loadingAnimator.SetBool ("isDisappear", false);
		loadingAnimator.SetBool ("isAppear", true);
		canvasLoading.SetActive (true);
		StartCoroutine (LoadLevelWithRealProgress ());

	}

	IEnumerator LoadLevelWithRealProgress(){
		yield return new WaitForSecondsRealtime (1);
		operationAsync = SceneManager.LoadSceneAsync (levelToLoad);
		while (!operationAsync.isDone) {
			yield return null;
			barFillImage.fillAmount = operationAsync.progress;

		}
	}
}
