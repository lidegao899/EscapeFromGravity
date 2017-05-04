using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuButton : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private GameObject ConfirmMenu;
	[SerializeField] private GameObject PauseMenu;

	[SerializeField] 	private Camera cam;
	[SerializeField]    private Canvas canvas;

	private int height;
	private int width;
	RectTransform rectTransform;
	Vector2 midOfScreen;
	void Start(){
		height=Screen.currentResolution.height;
		width= Screen.currentResolution.width;

		//ConfirmMenu = GameObject.Find ("ComfirmMenu");

	}

	public void OnMouseUp(){

		if (this.tag == "MainMenu") {
		
			//SceneManager.LoadScene (0);
			//Time.timeScale = 1;
			//GameObject pauseMenu = GameObject.Find ("PauseMenu");
//			ConfirmMenu.transform.position=new Vector2 (250f, 375);


			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width/2,Screen.height/2), canvas.worldCamera, out midOfScreen);
			rectTransform=ConfirmMenu.transform as RectTransform;

			rectTransform.anchoredPosition = midOfScreen;




			//GameObject pauseMenu = GameObject.Find ("PauseMenu");
//			PauseMenu.transform.position=new Vector2 (-250f, 375);

			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width*2,Screen.height*2), canvas.worldCamera, out midOfScreen);
			rectTransform=PauseMenu.transform as RectTransform;

			rectTransform.anchoredPosition = midOfScreen;



		} else if (this.tag == "Retry") {
		
			SceneManager.LoadScene (1);
			Time.timeScale = 1;

		} else if (this.tag== "Back") {

			Time.timeScale = 1;
			GameObject pauseMenu = GameObject.Find ("PauseMenu");

//			pauseMenu.transform.position=new Vector2 (-250f, 375);


			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width*2,Screen.height*2), canvas.worldCamera, out midOfScreen);
			rectTransform=pauseMenu.transform as RectTransform;
			rectTransform.anchoredPosition = midOfScreen;

		
		}




	}



}
