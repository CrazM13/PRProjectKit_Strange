using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhastionDetector : MonoBehaviour {

	[SerializeField] private BaseCharacterController character;
	[SerializeField] private string timeChannel = "SleepTime";

	[SerializeField] private float baseExhastion;
	[SerializeField] private float movementExhastionModifier;
	[SerializeField] private float sprintExhastionModifier;

	private void Start() {
		if (!GameTime.DoesChannelExist(timeChannel)) {
			GameTime.RegisterChannel(timeChannel, "CharacterTime", 1);
		}
	}

	void Update() {
		float exhastion = baseExhastion;

		if (character.IsMoving) {
			exhastion *= movementExhastionModifier;
			if (character.GetMovementType() == BaseCharacterController.MovementType.Sprint) exhastion *= sprintExhastionModifier;
		}

		SleepManager.Instance.AddSleep(exhastion * GameTime.GetDeltaTime(timeChannel));

		if (SleepManager.Instance.Value >= 1) {
			// Lose
			ServiceLocator.SceneManager.LoadScene(ServiceLocator.SceneManager.GetCurrentSceneName());
			SleepManager.Instance.SetSleep(0);
		}
	}
}
