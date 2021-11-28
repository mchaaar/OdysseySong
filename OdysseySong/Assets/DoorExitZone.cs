using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorExitZone : MonoBehaviour {

    public GameObject doorCore;
    private Door doorCoreScript;
    private bool closedOnce;

    void Start(){

        doorCoreScript = doorCore.GetComponent<Door>();

    }

    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.transform.tag == "Player" && !closedOnce){

            doorCoreScript.CloseNow();
            closedOnce = true;

        }

    }

}
