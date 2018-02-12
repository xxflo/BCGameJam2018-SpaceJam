using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loselife1 : MonoBehaviour {

    public GameObject player;

    void Start()
    {
        // player = 
    }

    // Update is called once per frame
    void Update () {
        if (player.GetComponent<Player_Healthbar>().health == 2)
        {
            Destroy(gameObject);
        }
		
	}
}
