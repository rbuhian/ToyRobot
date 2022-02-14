# ToyRobot
Toy Robot simulation moving on table top.

Current features:
- Place the robot on table top with 5 units x 5 units dimension.
- Move the robot one unit at a time. 
- Rotate the robot left and right.
- Display the location and direction of the robot. 


Description:

The application is a simulation of a toy robot moving on a square table top, of dimensions 5 units x 5 units. There are no
other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction. 
Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.

Commands (not case sensitive):
 
- PLACE X,Y,F     
- MOVE
- LEFT
- RIGHT
- REPORT

PLACE will put the toy robot on the table in position X,Y and facing NORTH, SOUTH, EAST or WEST. The origin (0,0)
can be considered to be the SOUTH WEST most corner. It is required that the first command to the robot is a PLACE
command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The
application will discard all commands in the sequence until a valid PLACE command has been executed.
MOVE will move the toy robot one unit forward in the direction it is currently facing.
LEFT and RIGHT will rotate the robot 90 degrees in the specified direction without changing the position of the robot.
REPORT will announce the X,Y and F of the robot. This can be in any form, but standard output is sufficient.
A robot that is not on the table can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.

Example Input and Output:

a)----------------
- PLACE 0,0,NORTH
- MOVE
- REPORT
- Output: 0,1,NORTH

b)----------------
- PLACE 0,0,NORTH
- LEFT
- REPORT
- Output: 0,0,WEST

c)----------------
- PLACE 1,2,EAST
- MOVE
- MOVE
- LEFT
- MOVE
- REPORT
- Output: 3,3,NORTH


Requirements:

- Visual Studio 2019 and up
- .NET framework 5.0
- No 3rd party frameworks were used, so this program will compile and run if above requirements are fulfilled.
