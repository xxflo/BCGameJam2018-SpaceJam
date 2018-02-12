using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public int EnemySpeed;
    public int XMoveDirection;



    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, transform.position.y));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        
        //if(hit.distance < 0.00001)
            //Flip();
            //if (hit.collider.tag == "Player")
            //{
              // hit.collider.GetComponent<Player_Healthbar>().health--;
            //}
        

        if (gameObject.transform.position.y < -50)
        {
             Destroy(gameObject);
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Floor")
        {
            Flip();
        }
    }

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }


}
