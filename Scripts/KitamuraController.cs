using UnityEngine;
using System.Collections;

public class KitamuraController : MonoBehaviour {

    public float speed;              //Floating point variable to store the player's horizontal movement speed.
    public float jspeed;
    public float maxSpeed;            //Floating point variable to store the player's jump movement speed.
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private bool airborne;
    private bool safetyoff=true;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D> ();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        if(Input.GetButtonDown("Fire1")&& airborne && safetyoff){
            RaycastHit2D

        }
       if(Input.GetButtonDown("Jump") && !airborne){
            rb2d.AddForce(Vector2.up * jspeed *Input.GetAxis("Jump"), ForceMode2D.Impulse);
            airborne= true;
        }
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = 0;


        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce (movement * speed, ForceMode2D.Impulse);
        if(rb2d.velocity.magnitude > maxSpeed)
         {
                rb2d.velocity =new Vector2(rb2d.velocity.normalized.x * maxSpeed,rb2d.velocity.y);
         }
    }
    void OnCollisionEnter2D(Collision2D col)
 {
   
        Debug.Log("Ouch!");
        airborne= false;
    
 }
}