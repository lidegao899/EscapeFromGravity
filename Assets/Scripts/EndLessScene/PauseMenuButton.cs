using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuButton : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private GameObject ConfirmMenu;
	[SerializeField] private GameObject PauseMenu;
	void Start(){

		//ConfirmMenu = GameObject.Find ("ComfirmMenu");

	}

	public void OnMouseUp(){

		if (this.tag == "MainMenu") {
		
			//SceneManager.LoadScene (0);
			//Time.timeScale = 1;
			//GameObject pauseMenu = GameObject.Find ("PauseMenu");
			ConfirmMenu.transform.position=new Vector2 (250f, 375);
			//GameObject pauseMenu = GameObject.Find ("PauseMenu");
			PauseMenu.transform.position=new Vector2 (-250f, 375);

		} else if (this.tag == "Retry") {
		
			SceneManager.LoadScene (1);
			Time.timeScale = 1;

		} else if (this.tag== "Back") {

			Time.timeScale = 1;
			GameObject pauseMenu = GameObject.Find ("PauseMenu");
			pauseMenu.transform.position=new Vector2 (-250f, 375);
		
		}




	}



}
