using HarmonyLib;
using UnityEngine;

namespace MouseFix {
	[HarmonyPatch(typeof(Cursor3D))]
	[HarmonyPatch("NormalCursorLock")]
	[HarmonyPatch(new[] {typeof(bool)})]
	internal class MouseLock {
		public static bool Prefix(bool isLocked) {
			var gameScript = GameScript.Get();
			if (GameMode.Get().CompareWithCurrentMode(gameMode.UI) ||
			    gameScript != null && gameScript.CurrentSceneType == SceneType.Menu ||
			    gameScript.CurrentSceneType == SceneType.Showroom ||
			    gameScript.CurrentSceneType == SceneType.Auction) {
				Screen.lockCursor = false;
				if (isLocked) {
					Cursor.visible = false;
					return false;
				}

				Cursor.lockState = 0;
				return false;
			}

			return true;
		}
	}
}