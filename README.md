# RiceGamesUnity
This is a sample project for Rice Games. The following are scripts incorporated into the sample game to demonstrate mechanics implemented. Character and environment sprites were taken from the Unity Asset Store ([Sunny Land](https://assetstore.unity.com/packages/2d/characters/sunny-land-103349))

The following are the three main scripts implemented into this sample project (can be found in "Assets" folder).

### CharacterController2D.cs
Free 2D controller script (provided [here](https://github.com/Brackeys/2D-Character-Controller)) to easily implement 2d player physics. All the crouch/jump detection were provided in cloned script, however, I did have to debug a specific line of code in regards to "jump" detection (marked by comment on line 57). 

Main feature added was the ability to pickup collectables. The OnTriggerEnter2D() function detect when two 2D colliders overlap one another, disabling the visiblility of the collectable item, effectively "picking it up". Future extensions of this function could invoke some other variable as a counter or storage as seen fit.

##### List of features (*italics* - cloned features):
* *movement*
* *jumping*
* *crouching*
* *trigger events (OnJump and OnCrouch)*
* pickup/collectables

### PlayerMovement.cs
Main script controlling all player movement and animations. This script uses the controller mentioned above to command the player's movement. This script also dictates the animations present on player sprite to accurately reflect what the player is doing (i.e. switches promptly to "player_idle" animation when not moving, "player_crouch" when 's' or 'down' is pressed, etc.). Also uses the OnLand() and OnCrouch() event triggers (that I had previously debugged, as mentioned before).

##### List of features:
* horizontal movement
* vertical movement (via jumping and crouching)
* sprite animation control

### FollowTarget.cs
Camera movement is controlled by this script, which allows the main camera to choose a target to follow. Added features include horizontal and vertical clamping, preventing the camera from viewing areas that the player is not intended to view (i.e. empty space below the map, "edge of the world" situations, etc.), as well as smoothing, which reduces harsh camera shakes caused by player movement.

##### List of features:
* target tracking for main camera
* horizontal/vertical clamping
* movement smoothing
