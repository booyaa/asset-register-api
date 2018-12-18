**Title**: Performing calculations in a consistent manner on any cloud platform and database provider

**Status**: 

**Context**: The client use case is calculating aggregated data over the entire dataset, a subset of it at a given time. Also modifiers to the dataset can be applied with regards to applying a the HPI (Housing Price Index at a point in time) to the dataset at a point in time.

The current data store is a PostgresSQL datastore. However the ultimate cloud platform that HomesEngland will migrate to is yet to be decided. As such we may not remain on Gov PaaS and so may end up on a different cloud platform with a different database provider. Given the choice of a different platform and any datastore the mainters of the project may not want to continue to use  One that may not be SQL.

- Option 1: Perform calculations at database level. 
- Option 2: Perform calculations at code level.

**Decision**: Option 2

**Consequences**: 
