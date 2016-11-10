using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TutorialDialogue : MonoBehaviour {

	public List<string> tutorialText;
	GameObject dialogueTextObj;
	GameObject dialogueBox;
	Text dialogueText;

	int dialogueCount;


	// Use this for initialization
	void Start () {

		dialogueBox = GameObject.FindGameObjectWithTag ("Dialogue");
		dialogueTextObj = GameObject.FindGameObjectWithTag ("DialogueText");
		dialogueText = dialogueTextObj.GetComponent<Text> ();
		dialogueBox.SetActive (false);

		tutorialText = new List<string> ();
		tutorialText.Add ("There's a gap here! Looks like I'll have to jump over.");

	}

	void OnTriggerEnter2D(Collider2D osvaldo) {
		if (osvaldo.gameObject.tag == "Player") {
			osvaldo.gameObject.GetComponent<MegamanController>().jumpForce = 0.0f;
			Time.timeScale = 0.0f;
			dialogueBox.SetActive (true);
			dialogueText.text = tutorialText [0];

			GetComponent<BoxCollider2D> ().enabled = false;

		}
	}

	public void onDialogueClick() {
		dialogueCount += 1;

		if (dialogueCount >= tutorialText.Count) {
			Debug.Log ("Dialogue Count " + dialogueCount);

			Time.timeScale = 1.0f;
			dialogueBox.SetActive (false);
			return;
		}

		dialogueText.text = tutorialText [dialogueCount];




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
