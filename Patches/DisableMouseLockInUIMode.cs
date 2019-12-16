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
				if (!GameMode.Get().CompareWithCurrentMode(gameMode.UI) && GameScript.Get() && GameScript.Get().CurrentSceneType != SceneType.Menu)
					return false;

				Screen.lockCursor = false;
				if (isLocked) {
					Cursor.visible = false;
					return false;
				}
				Cursor.lockState = 0;
				return true;
			}
		}
	}
}