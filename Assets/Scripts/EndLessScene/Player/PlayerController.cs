using UnityEngine;
using System.Collections;
using System;


public class PlayerController : MonoBehaviour {


	private float moveSpeed=0.025f;
	private float activeBurnSpeed=1f;
	private float moveBurnSpeed=1f;
	private float fly_speed=1;

	private float shellAcceleration=0.1f;
	private float passiveAcceleration=0.02f;
	private float activeAcceleration=0.3f;

	Player player;


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
		GameObject tp = GameObject.Find ("Player");
		player = tp.GetComponent<Player> ();
//		Player.liveStateChange += liveStateChange;
	
	}


	void OnEnable(){

		Player.liveStateChange += liveStateChange;

	}
	void OnDisable(){

		Player.liveStateChange -= liveStateChange;

	}


	// Update is called once per frame
	void Update () {

		if (player != null) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			if (moveHorizontal > 0) {
				onStateChange (PlayerController.playerStates.right);
			}
			else if(moveHorizontal<0)
				onStateChange (PlayerController.playerStates.left);



			if(moveVertical>0)
				onStateChange (PlayerController.playerStates.up);
			else if(moveVertical<0)
				onStateChange (PlayerController.playerStates.down);

			if(moveHorizontal==0)
				onStateChange (PlayerController.playerStates.idle);

			if (Input.GetKey (KeyCode.F)) {
				activeAccelerate ();
				player.activeBrunFuel ();
			}

			passiveAccelerate ();
		}


	}

	public float getSpeed(){
	
		return fly_speed;

	}


	public void passiveAccelerate(){
		//print (run_speed);
		fly_speed+= Time.deltaTime * passiveAcceleration;
//		print("passive acc");
	}

	public void activeAccelerate(){

		fly_speed += Time.deltaTime * activeAcceleration;

	}


	public	void shellAccelerate(){

		//print (run_speed);
		fly_speed += Time.deltaTime * shellAcceleration;
//		print("shell acc");
	}



	void liveStateChange(Player.liveStates newstage){


		if (newstage == Player.liveStates.dead) {
			Player.liveStateChange -= liveStateChange;
			print ("控制器知道死啦！");
//			Destroy (this.gameObject);
		
		}
	
	}


}
