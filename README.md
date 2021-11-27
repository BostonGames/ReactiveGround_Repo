# Reactive Ground

-Add objects that will trail a moving object, such as the player, in a Snake-like fashion<br>
-Visualize and log what path/ground a moving object has traversed<br>
-Visualize, handle, and log when the same moving object has visited a path/ground more than once<br>
-Compatible with 2D and 3D movement tracking<br>

<b>These scripts are made for a 3D project, but can easily be modified for a 2D project as well. 
The object currently moves on the X and Z axis, but can be modified to incorporate Y movement as well by 
adjusting the size of the "tiles" collider that detect traversed areas. I used lists that contain data on the Traversed and Previously visited tiles 
so that data can be used for things like scoring.</b>

TODO:
-Optimize for heavy use / computations using ECS and Burst; can do this by finding the max size of the map/grid area to be traversed 
and/or calculating the highest number of entities (tiles, trailable objects, visited tiles, etc) that will be required and use object pooling (ECS) to improve performance.<br>
-Optimize how lists are used for multithreading

11/24/2021 : Initial Commit - full functionality for traversed path, revisited path, and trailing objects<br>
11/26/2021 : Redesigned the scripts for traversed path and visited path. Added procedurally generated grid ground and procedurally generated cosmetic ground trail effect. 

<i>I will be working on this some more over the weekend between my working hours : )
