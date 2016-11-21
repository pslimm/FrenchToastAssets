using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public string levelName;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D ()
    {
        SceneManager.LoadScene(levelName);
    }
}
