using UnityEngine;
using System.Collections;

public class PositionManager : MonoBehaviour {

	[SerializeField] private GameObject[] MenuObject = new GameObject[4];

	[SerializeField] 	private Camera cam;
	[SerializeField]    private Canvas canvas;

	private int height;
	private int width;


	RectTransform rectTransform;
	Vector2 origenPosition;
	Vector2 posOfScreen;


	void Start () {

		height=Screen.height;
		width= Screen.width;
		foreach (GameObject menu in MenuObject)
			setPosition (menu);

	}
	
	// Update is called once per frame
	void Update () {

	}

	void setPosition(GameObject obj){
		print (obj.transform.ToString ());

		origenPosition = obj.transform.position;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (canvas.transform as RectTransform, origenPosition, canvas.worldCamera, out posOfScreen);
		rectTransform=obj.transform as RectTransform;
		rectTransform.anchoredPosition = posOfScreen;
	}
}
