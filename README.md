# Puzzle-Tag


Unity Top-Down Strategy Game (URP Desktop)


✅ keyboard input to move player

✅ Inventory with item usage

✅ Player vs. Enemy logic with patrol and chase

✅ Level management with prefabs

✅ Modular, event-driven architecture

Built for Unity 6000.0.51f1 LTS using the Universal Render Pipeline (URP) targeting desktop platforms.

🚀 Features

🔁 Game Loop

Start menu UI and GameManager

Modular LevelManager with prefab support

Level complete + auto-load next stage

👤 Player

Top-down control (WASD)

Walk/run toggle (Left Shift)

Smooth camera follow

Damage & health logic

Interacts with inventory system

🎒 Inventory

Collectable ScriptableObject items

Auto-stacking by type

UI with icons, quantities, and hover tooltips

Button to use healing potion (expandable)

👹 Enemy System

Inherit from EnemyBase to create new enemy types

Built-in patrol, chase, attack behavior

Health bar UI (slider above enemy)

🧠 Architecture

Fully modular and event-driven

EventSystem.cs for global events (health, level, inventory)

GameManager and LevelManager manage states and references

Separation of UI, gameplay logic, and input


🛠 How to Use

🔧 Setup

Open in Unity 6000.0.51f1 LTS 

Import URP and configure project for URP

Ensure all prefabs and references are assigned in the inspector (LevelManager, UIManager, etc.)

▶️ Controls

Move

WASD / Arrow Keys

Run

Left Shift

Open Inventory UI

I

Start Game

Button on UI

📦 Extendability

Add new items via ScriptableObjects

Extend EnemyBase to make new enemy types

Add new levels as prefabs with Level.cs script

Use events (EventSystem) to hook up custom game logic (cutscenes, checkpoints, etc.)

🧪 Known Limitations

No click-to-move yet (but structure supports adding it)

Scene loading is instant (no fade/loading screen)

Inventory system doesn’t persist across levels (yet)




