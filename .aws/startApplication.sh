#!/bin/bash
# to remove once you set bash_profile correctly
export DOTNET_ROOT=/tmp/dotnet
export PATH=$PATH:$DOTNET_ROOT
# end to remove
# we remove first and last quote get with ssm
cd /var/www/
mkdir website
sudo cp -R /var/www/my-temp-dir/* /var/www/website/
echo "start application"
cd /var/www/website/
echo "dotnet ChoixResto.dll > /dev/null 2>&1 &"
dotnet ChoixResto.dll > /dev/null 2>&1 &
cd  /var/www/my-temp-dir/
rm -rf *