using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public float elapsedTime { private set; get; }


	void Awake () {
		Application.targetFrameRate = 30;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MoveToNextScene () {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Result");
	}
}
