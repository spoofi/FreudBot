#!/bin/bash
# Script to maintain the website in the enabled state (on the free plan on MS Azure the website will be disabled when idle)
# Put script on a remote Linux machine in a crontab. For example with this configuration (runs every 5 minutes):
# */5 * * * * /path/to/pingbot.sh

curl http://bot-url.com/Ping &> /dev/null