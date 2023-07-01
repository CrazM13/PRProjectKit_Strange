using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WarpRendering : MonoBehaviour {

	[SerializeField] private Camera warpCamera;
	[SerializeField] private MeshRenderer meshRenderer;

	private RenderTexture renderTexture;
	private Warp warp;

	private void OnEnable() {
		//RenderPipelineManager.beginCameraRendering += UpdateCamera;

		warp = GetComponent<Warp>();

		renderTexture = RenderTexture.GetTemporary(Screen.width, Screen.height);

		meshRenderer.material.SetTexture("_MainTex", renderTexture);
	}

	private void OnDisable() {
		//RenderPipelineManager.beginCameraRendering -= UpdateCamera;
	}

	private void Update() {
		if (warp) {
			Warp partner = warp.Partner;

			if (partner) RenderWarp(partner, Camera.main);
		}
	}

	private void UpdateCamera(ScriptableRenderContext _, Camera camera) {
		if (warp) {
			Warp partner = warp.Partner;

			if (partner) RenderWarp(partner, camera);
		}
	}

	private void RenderWarp(Warp warpPartner, Camera camera) {
		warpCamera.projectionMatrix = camera.projectionMatrix;
		warpCamera.targetTexture = renderTexture;

		// Move To Location
		Vector3 relativePosition = transform.InverseTransformPoint(camera.transform.position);
		relativePosition = Vector3.Scale(relativePosition, new Vector3(-1, 1, -1));
		warpCamera.transform.position = warpPartner.transform.TransformPoint(relativePosition);

		// Set Rotation
		Vector3 relativeRotation = transform.InverseTransformDirection(camera.transform.forward);
		relativeRotation = Vector3.Scale(relativeRotation, new Vector3(-1, 1, -1));
		warpCamera.transform.forward = warpPartner.transform.TransformDirection(relativeRotation);
	}


}
