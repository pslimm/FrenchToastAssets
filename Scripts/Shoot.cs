﻿using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour 
{
	public Animator animatePlayer;
	bool shooting = false;

	// Use this for initialization
	void Start () 
	{
		animatePlayer = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown ("s")) 
		{
			shooting = true
		}
		if (shooting = true) 
		{
			animatePlayer.SetBool ("Shooting", shooting);
		}
	}
}