using UnityEngine;

public class Infection : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.tag == "Coin" && collision.gameObject.GetComponent<Void_Entity>().isInfected == false){

            collision.gameObject.GetComponent<Void_Entity>().GetInfected();

        }

    }

}
