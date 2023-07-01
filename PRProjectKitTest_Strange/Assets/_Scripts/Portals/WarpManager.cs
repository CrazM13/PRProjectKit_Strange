using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpManager {

	private static WarpManager instance;
	public static WarpManager Instance {
		get {
			if (instance == null) instance = new WarpManager();

			return instance;
		}
	}

	private Dictionary<string, Warp> warps;

	private WarpManager() {
		warps = new Dictionary<string, Warp>();
	}

	public void RegisterWarp(Warp warp) {
		if (!warps.TryAdd(warp.Key, warp)) {
			warps[warp.Key] = warp;
		}
	}


	public void ActivateWarps(string key) {

	}

	public Warp GetWarp(string key) {
		if (warps.ContainsKey(key)) return warps[key];

		return null;
	}



}
