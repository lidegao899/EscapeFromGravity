using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;



public class HelpMenu : MonoBehaviour {

	private bool isPause = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.E)){


			SceneManager.LoadScene (0);
			print ("return to Main");
			print ("E");


		}

		if (Input.GetMouseButtonUp (0)) {
		
			SceneManager.LoadScene (0);

			print ("mouse up");
		}
	}

	void OnMouseUp(){



		SceneManager.LoadScene (0);
		print ("return to Main");
	
	}

	void OnMouseEnter(){
	
		Debug.Log ("mouse enter");
		print ("enter");
	}


	void OnMouseExit(){

		Debug.Log ("mouse exit");

	}




}
