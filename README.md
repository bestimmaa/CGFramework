CGFramework
===========
Computer Graphics - Winter course 2013 / 2014 - Bauhaus University Weimar

[website of the course](http://www.uni-weimar.de/de/medien/professuren/grafische-datenverarbeitung/lehre/computergrafik/). 

You can find possible solutions for the assigments at the [release page](https://github.com/bestimmaa/CGFramework/releases)

The slides from the Q&A session and additional material can be found in the [wiki section](https://github.com/bestimmaa/CGFramework/wiki)
##Structure of the framework

All source files are in the /src subdirectory. The framework provides boiler plate code for setting up OpenGL in the [test.cpp](src/test.cpp). 

###gloost library

The [gloost library](http://gloost.sourceforge.net) is included to provide functionality for mathematics and object containers.It is included in /dependencies and is supposed to be build in the /lib sudirectory. The provided projects take care of building gloost.You can use a different IDE or makefile by pointing it to the folders /src and /dependencies. In this case you have to take care of building gloost yourself.

##Linux

Open the CGFramwork.workspace in /linux with Code::Blocks. The workspace contains two projects: The framework itself (CGFramework) and the gloost library (gloost).

Make sure you are running the latest (proprietary) drivers for your graphics card for full OpenGL 3.2 support. Tested with Ubuntu 12.04 and Nvidia 319 drivers.

###Dependencies

Install dependencies via apt-get

*sudo apt-get install freeglut3;sudo apt-get install freeglut3-dev;sudo apt-get install libfreeimage3sudo apt-get install libfreeimage-dev;sudo apt-get install libglew1.6;sudo apt-get install libglew1.6-dev*

###Ressources

Add all ressource files (objects, shaders, textures...) to [/linux/CGFramework/copyresources.sh]( /linux/CGFramework/copyresources.sh)

###Common problems

* "X Error of failed request..." -> No graphics drivers installed

##Mac OS X

Open the CGFramwork.xcodeproj in /mac with Xcode.

###Dependencies

Install the dependencies via [homebrew](http://brew.sh/)

*brew install glew;brew install freeimage*

Please note that Apple's GLUT implementation is used instead of FreeGLUT. FreeGLUT does not support OpenGL 3.2 on OS X. This is where the ugly IFDEF come from. Tested with Xcode 5 and OS X 10.8 / 10.9.

###Ressources

Add all ressource files in the corresponding section of "Build Phases" of Xcode's project settings.

###Common problems

* "error: failed to launch '/Users/.../Build/Products/Debug/OpenGLFramework' -- invalid host string: 'localhost'" -> See this [question]() on StackOverflow for a solution

##What you should see

A red sphere. Rendered on your GPU. 



