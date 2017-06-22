using UnityEngine;
using System.Collections;

public class knife : MonoBehaviour {

	public GameObject explosion;  //定义爆炸prefeb
	private GameObject explo;
	// Use this for initialization
	void Start () {
		Destroy (gameObject,3); 
	}

	// Update is called once per frame
	void OnExplode()
	{
		print ("22222");
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		

		// Instantiate the explosion where the rocket is with the random rotation.
		explo=GameObject.Instantiate(explosion, transform.position, randomRotation)as GameObject;
		Destroy(explo,0.2F);

	}
	void Update () {

	}


	void OnCollisionEnter(Collision col) 
	{
		if(col.collider.tag == "ground") {
			OnExplode();
			Destroy (gameObject);
		}

		if(col.collider.tag == "enemy")
		{
			// ... find the enemy script and call the Hurt function.
			col.gameObject.GetComponent<enemy>().Hurt();
			// Destroy the enemy
			OnExplode();
			Destroy (col.gameObject);
			GameObject.Find ("hero").GetComponent<playerControl> ().score += 10;
			print (GameObject.Find ("hero").GetComponent<playerControl> ().score);

		}
	
		/*
		Destroy (this.explosion);
		Instantiate (explosion, this.transform.position, Quaternion.identity);
		*/
		//OnExplode();
		//Quaternion q=Quaternion.Euler(new Vector3(0,0,Random.Range(0,360)));
		//GameObject e = (GameObject)Instantiate (explosion, this.transform.position, q);
		//Destroy (e, 0.333f);
		//Destroy (gameObject);

	/*	if (col.gameObject.layer == LayerMask.NameToLayer ("Enemy")) {
			//敌人死亡，玩家加分
			Destroy (col.gameObject);
			GameObject.Find ("Score").GetComponent<GUIText> ().text = "Score:" + GameObject.Find ("Hero").GetComponent<PlayerControl> ().score.ToString ();
		}
		*/
	}

}
