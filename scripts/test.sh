#!/bin/bash

set -e

cd HomesEnglandTest
dotnet test

cd ../AssetRegisterTest
dotnet test
