using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class AccButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerExitHandler  {

	[SerializeField] private Player player;
	[SerializeField] private PlayerController pl;

	private bool isPress = false;

	public AudioClip AccAudio;
	public AudioSource AccAudioSource=new AudioSource();
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		
	}

	public void OnPointerUp (PointerEventData eventData){

		print ("OnPointerUp");

		isPress = false;
		player.getAccelerationCondition ();
	}



	public void OnPointerDown (PointerEventData eventData){

		isPress = true;

		player.getAccelerationCondition ();
		if (!AccAudioSource.isPlaying) {
			AccAudioSource.PlayOneShot (AccAudio, 0.5f);
			print ("make acc sound");
		}


	}

	public void OnPointerExit (PointerEventData eventData){

	}


}
