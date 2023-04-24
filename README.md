# Rubik's cube tester
The solution has two CORE7 projects :-

	ConsoleApp - for running the project
	
	Rubik.Objects - the entities required to model a Rubik's cube and manipulate those entities
	

To run the project download/clone as preferred, make sure the ConsoleApp is set as StartUp project and press play.

To stop the project, press stop in Studio.

# User interface
The code returns a string of letters referring to the square colors on the cube.

This can be manipulated by a calling program in whatever ways required for the UI.

The color codes are returned in the order

Front, Right, Up, Back, Left, Down

then for each sides' squares

top left to bottom right.



# Tests
## For ConsoleApp
Create a new cube

GetDirection/GetFace

## For Rubik.Objects
Check rotations on all 6 sides in both directions

Check sequences of rotations

Check output string
