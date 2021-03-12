#Application Layer
This covers CQRS (Command Query Responsibility Segration) of the application. 
I separated the request query which basically just aggregating existing state of the resource in the persistence layer. 
While I also separated the command request which alters the state of the resource in the persistence layer.
