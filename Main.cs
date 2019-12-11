using System.Reflection;
using CMS.Mods;
using Harmony;

namespace MouseFix {
	public partial class Main : Mod {
		private HarmonyInstance harmonyInstance;

		public override void Activate() {
			harmonyInstance = HarmonyInstance.Create("com.sauler.cms.mousefix");
			harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
		}

		public override void Deactivate() {
			harmonyInstance.UnpatchAll();
		}

		public override ModInfo GetInfo() {
			return new ModInfo {
				Name = "MouseFix",
				Description = "Mouse improvements.",
				Author = "Rafał Babiarz",
				Version = "1.0.0"
			};
		}
	}
}