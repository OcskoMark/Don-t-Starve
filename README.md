# Don't Starve

It is the Don't Starve game simplified and improved version at the same time.

Your goal is to stay alive as long as possible with your character. You can choose multiple map sizes and difficulties. The choosed difficulty influences the frequency of resources, the raw materials and life of the equipments and a lot of values for the player during the game (for example maximal inventory, player's needs reduce and increase rate, etc.). This description contains the base values (if you choose the normal difficulty).

Your character has 4 needs, if either drops below 0 than you die and the maximum is 100.
 - Health: Your health, it doesn't change basically, but it decreases if you eat some raw food or you do any action in night without a campfire nearby.
 - Brain: Your character can go crazy easily if you brain decreases below 0. It decreases with every action which you do at night, this effect will be smaller if you have flower wreath and you brain heal after every action at daytime at this time. If you are not a near at a campfire at night, your brain decreases significantly.
 - Hunger: Your hunger decreases after every action which you do. You can increase it if you eat any food.
 - Thirst: Your thirst decreases after every action which you do, but the rate is smaller at night. You can increase it if you drink water.

Field types (the first two character is the short id for the fields):
 - Water: collectible resource, it can only be walked if there is any land field next to it.
 - Land: walkable basic field type with nothing collectible resource
 - Berry: collectible food, you can eat and cook it
 - Bough: collectible resource, you can use as raw material to make equipments
 - Carry: collectible food, you can eat and cook it
 - Flower: collectible resource, you can use as raw material to make equipments, you brain heal if you collect it
 - Grass: collectible resource, you can use as raw material to make equipments
 - Herb: collectible resource, you can use it to heal yourself
 - Stone: collectible resource, you can use as raw material to make equipments, you need an pickaxe to collect it
 - Tree: collectible resource, you can use as raw material to make equipments, you need an axe to collect it
 
Equipments (the requirement and "live" values depend on difficulty):
 - Axe: you can use to collect tree, it becomes unusable after you collect 10 trees (requirements: 2 grass, 3 bough)
 - Pickaxe: you can use to collect stone, it becomes unusable after you collect 7 stones (requirements: 2 tree, 2 grass)
 - Campfire: you can use to cook water, food and you can withstand the vicissitudes of night if a campfire is near you (max. 3 distance) (requirements: 2 tree, 4 stone, 2 grass)
 - Flower wreath: your brain heals at daytime and less goes bad at night if you have it, it lasts 15 days (requirement: 10 flower)
 
Actions:
 - Wait: do nothing
 - Move: move the next field to left/right/up/down (if the destination field is walkable)
 - Collect resource: collect the resource from the current field
 - Create equipment: make one equipment