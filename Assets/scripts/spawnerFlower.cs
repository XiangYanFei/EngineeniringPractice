using UnityEngine;
using System.Collections;

public class spawnerFlower : MonoBehaviour
{
	public float spawnTime = 20f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject flower;
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
		Instantiate(flower, pointPlatfomer.position, transform.rotation);

		// Play the spawning effect from all of the particle systems.
		//foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		//{
		//	p.Play();
		//}
	}
}
