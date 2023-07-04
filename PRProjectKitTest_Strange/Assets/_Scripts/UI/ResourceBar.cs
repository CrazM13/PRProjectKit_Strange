using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ResourceBar : MonoBehaviour {

	[SerializeField] private Image fill;

	public float ResourcePercentage {
		get => fill.fillAmount;
		set => fill.fillAmount = value;
	}
	
}
