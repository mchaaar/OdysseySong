using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnLimit : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision){
        
        if (collision.transform.tag == "Player"){

            SceneManager.LoadScene(0);

        }

    }

}
