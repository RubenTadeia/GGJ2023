using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{

    public void RestartGame (){
		SwitchPlay.play = false;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	public void BackToMenu (){
		SceneManager.LoadScene("Menu");
	}
}
