# ADR template by Michael Nygard

This is the template in [Documenting architecture decisions - Michael Nygard](http://thinkrelevance.com/blog/2011/11/15/documenting-architecture-decisions)

In each ADR file, write these sections:

* **Title**: Idiotmatic way of serializing data into csv format.

* **Status**: Accepted

* **Context**: The client use case is exporting indivual records as comma separated file (.csv)

* **Decision**: The decision we have gone with is to make use of the dotnet core output formatters as a delivery mechanism. Thereby removing the need to have the output model be aware of any sort of serialization. 

* **Consequences**: 
- Idiotmatic way of serializing data into csv format.
- Easily configurable
- Potentially restrictive around DateTime serialization.
- Allows http requests to response "accept" headers.
- Complies with RESTful API.
- Dependent on nuget package - WebApiContrib.Core.Formatter.Csv.