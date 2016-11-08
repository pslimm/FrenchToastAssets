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
		Debug.Log (codeCanvas.layer.ToString ());
	}

	public void onBubbleClick () {
		codeCanvas.SetActive (true);
	}

	public void onCheckClick() {
		codeCanvas.SetActive (false);
	}
}
