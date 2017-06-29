using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour
{
	public float spawnTime = 2f;		// The amount of time between each spawn.
	public float spawnDelay = 25f;		// The amount of time before spawning starts.
	public GameObject enemy;

	void Start ()
	{
		Invoke("Spawn", spawnDelay);
	}
		
	void Spawn ()
	{
		Instantiate(enemy, transform.position, transform.rotation);
	}
		
	void Update()
	{
		spawnTime += Time.deltaTime;
		if (spawnTime > spawnDelay) 
		{
			Instantiate(enemy, transform.position, transform.rotation);
			spawnTime -= spawnDelay;
		}
	}
}
