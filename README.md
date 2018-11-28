# Asset Register API

The role of the Asset Register API is to create, update and serve asset data for the [Asset Register Frontend][link_arf].

## Current endpoints

**Documentation**

When serving the application, current API docs live at `localhost:5000/swagger`

## Testing the application

Once you have cloned the repository run all tests with the following command:

`make test`

## Running the application

**Creating dummy data**

To fill the database with 100 rows of autogenerated data, you can use the command:

`make seeds`

**Serving**

Once you have cloned the repository you can run the application with the following command:

`make serve`

The application runs on port `5000`.

## Third party services used by this project

- [Gov PaaS][link_gov_pass]
- [Sentry][link_sentry]
- [Circle CI][link_circleci]

[link_arf]: https://github.com/homes-england/asset-register-frontend
[link_gov_pass]: https://www.cloud.service.gov.uk/
[link_sentry]: https://sentry.io/welcome/
[link_circleci]: https://circleci.com/