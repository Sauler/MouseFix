# MouseFix
Mod that fixes mouse behaviour in Car Mechanic Simulator 2018. 

### Features:
- Game can run in the background
- Mouse lock is disabled in UI mode
- Removed cursor movement smoothing. Game cursor position is the same as system cursor position (still can be inaccurate on low fps)

### How to use
1. Install [BepInEx](https://bepinex.github.io/bepinex_docs/master/articles/user_guide/installation/index.html#installing-bepinex-1) if you don't have it already (use x64 version).
2. Download the latest build from the [Releases](https://github.com/Sauler/MouseFix/releases/latest) page.
3. Copy MouseFix.dll file into ```BepInEx\plugins``` folder in game directory.
4. Done!

### Configuration file
Config file can be found at ```BepInEx\config\com.sauler.cms.mousefix.cfg``` in game directory.

| Setting             | Default value |               Description                |
| :------------------ |:------------- | :--------------------------------------- |
| BackgroundExecution | true          | Enables or disables background execution. |
| MouseEnhancements   | true          | Enables or disables mouse enhancements.<br> Cursor movement is fixed and cursor is not locked in game window when in UI mode   |
