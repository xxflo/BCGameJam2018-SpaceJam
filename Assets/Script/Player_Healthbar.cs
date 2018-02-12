using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Healthbar : MonoBehaviour
{

    public int health;
    public bool hasDied;
    private Rigidbody2D rb2d;

    public float pushBackForce = 100f;


    // Use this for initialization
    void Start()
    {
        hasDied = false;
        health = 3;
        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            hasDied = true;
        }

        if (health <= 0)
        {
            hasDied = true;
            Die();
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health--;
            rb2d.velocity = new Vector2(pushBackForce, -10f);
            //rb2d.AddForce(new Vector2.up * jumpPower);
            Debug.Log("wow");
        }
    }*/ 

    void Die()
    {
        SceneManager.LoadScene("DieScene");
        // DontDestroyOnLoad(gameObject.GetComponent<timeUI>());
        gameObject.GetComponent<timeUI>().CountScore();
    }
}
