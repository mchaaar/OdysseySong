using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogues : MonoBehaviour {

    public GameObject textUI;
    public bool multipleLines;
    public List<string> lines = new List<string>();
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

        if (!multipleLines){

            Invoke("Now", timeBeforeStarting);

        }

        else{

            Invoke("Multiple", timeBeforeStarting);

        }

    }

    private void Now(){

        StartCoroutine(TextUpdate());

    }

    private void Multiple(){

        StartCoroutine(MultipleTextUpdate());

    }

    IEnumerator MultipleTextUpdate(){

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
        string tempText = "";

        foreach (char c in tempChars){

            tempText += c;

        }

        text.text = tempText;

        yield return new WaitForSeconds(timeBetweenEachLetter);

        if (tempChars.Count > 0){

            StartCoroutine(EraseText());

        }

        else {

            StopCoroutine(EraseText());

        }

    }

}
