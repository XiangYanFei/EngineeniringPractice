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
	public bool bJump = false;
	private bool bGrounded = false;
	//private SpriteRenderer blood;
	private Animator anim;
	public float score=0;

	private void Awake()
	{
		//blood = GameObject.Find("Health").GetComponent<SpriteRenderer>();
	}

	void Start () {
		herobody.gameObject.GetComponent<Rigidbody>();
		anim = GetComponent<Animator>(); 

	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.W) && bGrounded)
		{
			bJump = true;
		}
		if (bJump) 
		{
			herobody.AddForce (Vector2.up * JumpForce);
			anim.SetTrigger ("Jump");
			bJump = false;
		} 
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis("Horizontal");
		anim.SetFloat("speed", Mathf.Abs(h));

		if (herobody.velocity.x <= MaxSpeed)                    //添加小于等于，使其可以在空中左右走S型
			herobody.AddForce(Vector2.right * h * MaxFroce);
		//限制最大速度
		if (Mathf.Abs(herobody.velocity.x) > MaxSpeed)          //判断速度是否大于最大速度，大于则置为最大速度
			herobody.velocity = new Vector2(Mathf.Sign(herobody.velocity.x) * MaxSpeed, herobody.velocity.y);
		if (h > 0 && !bFaceRight)
			Flip();
		else if (h < 0 && bFaceRight)
			Flip();
	}

	public void OnCollisionEnter(Collision col){
		if (col.collider.tag == "ground")
			//print ("开始碰撞");
		bGrounded = true;
	}

	public void OnCollisionExit(Collision col) {
		if (col.collider.tag == "ground")
			//print ("碰撞结束");
		bGrounded = false;
	}

	void Flip()                                                 //功能：转身
	{
		Vector3 localscale = transform.localScale;
		localscale.x *= -1;
		transform.localScale = localscale;
		bFaceRight = !bFaceRight;                               //每做一次修改一次正负值
	}
}
