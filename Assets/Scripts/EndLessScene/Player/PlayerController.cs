using UnityEngine;
using System.Collections;
using System;


public class PlayerController : MonoBehaviour {

	private float moveSpeed=0.025f;
	private float activeBurnSpeed=1f;
	private float moveBurnSpeed=1f;
	private float fly_speed=1;

	private float shellAcceleration=0.1f;
	private float passiveAcceleration=0.04f;
	private float activeAcceleration=0.3f;

	Player player;
	[SerializeField] private GameObject FailMenu;
	[SerializeField] private GameObject PauseButton;


	[SerializeField] private float WaitTimeForDeadMenu;

	[SerializeField] 	private Camera cam;
	[SerializeField]    private Canvas canvas;

	private int height;
	private int width;
	RectTransform rectTransform;
	Vector2 midOfScreen;

	private Vector2 mousePos;
	private Vector2 scrollPos;


	public enum playerStates
	{
		
		idle=0,
		left,
		right,
		up,
		down,

	}
		
	public delegate void playerStateHandler (PlayerController.playerStates newState);
	public static event playerStateHandler onStateChange;

//	public static event playerStateHandler onSpeedChange;


	void Start (){
		scrollPos = new Vector2 ();
		PauseButton = GameObject.Find ("PauseButton");

		GameObject tp = GameObject.Find ("Player");
		player = tp.GetComponent<Player> ();
		Player.liveStateChange += liveStateChange;
	
		height=Screen.currentResolution.height;
		width= Screen.currentResolution.width;
	}


	void OnEnable(){

		Player.liveStateChange += liveStateChange;

	}

	void OnDisable(){

		Player.liveStateChange -= liveStateChange;

	}


	// Update is called once per frame
	void Update () {

//		if (player != null) {
//			float moveHorizontal = Input.GetAxis ("Horizontal");
//			float moveVertical = Input.GetAxis ("Vertical");
//
//			if (moveHorizontal > 0) {
//				onStateChange (PlayerController.playerStates.right);
//			}
//			else if(moveHorizontal<0)
//				onStateChange (PlayerController.playerStates.left);
//
//
//
//			if(moveVertical>0)
//				onStateChange (PlayerController.playerStates.up);
//			else if(moveVertical<0)
//				onStateChange (PlayerController.playerStates.down);
//
////			if(moveHorizontal==0)
////				onStateChange (PlayerController.playerStates.idle);
//
//			if (Input.GetKey (KeyCode.F)) {
//				activeAccelerate ();
//				player.activeBrunFuel ();
//			}
//
//			
//			if(moveHorizontal==0)
//				onStateChange (PlayerController.playerStates.idle);
//
//			if (Input.GetMouseButton (1)) {
//				//暂时屏蔽
//				mousePos=Input.mousePosition;
//				print (mousePos.ToString ());
//				if (mousePos.x >100) {
//					onStateChange (PlayerController.playerStates.right);
//				}
//				else if(mousePos.x<100)
//					onStateChange (PlayerController.playerStates.left);
//
//
//
//				if(mousePos.y>100)
//					onStateChange (PlayerController.playerStates.up);
//				else if(mousePos.y<100)
//					onStateChange (PlayerController.playerStates.down);
//
//
//
//			}
//		}

		if (player != null) {

			if (scrollPos.x> 0) {
				onStateChange (PlayerController.playerStates.right);
//				print ("right");
			}
			else if(scrollPos.x<0)
				onStateChange (PlayerController.playerStates.left);



			if(scrollPos.y>0)
				onStateChange (PlayerController.playerStates.up);
			else if(scrollPos.y<0)
				onStateChange (PlayerController.playerStates.down);

			if(scrollPos.x==0)
				onStateChange (PlayerController.playerStates.idle);

		}
		passiveAccelerate ();
	}

	public void getScroll(Vector2 vec){
	
		scrollPos = vec;

	
	}

	public void getScroll(Vector3 vec){

		scrollPos.x = vec.x;
		scrollPos.y = vec.y;

	}

	public float getSpeed(){
	
		return fly_speed;

	}


	public void passiveAccelerate(){
		//print (run_speed);
		fly_speed+= Time.deltaTime * passiveAcceleration;
//		print("passive acc");
	}

//	public void activeAccelerate(){
//
//		fly_speed += Time.deltaTime * activeAcceleration;
//
//
//	}


	public	void shellAccelerate(){

		//print (run_speed);
		fly_speed += Time.deltaTime * shellAcceleration;
//		print("shell acc");
	}

	IEnumerator WaitForDeadMenu(){

		RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width*2,Screen.height*2), canvas.worldCamera, out midOfScreen);
		rectTransform=PauseButton.transform as RectTransform;

		rectTransform.anchoredPosition = midOfScreen;

		yield return new WaitForSeconds(2);
//		FailMenu.transform.position=new Vector2 (250f, 370);


		RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, new Vector2(Screen.width/2,Screen.height/2), canvas.worldCamera, out midOfScreen);
		rectTransform=FailMenu.transform as RectTransform;

		rectTransform.anchoredPosition = midOfScreen;





	}

	void liveStateChange(Player.liveStates newstage){


		if (newstage == Player.liveStates.dead) {
			Player.liveStateChange -= liveStateChange;
			print ("控制器知道死啦！");
//			Destroy (this.gameObject);

			StartCoroutine (WaitForDeadMenu ());
		}
	
	}


}
