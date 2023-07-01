using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : ItemBase {

	[SerializeField] private ItemBase coffeePrefab;

	public override void Interact(HandController hand) {

		ItemBase newCoffee = Instantiate(coffeePrefab.gameObject).GetComponent<ItemBase>();

		newCoffee.Interact(hand);
	}

	public override void UseItem(HandController hand, float force) { /* MT */ }
}
