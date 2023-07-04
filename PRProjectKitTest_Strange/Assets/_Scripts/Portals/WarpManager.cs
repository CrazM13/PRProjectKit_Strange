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

	public void ActivateWarpsByLevel(byte level, bool isActive = true) {
		foreach ((string _, Warp warp) in warps) {
			if (warp.IsLevel(level)) warp.IsWarpActive = isActive;
		}
	}

	public void ActivateWarpsByCode(byte level, byte code, bool isActive = true) {
		foreach ((string _, Warp warp) in warps) {
			if (warp.IsLevel(level) && warp.IsCode(code)) warp.IsWarpActive = isActive;
		}
	}

	public void ActivateWarpsByInstance(byte level, byte code, byte instance, bool isActive = true) {
		string checkKey = Warp.BytesToKey(level, code, instance);

		foreach ((string key, Warp warp) in warps) {
			if (key == checkKey) warp.IsWarpActive = isActive;
		}
	}


	public void ActivateWarp(string key, bool isActive = true) {

		if (warps.ContainsKey(key)) {
			warps[key].IsWarpActive = isActive;
		}

	}

	public Warp GetWarp(string key) {
		if (warps.ContainsKey(key)) return warps[key];

		return null;
	}



}
