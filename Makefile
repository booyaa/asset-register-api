COMPOSE = docker-compose
RUN_WEB = $(COMPOSE) run --rm web
RUN_WEB_SERVICE = $(COMPOSE) run --rm --service-ports web


.PHONY: \
		test test-homes-england test-web-api \
		setup serve build stop shell \
		docker-build docker-down docker-stop \


test: test-homes-england test-web-api

test-homes-england: build
	$(RUN_WEB) dotnet test HomesEnglandTest

test-web-api: build
	$(RUN_WEB) dotnet test AssetRegisterTest


setup: build
	# This is implicit: $(RUN_WEB) dotnet restore

serve: setup
	$(RUN_WEB_SERVICE) dotnet run --project WebApi

build: docker-build

stop: docker-stop

shell:
	$(RUN_WEB) bash


docker-build:
	$(COMPOSE) build

docker-down:
	$(COMPOSE) down

docker-stop:
	$(COMPOSE) stop
