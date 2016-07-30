using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	 
	float currentDegree;
	float elapsedTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		elapsedTime += Time.deltaTime;
		currentDegree = this.transform.rotation.z + elapsedTime;

		this.transform.Rotate(0, 0, currentDegree);
		Debug.Log ("Time: " + Time.deltaTime);
		Debug.Log ("elapsedTime: " + elapsedTime + ", Time: " + Time.deltaTime);
	}
}
