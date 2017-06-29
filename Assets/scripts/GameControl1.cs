using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl1 : MonoBehaviour {

	public void nextScenes(string sceneName)
	{
		SceneManager.LoadScene (2);

	}
	public void forwardScenes(string sceneName)
	{
		SceneManager.LoadScene (0);
	}
}
