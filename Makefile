WEBAPI_RUNTIME_TAG = webapi-rt

.PHONY: test setup serve build docker-build docker-down shell test-homes-england test-web-api

test: test-homes-england test-web-api

test-homes-england:
	docker build -q --pull --target test-homes-england -t asset-register-api:test-homes-england .
	docker run --rm asset-register-api:test-homes-england

test-web-api:
	docker build -q --pull --target test-web-api -t asset-register-api:test-web-api .
	docker run --rm asset-register-api:test-web-api


setup: build

serve: 
	docker run --rm  -p 5000:80 $(WEBAPI_RUNTIME_TAG)

build: docker-build

docker-build:
	docker build -q --pull -t $(WEBAPI_RUNTIME_TAG) .

docker-down:
	# FIXME

shell:
	docker run --rm  -p 5000:80 -it $(WEBAPI_RUNTIME_TAG) bash
