using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public float flyingTime = 2.0f;
	public GameObject pointGroup;

	bool isLanding;
	Vector3 nextPosition;
	float jumpTime;
	// 次の地点の番号（初期位置が0）
	int nextPoint;

	// Use this for initialization
	void Start () {
		Initialize ();
	}

	void Initialize () {
		isLanding = true;
		jumpTime = 0;
		nextPoint = 0;
		nextPosition = pointGroup.transform.GetChild (nextPoint).transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (isLanding) {
			if (Input.GetMouseButton (0) || Input.touchCount > 0) {
				Debug.Log ("Press Left Click");
				isLanding = false;

				if (nextPoint != 0) {
					this.transform.Rotate (0, 180, 0);
				}
			}
		} else {
			Debug.Log ("Jump");
			Jump ();
			if (this.transform.position == nextPosition) {
				isLanding = true;
				jumpTime = 0;
				nextPoint++;
				if (nextPoint >= pointGroup.transform.childCount) {
					nextPoint = 0;
				}
				nextPosition = pointGroup.transform.GetChild (nextPoint).transform.position;
			}
		}

	}

	void Jump () {
//		nextPosition = new Vector3 (0, 5, 0);
//		nextPosition = pointTransform.position;


		jumpTime += Time.deltaTime;

		this.transform.position = Vector3.Lerp (this.transform.position, nextPosition, jumpTime / flyingTime);
	}
}
