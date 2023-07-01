using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour {

	[SerializeField] private CustomMouseInput interactInput;
	[SerializeField] private float maxGrabDistance;
	[SerializeField] private float releaseForce;

	private Camera mainCamera;

	private ItemBase heldItem;

	// Start is called before the first frame update
	void Start() {
		mainCamera = Camera.main;
	}

	// Update is called once per frame
	void Update() {
		if (interactInput.IsButtonDown) {

			if (heldItem) {

				// Release Item
				heldItem.UseItem(this, releaseForce);

			} else {
				if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out RaycastHit hit, maxGrabDistance)) {

					// Pickup Item
					ItemBase newItem = hit.collider.GetComponentInParent<ItemBase>();
					if (newItem) {
						newItem.Interact(this);
					}
				}
			}
		}
	}

	public void HoldItem(ItemBase item) {
		if (item) {
			item.transform.SetParent(transform);
			item.transform.localPosition = Vector3.zero;
			item.transform.localRotation = Quaternion.identity;

			heldItem = item;
		}
	}

	public void ReleaseHeldItem() {
		if (heldItem) {
			heldItem.transform.SetParent(null);
			heldItem = null;
		}
	}

}
