using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

	// Use this for initialization

	public GameObject[] Prefabs=new GameObject[5];
	private PlayerController playercontroller;

	private float timer=6f;
	float initPlanetTimeGap=5f;




	void Start () {
		
//		playercontroller = GameObject.Find ("PlayerController");
	
	}
	
	// Update is called once per frame
	void Update () {

		makePlanet ();


	}


	void makePlanet(){
		
		timer -= Time.deltaTime;

//		print ("timer" + timer);
		if (timer <0) {
		
			Instantiate (this.Prefabs[Random.Range(0,5)]);
			if (initPlanetTimeGap > 2)
				initPlanetTimeGap *=0.99f;
			else
				initPlanetTimeGap =2;
			timer = initPlanetTimeGap;

//			print (initPlanetTimeGap);
//			print ("intitimeGAP"+initPlanetTimeGap);
		}
	
	}
}
