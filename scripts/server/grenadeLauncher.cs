//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

function enableManualDetonation(%obj)
{
   %obj.detonadeEnabled = true;
}

function doManualDetonation(%obj)
{
   %nade = new Item()
   {
      dataBlock = Detonade;
   };
   MissionCleanup.add(%nade);

   %nade.setTransform(%obj.getTransform());
   %nade.sourceObject = %obj.sourceObject;
   %nade.schedule(50, "setDamageState", "Destroyed"); // Why must we schedule?!
   //%nade.setDamageState(Destroyed);

   %obj.delete();
}

function Detonade::onDestroyed(%this, %object, %lastState)
{
   radiusDamage(%object, %object.getPosition(), 10, 25, "DetonadeDamage", 2000);
}

function GrenadeLauncherImage::onMount(%this, %obj, %slot)
{
   // Make it ready
   %obj.detonadeEnabled = true;
   Parent::onMount(%this, %obj, %slot);
}

function GrenadeLauncherImage::onAltFire(%this, %obj, %slot)
{
   /*
   //echo("\c4GrenadeLauncherImage::onFire("@ %this.getName() @", "@ %obj.client.nameBase @", "@ %slot@")");

   // It's not ready yet
   if(!%obj.detonadeEnabled)
      return;

   // If we already have one of these... blow it up!!!
   if(isObject(%obj.lastProj))
   {
      doManualDetonation(%obj.lastProj);
      if(%obj.lastNade)
      {
         // We remove the ammo of the last projectile fired only after it has
         // been triggered, otherwise we wouldn't be able to set it off.
         %obj.lastNade = "";
         %obj.decInventory(%this.ammo, 1);
      }
      return;
   }

   // We fire our weapon using the straight ahead aiming point of the gun.
   %muzzleVector = %obj.getMuzzleVector(%slot);

   // Get the player's velocity, we'll then add it to that of the projectile
   %objectVelocity = %obj.getVelocity();
   %muzzleVelocity = VectorAdd(
      VectorScale(%muzzleVector, %this.projectile.muzzleVelocity),
      VectorScale(%objectVelocity, %this.projectile.velInheritFactor));

   %p = new (%this.projectileType)()
   {
      dataBlock = %this.projectile;
      initialVelocity = %muzzleVelocity;
      initialPosition = %obj.getMuzzlePoint(%slot);
      sourceObject = %obj;
      sourceSlot = %slot;
      client = %obj.client;
   };

   %obj.lastProj = %p;
   MissionCleanup.add(%p);

   // Decrement inventory ammo.
   //%obj.decInventory(%this.ammo, 1);

   // Must do some trickiness with reducing the ammo count to account for the
   // very last shot.  If we don't you wouldn't be able to trigger it.
   %currentAmmo = %obj.getInventory(%this.ammo);
   if(%currentAmmo == 1)
      %obj.lastNade = 1;
   else
      %obj.decInventory(%this.ammo, 1);

   // We don't want to detonate it in our face now do we?  Give it a little time.
   %obj.detonadeEnabled = false;
   schedule(250, 0, "enableManualDetonation", %obj);
   
   */
}
