# cruel-world
[![Build status][img-appveyor-build]][appveyor]
[![Test status][img-appveyor-test]][appveyor]

Please, design domain model classes and implement following game mechanics.
There are three races: ogres, goblins and sheeps. Ogres can eat goblins and sheeps. Goblins can eat each other and sheeps. All races can attack each other. Ogres and goblins can use weapons.
If someone tries to eat another creature, he becomes an aggressor and the other party becomes a defender. In this case, fight is conducted. Party considered as winner in fight if all attendees from other party are dead. The result of the fight depends on attendee’s race, amount and weapons.

Implement situations based on the model described:
- A goblin eats a sheep.
- Two goblins fights for a sheep. The winner eat the sheep.
- An ogre tries to eat a group of goblins and fails.
- A group of ogres have successfully eaten a group of goblins.
- Two orges try to eat a goblin with a magic sword and fail.
- A herd of sheeps together with a group of goblins fight with two ogres and win.

[appveyor]: https://ci.appveyor.com/project/StanislavKhalash/cruel-world/branch/master

[img-appveyor-build]: https://ci.appveyor.com/api/projects/status/5s6bin9dd2yos2jl?svg=true
[img-appveyor-test]: http://teststatusbadge.azurewebsites.net/api/status/StanislavKhalash/cruel-world
