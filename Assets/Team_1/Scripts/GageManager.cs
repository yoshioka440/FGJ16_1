using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GageManager : MonoBehaviour {

	public Slider slider;

	// 経過時間
	float elapsedTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime * 1.6f;
//		Debug.Log(Mathf.Sin (Time.deltaTime));
		slider.value = Mathf.PingPong (elapsedTime, 1);

		if (Input.GetButtonDown("Jump")) {
			Debug.Log("Restart!");
			UnityEngine.SceneManagement.SceneManager.LoadScene (1);
		}
	}

	// ボタンが押された時の処理
	public void OnTouchEventGage () {

	}
}
