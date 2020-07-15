# ToyRobotSimulator is a .Net Core Console Application
# The simulator works on given commands (interactively) only as Commands input from the given file is not ready yet.
# After cloning this repository locally, please PUBLISH this in RELEASE Mode.
# Following are the Steps to execute the application  from Console :

1. Go to folder location : ToyRobotSimulator\bin\Release\netcoreapp2.2\publish
2. Write any of the below commands to start execution of ToyRobotSimulator:

   TheToyRobotSimulator
   
   Below output will be shown:

                ===========================================================================
                        * W E L C O M E  T O  T O Y  R O B O T  S I M U L A T O R *
                ===========================================================================
                Board size is: 4x4
                Valid Commands are : PLACE <x>,<y>,<DIRECTION>, MOVE, LEFT, RIGHT, REPORT
                Commands are Case Sensitive.
                Type <EXIT>,<QUIT> to Quit.. !
                ===========================================================================


                1>  
   


TheToyRobotSimulator -help

Below output will be shown:

               **********************************************************************
                TheToyRobotSimulator.exe [-help] [-nocase]

                -help           --> Displays this help.
                -nocase         --> By default the Robot commands are case-sensitive,
                use this switch to allow case insensitive commands in interactive mode
                ***********************************************************************


                ===========================================================================
                        * W E L C O M E  T O  T O Y  R O B O T  S I M U L A T O R *
                ===========================================================================
                Board size is: 4x4
                Valid Commands are : PLACE <x>,<y>,<DIRECTION>, MOVE, LEFT, RIGHT, REPORT
                Commands are Case Sensitive.
                Type <EXIT>,<QUIT> to Quit.. !
                ===========================================================================


                1>                                                                           
     
     
TheToyRobotSimulator -help -nocase

Below output will be shown:

                **********************************************************************
                TheToyRobotSimulator.exe [-help] [-nocase]

                -help           --> Displays this help.
                -nocase         --> By default the Robot commands are case-sensitive,
                use this switch to allow case insensitive commands in interactive mode
                ***********************************************************************


                ===========================================================================
                        * W E L C O M E  T O  T O Y  R O B O T  S I M U L A T O R *
                ===========================================================================
                Board size is: 4x4
                Valid Commands are : PLACE <x>,<y>,<DIRECTION>, MOVE, LEFT, RIGHT, REPORT
                Commands are NOT Case Sensitive.
                Type <EXIT>,<QUIT> to Quit.. !
                ===========================================================================


                1>  
