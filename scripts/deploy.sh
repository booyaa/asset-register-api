#!/bin/bash

set -e

curl -L "https://packages.cloudfoundry.org/stable?release=linux64-binary&source=github" | tar -zx
./cf api https://api.cloud.service.gov.uk
./cf auth "$CF_USER" "$CF_PASSWORD"
./cf target -o "$CF_ORG" -s "$CF_SPACE"
cd asset-register-api && ../cf push