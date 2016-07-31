using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    public static int time = 0;
    public static int distance = 0;
    public static string stageName = "";

    void Awake () {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
