using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepManager {

	private static SleepManager instance;
	public static SleepManager Instance {
		get {
			if (instance == null) instance = new SleepManager();

			return instance;
		}
	}
	private SleepManager() {}

	public float Value { get; private set; }

	public void AddSleep(float value) {
		Value += value;
	}

	public void RemoveSleep(float value) {
		Value -= value;
	}

	public void SetSleep(float value) {
		Value = value;
	}
	
}
