using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EntityCommand
{
    void Execute();
}

public class MoveCommand : EntityCommand
{
    Entity entity;
    Vector2 direction;

    public MoveCommand(Entity entity, Vector2 direction)
    {
        this.entity = entity;
        this.direction = direction;
    }

    public void Execute()
    {
        entity.Move(direction);
    }
}

public class ActionCommand1 : EntityCommand
{
    Entity entity;

    public ActionCommand1(Entity entity)
    {
        this.entity = entity;
    }

    public void Execute()
    {
        entity.Action1();
    }
}

public class ActionCommand2 : EntityCommand
{
    Entity entity;

    public ActionCommand2(Entity entity)
    {
        this.entity = entity;
    }
    public void Execute()
    {
        entity.Action2();
    }
}

public class AbilityCommand1 : EntityCommand
{
    Entity entity;

    public AbilityCommand1(Entity entity)
    {
        this.entity = entity;
    }

    public void Execute()
    {
        entity.Ability1();
    }
}

public class AbilityCommand2 : EntityCommand
{
    Entity entity;

    public AbilityCommand2(Entity entity)
    {
        this.entity = entity;
    }

    public void Execute()
    {
        entity.Ability2();
    }
}
