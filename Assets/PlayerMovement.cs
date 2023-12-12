using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PlayerMovement : MonoBehaviour
{
    public float speed = 0;
    public float rotationspeed;
    
    private Rigidbody rb;
    public int playerScore;    
    private bool isMoving; //is current sphere moving
    public bool isIce;
    public bool isLava;
    public bool isSand;



    // Start is called before the first frame update
    void Start()
    {
        //rbp2 = GetComponent<Rigidbody>();
        rb = GetComponent<Rigidbody>();

        playerScore = 0;
        //isTurn = false;
        isMoving = false;
        isIce = false;
        

    }

    // Update is called once per frame
   
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        movementDirection.Normalize();
        rb.AddForce(movementDirection * speed);


        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);
        //TODO
        //if speed of player is 0: apply affect/points and switch turns
        //changeTurn();

        Vector3 rbVelocity = rb.velocity;
        if (isMoving && rbVelocity == Vector3.zero)
        {
            //rb has stopped moving
            isMoving = false;
        }
        else if (!isMoving && rbVelocity != Vector3.zero)
        {
            isMoving = true;
        }
    }

    

    //public void OnTriggerEnter(Collider other)
    //{
    //    Vector3 rbVelocity = rb.velocity;

    //    if (other.transform.CompareTag("Player"))
    //    {
    //        //other play object will be hit and move based on force of current player
           
    //    } else if (other.transform.CompareTag("Ice"))
    //    {
    //        if (rbVelocity == Vector3.zero)
    //        {
    //            //apply "ice affect" when rb velocity == 0 
    //            //ice flag
    //            isIce = true;
    //        }
    //    } else if (other.transform.CompareTag("Lava"))
    //    {
    //        if (rbVelocity == Vector3.zero)
    //        {
    //            //apply "Lava affect" when rb velocity == 0
    //        }
    //    } else if (other.transform.CompareTag("Sand"))
    //    {
    //        if (rbVelocity == Vector3.zero)
    //        {
    //            //apply "Sand affect" when rb velocity == 0
    //        }
    //    } else if (other.transform.CompareTag("PosPoints") || other.transform.CompareTag("NegPoints"))
    //    {
    //        if (rounds % 2 == 0) 
    //        {
    //            //every 2 rounds, apply points if applicable 
    //            //player1score + space;
    //            //player2score + space;
    //        }
    //    }

    //    //after trigger event occured, switch turns?
    //    changeTurn();
    //}

    //use oncollision for floor spaces
    //apply floor affect @ end of round if points, apply floor affect after player turn if i/s/l
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("PosPoints"))
        {

        }
    }




   
}
