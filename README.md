# Snake_3D

This is a classic snake game, where your task is to make the length of the snake as much as possible. It is necessary to eat as many "apples" as possible and not crash into your tail or wall.

This game is nothing more than a tick in my asset, as any self-respecting application developer should write something like a snake game.

## Therefore, the whole logic of the game lies in only 3 small scripts.
- SnakeHead.cs watches to see if the snake has eaten "apple" or crashed into something.
- SnakeControl.cs is responsible for the direction of movement and elongation of the snake. (keys controls A -> left, B -> rigth)
- GameManager.ss instantiate the "apple" in an arbitrary area on the map, display scores the game and dialog box if player lose.
