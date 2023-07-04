using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coffee : BaseInteractable {

	[SerializeField] private new Rigidbody rigidbody;
	[SerializeField] private new Collider collider;
	[SerializeField] private int maxUses;

	[SerializeField] private UnityEvent OnCoffee;

	private int uses;

	private byte currentWarpLevel = 0;

	public override void Interact(HandController hand) {
		if (rigidbody) rigidbody.isKinematic = true;
		if (collider) collider.enabled = false;

		hand.HoldItem(this);
	}

	public override void UseItem(HandController hand, float force) {
		if (uses < maxUses) {
			OnCoffee.Invoke();

			currentWarpLevel++;
			if (currentWarpLevel > WarpHelper.MAX_WARP_LEVEL) currentWarpLevel = 0;

			SleepManager.Instance.SetSleep(0);
			WarpHelper.ActivateFullWarpLevel(currentWarpLevel);

			uses++;
		}

		if (uses >= maxUses) {
			hand.ReleaseHeldItem();

			if (collider) collider.enabled = true;

			if (rigidbody) {
				rigidbody.isKinematic = false;

				rigidbody.AddForce(transform.forward * force, ForceMode.Impulse);
			}
		}
	}
}
