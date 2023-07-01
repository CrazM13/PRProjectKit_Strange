using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {

	[SerializeField] private byte warpLevel;
	[SerializeField] private byte warpCode;
	[SerializeField] private byte warpInstance;

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

}
