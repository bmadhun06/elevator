# elevator
Elevator Problem solving

Problem Statement:
Consider a multi-storied building with the following floors
1. Lower Basement (-2)
2. Basement (-1)
3. Ground Floor (0)
4. 1st to 10th Floor

The building has 3 Elevators – E1, E2 & E3. The elevators have to be programmed such that, when a person presses
up / down button on the floor, the first elevator that crosses the respective floor should stop in that floor.

For instance, say a person in 3rd floor needs to go to ground floor, so he
pressed the down button.

Let’s say
E1 is in 7th floor moving up
E2 is in 4th floor moving down
E3 is in lower basement, moving up
In this caseE2 appears to be the best choice to halt in Floor 3.
But for some reason, say someone is holding E2 in 4th floor, long enough for
E1 to come down, in this case, E1 has to stop on 3rd floor instead of E2, as E1
crosses 3rd floor first, in down direction.
