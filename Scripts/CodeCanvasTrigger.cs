	using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CodeCanvasTrigger : MonoBehaviour {

	GameObject codeCanvas;
    GameObject fileHandler;

	// Use this for initialization
	void Start () {
		codeCanvas = GameObject.FindGameObjectWithTag ("CodeCanvas");
		codeCanvas.SetActive (false);
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
		}
	}

	public void onCheckClick() {

        bool correct = true;
        // Check answers
        fileHandler = GameObject.Find("FileHandler");
        List<GameObject> slots = fileHandler.GetComponent<FileHandler>().slots;

        foreach (GameObject slot in slots)
        {
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

        if (correct)
        {
            codeCanvas.SetActive(false);
            Time.timeScale = 1.0f;
            // Make character perform correct action
        }

        //codeCanvas.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<MegamanController>().jumpForce = 700.0f;



    }
}
