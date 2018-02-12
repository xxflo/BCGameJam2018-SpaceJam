using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Proto : MonoBehaviour {

    private GameObject player;
    public float mapLimitLeft;
    public float mapLimitRight;
    public float mapLimitUpper;
    public float mapLimitLower;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float xPos = Mathf.Clamp(player.transform.position.x, mapLimitLeft, mapLimitRight);                         // lock the camera once reached end
        float yPos = Mathf.Clamp(player.transform.position.y, mapLimitUpper, mapLimitLower);                        //      similiarly for the y axis
        gameObject.transform.position = new Vector3(xPos, yPos, player.gameObject.transform.position.z);            // lock the camera on the player.
	}
}
