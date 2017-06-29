using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour {

	public float health = 100f;					// The player's health.
	public float money = 0;
	public float flower=0;
	public float repeatDamagePeriod = 2f;		// How frequently the player can be damaged.
	//public AudioClip[] ouchClips;				// Array of clips to play when the player is damaged.
	public float hurtForce = 10f;				// The force with which the player is pushed when hurt.
	public float damageAmount = 10f;			// The amount of damage to take when enemies touch the player

	public UISlider mainSlider;			// Reference to the sprite renderer of the health bar.
	public UILabel moneylable;			// Reference to the sprite renderer of the health bar.
	public UILabel scorelable;			// Reference to the sprite renderer of the health bar.

	private float lastHitTime;					// The time at which the player was last hit.
	private Vector3 healthScale;				// The local scale of the health bar initially (with full health).
	private playerControl playerControl;		// Reference to the PlayerControl script.
	private Animator anim;						// Reference to the Animator on the player

	private bool dead = false;			// Whether or not hero is dead.
	//private SpriteRenderer ren;			// Reference to the sprite renderer.
	public float deathSpinMin = -100;			// A value to give the minimum amount of Torque when dying
	public float deathSpinMax = 100;			// A value to give the maximum amount of Torque when dying

	void Awake ()
	{
		playerControl = GetComponent<playerControl>();
		anim = GetComponent<Animator>();
	}


	void OnCollisionEnter (Collision col)
	{
		if(col.collider.tag == "enemy")
		{
			if (Time.time > lastHitTime + repeatDamagePeriod) 
			{
				if(health > 0f)
				{
					TakeDamage(col.collider.transform); 
					lastHitTime = Time.time; 
				}
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
			if(health > 0f && health < 100f)
			{
				health += damageAmount;
				//print ("加血");
				Destroy (col.gameObject);
				//Debug.Log (health);
			}
		}
		if (col.collider.tag == "money") {
				money += 10;
				//print ("加钱");
				Destroy (col.gameObject);
				//Debug.Log (money);
		}
	}


	void TakeDamage (Transform enemy)
	{
		playerControl.bJump = false;
		Vector3 hurtVector = transform.position - enemy.position + Vector3.up * 10f;
		GetComponent<Rigidbody>().AddForce(hurtVector * hurtForce);
		health -= damageAmount;
	}

	void Death()
	{
		Collider[] cols = GetComponents<Collider>();
		foreach(Collider c in cols)
		{
			c.isTrigger = true;
		}
			
		SpriteRenderer[] spr = GetComponentsInChildren<SpriteRenderer>();
		foreach(SpriteRenderer s in spr)
		{
			s.sortingLayerName = "UI";
		}

		dead = true;
		GetComponent<playerControl>().enabled = false;
		GetComponentInChildren<weapon1>().enabled = false;

		anim.SetTrigger("Die");
		print ("播放死亡动画");
	}

	void Update(){
		//Debug.Log (health);
		mainSlider.value = health / 100f;
		moneylable.text = money.ToString();
		scorelable.text = (string)GameObject.Find ("hero").GetComponent<playerControl> ().score.ToString();
		//Debug.Log (mainSlider.value);
		//GameObject.Find ("hero").GetComponent<playerControl> ().score += 10;
	}
}
