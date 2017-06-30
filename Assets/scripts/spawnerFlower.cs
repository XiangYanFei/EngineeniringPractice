using UnityEngine;
using System.Collections;

public class spawnerFlower : MonoBehaviour
{
	public float spawnTime = 20f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject flower;
	public Transform pointPlatfomer;

/*	void Start ()
	{
		Invoke("Spawn", spawnDelay);
	}


	void Spawn ()
	{
		Instantiate(flower, pointPlatfomer.position, transform.rotation);
	}
*/
	void Update()
	{
		spawnTime += Time.deltaTime;
		if (spawnTime > spawnDelay) 
		{
			Instantiate(flower, pointPlatfomer.position, transform.rotation);
			spawnTime -= spawnDelay;
		}
	}
}
