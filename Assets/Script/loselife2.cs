using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loselife2 : MonoBehaviour {
    public GameObject player;

    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        if (player.GetComponent<Player_Healthbar>().health == 1)
        {
            Destroy(gameObject);
        }

    }
}
