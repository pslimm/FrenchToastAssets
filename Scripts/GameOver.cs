using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public GameObject dialogueBox;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D osvaldo)
    {
        dialogueBox.SetActive(true);
        Time.timeScale = 0;
    }

    public void onDialogueClick()
    {
        SceneManager.LoadScene("7. End Credits (Optional)");
    }

    public void onGameOverClick()
    {
        Debug.Log("Test");
        Application.Quit();
    }
}
