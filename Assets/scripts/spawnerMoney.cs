using UnityEngine;
using System.Collections;

public class spawnerMoney : MonoBehaviour
{
	public float spawnTime = 20f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject money;
	public Transform pointPlatfomer;

	void Start ()
	{
		Invoke("Spawn", spawnDelay);
	}
		
	void Spawn ()
	{
		Instantiate(money, pointPlatfomer.position, transform.rotation);
	}
	void Update()
	{
		spawnTime += Time.deltaTime;
		if (spawnTime > spawnDelay) 
		{
			Instantiate(money, pointPlatfomer.position, transform.rotation);
			spawnTime -= spawnDelay;
		}
	}
}
