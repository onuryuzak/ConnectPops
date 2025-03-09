# ConnectPops

A Unity-based puzzle game where players connect matching pops on a game grid to merge and collect them.

https://github.com/onuryuzak/ConnectPops/assets/9118702/379694df-c467-4602-ade1-e2113e62c6a6

## Project Overview

ConnectPops is a match-three style puzzle game built in Unity where players connect matching pop items on a grid. The game features a line-drawing mechanic that allows players to create connections between similar pops, merging them to create higher-level pops.

## Game Features

- Line-drawing connection mechanic
- Matching and merging pops
- Grid-based gameplay
- Progression through levels by creating higher-level pops

## Project Structure

The project follows a well-organized structure with clear separation of concerns:

### Core Components

- **Assets/ConnectThePops/Scripts/Core/**: Contains fundamental game systems
  - `GameManager.cs`: Main game controller that initializes and runs the game
  - `GameModeBase.cs`: Abstract base class for defining game modes
  - `SingletonBehaviour.cs`: Implementation of the Singleton pattern for managers
  - **Game Grid/**: Core grid system implementation
  - **Input/**: Input handling systems
  - **Managers/**: Game system managers
  - **State/**: State management system
  - **Utilities/**: Helper functions and utility classes

### Game Components

- **Assets/ConnectThePops/Scripts/Game/**: Contains gameplay-specific systems
  - **Game Board/**: Implementation of the game board and grid
    - `GameBoard.cs`: Manages the game grid and tile spawning
    - `GameBoardMovement.cs`: Handles tile movement on the board
  - **Game Mode/**: Contains specific game mode implementations
    - `GameMode.cs`: Primary game mode implementation with game loop logic
  - **Game Tile/**: Tile-related systems and implementations
    - `GameTile.cs`: Base class for game tiles
    - `GameTileManager.cs`: Manages tile instances and lifecycle
  - **Selection/**: Player selection and line-drawing systems
  - **States/**: Game state implementations
  - **UI/**: Game UI components
  - **Validators/**: Logic for validating player moves and connections

### Resources and Assets

- **Assets/ConnectThePops/Prefabs/**: Game object prefabs
- **Assets/ConnectThePops/Textures/**: Game textures and sprites
- **Assets/ConnectThePops/Fonts/**: Text fonts
- **Assets/ConnectThePops/Scenes/**: Game scenes

## Architecture

The game uses a component-based architecture with the following key patterns:

1. **Singleton Pattern**: Used for manager classes to ensure single instance access
2. **State Pattern**: For managing game state transitions
3. **Factory Pattern**: For creating game objects like tiles
4. **Command Pattern**: For handling user input and game actions

## How to Use

1. Open the project in Unity 2020.3 or newer
2. Navigate to Assets/ConnectThePops/Scenes/ and open the main game scene
3. Press Play to test the game in the Unity editor

## Development

To extend or modify the game:

- Add new tile types in the Game Tile directory
- Modify game rules in the Game Mode classes
- Adjust the board size in the GameBoard component

## Dependencies

- Unity 2020.3 or newer
- TextMesh Pro package (included)

