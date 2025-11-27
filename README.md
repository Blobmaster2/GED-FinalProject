# Bloodbound Survivors

## Team

| Name | Student ID |
| :-: | :-: |
| Scott | 100826964 |
| Udey | 100918410 |
| Sidharth | 100938544 |

## About

About the game

## Singleton

- Game Manager

Flowchart - https://github.com/Blobmaster2/GED-FinalProject/blob/main/Singleton.png

GameManager gets and sets player level, score and position for other objects to reference

- Audio Manager (you can find the chart below at Audio System)

## Command

- Save command

Flowchart - https://github.com/user-attachments/assets/d7a183e4-ebf4-45d0-b505-6f9fc67b2ffc  

Save command that will save the score from a run to a JSON file.  
Delete Command that will delete the JSON file containing the score information.

## Factory

- Enemy Factory

Flowchart - https://github.com/Blobmaster2/GED-FinalProject/blob/main/Factory.png

EnemyFactory adds a layer of abstraction between Wavespawner spawning the enemies and instantiating the actual enemies into the game thereby making it easier to make changes to the enemies easier.

## Observer

- IObserver (AudioPlayerS) and Subject (Player and PlayerStats) (you can find the chart below at Audio System)

## Plugin/DLL

- Upgrade Manager

Flowchart - https://docs.google.com/drawings/d/1J04ZUH5q1G4yRHJqfaaR1oAhecq0elV_uP503-wuRh4/edit  

Upgrade Manager that is in charge of picking random upgrades from a JSON file.  
Also supports writing to JSON in the correct format.

## Audio System

Flowchart - https://github.com/Blobmaster2/GED-FinalProject/blob/main/Audio%20Systems.pdf

The audio system is a hybrid of command, singleton and observer patterns combined. This system includes an AudioManager singleton, IObserver which is inherited by AudioPlayerS which also acts like it's a command pattern (the logic for playing the audio through AudioManager is simplified and modularised through AudioPlayerS) and Subject which is inherited by Player class and PlayerStats class. Player class notifies its observers about player shooting bullets while PlayerStats notifies about the player getting hurt. 

### References used for Audio System

Observer - https://www.youtube.com/watch
Audio files generated using `sfxr` - https://www.drpetter.se/project_sfxr.html

## Video Report

https://youtu.be/t4EYMOf4jNM

## Presentaion

https://docs.google.com/presentation/d/1CAnIlv9s_S9XTEkxA7LymCoS1-PaGjN4dShnk40YMrs/edit?usp=sharing
