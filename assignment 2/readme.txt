Names and StudentIDs
Gerwin de Kruijf - 5933439
Ilhan Kalkan - 5893348				

Application Class
This class was useless to us, because we have everything in the game class. 
The render method, FOV and keyboard input are in the game class (our application class). 

Extra instructions
The FOV int is in the game class, its max is 179. It causes the screen to look very small obviously, but it works ;)

Bonus exercises 
We haven't implemented bonus exercises 

Materials
We have used the slides from the graphics website. We also used the help of other students (and the student assistants) and professors (mainly via slack).


Camera movement: wasd are used to zoom in, out, and look to the left and right. There's also the two arrows keys left and right, for bigger angles.

Debug:

White horizontal line: screen plane;
very small dot where all those yellow lines come from: camera
yellow lines: primary rays
circles: spheres
boxes with 45 degree angle: lights
green lines: secondary rays.

Our plane is glitched but we haven't commented it out so you can see that our 3rd sphere with the mirror class actually works.


For the camera: you can change the z of the camera and the direction in the game class. Spheres are fully supported (hue).
We have keyboard support in the game class aswell (handlekeyboarpress methods). Very sexy debug output.



 _____  ______      _         _____       _ _     _   _____    ________
|_   _| | ___ \    | |       /  ___|     | (_)   | | |  ___|  / /___  /
  | |   | |_/ /__ _| |_ ___  \ `--.  ___ | |_  __| | |___ \  / /   / / 
  | |   |    // _` | __/ _ \  `--. \/ _ \| | |/ _` |     \ \/ /   / /  
 _| |_  | |\ \ (_| | ||  __/ /\__/ / (_) | | | (_| | /\__/ / /  ./ /   
 \___/  \_| \_\__,_|\__\___| \____/ \___/|_|_|\__,_| \____/_/   \_/    
                                                                       
                                                                       

