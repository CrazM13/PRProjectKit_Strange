using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLocking : MonoBehaviour {

	[SerializeField] private bool startLocked;
	[SerializeField] private bool unlockOnDestroy;

	// Start is called before the first frame update
	void Start() {
		if (startLocked) Cursor.lockState = CursorLockMode.Locked;
	}

	private void OnDestroy() {
		if (unlockOnDestroy) Cursor.lockState = CursorLockMode.None;
	}

}
