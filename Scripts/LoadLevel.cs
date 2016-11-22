using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public string levelName;
    public GameObject dialogueEnd;
    public static bool dialogueFinish = false;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    if (dialogueFinish)
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(levelName);
        }
	}

    void OnTriggerEnter2D ()
    {
        Time.timeScale = 0.0f;
        dialogueEnd.SetActive(true);
    }
}
