# Use Case: Create Help Ticket
**<div style="text-align: right">Steven Fairchild</div>** 
*<div style="text-align: right">October 10, 2020</div>*

**Actors**
* Technician
* Ticket
* System<br>

**Triggers**
* New ticket is assigned to Technician.<br>

**Preconditions**
* Technician is available to accept tickets.<br>

**Postconditions**
* Technician has resolved issue and ticket is closed.<br>

**Normal Flow**
1. Ticket has been assigned to a technician.
2. Technician reviews information and decides to either.
  - Work on issue with present information.
  - Contact user for more information.
3. Technician begins working on issue or troubleshooting to determine cause.
4. Technician believes they have resolved the issue.
5. End user is contacted to confirm.<br>

**Alternate Flows**
1. Technician is unable to resolve issue and must follow an escalation path.
  - Ticket is assigned to higher level of support, process repeats.
2. User is unreachable.
  - Ticket is closed and user must recreate ticket.
