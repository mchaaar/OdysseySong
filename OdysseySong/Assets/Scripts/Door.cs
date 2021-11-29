using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public Animator animator;

    void Start(){

        animator = GetComponent<Animator>();
        
    }

    public void OpenNow(){

        animator.SetTrigger("Open");

    }

    public void CloseNow(){

        animator.SetTrigger("Close");

    }

}
