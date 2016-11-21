﻿	using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodeCanvasTrigger : MonoBehaviour {

	GameObject codeCanvas;
    GameObject fileHandler;
    GameObject operatorUse;

    // Use this for initialization
    void Start () {
		codeCanvas = GameObject.FindGameObjectWithTag ("CodeCanvas");
        operatorUse = GameObject.Find("OperatorUse");
        codeCanvas.SetActive (false);
        operatorUse.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (codeCanvas.layer.ToString ());
	}

	/*public void onBubbleClick () {
		codeCanvas.SetActive (true);
	}*/

	void OnTriggerEnter2D(Collider2D osvaldo) {
		if (osvaldo.gameObject.tag == "Player") {
			osvaldo.gameObject.GetComponent<MegamanController>().jumpForce = 0.0f;
			Time.timeScale = 0.0f;
			codeCanvas.SetActive (true);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
		}
	}

	public void onCheckClick() {

        bool correct = true;
        // Check answers
        fileHandler = GameObject.Find("FileHandler");
        List<GameObject> slots = fileHandler.GetComponent<FileHandler>().slots;

        foreach (GameObject slot in slots)
        {
            try { 
                if (!slot.GetComponentInChildren<PuzzlePieceDrag>().matchTag.Equals(slot.GetComponent<PuzzlePieceSlot>().matchTag))
                {
                    Debug.Log("Incorrect answer!");
                    slot.GetComponentInChildren<Image>().color = Color.red;
                    correct = false;
                } else
                {
                    slot.GetComponentInChildren<Image>().color = Color.green;
                }
            }
            catch
            {
                Debug.Log("No options selected");
                correct = false;
            }
        }

        if (correct)
        {
            // If tutorial
            if (SceneManager.GetActiveScene().name[0] == '3')
            {
                Debug.Log("Test");
                codeCanvas.SetActive(false);
                Time.timeScale = 1.0f;
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 7000.0f));       
            }
        }
    }
}
