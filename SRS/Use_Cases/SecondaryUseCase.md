# Use Case: Create Help Ticket
**<div style="text-align: right">Steven Fairchild</div>** 
*<div style="text-align: right">September 26, 2020</div>*

**Actors**
* User
* Technician
* System
* Ticket
* Manager role

**Triggers**
* User encounters error they are unable to recover from.
* User uses all of a product in a system that the Technician is responsible for maintaining.

**Preconditions**
* User has created a help ticket
* The ticket is still open

**Post-conditions**
* The ticket life-cycle is continued until it is resolved and closed.

**Normal Flow**
1. User authenticates with username and password.
2. User navigates to their dashboard.
3. User selects an existing ticket they created.
4. User submits a comment to their ticket.
5. The technician uses this information to resolve the problem.

    

**Alternate Flows**
1. Technician makes a comment on a ticket they are assigned to.
2. User see the progress being made on their ticket.
3. The ticket is worked until it is resolved and closed.