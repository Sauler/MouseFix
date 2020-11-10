using HarmonyLib;
using UnityEngine;

namespace MouseFix.Patches {
	[HarmonyPatch(typeof(IntroPlayer))]
	[HarmonyPatch("Awake")]
	internal class BackgroundExecution {
		private static void Prefix() {
			Application.runInBackground = true;
		}
	}
}