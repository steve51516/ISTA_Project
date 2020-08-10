# <center> Use Case: Create Help Ticket</c>
**<div style="text-align: right">Steven Fairchild</div>** 
*<div style="text-align: right">August 10, 2020</div>*


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
* User is using a supported system(s).
* Technician(s) are available to accept Ticket.

**Post-conditions**
* User resumes normal workflow/system(s) operation.
* Ticket is closed and archived.

**Normal Flow**
1. User navigates to proper web URI.
1. User authenticates with username and password.
1. User has logged into application and is taken to their dashboard.
1. User chooses to create a new ticket.
1. User is taken to create ticket form, and prompted to enter the following information:
	1. Brief sentence describing problem (used to set ticket title).
	1. Longer detailed description of the probelm (used to set description).
	1. Preferred contact method is set, either phone or email.
	1. Location of problem.
	1. System experiencing problem.
1. A new ticket has been created and assigned to the next technician in que.
	* Technician is notified with system and notification data.
1. Technician reviews the ticket.
1. Technician performs one of the following:
	1. Troubleshoots system
	1. Replaces part
	1. Orders part to be replaced (either to replace or replace spare used)
	1. Contacts user for more information.
	1. Sets engagement date.
	1. Other.
1. Technician verifies that the problem has been resolved
	* If not repeat previous steps or try another method.
1. If the problem has been corrected:
	1. Technician ensures all information has been logged from start to finish.
	1. Ticket is closed and archived.
	

**Alternate Flows**
* Must wait for parts to arrive before attempting repair.
	1. Ticket status is set to awaiting parts
	1. Temporary solution is offered if possible and noted in comments
	1. Expected reengagement date set.
* The problem was not resolved on first, technician must take proper follow up action to correct problem and verifies with user.
	1. Technician reviews steps previously taken, takes more steps.
* Technician does not have enough information, or information is vague
	* Technician contacts user to clarify.
* User has resolved the problem before technician has engaged
	* User closes Ticket and is prompted to enter a reason.
* A Ticket is generated but for some reason no Technician can be assigned.
	* Employee with manager role is notified.
* Invalid information is entered by User or Technician
	* User or Technician is reprompted to enter data until proper format is used.
* User does not have an account
	* User creates an account
* Users account password is expired or locked
	* User resets password
	* If locked manager role is notified
* Too long has passed between Ticket creation and new action
	* Notifications are sent to Technician and Manager.
* User requests a status update
	* Notification is sent to Technician.

