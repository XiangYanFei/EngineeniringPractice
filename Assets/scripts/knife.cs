using UnityEngine;
using System.Collections;

public class knife : MonoBehaviour {

	public GameObject explosion;  //定义爆炸prefeb
	private GameObject explo;


	public float Power=10;//这个代表发射时的速度/力度等，可以通过此来模拟不同的力大小
	public float Angle=45;//发射的角度，这个就不用解释了吧
	public float Gravity = -10;//这个代表重力加速度
	public bool IsOne=false;
	private Vector3 MoveSpeed;//初速度向量
	private Vector3 GritySpeed = Vector3.zero;//重力的速度向量，t时为0
	private float dTime;//已经过去的时间
	private Vector3 currentAngle;

	private playerControl playerControl;		// Reference to the PlayerControl script.

	void Awake(){
	}

	void Start () {
		playerControl = GameObject.Find("hero").GetComponent<playerControl>();
		if (playerControl.bFaceRight) 
		{
			MoveSpeed = Quaternion.Euler(new Vector3(0, 0, Angle)) * Vector3.right * Power;
			print ("向右发射");
		} 
		else 
		{
			Vector3 localScale = gameObject.transform.localScale;
			localScale.x *= -1;
			gameObject.transform.localScale = localScale;
			MoveSpeed = Quaternion.Euler(new Vector3(0, 0, Angle)) * Vector3.left * Power;
			print ("向左发射");
		}
		currentAngle = Vector3.zero;
	}

	void FixedUpdate()
	{
		GritySpeed.y = Gravity * (dTime += Time.fixedDeltaTime);
		//位移模拟轨迹
		transform.position+=(MoveSpeed + GritySpeed) * Time.fixedDeltaTime;
		currentAngle.z = Mathf.Atan ((MoveSpeed.y + GritySpeed.y) / MoveSpeed.x) * Mathf.Rad2Deg;
		transform.eulerAngles = currentAngle;
	}

	// Update is called once per frame
	void Update ()
	{

	}

	void OnExplode()
	{
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
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

			//score += 10;
			GameObject.Find ("hero").GetComponent<playerControl> ().score += 10;
			//print (GameObject.Find ("hero").GetComponent<playerControl> ().score);

		}
		if(col.collider.tag == "deadline")
		{
			Destroy (gameObject);
		}
	}

}

