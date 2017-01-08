using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System;


[System.Serializable]

public class Boundry{
	
	public	float Xmin,Xmax,Zmin,Zmax;

}


public class Player: MonoBehaviour {

	// Use this for initialization

	public float fuelAmount=100f;
	public float fly_speed=1f;
	public float flyDistance=0f;

	private float StartTime;

	private bool isInShell=false;

	private float shellAcceleration=0.1f;
	private float passiveAcceleration=0.02f;
	private float activeAcceleration=0.3f;

	private float moveSpeed=0.04f;
	private float activeBurnSpeed=1f;
	private float moveBurnSpeed=1f;

	public Boundry boundry;

	public AudioSource music;
	public  AudioClip Crash;




	//[SerializeField] static private Player player;


	//dead()  make a explosion
	public GameObject dead_Explosion;

	[SerializeField] private GameObject camer;
	[SerializeField] private GameObject FailMenu;





	private Animator playerAnimator;

	private PlayerController playercontroller;

	//设置player监听对象
	public enum liveStates{

		Idle=0,
		dead,
		pause,

	}
	public delegate void liveStateHandler (Player.liveStates newState);
	public static event  liveStateHandler liveStateChange;

	private PlayerController.playerStates currentState=PlayerController.playerStates.idle;




	void OnEnable(){
	
		PlayerController.onStateChange += onStateChange;
	
	}
	void OnDisable(){
		print ("取消监听");
		PlayerController.onStateChange -= onStateChange;
	
	}




	public void onStateChange(PlayerController.playerStates newState){


		if (newState == currentState)
					return;
		currentState=newState;

		switch (currentState) {

		case PlayerController.playerStates.idle:
			playerAnimator.SetInteger ("State", 0);
			break;

		case PlayerController.playerStates.up:

		
			break;
		case PlayerController.playerStates.down:


			break;

		case PlayerController.playerStates.left:
			playerAnimator.SetInteger ("State", -1);
			break;
		case PlayerController.playerStates.right:
			playerAnimator.SetInteger ("State", 1);
			break;
		}




	}

	public void Init(){
		print ("init");
		fuelAmount=100f;
		fly_speed=1f;

		print (StartTime);
		StartTime=Time.time;
		flyDistance = 0;
		print (StartTime);
//		moveSpeed=0.02f;
		Time.timeScale = 1;
		FailMenu.transform.position=new Vector2 (500f, 300);
	}


	void Start () {
		GameObject pcontroller = GameObject.FindGameObjectWithTag ("PlayerController");
		playercontroller = pcontroller.GetComponent<PlayerController> ();
//		playercontroller.g
		//获取自身的组件这么简单吗？？？
		playerAnimator = GetComponent<Animator> ();


		music.Play ();
		this.GetComponent<Rigidbody> ().useGravity = false;
		Vector3 vector = this.GetComponent<Rigidbody> ().velocity;
		vector.z = fly_speed;
//		this.GetComponent<Rigidbody> ().velocity = vector;

	
	}

	void FixedUpdate(){
		
//		print ("dedaosudu"+playercontroller.getSpeed ());
//		print("平滑移动啦"+Input.GetAxis("Horizontal"));
		Vector3 vector = getPosition();

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 moment = new Vector3 (moveHorizontal, 0,moveVertical);

		vector+=moment*moveSpeed;
		this.transform.position = vector;
		this.transform.position = new Vector3 (Mathf.Clamp (vector.x,boundry.Xmin,boundry.Xmax), vector.y, Mathf.Clamp (vector.z,boundry.Zmin, boundry.Zmax));
		moveBrunFuel ();

		if (Input.GetKey (KeyCode.R)) {

			//提前初始化；

			Init ();
			SceneManager.LoadScene (1);

		}

	}


	// Update is called once per frame
	void Update () {



		//有命才能动,死后可以空格续命,不断加速 
		if (isAlive ()) {

			addFlyDistance ();
//			passiveAccelerate ();

//			playercontroller.passiveAccelerate ();
//			if (isInShell) {
//			
////				shellAddFuel ();
////				shellAccelerate ();
//
//				
//			}
				
		
		} else {
			
			print ("deadd");
			liveStateChange (Player.liveStates.dead);

		}
			


	}


	private void shellAddFuel(){

		fuelAmount += Time.deltaTime*fly_speed*0.1f;

	}





	public void activeBrunFuel(){

		fuelAmount -= Time.deltaTime*activeBurnSpeed;
	
	}

	private void moveBrunFuel(){

		fuelAmount -= Time.deltaTime*moveBurnSpeed;


	}

	void dead(){
		
		//liveStateChange (PlayerScript.liveStates.dead);
		//GameState(this,EventArgs.Empty);

		Instantiate (dead_Explosion, this.transform.position,this.transform.rotation);



		fly_speed = 0f;
		fuelAmount = 0f;
//		Time.timeScale=0f;

		if (music.isPlaying) {
		
			music.Stop ();
			music.PlayOneShot (Crash);
			//print ("播放音频");
		
		}

		FailMenu.transform.position=new Vector2 (250f, 370);

		Destroy (this.gameObject);

	}

	Vector3 getPosition(){
	
		return this.transform.position;
	
	}


	void OnCollisionEnter(Collision collision){

		print ("碰撞啦");

		//fuelAmount = -1;


//		OnDisable ();
//		OnDisable();
		dead ();
		liveStateChange (Player.liveStates.dead);

	}




	void OnTriggerStay(Collider collider){

		//shellAccelerate ();

//		print("player保持引力场");


		playercontroller.shellAccelerate();

		shellAddFuel ();
	}


	void OnTriggerExit(Collider collider){

		isInShell = false;

	}


	private void addFuel(){

		if (Input.GetKey (KeyCode.Space)&&!isAlive ()) {

			Time.timeScale = 1;
			fuelAmount += 10;
			print ("back to live");

		} 

	}
		
	public bool isAlive(){
	
		return fuelAmount >0;
	
	}

	public void addFlyDistance(){

		flyDistance += Time.deltaTime * playercontroller.getSpeed ();

	}



}
