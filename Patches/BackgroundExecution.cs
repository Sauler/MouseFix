using Harmony;
using UnityEngine;

namespace MouseFix {
	public partial class Main {
		[HarmonyPatch(typeof(GameInit))]
		[HarmonyPatch("Awake")]
		private class BackgroundExecution {
			[HarmonyPrefix]
			public static void Prefix() {
				Application.runInBackground = true;
			} 
		}
	}
}