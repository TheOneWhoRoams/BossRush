BossRush

A 3D Action-RPG boss-fight framework and visual rule-builder built in Unity (C#). Designed to connect backend combat systems with a non-technical front-end UI, this project also serves as a live educational software deployment for a 7th-grade English (CLIL) "QA Studio" module (Module E/47).

Overview

Instead of writing raw code, users assemble real-time boss AI behavior using structured English dropdown menus mapped to core grammar targets (First Conditionals, Imperatives, and Comparatives).

To prevent impossible, zero-recovery attack loops, every custom boss must pass a real-time Validation Run—creators must defeat their own boss using Action-RPG combat mechanics (dodge-rolls, stamina management, and timing windows) before peers playtest the encounter and submit structured English bug reports.

Core Design Goals (Implementation TBD)

UI-to-Logic Translation: A modular interface that converts English dropdown selections into executable boss behaviors, allowing new conditions and actions to be added cleanly over time.

Readable Combat: Tight, responsive real-time combat focused on clear visual telegraphs, fair punish windows, and precise hitboxes.

Streamlined Asset Pipeline: Focusing on non-humanoid/abstract designs and lightweight geometry to avoid heavy manual animation bottlenecks and keep development centered on systems design and UX.

Roadmap

Phase 1 — Vertical Slice (In Progress): Build a single complete boss archetype to prove the full end-to-end pipeline (English UI Builder -> Combat Execution -> Real-Time Validation -> Peer Bug Report).

Phase 2 — Expansion (Planned): Add additional boss archetypes with distinct mechanics and combat loops as time permits.

Deployment Context

Target Environment: Built to run smoothly on standard public school lab PCs (scheduled for live deployment in January 2027).

Live UX Testing: Designed to survive real-world playtesting by middle-school users, prioritizing clear UI feedback and crash-resistant input handling.

Tech Stack & Setup

Engine: Unity [6.6]

Language: C#

Version Control: Git

Getting Started

Clone the repository:

git clone https://github.com/your-username/BossRush.git


Open the project folder via Unity Hub.

(Setup and scene details TBD.)

Status & Media

Currently in initial setup and architecture planning. Grey-box combat clips, flowcharts, and classroom QA documentation will be added as the vertical slice progresses.
