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
<<<<<<< HEAD
		elapsedTime += Time.deltaTime;
//		Debug.Log(Mathf.Sin (Time.deltaTime));
=======
		elapsedTime += Time.deltaTime * 1.6f;
		Debug.Log(Mathf.Sin (Time.deltaTime));
>>>>>>> 5ce40d1a26a6b4109dbaed1d7f31ca8af8393625
		slider.value = Mathf.PingPong (elapsedTime, 1);
	}

	// ボタンが押された時の処理
	public void OnTouchEventGage () {

	}
}
