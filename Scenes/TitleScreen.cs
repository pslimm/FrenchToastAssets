﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void loadGame()
    {
        SceneManager.LoadScene("2.Background & Instructions(How To Play)");   
    }
}
