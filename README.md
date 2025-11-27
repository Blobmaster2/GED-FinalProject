# Bloodbound Survivors

## Team

| Name | Student ID |
| :-: | :-: |
| Scott | 100826964 |
| Udey | 100918410 |
| Sidharth | 100938544 |

## About

A 2D top-down vampire-suvivors like game with highly optimized code (using design patterns).

## Singleton

- Game Manager

Flowchart - https://github.com/Blobmaster2/GED-FinalProject/blob/main/Singleton.png

- Upgrade System

This system can be accessed fully in the editor only, and allows developers to create new upgrades for cards. 
It is a single instance that has a static reference, and it is implemented heavily into the DLL for reading and writing JSON, as well as applying the actual upgrade to the player.

- PowerupController

This system is a singleton that keeps track of how many powerups are on the field, and which ones are active on the player. 
It has a static reference that is used to apply the powerup's effect via command (more later).

GameManager gets and sets player level, score and position for other objects to reference

- Audio Manager (you can find the chart below at Audio System)

## Command

- Save command

Flowchart - https://github.com/user-attachments/assets/d7a183e4-ebf4-45d0-b505-6f9fc67b2ffc  

Save command that will save the score from a run to a JSON file.  
Delete Command that will delete the JSON file containing the score information.

- Powerup system

When a powerup is collected, it creates a command for the PowerupController to store in a List, and the PowerupController sends Execute() to the powerup. 
When the powerup wears off, it sends an Undo() command to the powerup, and the powerup removes the effect and deletes itself.

## Factory

- Enemy Factory

Flowchart - https://github.com/Blobmaster2/GED-FinalProject/blob/main/Factory.png

EnemyFactory adds a layer of abstraction between Wavespawner spawning the enemies and instantiating the actual enemies into the game thereby making it easier to make changes to the enemies easier.

- Bullet Factory

The bullet factory can create different types of bullets, and has a generic SpawnBullet<T> method that a bullet type can be passed through. 
It spawns bullets for players, and has the capability to spawn bullets for enemies.

- PowerupController

This Controller is responsible for spawning the powerups and assigning the effect to them. 
There is a 40% chance every 4 seconds to spawn a powerup, and when it does so, it also assigns a random effect to the powerup, and customizes the base prefab accordingly.
This allows for expanability later on, as it is very simple to add new powerup types.

## Observer

- IObserver (AudioPlayerS) and Subject (Player and PlayerStats) (you can find the chart below at Audio System)
- The enemies send a signel to the spawner once they die using an event. The spawner listens for this event, instead of constantly checking for the status of the enemies.

## State

- When a player collects a powerup, it puts them in a 'powerup state', which ends when all powerups wear off.

This gives the player feedback about whether a powerup is active or not.

## Object Pooling

- Player bullets are pooled, if more are spawned than the allowed amount (100), the oldest bullet will disappear.
- Powerups are also pooled, if more are spawned than the allowed amount (10), the oldest powerup will disappear.
- Enemies are pooled, instead of consentantly deleteing and respawning new enemies, we turn of the killed enemies and relocate them before turning them back on. 

## Plugin/DLL

- Upgrade Manager

Flowchart - https://docs.google.com/drawings/d/1J04ZUH5q1G4yRHJqfaaR1oAhecq0elV_uP503-wuRh4/edit  

Upgrade Manager that is in charge of picking random upgrades from a JSON file.  
Also supports writing to JSON in the correct format.

## Audio System

Flowchart - https://github.com/Blobmaster2/GED-FinalProject/blob/main/Audio%20Systems.pdf

The audio system is a hybrid of command, singleton and observer patterns combined. This system includes an AudioManager singleton, IObserver which is inherited by AudioPlayerS which also acts like it's a command pattern (the logic for playing the audio through AudioManager is simplified and modularised through AudioPlayerS) and Subject which is inherited by Player class and PlayerStats class. Player class notifies its observers about player shooting bullets while PlayerStats notifies about the player getting hurt. 

### References used for Audio System

- Observer - https://www.youtube.com/watch
- Audio files generated using `sfxr` - https://www.drpetter.se/project_sfxr.html

## Video Report

Progress check video - https://youtu.be/t4EYMOf4jNM

## Presentation

https://docs.google.com/presentation/d/1CAnIlv9s_S9XTEkxA7LymCoS1-PaGjN4dShnk40YMrs/edit?usp=sharing
