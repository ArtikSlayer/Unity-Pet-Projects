using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;

	public float smoothTimeY;
	public float smoothTimeX;

	//public GameObject player;
	public PlayerController player;

	public bool bounds;

	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	void Awake()
	{
		Application.targetFrameRate = 60;
	}
	// Use this for initialization
	void Start () {
	
		//player = GameObject.FindGameObjectsWithTag ("Player");
		player = FindObjectOfType<PlayerController>();

	}


	//void Update () {

		 //float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		 //float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.x, smoothTimeY);
	//}

	// Update is called once per frame
//	void FixedUpdate () {

	void LateUpdate () {
		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.x, smoothTimeY);

		transform.position = new Vector3 (posX, posY, transform.position.z);

		if (bounds)
		{
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
			                                 Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
			                                 Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
		}
	}
}
