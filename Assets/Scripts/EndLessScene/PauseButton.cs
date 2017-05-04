using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	// Use this for initialization

	[SerializeField] private Player  player;
	[SerializeField] private GameObject PauseMenu;

	[SerializeField] 	private Camera cam;
	[SerializeField]    private Canvas canvas;

	private int height;
	private int width;
	RectTransform rectTransform;
	Vector2 posOfScreen;


	private Vector2 pausePosition;
	private Vector2 unPausePosition;
	private bool isPause=false;

	Vector2 pos;

	void Start () {

		height=Screen.height;
		width= Screen.width;


//		pos = new Vector2 (width-height/12, height * 11 / 12);


	}
	
	// Update is called once per frame
	void Update () {
	


	}

	public void OnButtonDown(){
	
		print ("暂停");
	


	}

	public void Click(){
	
		print ("click");
	
	}

	public void OnMouseUp(){
		print ("pause");
		if (Time.timeScale>0) {
		
			Time.timeScale = 0;
			isPause = true;
//			PauseMenu.transform.position = pausePosition;

			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform,new Vector2(Screen.width/2,Screen.height/2), canvas.worldCamera, out posOfScreen);
			rectTransform=PauseMenu.transform as RectTransform;
			rectTransform.anchoredPosition = posOfScreen;


		} else if(Time.timeScale==0&&player.fuelAmount>0)
		{
//			PauseMenu.transform.position = unPausePosition;

			RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width*2,Screen.height*2), canvas.worldCamera, out posOfScreen);
			rectTransform=PauseMenu.transform as RectTransform;
			rectTransform.anchoredPosition = posOfScreen;


			isPause = false;
			Time.timeScale = 1;
		
		}

			
	
	}

}
