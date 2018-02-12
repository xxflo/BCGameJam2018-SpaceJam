using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadOnClick : MonoBehaviour {

	public void LoadByIndex(int scoreIndex){
		SceneManager.LoadScene(scoreIndex);	
	}
}
