#!/bin/bash

set -e

if [ -z "$1" ]; then
  echo 'Provide an environment to deploy'
  exit 1
fi
ENVIRONMENT_NAME="${1}"

PRODUCTION_NAME="production"
if [[ "${ENVIRONMENT_NAME}" == "${PRODUCTION_NAME}" ]]; then
  APP_NAME="${ENVIRONMENT_NAME}-dark"
  FRONTEND_URI="${FRONTEND_URI_PRODUCTION}"
else
  APP_NAME="${ENVIRONMENT_NAME}"
  FRONTEND_URI="${FRONTEND_URI_STAGING}"
fi

curl -L "https://packages.cloudfoundry.org/stable?release=linux64-binary&source=github" | tar -zx
./cf api https://api.cloud.service.gov.uk
./cf auth ${CF_USER} ${CF_PASSWORD}

./cf target -o ${CF_ORG} -s ${1}

./cf push -f deploy-manifests/${APP_NAME}.yml
./cf set-env asset-register-api-${APP_NAME} circle_commit ${CIRCLE_SHA1}
./cf set-env asset-register-api-${APP_NAME} SENTRY_DSN ${SENTRY_DSN}
./cf set-env asset-register-api-${APP_NAME} CorsOrigins "${FRONTEND_URI}"
