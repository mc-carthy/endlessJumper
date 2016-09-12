using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ButtonController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public void OnPointerDown (PointerEventData data) {
		if (PlayerController.instance != null) {
			PlayerController.instance.SetPower (true);
		}
	}

	public void OnPointerUp (PointerEventData data) {
		if (PlayerController.instance != null) {
			PlayerController.instance.SetPower (false);
		}
	}
}
