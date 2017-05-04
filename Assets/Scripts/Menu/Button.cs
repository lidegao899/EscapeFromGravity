using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour {

	[SerializeField]	private GameObject ConfirmMenu;
	[SerializeField]	private GameObject TargetMenu;
	[SerializeField]	private GameObject HelpPic;
	[SerializeField] 	private GameObject MenuObject;

	[SerializeField] 	private Camera cam;
	[SerializeField]    private Canvas canvas;

	private int height;
	private int width;
	RectTransform rectTransform;
	Vector2 midOfScreen;

	void Start () {
		height=Screen.currentResolution.height;
		width= Screen.currentResolution.width;

	}


	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter()
	{

		print ("jinru");
	}

	public void Click(){

		//print ("click");
		//print(this.tag);


		if (this.tag == "t_Start") {
			SceneManager.LoadScene (1);
			print ("t_play");


		}


		if (this.tag == "t_Board") {

			print ("t_Board");

		}





		if (this.tag == "t_Exit") {

			Vector2 pos;
			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width/2,Screen.height/2), canvas.worldCamera, out pos);

			rectTransform=ConfirmMenu.transform as RectTransform;

			rectTransform.anchoredPosition = pos;


		}

		if (this.tag == "t_Help") {

			print ("t_Help");
//			SceneManager.LoadScene (2);

			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width*2,Screen.height*2), canvas.worldCamera, out midOfScreen);
			rectTransform = MenuObject.transform as RectTransform;

			rectTransform.anchoredPosition = midOfScreen;

			//			ConfirmMenu.transform.position = new Vector2 (800, 0);


			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width/2,Screen.height/2), canvas.worldCamera, out midOfScreen);
			rectTransform=HelpPic.transform as RectTransform;

			rectTransform.anchoredPosition = midOfScreen;



		}

		if (this.tag == "Yes") {
			Time.timeScale = 1;
			SceneManager.LoadScene (0);


		}


		if (this.tag == "No") {

			print ("No");

			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width*2,Screen.height*2), canvas.worldCamera, out midOfScreen);
			rectTransform=ConfirmMenu.transform as RectTransform;
			rectTransform.anchoredPosition = midOfScreen;

//			ConfirmMenu.transform.position = new Vector2 (800, 0);


			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width/2,Screen.height/2), canvas.worldCamera, out midOfScreen);
			rectTransform=TargetMenu.transform as RectTransform;

			rectTransform.anchoredPosition = midOfScreen;

		}

		if (this.tag == "HelpPic") {

			print ("HelpPic");

			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width*2,Screen.height*2), canvas.worldCamera, out midOfScreen);
			rectTransform=HelpPic.transform as RectTransform;
			rectTransform.anchoredPosition = midOfScreen;

			//			ConfirmMenu.transform.position = new Vector2 (800, 0);


			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width/2,Screen.height/2), canvas.worldCamera, out midOfScreen);
			rectTransform=MenuObject.transform as RectTransform;
			rectTransform.anchoredPosition = midOfScreen;

		}

		if (this.tag == "Exit_No") {

			Vector2 pos;
			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width*2,Screen.height*2), canvas.worldCamera, out pos);

			rectTransform=ConfirmMenu.transform as RectTransform;

			rectTransform.anchoredPosition = pos;

		}

		if (this.tag == "Exit_Yes") {


			Application.Quit();

		}
	}


}
