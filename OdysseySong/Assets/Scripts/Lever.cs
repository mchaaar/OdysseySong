using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour{

    public GameObject linkedDoor;
    public bool isUnlocked;

    private Animator animator;
    private GameObject error;
    private GameObject validate;
    private Door linkedDoorScript;

    private void Start(){

        animator = GetComponent<Animator>();
        error = transform.GetChild(0).gameObject;
        validate = transform.GetChild(1).gameObject;
        linkedDoorScript = linkedDoor.GetComponent<Door>();

    }

    private void OnMouseDown(){
        
        if (isUnlocked){

            animator.SetTrigger("Open");
            error.SetActive(false);
            validate.SetActive(true);
            linkedDoorScript.OpenNow();

        }

        else{

            validate.SetActive(false);
            error.SetActive(true);
            Invoke("RParticles", 1.5f);

        }

    }

    void RParticles(){

        transform.GetChild(0).gameObject.SetActive(false);

    }

}
