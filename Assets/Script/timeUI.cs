using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class timeUI : MonoBehaviour
{

    private float timeLeft = 40; // seconds
    private int multiplier = 10;
    public GameObject timeLeftUI;
    public GameObject Score_UI;



    // Update is called once per frame
    public void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);

		if (timeLeft < 0.1f) {
			// CountScore ();
			SceneManager.LoadScene ("DieScene");
		}
			
    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        //CountScore();
    }

    public void CountScore()

	{
       //  Score_UI.gameObject.GetComponent<Text>().text = ((int)timeLeft * multiplier).ToString();

    }

}