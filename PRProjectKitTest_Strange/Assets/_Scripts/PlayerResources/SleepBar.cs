using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepBar : ResourceBar {

	private void Update() {
		float value = SleepManager.Instance.Value;

		value = Mathf.Clamp01(value);
		ResourcePercentage = value;
	}

}
