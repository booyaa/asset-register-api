COMPOSE = docker-compose -f asset-register-api/docker-compose.yml

.PHONY: test setup serve build docker-build docker-down shell test-homes-england test-web-api

test: test-homes-england test-web-api

test-homes-england:
	docker build -q --pull --target test-homes-england -t asset-register-api:test-homes-england .
	docker run --rm asset-register-api:test-homes-england

test-web-api:
	docker build -q --pull --target test-web-api -t asset-register-api:test-web-api .
	docker run --rm asset-register-api:test-web-api


setup: build

serve: docker-down docker-build
	$(COMPOSE) up

build: docker-build

docker-build:
	$(COMPOSE) build

docker-down:
	$(COMPOSE) down

shell:
	$(COMPOSE) run --rm web /bin/bash
