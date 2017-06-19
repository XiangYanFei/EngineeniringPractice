using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {
	public float MaxFroce = 300;
	public float MaxSpeed = 6;
	public float JumpForce = 400;
	[HideInInspector]
	public bool bFaceRight = true;
	public Rigidbody herobody;
	//private Transform mGroundCheck;
	public bool bJump = false;
	private bool bGrounded = false;
	//private SpriteRenderer blood;
	//private Animator anim;

	private void Awake()
	{
		//	mGroundCheck = transform.Find("groundcheck");
		//blood = GameObject.Find("Health").GetComponent<SpriteRenderer>();
	}

	void Start () {
		herobody.gameObject.GetComponent<Rigidbody>();
		//anim = GetComponent<Animator>(); 

	}

	void Update()
	{
		//	int nlayer = LayerMask.NameToLayer("ground");
		//	bGrounded = Physics2D.Linecast(transform.position, mGroundCheck.position, 1 << nlayer);
		if (Input.GetKeyDown (KeyCode.W) && bGrounded) {
			print ("fff");
			bJump = true;
		}
		if (bJump) {
			print ("ddd");
			herobody.AddForce (Vector2.up * JumpForce);
			//anim.SetBool ("jump", bJump);
			//print ("DDD");
			bJump = false;
		} 
		//bJump = false;
		//anim.SetBool ("jump", bJump);
		//anim.SetBool ("jump", bJump);
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		//anim.SetFloat("speed", Mathf.Abs(h));

		if (herobody.velocity.x <= MaxSpeed)                    //添加小于等于，使其可以在空中左右走S型
			herobody.AddForce(Vector2.right * h * MaxFroce);
		//限制最大速度
		if (Mathf.Abs(herobody.velocity.x) > MaxSpeed)          //判断速度是否大于最大速度，大于则置为最大速度
			herobody.velocity = new Vector2(Mathf.Sign(herobody.velocity.x) * MaxSpeed, herobody.velocity.y);
		if (h > 0 && !bFaceRight)
			Flip();
		else if (h < 0 && bFaceRight)
			Flip();
		/*
		if (bJump)
		{ 
			print ("aaa");
			herobody.AddForce(Vector2.up * JumpForce);
			print ("bbb");
			//anim.SetTrigger("jump");
			bJump = false;
		}
		*/
	}

	public void OnCollisionEnter(Collision col){
		if (col.collider.tag == "ground")
			print ("开始碰撞");
		bGrounded = true;
		//	anim.SetBool ("bGrounded", bGrounded);
	}

	public void OnCollisionExit(Collision col) {
		if (col.collider.tag == "ground")
			print ("碰撞结束");
		bGrounded = false;
		//	anim.SetBool ("bGrounded", bGrounded);
	}

	void Flip()                                                 //功能：转身
	{
		Vector3 localscale = transform.localScale;
		localscale.x *= -1;
		transform.localScale = localscale;
		bFaceRight = !bFaceRight;                               //每做一次修改一次正负值
	}
}
