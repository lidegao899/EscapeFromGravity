using UnityEngine;
using System.Collections;

public class CamControler : MonoBehaviour {


	[SerializeField] private GameObject player;
	private Vector3 initPosition;
	private Vector3 playerinitPosition;

	public float run_speed=2f;


	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		playerinitPosition = player.transform.position;
		initPosition = this.transform.position;
		print (initPosition.z);


		Vector3 vector=  this.GetComponent<Rigidbody> ().velocity;
		this.GetComponent<Rigidbody> ().velocity =player.GetComponent<Rigidbody> ().velocity;


	}
	
	// Update is called once per frame
	void LateUpdate () {

		this.GetComponent<Rigidbody> ().velocity =player.GetComponent<Rigidbody> ().velocity;
		//Vector3 vector = player.transform.position;
		//vector.y= player.transform.position.y-playerinitPosition.y;

		//2D向量会导致坐标扁平化，出现坐标错误
		//Vector3 moveVector = initPosition;
		//moveVector.y = initPosition.y + vector.y;
		//this.transform.position=moveVector;

	}
}
