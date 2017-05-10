Names and StudentIDs
Gerwin de Kruijf - 5933439
Ilhan Kalkan - 5893348				

Bonus exercises 
5 
what we have done:
made a method to draw lines in the form of y = ax + b. Also takes a color parameter. We also made a "movement" option within the worldspace.
it's the drawLine method.
we also used the screen.Print function you gave us to draw the line formula, 
but this keeps giving us an index out of range exception, so we've commented it away in the method.

We haven't implemented anything crazy, we just made a method. We take the left x and right x and calc the y for them. Then draw the line between them.
(but first we check if the y's arent out of bounds (so bigger than maxY or smaller than minY), if they are, we recalculate the x and change the y so the line
stays within the bounds.

The movement just detects keyboard inputs. A higher zoom means you can see more of the screen (we couldn't find another name for that), and there's a minimum zoom
so that you can not zoom through the screen (1).

You move around with the arrow keys.
