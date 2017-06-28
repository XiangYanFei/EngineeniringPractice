using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {

	public float health = 100f;					// The player's health.
	public float repeatDamagePeriod = 2f;		// How frequently the player can be damaged.
	//public AudioClip[] ouchClips;				// Array of clips to play when the player is damaged.
	public float hurtForce = 10f;				// The force with which the player is pushed when hurt.
	public float damageAmount = 10f;			// The amount of damage to take when enemies touch the player

	//private SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private float lastHitTime;					// The time at which the player was last hit.
	private Vector3 healthScale;				// The local scale of the health bar initially (with full health).
	private playerControl playerControl;		// Reference to the PlayerControl script.
	private Animator anim;						// Reference to the Animator on the player

	//public Sprite deadhero;			// An optional sprite of the enemy when it's dead.
	private bool dead = false;			// Whether or not hero is dead.
	//private SpriteRenderer ren;			// Reference to the sprite renderer.
	public float deathSpinMin = -100;			// A value to give the minimum amount of Torque when dying
	public float deathSpinMax = 100;			// A value to give the maximum amount of Torque when dying

	void Awake ()
	{
		//ren = transform.Find("hero").GetComponent<SpriteRenderer>();
		// Setting up references.
		playerControl = GetComponent<playerControl>();
		//healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();

		// Getting the intial scale of the healthbar (whilst the player has full health).
		//healthScale = healthBar.transform.localScale;
	}


	void OnCollisionEnter (Collision col)
	{
		// If the colliding gameobject is an Enemy...
		if(col.collider.tag == "enemy")
		{
			// ... and if the time exceeds the time of the last hit plus the time between hits...
			if (Time.time > lastHitTime + repeatDamagePeriod) 
			{
				// ... and if the player still has health...
				if(health > 0f)
				{
					// ... take damage and reset the lastHitTime.
					TakeDamage(col.collider.transform); 
					lastHitTime = Time.time; 
				}
				// If the player doesn't have health, do some stuff, let him fall into the river to reload the level.
				else
				{
					Death ();
				}
			}
		}

		if (col.collider.tag == "deadline") {
			GetComponent<playerControl>().enabled = false;
			print ("dead");
		}
		if (col.collider.tag == "flower") {
			if(health > 0f)
			{
				health += damageAmount;
				print ("加血");
			}
		}
	}


	void TakeDamage (Transform enemy)
	{
		// Make sure the player can't jump.
		playerControl.bJump = false;

		// Create a vector that's from the enemy to the player with an upwards boost.
		Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 10f;

		// Add a force to the player in the direction of the vector and multiply by the hurtForce.
		GetComponent<Rigidbody>().AddForce(hurtVector * hurtForce);

		// Reduce the player's health by 10.
		health -= damageAmount;

		// Update what the health bar looks like.
		UpdateHealthBar();

		// Play a random clip of the player getting hurt.
		//int i = Random.Range (0, ouchClips.Length);
		//AudioSource.PlayClipAtPoint(ouchClips[i], transform.position);
	}

	void Death()
	{
		// Find all of the colliders on the gameobject and set them all to be triggers.
		Collider[] cols = GetComponents<Collider>();
		foreach(Collider c in cols)
		{
			c.isTrigger = true;
		}

		// Move all sprite parts of the player to the front
		SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
		foreach(SpriteRenderer s in spr)
		{
			s.sortingLayerName = "UI";
		}

		dead = true;
		// ... disable user Player Control script
		GetComponent<playerControl>().enabled = false;

		// ... disable the Gun script to stop a dead guy shooting a nonexistant bazooka
		GetComponentInChildren<weapon1>().enabled = false;

		anim.SetTrigger("Die");
		print ("播放死亡动画");


		// ... Trigger the 'Die' animation state
		// Find all of the sprite renderers on this object and it's children.
		//SpriteRenderer[] otherRenderers = GetComponentsInChildren<SpriteRenderer>();

		// Disable all of them sprite renderers.
		//foreach(SpriteRenderer s in otherRenderers)
		//{
		//	s.enabled = false;
		//}

		// Re-enable the main sprite renderer and set it's sprite to the deadEnemy sprite.
		//ren.enabled = true;
		//ren.sprite = deadEnemy;

		// Increase the score by 100 points
		//score.score += 100;

		// Set dead to true.
		//dead = true;

		// Allow the enemy to rotate and spin it by adding a torque.
		GetComponent<Rigidbody>().freezeRotation = false;
		GetComponent<Rigidbody> ().AddTorque (Vector3.up * 10);
		//Random.Range (deathSpinMin, deathSpinMax)
		// Find all of the colliders on the gameobject and set them all to be triggers.
		//Collider2D[] cols = GetComponents<Collider2D>();
		//foreach(Collider2D c in cols)
		//{
		//	c.isTrigger = true;
		//}

		// Play a random audioclip from the deathClips array.

		//int i = Random.Range(0, deathClips.Length);
		//AudioSource.PlayClipAtPoint(deathClips[i], transform.position);

		// Create a vector that is just above the enemy.
		//Vector3 scorePos;
		//scorePos = transform.position;
		//scorePos.y += 1.5f;

		// Instantiate the 100 points prefab at this point.
		//Instantiate(hundredPointsUI, scorePos, Quaternion.identity);
	}

	public void UpdateHealthBar ()
	{
		Debug.Log (health);
		// Set the health bar's colour to proportion of the way between green and red based on the player's health.
		//healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);

		// Set the scale of the health bar to be proportional to the player's health.
		//healthBar.transform.localScale = new Vector3(healthScale.x * health * 0.01f, 1, 1);
	}
	void Update(){
		
	}
}
