type: moscrif source code
name: Application
description: Empty native application skeleton
author: Jozef Pr�davok, (c) Mothiva, s.r.o. 2010
param: application				text	app		^[a-zA-Z_][a-zA-Z0-9_]*$
################################################################################
; Date: $now$
; Author: $username$ on $computername$
           main: main.ms
          title: $application$
    description: 
         author: Generated by Moscrif-Ide
      copyright: 
       homepage: 
           uses: core graphics uix crypto
    orientation: portrait
 remote-console: 192.168.0.156:4321
        version: 1.0