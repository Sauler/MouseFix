using BepInEx;
using HarmonyLib;
using MouseFix.Patches;

namespace MouseFix {
	
	[BepInPlugin("com.sauler.cms.mousefix", "MouseFix", "2.0.0.0")]
	[BepInProcess("cms2018.exe")]
	public class MouseFix : BaseUnityPlugin {
		#region Unity events
		private void Awake() {
			LoadConfig();
			Patch();
		}

		private void OnDestroy() {
			Unpatch();
		}
		#endregion

		#region Patching
		private Harmony harmonyInstance;
		private bool patched;
		
		private void Patch() {
			if (patched)
				return;
			
			harmonyInstance = new Harmony("com.sauler.cms.mousefix");
			PatchBackgroundExecution();
			PatchMouseMovementAndMouseLock();
			patched = true;
			Logger.LogInfo("Patching done!");
		}

		private void PatchBackgroundExecution() {
			if (Settings.backgroundExecution.Value) {
				harmonyInstance.PatchAll(typeof(BackgroundExecution));
				Logger.LogInfo("Applying BackgroundExecution patch");
			}
		}

		private void PatchMouseMovementAndMouseLock() {
			if (Settings.mouseEnhancements.Value) {
				harmonyInstance.PatchAll(typeof(MouseLock));
				harmonyInstance.PatchAll(typeof(MouseMovement));
				Logger.LogInfo("Applying MouseMovement and MouseLock patches");
			}
		}

		private void Unpatch() {
			if (!patched)
				return;
			
			harmonyInstance.UnpatchAll();
			patched = false;
		}
		#endregion

		#region Config
		private void LoadConfig() {
			Settings.backgroundExecution = Config.Bind("General", 
				"BackgroundExecution",
				true,
				"Enables or disables background execution.");

			Settings.mouseEnhancements = Config.Bind("General", 
				"MouseEnhancements",
				true,
				"Enables or disables mouse enhancements.\nCursor movement is fixed and cursor is not locked " +
						  "in game window when in UI mode");
		}
		#endregion
	}
}