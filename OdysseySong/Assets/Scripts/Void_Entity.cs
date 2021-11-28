using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void_Entity : MonoBehaviour{

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    public bool isInfected;

    public int destroyTimer;

    public bool randomColorOn;

    public Color[] colors;
    public Color[] infectedColors;

    private void Start(){

        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        if (randomColorOn){

            PickARandomColor();

        }

        Invoke("YoureAFailureKillYourself", destroyTimer);

    }

    void PickARandomColor(){

        spriteRenderer.color = colors[Random.Range(0, colors.Length)];

    }

    void OnCollisionEnter2D(Collision2D collision){

        if (isInfected && collision.gameObject.tag == "Coin" && collision.gameObject.GetComponent<Void_Entity>().isInfected == false){

            collision.gameObject.GetComponent<Void_Entity>().GetInfected();

        }

    }

    void YoureAFailureKillYourself(){

        Destroy(gameObject);

    }

    public void GetInfected(){

        if (!isInfected){

            isInfected = true;
            spriteRenderer.color = infectedColors[Random.Range(0, infectedColors.Length)];
            Shake();

        }

    }

    void Shake(){

        int randomHorizontal = Random.Range(-300, 300);
        int randomVertical = Random.Range(-300, 300);

        rb.AddForce(new Vector2(randomHorizontal * (Time.deltaTime * 100), randomVertical * (Time.deltaTime * 100)));

    }

}
