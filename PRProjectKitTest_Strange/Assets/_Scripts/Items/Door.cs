using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseInteractable {

	[SerializeField] private new Animator animation;
	[SerializeField] private new Collider collider;

	bool isOpen = false;

	public override void Interact(HandController hand) {
		isOpen = !isOpen;
		if (animation) animation.SetTrigger(isOpen ? "Open" : "Close");
		if (collider) collider.enabled = !isOpen;
	}

	public override void UseItem(HandController hand, float force) { /*MT*/ }
}
