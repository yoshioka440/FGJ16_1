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
		elapsedTime += Time.deltaTime;
//		Debug.Log(Mathf.Sin (Time.deltaTime));
		slider.value = Mathf.PingPong (elapsedTime, 1);
	}

	// ボタンが押された時の処理
	public void OnTouchEventGage () {

	}
}
