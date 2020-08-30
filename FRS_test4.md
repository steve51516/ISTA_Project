<br>
TITLE: Host Service\<br>
DESC: A host service will be responsible for hosting the application, such as ASP.NET MVC. This will provide the user with a URL to access the application.\<br>
RAT: To provide access for the user.\<br>
DEP: None<br>
<br>
TITLE: Ability to upload and download files<br>
DESC: The user should be able to upload image files, and text files when creating tickets or submitting a new comment. The file paths will be stored in the database.<br>
RAT: The user needs to be able to provide as much information in a variety of methods<br>
<br>
TITLE: Account Creation<br>
DESC: If the user does not already have a user account, there must be a method to create a new account.<br>
RAT: An account is needed to authenticate to the application and use it.<br>
<br>
TITLE: Authentication<br>
DESC: The application will provide an authentication service such as OAuth. This will provide identification while creating and managing tickets.<br>
RAT: The user needs to have Authenticate to properly store and retrieve data.<br>
<br>
<br>
TITLE: Notification System<br>
DESC: Users should be notified about changes to tickets that they have created. This system will be internal to the application, but there will also be an option for the user to opt into receiving email notifications. Technicians will email Users through the application.<br>
RAT: This will allow users to know about changes when they happen.<br>
<br>
TITLE: View existing tickets<br>
DESC: A portal will exist to provide users with their past and present tickets.<br>
RAT: This will allow users to view the status/progress of the ticket, and make changes if needed.<br>
<br>
TITLE: Submit comment<br>
DESC: If needed the user should be able to add additional comments, images or other files to the ticket to aid the technician.<br>
RAT: Provide additional information to help resolve the problem.<br>
<br>
TITLE: Close ticket<br>
DESC: If the user has resolved the problem on their own, there will be an option to close an existing ticket.<br>
RAT: This will prevent time and resources from being wasted on previously resolved issues.<br>
<br>
TITLE: Technician Interface<br>
DESC: There should be separate functionality and views for technicians and users. This will allow technicians to view all tickets.<br>
RAT: Allows collaboration among technicians, and allows a technician to work on multiple tickets at once.<br>
<br>
TITLE: Statistics Dashboard<br>
DESC: Technician's with Management roles should have a dashboard that shows all open tickets and their statuses, along with all data related to individual tickets from this dashboard. It may include charts for visual representation.<br>
RAT: This will provide a high level overview of how well operations are being handled, along with spikes or dips in tickets opened or closed.<br>
DEP: FR9<br>
<br>
TITLE: Input Validation<br>
DESC: User submissions must be checked to ensure they are valid before being processed by the application.<br>
RAT: This will ensure the integrity, safety and security of data contained within the application.<br>
DEP:<br>
<br>
TITLE: Required Fields<br>
DESC: HTML forms will have required fields that will not allow submission until they are entered.<br>
RAT: This will prevent empty submissions to the database, and missing information for the assigned technician.<br>
<br>
TITLE: Permanent Ticket Record<br>
DESC: Tickets will have the option to be closed and archived, but neither the technician nor the user will have the option to permanently delete the ticket.<br>
RAT: A ticket history will allow reoccurring issues to noticed more readily. Preserving a ticket history will also keep a permanent record of work performed and actions taken/not taken to resolve the problem.<br>
<br>
TITLE: Search Function<br>
DESC: Technicians should be able to search for ticket IDs and user IDs both past and present.<br>
RAT: To aid in collecting relevant information to a current problem.<br>
<br>
TITLE: Location Specific Assignment<br>
DESC: The application must ensure that tickets are assigned to technicians that are local to the location of the ticket.<br>
RAT: This will stop tickets from being assigned to technicians that cannot physically work on the problem if required to, this would result in additional work to reassign tickets later.<br>
