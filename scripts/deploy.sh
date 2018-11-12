#!/usr/bin/env bash

sshpass -p $FTP_PASSWORD ssh -o StrictHostKeyChecking=no $FTP_USER@$FTP_HOST 'sudo systemctl stop payroll.web.service'
sshpass -p $FTP_PASSWORD scp -o StrictHostKeyChecking=no -r /home/travis/build/collinbarrett/Payroll/src/Payroll.Web/bin/Release/netcoreapp2.1/ubuntu.18.04-x64/publish/* $FTP_USER@$FTP_HOST:$FTP_DIR
sshpass -p $FTP_PASSWORD ssh -o StrictHostKeyChecking=no $FTP_USER@$FTP_HOST 'sudo systemctl start payroll.web.service'