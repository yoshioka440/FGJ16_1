using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (1);
//			var sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene ();
//			if (sceneName == "Title") {
//				
//			}
		}
	}
}
