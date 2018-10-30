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
	docker run --rm  -p 5000:80 -it webapi-rt

build: docker-build

docker-build:
	docker build -q --pull -t webapi-rt .

docker-down:
	# FIXME

shell:
	docker run --rm  -p 5000:80 -it webapi-rt bash
