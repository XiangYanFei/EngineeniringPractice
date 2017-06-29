using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour {

	public float m_speed = 2f;
	public int HP = 2;					

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
		HP--;
	}

	public void OnCollisionEnter(Collision col){
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
