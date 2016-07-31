using UnityEngine;
using System.Collections;

public class BirdController : MonoBehaviour {

	public GameObject bird;
	public Transform point1;
	public Transform point2;
	public GameObject unko;
	bool wentTo2From1;
	float jumpTime;
	public float flyingTime = 5.0f;
	bool to2 = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (to2) {
			jumpTime += Time.deltaTime;
			bird.transform.position = Vector3.Lerp (point1.transform.position, point2.transform.position, jumpTime / flyingTime);
			if (jumpTime / flyingTime >= 1.0f) {
				to2 = false;
				jumpTime = 0.0f;
				bird.transform.Rotate (new Vector3(0, 180, 0));
			}
		} else {
			jumpTime += Time.deltaTime;
			bird.transform.position = Vector3.Lerp (point2.transform.position, point1.transform.position, jumpTime / flyingTime);
			if (jumpTime / flyingTime >= 1.0f) {
				to2 = true;
				jumpTime = 0.0f;
				bird.transform.Rotate (new Vector3(0, 180, 0));
			}
		}
	}
}
