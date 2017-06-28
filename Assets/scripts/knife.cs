using UnityEngine;
using System.Collections;

public class knife : MonoBehaviour {

	public GameObject explosion;  //定义爆炸prefeb
	private GameObject explo;

	//public float score = 0;
	public float time=3;//代表从A点出发到B经过的时长
	public Transform pointA;//点A
	public Vector3 pointB;//点B
	public float g=-10;//重力加速度
	// Use this for initialization
	public Vector3 speed;//初速度向量
	public Vector3 Gravity;//重力向量

	private playerControl playerControl;		// Reference to the PlayerControl script.

	void Awake(){
	}

	void Start () {
		playerControl = GameObject.Find("hero").GetComponent<playerControl>();
		pointA = gameObject.transform;
		pointB = GameObject.Find ("weapon").GetComponent<weapon1> ().mousePositionInWorld;
		transform.position = pointA.position;//将物体置于A点
		//通过一个式子计算初速度
		if (playerControl.bFaceRight) 
		{
			speed = new Vector3 ((pointB.x - pointA.position.x) / time,
				(pointB.y - pointA.position.y) / time - 0.5f * g * time, (pointB.z - pointA.position.z) / time);
			print ("向右发射");
		} 
		else 
		{
			Vector3 localScale = gameObject.transform.localScale;
			localScale.x *= -1;
			gameObject.transform.localScale = localScale;
			speed = new Vector3 (-(pointB.x - pointA.position.x) / time,
				(pointB.y - pointA.position.y) / time - 0.5f * g * time, (pointB.z - pointA.position.z) / time);
			print ("向左发射");
		}
		Gravity = Vector3.zero;//重力初始速度为0
		/*
		//通过一个公式计算出初速度向量，角度*力度
		MoveSpeed = Quaternion.Euler (new Vector3 (-Angle, 0, 0)) * Vector3.forward * Power;
		currentAngle = Vector3.zero;
		Destroy (gameObject,3); 
		*/
	}

	private float dTime=0;

	void FixedUpdate()
	{
		Gravity.y = g * (dTime += Time.fixedDeltaTime);//v=at
		//模拟位移
		transform.Translate(speed*Time.fixedDeltaTime);
		transform.Translate(Gravity * Time.fixedDeltaTime);
		/*
		//计算物体的重力速度
		//v = at ;
		GritySpeed.y = Gravity * (dTime += Time.fixedDeltaTime);
		//位移模拟轨迹
		transform.position += (MoveSpeed + GritySpeed) * Time.fixedDeltaTime;
		currentAngle.z = Mathf.Atan((MoveSpeed.y + GritySpeed.y) / MoveSpeed.x) * Mathf.Rad2Deg;
		transform.eulerAngles = currentAngle;
		Debug.Log (transform.position);
		*/
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
		// Instantiate the explosion where the rocket is with the random rotation.
		explo=GameObject.Instantiate(explosion, transform.position, randomRotation)as GameObject;
		Destroy(explo,0.2F);
		
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
		if(col.collider.tag == "deadline")
		{
			Destroy (gameObject);
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
