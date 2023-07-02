using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractable : MonoBehaviour {

	public abstract void Interact(HandController hand);

	public abstract void UseItem(HandController hand, float force);

}
