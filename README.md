# BlockBurster

CSCI-526: Advanced Mobile Devices & Game Consoles

Overview -
This is a Word Puzzle Game where the player has to form the word given on the screen by shooting the blocks with letters using a laser beam with reflection.

Details - 
* Blocks of letters appear from the top in a linear fashion.
* Player is at the bottom with the following abilities -
  * Player has a laser beam which can be adjusted to point in any direction
  * Player can move left or right
  * Players can jump & hit the block (special case!)
* Player has to use the laser beam to hit the letters and form the given word.
* Player cannot directly aim the blocks. Reflector blocks/mirrors have to be used to reflect the laser beam at a particular angle to aim the block
* If the blocks of letters touch the user, game is over
* If the bottommost layer is quite close to the player, player can jump & hit the letter
* When a laser beam hits the target block, it is selected. If the laser beam hits the target block again, it gets deselected.


Tech Stack - 

* Unity Game Engine
* C#


