using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_Open : MonoBehaviour {

    public GameObject platform;

    private void OnMouseDown(){

        platform.transform.GetChild(0).GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("open");
        platform.transform.GetChild(0).GetChild(1).gameObject.GetComponent<Animator>().SetTrigger("open");

    }

}
