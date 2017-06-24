using UnityEngine;
using System.Collections;

public class weapon1 : MonoBehaviour {
	public Rigidbody knife;  //指定刀原型(prefeb)
//	public float speed = 100f;
	public float Power = 10;//发射时的速度（力度）
	public float Angle=45;//发射的角度
	public float Gravity = -10;
	private Vector3 MoveSpeed;//初速度向量
	private Vector3 GritySpeed=Vector3.zero;//重力的速度向量，t时为0
	private float dTime; //已经过去的时间
	private Animator anim;	
	private playerControl playerCtrl;	
	//public Transform point;    
	//private float nextAttack=1f;
	//public float  nextRare=2f;
	// Use this for initialization
	void Awake()
	{
		anim = this.transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<playerControl> ();
	}

	void Start () {
		//通过一个公式计算出初速度向量，角度*力度
		MoveSpeed = Quaternion.Euler (new Vector3 (-Angle, 0, 0)) * Vector3.forward * Power;
	}
	/*
	void FixedUpdate(){
		if (Input.GetMouseButton (0)) {
			anim.SetTrigger ("Attack");
			print ("fff");
			Rigidbody knifeInstance = Instantiate (knife, transform.position, transform.rotation) as Rigidbody;
			//计算物体的重力速度v=at
			GritySpeed.y=Gravity*(dTime+=Time.fixedDeltaTime);
			//位移模拟轨迹
			knifeInstance.Translate(MoveSpeed*Time.fixedDeltaTime);
			knifeInstance.Translate(GritySpeed*Time.fixedDeltaTime);
		}

	}
	*/
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
			Vector3 mousePositionOnScreen = Input.mousePosition;   
			mousePositionOnScreen.z = screenPosition.z;  
			Vector3 mousePositionInWorld =  Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
			//Debug.Log (mousePositionInWorld);

			if (transform.root.GetComponent<playerControl> ().bFaceRight==true) 
			{
				//Debug.Log (transform.root.GetComponent<playerControl> ().bFaceRight);

				if (mousePositionInWorld.x >= gameObject.transform.parent.position.x)
				{	
					//	print ("面向右不转身");
					anim.SetTrigger ("Attack");
					Rigidbody knifeInstance = Instantiate (knife, transform.position, transform.rotation) as Rigidbody;
				} 
				if(mousePositionInWorld.x < gameObject.transform.parent.position.x) 	
				{
					//print ("面向右转身");
					Vector3 localScale = gameObject.transform.parent.localScale;
					localScale.x *= -1;
					gameObject.transform.parent.localScale = localScale;
					transform.root.GetComponent<playerControl> ().bFaceRight = false;
					anim.SetTrigger ("Attack");
					Rigidbody knifeInstance = Instantiate (knife, transform.position, transform.rotation) as Rigidbody;
				}
			}
			if(transform.root.GetComponent<playerControl> ().bFaceRight==false) 
			{
				if (mousePositionInWorld.x <= gameObject.transform.parent.position.x) 
				{
					//print ("面向左不转身");
					anim.SetTrigger ("Attack");
					Rigidbody knifeInstance = Instantiate (knife, transform.position, transform.rotation) as Rigidbody;
				} 
				if(mousePositionInWorld.x > gameObject.transform.parent.position.x)
				{
					//print ("面向左转身");
					anim.SetTrigger ("Attack");
					Vector3 localScale = gameObject.transform.parent.localScale;
					localScale.x *= -1;
					gameObject.transform.parent.localScale = localScale;
					transform.root.GetComponent<playerControl> ().bFaceRight = true;
					Rigidbody knifeInstance = Instantiate (knife, transform.position, transform.rotation) as Rigidbody;
				}
			}
		}
	}
}