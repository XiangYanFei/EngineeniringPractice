﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStart : MonoBehaviour {

	public void PauseGame()
	{
		Time.timeScale = 0;
	}
	public void StartGame()
	{
		Time.timeScale = 1;
	}
}
