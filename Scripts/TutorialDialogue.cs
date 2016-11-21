using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TutorialDialogue : MonoBehaviour {

	public List<string> dialogueList;
    public List<string> tutorialTextList;

	GameObject dialogueTextObj;
	GameObject dialogueBox;

    GameObject tutorialTextObj;
    GameObject tutorialBox;

    Text dialogueText;
    Text tutorialText;

	int dialogueCount;
    public bool overloadTrigger = false;


	// Use this for initialization
	void Start () {

        // Initialize dialogue box
		dialogueBox = GameObject.FindGameObjectWithTag ("Dialogue");
		dialogueTextObj = GameObject.FindGameObjectWithTag ("DialogueText");
		dialogueText = dialogueTextObj.GetComponent<Text> ();
		dialogueBox.SetActive (false);

		dialogueList = new List<string> ();
		dialogueList.Add ("There's a gap here! Looks like I'll have to jump over.");


        // Initialize dialogue in code canvas
        tutorialBox = GameObject.FindGameObjectWithTag("TutorialDialogue");
        tutorialTextObj = GameObject.FindGameObjectWithTag("TutorialDialogueText");
        tutorialText = tutorialTextObj.GetComponent<Text>();
        tutorialBox.SetActive(true);

        tutorialTextList = new List<string>();
        tutorialTextList.Add("I'll have to overload the multiplication operator so I can jump over.");
        tutorialTextList.Add("Drag the correct lines of code to the corresponding spot in the center and press the green button when you're done.");
        tutorialTextList.Add("Use the class definition at the bottom as a reference!");

        tutorialText.text = tutorialTextList[0];


	}

	void OnTriggerEnter2D(Collider2D osvaldo) {
		if (osvaldo.gameObject.tag == "Player") {
			osvaldo.gameObject.GetComponent<MegamanController>().jumpForce = 0.0f;
			Time.timeScale = 0.0f;
			dialogueBox.SetActive (true);
			dialogueText.text = dialogueList [0];

			GetComponent<BoxCollider2D> ().enabled = false;

		}
	}

	public void onDialogueClick() {
		dialogueCount += 1;

		if (dialogueCount >= dialogueList.Count) {
			Debug.Log ("Dialogue Count " + dialogueCount);

			Time.timeScale = 1.0f;
			dialogueBox.SetActive (false);
            dialogueCount = 0;
			return;
		}
		dialogueText.text = dialogueList [dialogueCount];
	}

    public void onTutorialClick()
    {
        dialogueCount += 1;

        if (dialogueCount >= tutorialTextList.Count)
        {
            // Debug.Log("Dialogue Count " + dialogueCount);
            tutorialBox.SetActive(false);
            dialogueCount = 0;
            return;
        }
        tutorialText.text = tutorialTextList[dialogueCount];
    }



    // Update is called once per frame
    void Update () {
	    if (overloadTrigger)
        {
            Debug.Log("overload enabled");
        }
	}
}
