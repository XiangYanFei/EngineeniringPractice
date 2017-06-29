using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl3 : MonoBehaviour {

	public void OnChangeScenes(string sceneName)
	{
		SceneManager.LoadScene (0);

	}
}
