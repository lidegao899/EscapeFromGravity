using UnityEngine;
using System.Collections;

public class Planet : MonoBehaviour {

	// Use this for initialization

	public Vector3 initPosition;
	public Vector3 initSpeed;
	public Camera camera;
	Vector3 rotaOfPlane;

	public AudioSource planetAudio=new AudioSource();
	public AudioClip passbyAudio;

	private bool isHit=false;
	private float planetSpeed=1f;



	private PlayerController pc;

	void Start () {

		GameObject tpc = GameObject.Find ("PlayerController");
		pc = tpc.GetComponent<PlayerController> ();

		camera = GameObject.Find ("Camera").GetComponent<Camera> ();
		Vector3 initPosition = camera.transform.position;

		initPosition = new Vector3 ((float)Random.Range (-3, +3), 1.5f,initPosition.z+7.24f);
		this.transform.position=initPosition;

		rotaOfPlane = new Vector3 ( 0,0,Random.value * 3f - 1.5f);
		planetAudio=GameObject.Find("PlanetSound").GetComponent<AudioSource> ();

		Vector3 vector = this.GetComponent<Rigidbody> ().velocity;
		vector.z = -pc.getSpeed();
		this.GetComponent<Rigidbody> ().velocity=vector;

//		Destroy (this.gameObject, 8);
	
	}

	public void makePassbySound(){
		if (!isHit) {
			
			print ("make sound");
			isHit = true;
		}

		if(!planetAudio.isPlaying) 
			planetAudio.PlayOneShot (passbyAudio, 0.5f);

	
	}

	void OnTriggerEnter(Collider collider){

		if (collider.tag == "Player") {
			makePassbySound ();
		}
			

	}
	void OnTriggerExit(Collider collider){

		if (collider.tag == "Boundry") {
			
			Destroy (this.gameObject);

		}
	}



	// Update is called once per frame
	void FixedUpdate () {
		
		this.transform.Rotate (rotaOfPlane);

		Vector3 vector = this.GetComponent<Rigidbody> ().velocity;
		vector.z = -pc.getSpeed();
		this.GetComponent<Rigidbody> ().velocity=vector;
//		print ("jasula");
	}


}
