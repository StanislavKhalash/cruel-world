# cruel-world

Please, design domain model classes and implement following game mechanics.
There are three races: ogres, goblins and sheeps. Ogres can eat goblins and sheeps. Goblins can eat each other and sheeps. All races can attack each other. Ogres and goblins can use weapons.
If someone tries to eat another creature, he becomes an aggressor and the other party becomes a defender. In this case, fight is conducted. Party considered as winner in fight if all attendees from other party are dead. The result of the fight depends on attendee’s race, amount and weapons.

Implement situations based on the model described:
- A goblin eats a ship.
- Two goblins fights for a ship. The winner eat the ship.
- An ogre tries to eat a group of goblins and fails.
- A group of ogres have successfully eaten a group of goblins.
- Two orges try to eat a goblin with a magic sword and fail.
- A herd of ships together with a group of goblins fight with two ogres and win.
