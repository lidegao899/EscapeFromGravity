using UnityEngine;
using System.Collections;

public class PlanetController : MonoBehaviour {

	// Use this for initialization

	public GameObject[] Prefabs=new GameObject[5];
	private PlayerController playercontroller;

	private float timer=0f;
	[SerializeField] float accelerateTime=0.97f;
	[SerializeField] float initPlanetTimeGap=3f;
	void Start () {
		
//		playercontroller = GameObject.Find ("PlayerController");
	
	}
	
	// Update is called once per frame
	void LateUpdate () {

		makePlanet ();


	}


	void makePlanet(){
		
		timer += Time.deltaTime;
		if (timer > 3) {
		
			Instantiate (this.Prefabs[Random.Range(0,5)]);
			timer = 0;
			initPlanetTimeGap = initPlanetTimeGap*0.97f;
//			print ("intitimeGAP"+(3f*0.97f));
//			print ("intitimeGAP"+initPlanetTimeGap);
		}
	
	}
}
