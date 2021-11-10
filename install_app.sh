#!/bin/bash
cd /home/ubuntu/PizzaDeliveryService
export DOTNET_CLI_HOME=/home/ubuntu
dotnet restore
dotnet publish