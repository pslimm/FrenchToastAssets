﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour 
{
	// Use this for initialization
	void Start() 
	{
	
	}
	
	// Update is called once per frame
	void Update() 
	{
	
	}

    public void loadGame()
    {
		SceneManager.LoadScene("2. Background & Instructions (How To Play)");   
    }

	public void loadTutorial()
	{
		SceneManager.LoadScene("3. Tutorial");
	}
}
