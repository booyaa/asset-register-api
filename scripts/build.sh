#!/bin/bash

set -e

cd HomesEngland
dotnet restore
dotnet publish -c Release -o out

cd ../WebApi
dotnet restore
dotnet publish -c Release -o out
