#!/bin/bash

set -e

if [ -z "$1" ]; then
  echo 'Provide an environment to deploy'
  exit 1
fi

curl -L "https://packages.cloudfoundry.org/stable?release=linux64-binary&source=github" | tar -zx
./cf api https://api.cloud.service.gov.uk
./cf auth ${CF_USER} ${CF_PASSWORD}

# Use when we can safely deploy to the `staging` and `production` spaces
# For now, fix to `sandbox` space
# ./cf target -o ${CF_ORG} -s ${1}
./cf target -o ${CF_ORG} -s sandbox

# Deploy when not production
if [ "${1}" != "Production" ]; 
then
  ./cf push -f deploy-manifests/${1}.yml && exit 0
fi

# Blue green deploy (draft)
# Assumes Asset Register API address is https://asset-register-api.cloudapps.digital
# Step 0 - TODO: workout our state (are we blue or green), we'll assume it's stored in ${BLUEGREEN}
# Step 1 - Add temporary domain
# ./cf push -f deploy-manifests/${1}-{BLUEGREEN}.yml -n asset-register-api-temp
# Step 2 - Map new app to default route
# ./cf map-route ${1}-${BLUEGREEN} cloudapps.digital -n asset-register-api
# Step 3 - Remove old app from default route
# ./cf unmap-route ${1}-${FIXME_NEED_NEW_VARIABLE_FOR_OLD_APP} cloudapps.digital -n asset-register-api
# Step 4 -- Remove new app from temporary route
# ./cf unmap-route ${1}-${BLUEGREEN} cloudapps.digital -n asset-register-api-temp
# Step 5 -- update BLUEGREEN to new state i.e. if we were Blue we're now Green vica versa