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
./cf target -o ${CF_ORG} -s ${1}
# ./cf target -o ${CF_ORG} -s sandbox

./cf push -f deploy-manifests/${1}.yml
