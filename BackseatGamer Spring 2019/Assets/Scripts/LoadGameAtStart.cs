using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadGameAtStart : MonoBehaviour {

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reloads current scene
 	}

 	public void StartMainGame() {
		SceneManager.LoadScene("RileysSuperFunTestingWorld"); // reloads current scene
 	}

 	public void Menu() {
		SceneManager.LoadScene("StartMenu"); // reloads current scene
 	}

}