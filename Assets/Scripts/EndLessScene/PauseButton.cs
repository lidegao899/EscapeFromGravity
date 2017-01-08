using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour {

	// Use this for initialization

	[SerializeField] private Player  player;
	[SerializeField] private GameObject PauseMenu;

	private Vector2 pausePosition;
	private Vector2 unPausePosition;
	private bool isPause=false;
	void Start () {
	
		pausePosition = new Vector2 (250.2f,370);
		unPausePosition = new Vector2 (-250.2f, 370);
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
			PauseMenu.transform.position = pausePosition;

		} else if(Time.timeScale==0&&player.fuelAmount>0)
		{
			PauseMenu.transform.position = unPausePosition;
			isPause = false;
			Time.timeScale = 1;
		
		}
		print ("mouse");

			
	
	}

}
