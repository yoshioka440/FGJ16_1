using UnityEngine;
using System.Collections;

public class ScrollManager : MonoBehaviour {

	public GameObject backGround;
	public GameObject Stage;
	public Camera mainCamera;
	public GameObject player;

	public float cameraSpeed = 1.0f;

	float distancePlayerToCamera;

	// Use this for initialization
	void Start () {
		distancePlayerToCamera = mainCamera.transform.position.y - player.transform.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 cameraPosition = new Vector3 (0, player.transform.position.y + distancePlayerToCamera, -10);

		mainCamera.transform.position = cameraPosition;
		backGround.transform.position = cameraPosition;

//		Vector3 cameraPosition = new Vector3 (0, player.transform.position.y + 1, 0);
//		mainCamera.transform.position = cameraPosition;
//		backGround.transform.position = cameraPosition;

//		backGround.transform.position = new Vector3 (0, player.transform.position.y + 1, 0);
	}

}
