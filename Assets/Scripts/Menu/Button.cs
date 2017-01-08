using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class Button : MonoBehaviour {

	[SerializeField]	private GameObject ConfirmMenu;
	[SerializeField]	private GameObject TargetMenu;
	void Start () {

		//ComfirmMenu = GameObject.Find ("ComfirmMenu");

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

			ConfirmMenu.transform.position = new Vector2 (250,375);
			print ("Confirm");

		}

		if (this.tag == "t_Help") {

			print ("t_Help");
			SceneManager.LoadScene (2);

		}

		if (this.tag == "Yes") {
			Time.timeScale = 1;
			SceneManager.LoadScene (0);


		}

		if (this.tag == "No") {

			print ("No");
			ConfirmMenu.transform.position = new Vector2 (800, 0);
			TargetMenu.transform.position=new Vector2 (250,375);
		}

		if (this.tag == "Exit_No") {

	
			ConfirmMenu.transform.position = new Vector2 (800, 0);

		}

		if (this.tag == "Exit_Yes") {


			Application.Quit();

		}
	}


}
