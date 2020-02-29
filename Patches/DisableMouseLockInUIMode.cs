using Harmony;
using UnityEngine;

namespace MouseFix {
	public partial class Main {
		[HarmonyPatch(typeof(Cursor3D))]
		[HarmonyPatch("NormalCursorLock")]
		[HarmonyPatch(new[] {typeof(bool)})]
		private class DisableMouseLockInUIMode {
			[HarmonyPrefix]
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
}