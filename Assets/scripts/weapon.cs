using UnityEngine;
using System.Collections;

public class weapon : MonoBehaviour {
	public Rigidbody knife;  //指定刀原型(prefeb)
	public float speed = 100f;
	private Animator anim;	
	private playerControl playerCtrl;	
	public Transform point;
	private float nextAttack=1f;
	public float  nextRare=2f;
	// Use this for initialization
	void Awake()
	{
		anim = this.transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<playerControl> ();
	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			//触发Shoot
			anim.SetTrigger("Attack");
			//音效
		//	this.GetComponent<AudioSource> ().Play ();
			//首先创建火箭
			if(playerCtrl.bFaceRight)
			{
			// ... instantiate the rocket facing right and set it's velocity to the right. 
			 Rigidbody knifeInstance = Instantiate(knife, transform.position, transform.rotation) as Rigidbody;
			 knifeInstance.velocity = new Vector2(speed, 0);
			}
			else
			{
				// Otherwise instantiate the rocket facing left and set it's velocity to the left.
				Rigidbody knifeInstance = Instantiate(knife, transform.position, Quaternion.Euler(new Vector3(0,0,180))) as Rigidbody;
				knifeInstance.velocity = new Vector2(-speed, 0);
			}

		}
	}
}
