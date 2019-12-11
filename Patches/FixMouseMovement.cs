using Harmony;
using UnityEngine;

namespace MouseFix {
	public partial class Main {
		[HarmonyPatch(typeof(Cursor3D))]
		[HarmonyPatch("MouseMove")]
		private class FixMouseMovement {
			[HarmonyPrefix]
			public static bool Prefix(ref Vector2 ___screenPos, ref RectTransform ___Cursor) {
				___screenPos.x = Input.mousePosition.x;
				___screenPos.y = Input.mousePosition.y;
				___Cursor.transform.position = ___screenPos;
				return false;
			}
		}
	}
}