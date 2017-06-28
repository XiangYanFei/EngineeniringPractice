using UnityEngine;
using System.Collections;

public class spawnerMoney : MonoBehaviour
{
	public float spawnTime = 20f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject money;
	public Transform pointPlatfomer;
	//public GameObject[] enemies;		// Array of enemy prefabs.


	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		Invoke("Spawn", spawnDelay);
	}


	void Spawn ()
	{
		// Instantiate a random enemy.
		//int enemyIndex = Random.Range(0, enemies.Length);
		Instantiate(money, pointPlatfomer.position, transform.rotation);

		// Play the spawning effect from all of the particle systems.
		//foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		//{
		//	p.Play();
		//}
	}
}
