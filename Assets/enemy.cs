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
	void FixedUpdate(){
		// Create an array of all the colliders in front of the enemy.
		RaycastHit[] frontHits = Physics.RaycastAll(frontcheck.position,transform.forward, 1);

		// Check each of the colliders.
		foreach(RaycastHit c in frontHits)
		{
			// If any of the colliders is an Obstacle...
			if(c.collider.tag == "Obstacle")
			{
				// ... Flip the enemy and stop checking the other colliders.
				Flip ();
				break;
			}
		}
		this.GetComponent<Rigidbody> ().velocity = new Vector2 (
			m_speed * this.transform.localScale.x,this.GetComponent<Rigidbody> ().velocity.y 
		);

	}
	public void Hurt()
	{
		// Reduce the number of hit points by one.
		HP--;
	}

	public void OnCollisionEnter(Collision col){
		if (col.collider.tag == "deadline")
			Destroy(gameObject);
	}
	public void Flip()
	{
		// Multiply the x component of localScale by -1.
		Vector3 enemyScale = transform.localScale;
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}
}
