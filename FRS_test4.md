TITLE: Host Service\\
DESC: A host service will be responsible for hosting the application, such as ASP.NET MVC. This will provide the user with a URL to access the application.\\
RAT: To provide access for the user.\\
DEP: None\
TITLE: Ability to upload and download files\
DESC: The user should be able to upload image files, and text files when creating tickets or submitting a new comment. The file paths will be stored in the database.\
RAT: The user needs to be able to provide as much information in a variety of methods\
TITLE: Account Creation\
DESC: If the user does not already have a user account, there must be a method to create a new account.\
RAT: An account is needed to authenticate to the application and use it.\
TITLE: Authentication\
DESC: The application will provide an authentication service such as OAuth. This will provide identification while creating and managing tickets.\
RAT: The user needs to have Authenticate to properly store and retrieve data.\
TITLE: Notification System\
DESC: Users should be notified about changes to tickets that they have created. This system will be internal to the application, but there will also be an option for the user to opt into receiving email notifications. Technicians will email Users through the application.\
RAT: This will allow users to know about changes when they happen.\
TITLE: View existing tickets\
DESC: A portal will exist to provide users with their past and present tickets.\
RAT: This will allow users to view the status/progress of the ticket, and make changes if needed.\
TITLE: Submit comment\
DESC: If needed the user should be able to add additional comments, images or other files to the ticket to aid the technician.\
RAT: Provide additional information to help resolve the problem.\
TITLE: Close ticket\
DESC: If the user has resolved the problem on their own, there will be an option to close an existing ticket.\
RAT: This will prevent time and resources from being wasted on previously resolved issues.\
TITLE: Technician Interface\
DESC: There should be separate functionality and views for technicians and users. This will allow technicians to view all tickets.\
RAT: Allows collaboration among technicians, and allows a technician to work on multiple tickets at once.\
TITLE: Statistics Dashboard\
DESC: Technician's with Management roles should have a dashboard that shows all open tickets and their statuses, along with all data related to individual tickets from this dashboard. It may include charts for visual representation.\
RAT: This will provide a high level overview of how well operations are being handled, along with spikes or dips in tickets opened or closed.\
DEP: FR9\
TITLE: Input Validation\
DESC: User submissions must be checked to ensure they are valid before being processed by the application.\
RAT: This will ensure the integrity, safety and security of data contained within the application.\
DEP:\
TITLE: Required Fields\
DESC: HTML forms will have required fields that will not allow submission until they are entered.\
RAT: This will prevent empty submissions to the database, and missing information for the assigned technician.\
TITLE: Permanent Ticket Record\
DESC: Tickets will have the option to be closed and archived, but neither the technician nor the user will have the option to permanently delete the ticket.\
RAT: A ticket history will allow reoccurring issues to noticed more readily. Preserving a ticket history will also keep a permanent record of work performed and actions taken/not taken to resolve the problem.\
TITLE: Search Function\
DESC: Technicians should be able to search for ticket IDs and user IDs both past and present.\
RAT: To aid in collecting relevant information to a current problem.\
TITLE: Location Specific Assignment\
DESC: The application must ensure that tickets are assigned to technicians that are local to the location of the ticket.\
RAT: This will stop tickets from being assigned to technicians that cannot physically work on the problem if required to, this would result in additional work to reassign tickets later.\
