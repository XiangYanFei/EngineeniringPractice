using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformer : MonoBehaviour {

	void Start(){
		RandomGeneratePosition ();	
	}
	public void RandomGeneratePosition()
	{
		//how to random a number
		float pos_y=Random.Range(0.82f,-3.36f);
		this.transform.localPosition = new Vector3 (this.transform.localPosition.x, pos_y, this.transform.localPosition.z);
	}

	// Update is called once per frame
	void Update () {

	}
}
