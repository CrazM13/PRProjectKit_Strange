using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalItem : ItemBase {

	[SerializeField] private new Rigidbody rigidbody;
	[SerializeField] private new Collider collider;

	public override void Interact(HandController hand) {
		if (rigidbody) rigidbody.isKinematic = true;
		if (collider) collider.enabled = false;

		hand.HoldItem(this);
	}

	public override void UseItem(HandController hand, float force) {
		hand.ReleaseHeldItem();

		if (collider) collider.enabled = true;

		if (rigidbody) {
			rigidbody.isKinematic = false;

			rigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
		}
	}
}
