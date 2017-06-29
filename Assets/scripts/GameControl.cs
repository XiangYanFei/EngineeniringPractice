using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public void OnChangeScenes(string sceneName)
	{
		SceneManager.LoadScene (1);

	}

}
