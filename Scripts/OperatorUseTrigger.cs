using UnityEngine;
using System.Collections;

public class OperatorUseTrigger : MonoBehaviour {

    GameObject operatorBox;

	// Use this for initialization
	void Start () {
        operatorBox = GameObject.Find("OperatorUse");
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter2D(Collider2D osvaldo)
    {
        if (osvaldo.gameObject.tag == "Player")
        {
            operatorBox.SetActive(true);
            Animation anim = operatorBox.GetComponent<Animation>();
            anim["FadeOut"].speed = 0.25f;
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
