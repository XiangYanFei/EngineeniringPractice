using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public float m_speed = 2f;
	private Transform frontcheck;		// Reference to the position of the gameobject used for checking if something is in front.
	public int HP = 2;					// How many times the enemy can be hit before it dies.

	void Awake (){
		
	}
	// Use this for initialization
	void Start () {
		frontcheck = transform.Find("frontcheck").transform;

	}

	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate()
	{
		this.GetComponent<Rigidbody> ().velocity = new Vector2 (
		m_speed * this.transform.localScale.x,this.GetComponent<Rigidbody> ().velocity.y);
	}
	public void Hurt()
	{
		// Reduce the number of hit points by one.
		HP--;
		Debug.Log (HP);
	}

	public void OnCollisionEnter(Collision col){
		if (col.collider.tag == "deadline")
			Destroy(gameObject);
		if (col.collider.tag == "flap")
			Flip ();
	}

	public void Flip()
	{
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
