using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	[Header("Warp Configuration")]
	[SerializeField] private byte warpLevel;
	[SerializeField] private byte warpCode;
	[SerializeField] private byte warpInstance;

	[Header("Warp Partner")]
	[SerializeField] private string partnerInstance;

	private void Start() {
		WarpManager.Instance.RegisterWarp(this);

		Debug.Log($"KEY: {Key}", gameObject);
	}

	public void SetPartnerKey(string warpKey) {
		partnerInstance = warpKey;
	}

	public string PartnerKey => $"LEVEL{warpLevel}:CODE{warpCode}:OBJ{partnerInstance}";
	public Warp Partner => WarpManager.Instance.GetWarp(PartnerKey);
	public string Key => $"LEVEL{warpLevel}:CODE{warpCode}:OBJ{warpInstance}";

	private void OnTriggerEnter(Collider other) {

		Vector3 enterDirection = other.transform.position - transform.position;
		float angle = Vector3.Angle(transform.forward, enterDirection);
		if (angle < 90) {
			WarpObject(other.transform.root);
		}

		//{
		//
		//	Rigidbody rigidbody = other.attachedRigidbody;
		//
		//	if (rigidbody && rigidbody.velocity.sqrMagnitude > 0) {
		//		float angle = Vector3.Angle(transform.forward, rigidbody.velocity);
		//		if (angle < 90) {
		//			WarpObject(other.transform);
		//		}
		//	}
		//}
	}

	private void WarpObject(Transform @object) {
		Warp partner = Partner;
		if (partner) {

			// Set Rotation
			Vector3 relativeRotation = transform.InverseTransformDirection(@object.forward);
			relativeRotation = Vector3.Scale(relativeRotation, new Vector3(-1, 1, -1));
			@object.forward = partner.transform.TransformDirection(relativeRotation);

			// Move To Location
			Vector3 relativePosition = transform.InverseTransformPoint(@object.position);
			relativePosition = Vector3.Scale(relativePosition, new Vector3(-1, 1, -1));
			@object.position = partner.transform.TransformPoint(relativePosition);


			// Set Vecolity
			Rigidbody rb = @object.GetComponent<Rigidbody>();
			if (rb) {
				Vector3 relativeVelocity = transform.InverseTransformDirection(rb.velocity);
				relativeVelocity = Vector3.Scale(relativeVelocity, new Vector3(-1, 1, -1));
				rb.velocity = partner.transform.TransformDirection(relativeVelocity);
			}
		}
	}

}
