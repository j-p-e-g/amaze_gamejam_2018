using System;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleChoice : MonoBehaviour
{
    // the correct choice should always be the first one, they'll be randomized in the display
	public GameObject[] menuEntries;
    public String[] choices;
    int correctChoice = 0;

    // Use this for initialization
    void Start()
    {
        this.ShuffleArray(choices);

        foreach (String c in choices)
        {
            Debug.Log(c);
        }
        Debug.Log("correct choice: " + choices[correctChoice]);
		
        for (int k = 0; k < choices.Length && k < menuEntries.Length; k++)
		{
			UnityEngine.UI.Text textComp = menuEntries[k].GetComponent<UnityEngine.UI.Text>();
			textComp.text = choices[k];
		}
    }

    private void ShuffleArray(String[] array)
    {
        // Knuth shuffle algorithm
        for (int t = 0; t < array.Length; t++)
        {
            int r = UnityEngine.Random.Range(t, array.Length);
            String tmp = array[t];
            array[t] = array[r];
            array[r] = tmp;

            if (r == correctChoice)
            {
                correctChoice = t;
            }
            else if (t == correctChoice)
            {
                correctChoice = r;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public void HandleClickOnAnswer(int answerId)
    {
        Debug.Log("clicked on answer " + answerId);
        this.EvaluateAnswerByIndex(answerId);
    }

    void EvaluateAnswerByIndex(int index)
    {
        if (index < 0 || index >= choices.Length)
        {
            Debug.LogError("Trying to evaluate answer with index " + index + " of " + choices.Length + " answers");
        }
        else
        {
            if (index == correctChoice)
            {
				SoundManager.getInstance().playWinSound();
                Debug.Log("Correct!");
            }
            else
            {
				SoundManager.getInstance().playLoseSound();
                Debug.Log("Wrong");
            }
        }
    }
}
