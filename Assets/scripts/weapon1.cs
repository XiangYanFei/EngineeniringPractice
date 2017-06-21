using UnityEngine;
using System.Collections;

public class weapon1 : MonoBehaviour {
	public Rigidbody knife;  //指定刀原型(prefeb)
	//public float speed = 100f;
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

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			if (Input.mousePosition.x > transform.position.x) {
				anim.SetTrigger ("Attack");
				//创建一条从摄像机到屏幕的射线，并穿过屏幕position（x，y）（忽略z）
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				Vector3 target = ray.GetPoint (10);
				//返回射线每5个单位的点
				transform.LookAt (target);
				Rigidbody knifeInstance = Instantiate (knife, transform.position, transform.rotation) as Rigidbody;
				knifeInstance.velocity = target - transform.position;
				//音效
				//	this.GetComponent<AudioSource> ().Play ();
			} 
			else {
				//改变武器朝向
				Vector3 localscale = transform.localScale;
				localscale.x *= -1;
				transform.localScale = localscale;
				anim.SetTrigger ("Attack");
				//创建一条从摄像机到屏幕的射线，并穿过屏幕position（x，y）（忽略z）
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				Vector3 target = ray.GetPoint (5);
				//返回射线每5个单位的点
				transform.LookAt (target);
				Rigidbody knifeInstance = Instantiate (knife, transform.position, transform.rotation) as Rigidbody;
				knifeInstance.velocity = target - transform.position;
			}
		}
	}
}
