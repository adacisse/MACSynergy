#!/bin/bash
echo "stop application"
cd  /var/www/website/
echo "kill $(ps aux | grep ChoixResto.dll | awk '{print $2}')"
kill $(ps aux | grep ChoixResto.dll | awk '{print $2}') || echo "Process ChoixResto.dll was not running."
rm -rf /var/www/website/
