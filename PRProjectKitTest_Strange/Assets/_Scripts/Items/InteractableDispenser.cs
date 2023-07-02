using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDispenser : BaseInteractable {

	[SerializeField] private BaseInteractable interactablePrefab;

	public override void Interact(HandController hand) {

		BaseInteractable newCoffee = Instantiate(interactablePrefab.gameObject).GetComponent<BaseInteractable>();

		newCoffee.Interact(hand);
	}

	public override void UseItem(HandController hand, float force) { /* MT */ }
}
