	using UnityEngine;
using System.Collections;

public class CodeCanvasTrigger : MonoBehaviour {

	GameObject codeCanvas;

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
		codeCanvas.SetActive (false);
		Time.timeScale = 1.0f;
		GameObject.FindWithTag("Player").GetComponent<MegamanController>().jumpForce = 700.0f;

      




	}
}
