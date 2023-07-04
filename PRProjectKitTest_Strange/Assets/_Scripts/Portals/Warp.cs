using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	[Header("Warp Configuration")]
	[SerializeField] private byte warpLevel;
	[SerializeField] private byte warpCode;
	[SerializeField] private byte warpInstance;

	[Header("Warp Partner")]
	[SerializeField] private byte partnerInstance;

	[Header("Settings")]
	[SerializeField] private bool startActive;

	private bool isWarpActive = false;
	public bool IsWarpActive {
		get => isWarpActive;
		set {
			isWarpActive = value;

			// Activate/Deactivate
		}
	}

	private void Start() {
		WarpManager.Instance.RegisterWarp(this);

		if (startActive) IsWarpActive = true;
	}

	public void SetPartnerInstance(byte warpInstance) {
		partnerInstance = warpInstance;
	}

	public string PartnerKey => BytesToKey(warpLevel, warpCode, partnerInstance);
	public Warp Partner => WarpManager.Instance.GetWarp(PartnerKey);
	public string Key => BytesToKey(warpLevel, warpCode, warpInstance);

	private void OnTriggerEnter(Collider other) {
		if (isWarpActive) {
			Vector3 enterDirection = other.transform.position - transform.position;
			float angle = Vector3.Angle(transform.forward, enterDirection);
			if (angle < 90) {
				WarpObject(other.transform.root);
			}
		}
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

	public bool IsLevel(byte level) => level == this.warpLevel;
	public bool IsCode(byte code) => code == this.warpCode;
	public bool IsInstance(byte instance) => instance == this.warpInstance;

	public static string BytesToKey(byte level, byte code, byte instance) {
		return $"LEVEL{level}:CODE{code}:OBJ{instance}";
	}

}
