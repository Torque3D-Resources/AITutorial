function BarracksTrigger::onEnterTrigger(%this,%trigger,%obj)
{
    // Apply health to colliding object if it needs it.
    // Works for all shapebase objects.
    %damageLevel = %obj.getDamageLevel();
    %maxDamage = %obj.getDatablock().maxDamage;
    %state = %obj.getState();
    //echo(" @@@ " @ %obj @ " : " @ %maxDamage @"/"@ %damageLevel@" : " @ %state);

    // Let's not do this twice on spawn....
    if ( !%obj.spawning)
        AIManager.loadOutUnit(%obj);
    else
        %obj.spawning = false;
        
    if (%damageLevel != 0 && %state !$= "Dead" && %obj.team == %trigger.owner.team)
    {
        %obj.applyRepair(%maxDamage - %damageLevel);

        serverPlay3D(HealthUseSound, %trigger.owner.getTransform());
    }
    %x = getRandom(-10, 10);
    %y = getRandom(6, 12);
    %vec = %x SPC %y SPC "0";

    %obj.setMoveDestination(VectorAdd(%trigger.position, %vec));

    %obj.nextTask();
}
