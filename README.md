# Unity_SpaceShooter
My space shooter is a mix between ECS and OOP, where the space ship is a GameObject and I tried to make the rest as entities.

EntitySpawnSystem:
Using the conversion workflow I made an enemy GameObject prefab that turns into an entity, this entity is then instantiated with the EntityManager.

MovementSystem:
With two tags; BulletComponentTag and EnemyComponentTag, which are empty components. I use Entities.WithAll<> to single out the difference between 
bullet and enemy entities, and then I apply force in different direction to the entities. Here I also try and check for collision by the entities positions.
However I did not manage to make it work efficiently without hurting performance. 
