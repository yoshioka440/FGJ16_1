using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour {

    SoundManager m_SoundManager;

	// Use this for initialization
	void Start () {
        m_SoundManager = GetComponent<SoundManager>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) || Input.touchCount > 0) {
            m_SoundManager.SoundRings(0);

            UnityEngine.SceneManagement.SceneManager.LoadScene (1);
            //			var sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene ();
            //			if (sceneName == "Title") {
            //				
            //			}

		}
	}
}
