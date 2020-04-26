# UnityScripts
Ready to go useful Unity scripts for rapid prototyping
BulletTime.cs:-
Gives slow motion effect.
To activate call DoSlowMotion function.
To stop call ResumeTime function.

Timer.cs:-
Gives you all the necessary timer related functionality
You can create an abject of class with a timeout value.
You need to call the RunTimer function in Update to start down the timer.
You need to call RestTimer or while creating object give second parameter as true to start the timer.
You can get value of timer at any point in time using TimeRemaining function (return int you can tweak).

RotateObject.cs:-  (Dependent on Timer.cs)
