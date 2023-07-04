using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WarpHelper {

	public const byte MAX_WARP_LEVEL = 3;

	public static void DeactivateFullWarpLevel(byte level) {
		WarpManager.Instance.ActivateWarpsByLevel(level, false);
	}

	public static void ActivateFullWarpLevel(byte level) {
		for (byte i = 0; i <= MAX_WARP_LEVEL; i++) {
			if (i != level) DeactivateFullWarpLevel(i);
		}

		WarpManager.Instance.ActivateWarpsByLevel(level);
	}

}
