Names and StudentIDs
Gerwin de Kruijf - 5933439
Ilhan Kalkan - 5893348				

Bonus exercises 
5 
What we have done:
We made a method to draw lines in the form of y = ax + b. The method also takes a color parameter. 
We made a "movement" option within the worldspace, it's the drawLine method.
We used the screen.Print function you gave us to draw the line formula, but this kept giving us an index out of range exception, so we've commented it away in the method.

We haven't implemented anything spectacular, we just made a method. We take the left x and the right x and calc the y for them, so we can draw the line between them.
But first we check if the y's arent out of bounds (so bigger than maxY or smaller than minY). If they are, we recalculate the x and change the y so the line
stays within the bounds.

The movement detects keyboard inputs. A higher zoom means you can see more of the screen (we couldn't find another name for that), and there's a minimum zoom
so that you are not able to zoom through the screen (1).

Instructions:
You can move around with the arrow keys.
You can zoom in with z, zoom out with x.