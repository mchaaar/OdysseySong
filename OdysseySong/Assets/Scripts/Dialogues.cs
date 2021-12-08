using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogues : MonoBehaviour {

    public GameObject textUI;
    public string textToSpell;
    public float timeBetweenEachLetter;
    public float timeBeforeStarting;
    public bool permanentText;
    public float timeBeforeErasing;

    private List<char> charsToSpell = new List<char>();
    private TextMeshProUGUI text;
    private char letterToAdd;
    private int index = 0;

    void Start() {

        text = textUI.GetComponent<TextMeshProUGUI>();

        char[] tempChars = textToSpell.ToCharArray();

        for (int i = 0; i < tempChars.Length; i++){

            charsToSpell.Add(tempChars[i]);

        }

        Invoke("Now", timeBeforeStarting);

    }

    private void Now(){

        StartCoroutine(TextUpdate());

    }

    IEnumerator TextUpdate(){

        text.text = text.text += charsToSpell[index];
        index++;

        yield return new WaitForSeconds(timeBetweenEachLetter);

        if (index < charsToSpell.Count){

            StartCoroutine(TextUpdate());

        }

        else {

            StopCoroutine(TextUpdate());

            if (!permanentText){

                Invoke("Erase", timeBeforeErasing);

            }

        }

    }

    private void Erase(){

        StartCoroutine(EraseText());

    }

    IEnumerator EraseText(){

        List<char> tempChars = charsToSpell;
        tempChars.RemoveAt(tempChars.Count - 1);
        index = tempChars.Count;
        string tempText = "";

        foreach (char c in tempChars){

            tempText += c;

        }

        text.text = tempText;

        yield return new WaitForSeconds(timeBetweenEachLetter);

        if (index > tempChars.Count){

            StartCoroutine(EraseText());

        }

        else {

            StopCoroutine(EraseText());

        }

    }

}
