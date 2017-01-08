using UnityEngine;
using System.Collections;

public class SkyController : MonoBehaviour {

	// Use this for initialization
	public float WidthOfSky=20.0f;

	public Camera player;
	private Vector3 initPosition;
	private int NumOfSky=3;
	private float verlosity=0.2f;
	void Start () {

		initPosition = this.transform.position;

//		Vector3 vector = this.GetComponent<Rigidbody> ().velocity;
//		vector.z = -verlosity;
//		this.GetComponent<Rigidbody> ().velocity=vector;

	}
	
	// Update is called once per frame
	void Update () {

		float newPosition = Mathf.Repeat(Time.time * verlosity, 20);
		transform.position = initPosition + Vector3.back * newPosition;




	}
}
