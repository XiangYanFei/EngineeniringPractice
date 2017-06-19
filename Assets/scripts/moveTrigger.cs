using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTrigger : MonoBehaviour {

	public Transform currentbg;
	public platformer platformer1;
	public platformer platformer2;
	public platformer platformer3;

	public void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			//move the bg to the front of the first transform
			//1.get the first transform
			Transform firstbg=GameManager._intance.firstbg;
			//2.move
			currentbg.position=new Vector3(firstbg.position.x+29,currentbg.position.y,currentbg.position.z);

			GameManager._intance.firstbg = currentbg;
			//new position for platfomer
			platformer1.RandomGeneratePosition ();
			platformer2.RandomGeneratePosition ();
			platformer3.RandomGeneratePosition ();
		}
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
