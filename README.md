# Summer-is_Great Game

## Overview

This project is a card matching game developed using Unity 2021 LTS. The game features various card layouts, smooth animations, a save/load system, and a scoring mechanism with a combo system. It supports both desktop and mobile platforms (Android and iOS).

## Requirements

1. **Development Platform**: Unity 2021 LTS
2. **Card Layouts**: Various configurations such as 2x2, 3x3, 5x6, etc.
3. **Animations**: Smooth card flipping and matching animations.
4. **Save/Load System**: Persist game high score between sessions.
5. **Scoring Mechanism**: Basic scoring with a combo system.
6. **Sound Effects**: Basic sound effects for card interactions.
7. **Platform Support**: Desktop and mobile (Android, iOS).

## Implementation Details

### Project Setup

1. **Created a new Unity project** using Unity 2021 LTS.
2. **Scene Setup**:
   - Created two scenes: `0. MainMenu` and `1. Game`.
   - Added `0. MainMenu` and `1. Game` to the build settings.

### Scripts

#### _CardGameManager.cs

This script manages the core game logic, including setting up the game board, handling card interactions, saving/loading game high score, and updating the score.

- **Awake**: Initializes the game manager instance.
- **Start**: Sets the initial game state and attempts to load any saved game state.
- **PreloadCardImage**: Preloads card images to avoid lag during gameplay.
- **StartCardGame**: Starts a new game, sets up the game board, and initializes variables.
- **SetGamePanel**: Sets up the card positions and initializes the card list based on the selected game size.
- **ResetFace**: Resets all cards to their face-down position.
- **HideFace**: Coroutine to flip all cards after a short delay.
- **SpriteCardAllocation**: Allocates card sprites in pairs to the game board.
- **SetGameSize**: Updates the game size based on the slider input.
- **GetSprite**: Returns a sprite based on its ID.
- **CardBack**: Returns the card back sprite.
- **canClick**: Checks if a card click is allowed based on the game state.
- **cardClicked**: Handles card click events, checking for matches and updating the score.
- **CheckGameWin**: Checks if all cards have been matched to end the game.
- **EndGame**: Ends the current game and resets the game state.
- **GiveUp**: Ends the current game without saving the state.
- **DisplayInfo**: Toggles the display of additional game info.
- **Update**: Tracks elapsed time and updates the score and combo timer.

#### HighScore.cs

This script manages the high score functionality, saving the highest scores for different game sizes and displaying them.

- **HighScoreManager**: Singleton instance to manage high scores.
- **Awake**: Initializes the high score manager instance.
- **Start**: Loads the high score for the current game size.
- **LoadHighScores**: Loads high scores from PlayerPrefs.
- **SaveHighScores**: Saves high scores to PlayerPrefs.
- **UpdateHighScore**: Updates the high score if the current score is higher.
- **DisplayHighScore**: Displays the current high score.

#### MainMenu.cs

This script manages the main menu functionality, allowing the player to start the game or quit the application.

- **Play**: Loads the game scene to start a new game.
- **Quit**: Exits the application, handling both editor and build environments.

### Game Flow

1. **Main Menu**: The player can start a new game or quit the application.
2. **Game Scene**: The game board is set up based on the selected size. Cards are displayed and can be clicked to find matches. The game tracks score, including a combo system for consecutive matches within a short time.
3. **End Game**: The game ends when all cards are matched or the player gives up. The high score is updated and saved.
4. **Save/Load System**: The game high score is saved on exit and loaded on startup to allow resuming from where the player left off.

### Technical Considerations

- **Smooth Gameplay**: Ensured continuous card flipping without waiting for comparisons to finish, allowing for a smooth user experience.
- **Card Layouts**: Supported various layouts, dynamically scaling cards to fit the screen.
- **Animations**: Included smooth animations for card flipping and matching.
- **Save/Load System**: Used PlayerPrefs to persist game progress and high scores.
- **Scoring Mechanism**: Implemented a basic scoring system with additional points for combos.
- **Sound Effects**: Integrated basic sound effects for card interactions.
- **Platform Support**: Targeted both desktop and mobile platforms, ensuring the game ran smoothly on different devices.

### Conclusion

The card matching game developed using Unity 2021 LTS fulfilled all the specified requirements, providing a smooth and engaging gameplay experience across various platforms. The inclusion of a save/load system and a scoring mechanism with a combo system added depth and replayability to the game.
