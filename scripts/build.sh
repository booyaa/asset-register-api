#!/bin/bash

set -e

cd asset-register-api
dotnet restore
dotnet publish -c Release -o out