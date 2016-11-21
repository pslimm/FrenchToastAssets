using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine.UI;

public class FileHandler : MonoBehaviour {

    public TextAsset file;

    public List<string> lineList;
    public List<string> headerFile;
    public List<string> classDefinition;
    public List<string> puzzleSlots;
    public List<string> puzzlePieces;

    public List<GameObject> draggables;
    public List<GameObject> slots;

    public Text headerText, classDecText, commentText;
    public GameObject draggable;
    public GameObject slot;
    public GameObject draggableBox;
    public GameObject implementationArea;

	// Use this for initialization
	void Start () {
        readFile();
        splitLineList();

        // Initialize the header
        foreach (string line in headerFile) {
            headerText.text += line + '\n';
        }

        classDecText.text = classDefinition[0].ToString();
       
        // Instantiate our slots and draggables, doing some string parsing to process tags
        for (int i = 0; i < puzzleSlots.Count; i++)
        {
            slots.Add(Instantiate(slot));
            slots[i].transform.SetParent(implementationArea.transform);
            slots[i].gameObject.GetComponent<PuzzlePieceSlot>().matchTag = puzzleSlots[i][puzzleSlots[i].Length - 1].ToString();

            // If there's a comment, instantiate and draw
            if (puzzleSlots[i].Length > 3)
            {
                Debug.Log("reached");
                Instantiate(commentText);
                commentText.text = puzzleSlots[i].ToString().Remove(puzzleSlots[i].Length -1).Replace("\t", "");
               // commentText.GetComponent<RectTransform>().position = slots[i].GetComponent<RectTransform>().position;
                // commentText.transform.rotation = slots[i].transform.rotation;

            }
        }

        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            draggables.Add(Instantiate(draggable));
            draggables[i].transform.SetParent(draggableBox.transform);
            draggables[i].gameObject.GetComponentInChildren<Text>().text = puzzlePieces[i].ToString();
            draggables[i].GetComponentInChildren<PuzzlePieceDrag>().matchTag = puzzlePieces[i][puzzlePieces[i].Length - 1].ToString();

        }
    }

    private void splitLineList()
    {
       for (int i = 0; i < lineList.Count; i++)
        {
            if (lineList[i][0].Equals('h'))
            {
                headerFile.Add(lineList[i].Replace("h_", ""));
            }

            else if (lineList[i][0].Equals('i'))
            {
                classDefinition.Add(lineList[i].Replace("i_", ""));
            }

            else if (lineList[i][0].Equals('c'))
            {
                puzzlePieces.Add(lineList[i].Replace("c_", ""));
            }

            else
                puzzleSlots.Add(lineList[i].Replace("p_", ""));

        }
    }
    
    private void readFile()
    {
        if (file)
        {
            string line;
            StringReader textStream = new StringReader(file.text);


            while ((line = textStream.ReadLine()) != null)
            {
                // Read each line from text file and add into list
                lineList.Add(line);
            }

            textStream.Close();
        }
    }

    private string GetRandomLine()
    {
        return lineList[UnityEngine.Random.Range(0, lineList.Count)];
    }

    // Update is called once per frame
    void Update () {
       
    }
}
