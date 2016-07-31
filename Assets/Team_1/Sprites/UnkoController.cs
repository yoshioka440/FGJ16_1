using UnityEngine;
using System.Collections;

public class UnkoController : MonoBehaviour {

	float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 5.0f) {
			Destroy (this.gameObject);
		}
	}

//	void OnCollisionEnter2D (Collision2D collision) {
//		if (collision.transform.tag == "Finish") {
//			UnityEngine.SceneManagement.SceneManager.LoadScene ();
//		}
//	}
}
