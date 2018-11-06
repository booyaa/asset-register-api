#!/bin/bash

set -e

if [ -z "$1" ]; then
  echo 'Provide an environment to deploy'
  exit 1
fi

APP_NAME=asset-register-api-${1}

curl -L "https://packages.cloudfoundry.org/stable?release=linux64-binary&source=github" | tar -zx
./cf api https://api.cloud.service.gov.uk
./cf auth ${CF_USER} ${CF_PASSWORD}

./cf target -o ${CF_ORG} -s ${1}

./cf map-route ${APP_NAME}-dark ${CF_DOMAIN} -n ${APP_NAME}
./cf unmap-route ${APP_NAME} ${CF_DOMAIN} -n ${APP_NAME}

./cf rename ${APP_NAME} ${APP_NAME}-temp
./cf rename ${APP_NAME}-dark ${APP_NAME}
./cf rename ${APP_NAME}-temp ${APP_NAME}-dark