using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodeCanvasHandler : MonoBehaviour {

	public static GameObject codeCanvas;
    GameObject fileHandler;
    GameObject operatorUse;
    public TextAsset fileToLoad;
	bool enemyDead = false;

    // Use this for initialization
    void Start () {
		codeCanvas = GameObject.FindGameObjectWithTag ("CodeCanvas");
        operatorUse = GameObject.Find("OperatorUse");
        fileHandler = GameObject.Find("FileHandler");

        // When the player steps into this trigger, load the specified file
        fileHandler.GetComponent<FileHandler>().file = fileToLoad;
        fileHandler.GetComponent<FileHandler>().runFileHandler();

        codeCanvas.SetActive (false);
    }
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D osvaldo) {
		if (osvaldo.gameObject.tag == "Player") {
			osvaldo.gameObject.GetComponent<MegamanController>().jumpForce = 0.0f;
			Time.timeScale = 0.0f;
			codeCanvas.SetActive (true);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
		}
	}

    public void onCheckClick()
    {
        bool correct = true;
        // Check answers
        List<GameObject> slots = fileHandler.GetComponent<FileHandler>().slots;
        foreach (GameObject slot in slots)
        {
            try
            {
                if (!slot.GetComponentInChildren<PuzzlePieceDrag>().matchTag.Equals(slot.GetComponent<PuzzlePieceSlot>().matchTag))
                {
                    Debug.Log("Incorrect answer!");
                    slot.GetComponentInChildren<Image>().color = Color.red;
                    correct = false;
                }
                else
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
            if (fileHandler.GetComponent<FileHandler>().file.name == "Addition" || fileHandler.GetComponent<FileHandler>().file.name == "Multiplication" || fileHandler.GetComponent<FileHandler>().file.name == "AdditionUsage1" || fileHandler.GetComponent<FileHandler>().file.name == "MultiplicationUsage1")
            {
                codeCanvas.SetActive(false);
                Time.timeScale = 1.0f;
                GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 7000.0f));
            }

            if (fileHandler.GetComponent<FileHandler>().file.name == "Increment" || fileHandler.GetComponent<FileHandler>().file.name == "IncrementUsage1")
            {
                codeCanvas.SetActive(false);
                Time.timeScale = 1.0f;
				GameObject.FindWithTag ("Enemy").GetComponent<Collider2D> ().enabled = false;
				StartCoroutine(shootTime());
            }
        }
    }

    IEnumerator shootTime()
    {
		
		GameObject.FindWithTag("Player").GetComponent<Shoot>().shooting = true;
        Debug.Log("player shooting");
		GameObject.FindWithTag ("Player").GetComponent<MegamanController> ().maxSpeed = 0.0f;
		enemyDead = true; 
		GameObject.FindWithTag ("Enemy").GetComponent<Animator> ().SetBool ("dead", enemyDead);
		yield return new WaitForSeconds(1.25f);
		Destroy(GameObject.FindWithTag ("Enemy"));
        GameObject.FindWithTag("Player").GetComponent<Shoot>().shooting = false;
		GameObject.FindWithTag ("Player").GetComponent<MegamanController> ().maxSpeed = 100.0f;
        //GameObject.FindWithTag("Player").GetComponent<Animator>().
        Debug.Log("player not shooting");
   
    }
}
