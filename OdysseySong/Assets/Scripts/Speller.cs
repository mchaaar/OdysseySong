using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Speller : MonoBehaviour {

    public GameObject textUI;
    private TextMeshProUGUI text;

    void Start() {

        text = textUI.GetComponent<TextMeshProUGUI>();
        
    }



}
