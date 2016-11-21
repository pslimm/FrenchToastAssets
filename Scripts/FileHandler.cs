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
    public List<string> operatorAnswers;

    public List<GameObject> draggables;
    public List<GameObject> slots;

    public Text headerText, classDecText, commentText, operatorText;
    public GameObject draggable;
    public GameObject slot;
    public GameObject draggableBox;
    public GameObject implementationArea;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("File handler");
        runFileHandler();
    }

    public void runFileHandler()
    {
        operatorText = GameObject.Find("OperatorText").GetComponentInChildren<Text>();
        clearBoard();
        readFile();
        splitLineList();

        // Initialize the header
        foreach (string line in headerFile)
        {
            headerText.text += line + '\n';
        }

        foreach (string line in operatorAnswers)
        {
            operatorText.text += line + '\n';
        }

        classDecText.text = classDefinition[0].ToString();

        // Instantiate our slots and draggables, doing some string parsing to process tags
        drawSlots();
        drawDraggables();
    }

    private void clearBoard()
    {
        lineList.Clear();
        headerFile.Clear();
        classDefinition.Clear();
        puzzleSlots.Clear();
        puzzlePieces.Clear();
        operatorAnswers.Clear();

        draggables.Clear();
        slots.Clear();

        headerText.text = "";
        operatorText.text = "";

        foreach (Transform child in draggableBox.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (Transform child in implementationArea.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void drawDraggables()
    {
        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            draggables.Add(Instantiate(draggable));
            draggables[i].transform.SetParent(draggableBox.transform);
            draggables[i].gameObject.GetComponentInChildren<Text>().text = puzzlePieces[i].Substring(0, puzzlePieces[i].Length - 1);
            draggables[i].GetComponentInChildren<PuzzlePieceDrag>().matchTag = puzzlePieces[i][puzzlePieces[i].Length - 1].ToString();

        }
    }

    private void drawSlots()
    {
        for (int i = 0; i < puzzleSlots.Count; i++)
        {
            slots.Add(Instantiate(slot));
            slots[i].transform.SetParent(implementationArea.transform);
            slots[i].gameObject.GetComponent<PuzzlePieceSlot>().matchTag = puzzleSlots[i][puzzleSlots[i].Length - 1].ToString();

            // If there's a comment, instantiate and draw
            if (puzzleSlots[i].Length > 3)
            {
                Instantiate(commentText, slots[i].transform);

                Text commentTextToModify = slots[i].GetComponentInChildren<Text>();
                commentTextToModify.text = puzzleSlots[i].ToString().Remove(puzzleSlots[i].Length - 1).Replace("\t", " ");
            }
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

            else if (lineList[i][0].Equals('s'))
            {
                operatorAnswers.Add(lineList[i].Replace("s_", ""));
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
