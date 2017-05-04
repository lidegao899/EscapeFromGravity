using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;


[System.Serializable]

public class Boundry{
	
	public	float Xmin,Xmax,Zmin,Zmax;

}


public class Player: MonoBehaviour {

	// Use this for initialization

	public float fuelAmount=100f;

	public float flyDistance=0f;



	private float StartTime;

	private bool isInShell=false;
	private bool isAccelerate = false;

	private float activeAccelerateSpeed=0.03f;
	private float fly_Speed;

	private float moveSpeed=0.03f;


	private float moveBurnSpeed=1.5f;
	private float activeBurnSpeed=10f;
	private float passiveBurnFuleSpeed=1.5f;
	public float shellAddFuelSpeed=0.03f;


	public Boundry boundry;

	public AudioSource music;
	public  AudioClip Crash;

	private Vector3 ScrollVec;




	//[SerializeField] static private Player player;


	//dead()  make a explosion
	public GameObject dead_Explosion;

	[SerializeField] private GameObject camer;

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
		shellAddFuelSpeed=1f;

		print (StartTime);
		StartTime=Time.time;
		flyDistance = 0;
		print (StartTime);
//		moveSpeed=0.02f;
		Time.timeScale = 1;

	}


	void Start () {
		


		GameObject pcontroller = GameObject.FindGameObjectWithTag ("PlayerController");
		playercontroller = pcontroller.GetComponent<PlayerController> ();

		playerAnimator = GetComponent<Animator> ();


		music.Play ();
//		this.GetComponent<Rigidbody> ().useGravity = false;


		ScrollVec = new Vector3 ();
	}


	public void getScroll(Vector2 vec){
		ScrollVec.x = vec.x;
		ScrollVec.z = vec.y;
		print ("ScrollVec" + ScrollVec.ToString ());
	}

	public void getScroll(Vector3 vec){

		ScrollVec.x = vec.x;
		ScrollVec.z = vec.y;
		print (vec.ToString ());

	}

	// Update is called once per frame
	void Update () {


		if (fuelAmount <= 0)
			dead ();

		addFlyDistance ();

		Vector3 vector = getPosition();

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");



		Vector3 moment = new Vector3 (moveHorizontal, 0,moveVertical);



		if (isAccelerate) {
		
			print ("acc");
			vector+=(moment+ScrollVec)*(moveSpeed+activeAccelerateSpeed);
			activeBrunFuel ();
		}
		else
			vector+=(moment+ScrollVec)*moveSpeed;

		//burn fuel when move
		//get in shell would not burn fuel
		if ((moment+ScrollVec).magnitude != 0&&!isInShell) {
			moveBrunFuel ();
		}


		if (isInShell)
			shellAddFuel ();
		else
			passiveBurnFule ();
//		print (fuelAmount);

		this.transform.position = vector;
		this.transform.position = new Vector3 (Mathf.Clamp (vector.x,boundry.Xmin,boundry.Xmax), vector.y, Mathf.Clamp (vector.z,boundry.Zmin, boundry.Zmax));


	
			
	}


	private void shellAddFuel(){


		fly_Speed= playercontroller.getSpeed ();


		fuelAmount += Time.deltaTime*shellAddFuelSpeed*fly_Speed;
//		print ("shelll add "+fuelAmount);
	}
		
	public void activeBrunFuel(){

		fuelAmount -= Time.deltaTime*activeBurnSpeed;
		print ("active burn fuel");
	
	}
		
	private void moveBrunFuel(){

		fuelAmount -= Time.deltaTime*moveBurnSpeed;
//		print (fuelAmount);

	}

	private void passiveBurnFule(){

		fuelAmount -= Time.deltaTime*passiveBurnFuleSpeed;
//		print ("passive burn" + fuelAmount);
	}

	IEnumerator kkkk(){
		print("死啦1");
		yield return new WaitForSeconds (3);
		print("死啦2");
	
	}

	void dead(){
		
		liveStateChange (Player.liveStates.dead);
		Instantiate (dead_Explosion, this.transform.position,this.transform.rotation);



		fuelAmount = 0f;
//		Time.timeScale=0f;

		if (music.isPlaying) {
		
			music.Stop ();
			music.PlayOneShot (Crash);
			//print ("播放音频");
		
		}

		Destroy (this.gameObject);

	}

	Vector3 getPosition(){
	
		return this.transform.position;
	
	}


	public void getAccelerationCondition(){
	
		isAccelerate =!isAccelerate;
	
	}


	void OnCollisionEnter(Collision collision){

		print ("碰撞啦");
		dead ();
	}



	void OnTriggerEnter(Collider collider){


		if (collider.tag == "Planet") {
			print("进入引力场");
			isInShell = true;
//			print ("start add fuel" + fuelAmount);
		}

	
	}

	void OnTriggerStay(Collider collider){
				
	}


	void OnTriggerExit(Collider collider){

		if (collider.tag == "Planet") {
			print("出引力场");
			isInShell = false;print ("end add fuel" + fuelAmount);

		}
			
	}

	public void addFlyDistance(){

		flyDistance += Time.deltaTime * playercontroller.getSpeed ();

	}



}
