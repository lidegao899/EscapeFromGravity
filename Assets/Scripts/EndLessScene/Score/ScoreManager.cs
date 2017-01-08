using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private Player player;
	[SerializeField ] private Text DistanceLabel;
	[SerializeField] private Image FuelImage;
	[SerializeField] private GameObject PauseMeun;
	[SerializeField ] private Text FailDistanceLabel;
	public Sprite[] Fuelimages=new Sprite[6];

	private float fuelAmount=0;
	private float distance=0;
	public Sprite mysprite;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		fuelAmount=player.fuelAmount;
		distance = player.flyDistance;
		DistanceLabel.text =""+(int)distance;
		FailDistanceLabel.text = DistanceLabel.text;
		int fuelNum =getFuelImageNum (fuelAmount);

		Sprite tempspr = Fuelimages [fuelNum];
		FuelImage.sprite =tempspr;
	}

	int getFuelImageNum(float fuelAmount){


		if (fuelAmount > 90f)
			return 5;
		else if (fuelAmount > 80f)
			return 4;
		else if (fuelAmount > 60f)
			return 3;
		else if (fuelAmount > 40f)
			return 2;
		else if (fuelAmount > 20f)
			return 1;
		else if (fuelAmount >= 0f)
			return 0;
		return 0;
	
	}


}
