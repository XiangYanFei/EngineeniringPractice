using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour {

	Vector3 Dir;//摄像机要跟随物体的距离
	public GameObject Player;//要跟随的物体
	// Use this for initialization
	void Start () {
		Dir.x = Player.transform.position.x - transform.position.x;
		Dir.y = Player.transform.position.y - transform.position.y-6;
	}

	// Update is called once per frame
	void Update () {
		transform.position = Player.transform.position - Dir;
	}
}
