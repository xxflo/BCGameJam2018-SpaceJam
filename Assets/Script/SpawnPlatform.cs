using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour {

    public int maxPlatforms;
    public GameObject platform;
    public float horizontalMin = 5f;
    public float horizontalMax = 20f;
    public float verticalMin = -6f;
    public float verticalMax = 6f;
    public float spawnTime;



    private Vector2 originPosition;// = gameObject.transform.position;




	// Use this for initialization
	void Start () {

        originPosition = transform.position;
        //InvokeRepeating("Spawn", 0, spawnTime);

        // Spawn();
	}
	
	// Update is called once per frame
	void Spawn () {

        float x = Random.Range(horizontalMin, horizontalMax);
        float y = Random.Range(verticalMin, verticalMax);
        Vector2 pos = originPosition + new Vector2(x, y);

        if (pos.y > 18 || pos.y < 0)
        {
            pos = new Vector2(pos.x, 5);
        }
        
        Instantiate(platform, pos, Quaternion.identity);
        // originPosition = pos;
        /*for (int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2(Random.Range(horizontalMin, horizontalMax), Random.Range(verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }*/
    }
}
