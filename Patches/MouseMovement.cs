using HarmonyLib;
using UnityEngine;

namespace MouseFix.Patches {
	[HarmonyPatch(typeof(Cursor3D))]
	[HarmonyPatch("MouseMove")]
	internal class MouseMovement {
		private static bool Prefix(ref Vector2 ___screenPos, ref RectTransform ___Cursor) {
			var gameScript = GameScript.Get();
			if (GameMode.Get().CompareWithCurrentMode(gameMode.UI) ||
			    gameScript != null && gameScript.CurrentSceneType == SceneType.Menu ||
			    gameScript.CurrentSceneType == SceneType.Showroom ||
			    gameScript.CurrentSceneType == SceneType.Auction) {
				___screenPos.x = Input.mousePosition.x;
				___screenPos.y = Input.mousePosition.y;
				___Cursor.transform.position = ___screenPos;
				return false;
			}

			return true;
		}
	}
}