using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Commander
{
    void Execute();
}

public class MoveCommand : Commander
{
    Vector2 direction;
    public MoveCommand(Vector2 direction)
    {
        this.direction = direction;
    }

    public void Execute()
    {

    }
}

public class ActionCommand1 : Commander
{
    public void Execute()
    {

    }
}

public class ActionCommand2 : Commander
{
    public void Execute()
    {

    }
}

public class AbilityCommand1 : Commander
{
    public void Execute()
    {

    }
}

public class AbilityCommand2 : Commander
{
    public void Execute()
    {

    }
}
