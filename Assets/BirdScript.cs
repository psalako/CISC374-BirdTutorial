using System;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float deadZoneX = 25;
    public float deadZoneY = 15;
    public AudioSource deathSFX;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameObject.name = "Bob Bird";
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(transform.position.x) > 25 || Math.Abs(transform.position.y) > 15){
            Debug.Log("Bird out of frame");
            logic.gameOver();
            birdIsAlive = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {myRigidbody.linearVelocity = Vector2.up * flapStrength;}
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        deathSFX.Play();
        logic.gameOver();
        birdIsAlive = false;
    }
}
