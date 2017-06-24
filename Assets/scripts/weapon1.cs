using UnityEngine;
using System.Collections;

public class weapon1 : MonoBehaviour {
	public Rigidbody knife;  //指定刀原型(prefeb)
//	public float speed = 100f;

	private Animator anim;	
	private playerControl playerCtrl;	
	public Vector3 mousePositionInWorld;

	void Awake()
	{
		
		anim = this.transform.root.gameObject.GetComponent<Animator>();
		playerCtrl = transform.root.GetComponent<playerControl> ();
	}

	void Start () {
	}

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