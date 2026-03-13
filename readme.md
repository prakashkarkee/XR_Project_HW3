

# HW3 — Hands and Physics Game

**Student:** Prakash Karkee  
**Unity Version:** Unity 6.2.x (6000.2.9f1)  
**XR:** OpenXR + XR Interaction
**Headset Tested:** Meta Quest 3 (PC VR via Link)



---

## GitHub Repository

https://github.com/prakashkarkee/XR_Project_HW3
---

## Project Summary
This project is a VR hands-focused physics shooter mini-game. The player can grab a gun, start the game from a world-space UI, shoot spawned enemies, and earn score points. The scene is built using XR Interaction Toolkit Hands rig and OpenXR.

---

## Features Implemented

### 1) Custom Hands (Visual Customization)
- Customized the template hand visuals by applying a **custom “fire/lava” material** using the `Unity_Hand_Noise` shader.
- Adjusted main/edge/finger colors and noise parameters to create a lava effect.

### 2) Hand Colliders (Moving Parts)
- Added colliders to multiple hand parts (finger tips / bones) so hand interactions can be detected.
- Hand objects include kinematic rigidbodies to support trigger interactions.

### 3) Interactions (Hands + Physics Gameplay)
- **Grab Gun:** The gun is grabbable using XR interactions (hand/controller based on rig).
- **Shoot Projectiles:** When the game is started, pressing the trigger fires a projectile from the gun muzzle.
- **Enemy Hits + Score:** Projectiles hit enemies; enemies take damage and are destroyed, updating the score.
- **Enemy Spawning:** Enemies spawn from multiple spawn points during gameplay.
- **Enemy Movement:** Enemies can move (random roaming / movement script applied).

### 4) Objective and Game Flow
- **Start Game UI:** A world-space Start button begins the game:
  - enables enemy spawning
  - enables shooting (`gameStarted` flag)
  - hides the start menu
- **Goal:** Increase score by shooting enemies.

### 5) Effects
- Added particle effects (fire) to hands and configured them to appear during interactions (e.g., holding/grabbing the gun), depending on the setup in the scene.
- Gun muzzle includes shooting particle feedback.

---

## Controls
- **Grab / Hold gun:** Hand pinch / grab (depending on hand rig interaction)  
- **Shoot:** Controller Trigger (XRI Interaction / Activate) — enabled after Start Game  
- **Start Game:** World-space UI button (ray interaction)  
- **Exit Game:** Controller **B** button (if ExitOnB script is enabled/connected)

---

## How to Run (Windows Build)
1. Unzip the submission folder.
2. Run the executable: `HW3.exe` 
3. Ensure Quest 3 is connected via **Quest Link/Air Link** and OpenXR runtime is active.
4. Click **Start Game** to begin.

---

## Build Contents Included
- `.exe` file
- `_Data` folder
- `UnityPlayer.dll`
- `MonoBleedingEdge` folder
- Demo video(s)

---

## Notes / Special Instructions
- Shooting is controlled by Input System actions:
  - `XRI Right Interaction/Activate`
  - `XRI Left Interaction/Activate`
- Projectiles spawn with a forward offset from the muzzle and ignore collisions with the gun to avoid instant destruction.
- If hand visuals do not appear in the Windows build, the rig may default to controller visuals when controllers are active (template behavior).

---

## Demo Video(s)
[Watch the demo](./HW3_video.mp4)