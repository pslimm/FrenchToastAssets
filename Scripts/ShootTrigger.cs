﻿using UnityEngine;
using System.Collections;

public class ShootTrigger : MonoBehaviour {

    GameObject fileHandler;
    public TextAsset fileToRead;

	// Use this for initialization
	void Start () {
        fileHandler = GameObject.Find("FileHandler");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D osvaldo)
    {
        if (osvaldo.gameObject.tag == "Player")
        {
            Debug.Log("Entering shoot trigger");
            osvaldo.gameObject.GetComponent<MegamanController>().jumpForce = 0.0f;
            Time.timeScale = 0.0f;
            fileHandler.GetComponent<FileHandler>().file = fileToRead;
            fileHandler.GetComponent<FileHandler>().runFileHandler();
            CodeCanvasTrigger.codeCanvas.SetActive(true);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
