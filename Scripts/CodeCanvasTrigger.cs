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
			osvaldo.gameObject.GetComponent<MegamanController>().maxSpeed = 0;
			osvaldo.gameObject.SetActive(false);
			codeCanvas.SetActive (true);
		}
	}

	public void onCheckClick() {
		codeCanvas.SetActive (false);
		GameObject.FindWithTag("Player").SetActive(true);
	}
}
