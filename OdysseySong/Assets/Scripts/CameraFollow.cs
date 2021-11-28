using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public GameObject player;
    private Vector3 pPosition;
    public float offset;
    public float offsetSmoothing;

    void Update(){

        pPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f) {

            pPosition = new Vector3(pPosition.x + offset, pPosition.y, pPosition.z);
        
        }

        else {

            pPosition = new Vector3(pPosition.x - offset, pPosition.y, pPosition.z);
        
        }
        
        transform.position = Vector3.Lerp(transform.position, pPosition, offsetSmoothing * Time.deltaTime);
    
    }

}
