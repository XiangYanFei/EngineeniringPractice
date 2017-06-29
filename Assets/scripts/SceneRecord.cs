using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRecord {


	static SceneRecord instance = null;

	Stack<int>  sceneName =  new Stack<int>();

	static public SceneRecord GetInstanse()
	{
		if (instance == null) 
		{

			instance = new SceneRecord ();
		}

		return instance;
	}



	public void LoadScene(int  nameNum)
	{
		sceneName.Push (nameNum);
		SceneManager.LoadScene (nameNum);

	}


	public void JumpBack()
	{
		if (sceneName.Count > 1) {
			int num = sceneName.Pop ();
			SceneManager.LoadScene (num);
		}

	}



}
