using UnityEngine;
using System.Collections;
using UnityEngine.Events;

using UnityEngine.EventSystems;

public class MyScroll :MonoBehaviour , IDragHandler , IEndDragHandler , IBeginDragHandler{

	// Use this for initialization
	[System.Serializable]
	public class VirtualJoystickEvent : UnityEvent<Vector3>{}

	public Transform content;
	public UnityEvent beginControl;
	public VirtualJoystickEvent controlling;
	public UnityEvent endControl;

	public void OnBeginDrag(PointerEventData eventData){

		this.beginControl.Invoke();
	}

	public void OnDrag(PointerEventData eventData){

		if(this.content){

			this.controlling.Invoke(this.content.localPosition.normalized);
//			print (this.content.localPosition.normalized.ToString ());
		}

	}

	public void OnEndDrag(PointerEventData eventData){
		

		if(this.content){
			Vector3 vec = new Vector3 ();
			this.controlling.Invoke(vec);
			//			print (this.content.localPosition.normalized.ToString ());
		}
	}
}
