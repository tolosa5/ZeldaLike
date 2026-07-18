using System.Collections.Generic;
using Ink.Runtime;

public class EventData
{
    public float cooldown { get; private set; }

    protected EventData(float cooldown = 0)
    {
        this.cooldown = cooldown;
    }
}

public class OnActivateTooltipEvent : EventData
{
    public string tooltip { get; private set; }

    public OnActivateTooltipEvent(string tooltip, float cooldown = 0) : base(cooldown)
    {
        this.tooltip = tooltip;
    }
}

public class OnDeactivateTooltipEvent : EventData
{
    public OnDeactivateTooltipEvent(float cooldown = 0) : base(cooldown)
    {
        
    }
}

public class OnActivateLeverEvent : EventData
{
    public int id { get; private set; }

    public OnActivateLeverEvent(int id, float cooldown = 0) : base(cooldown)
    {
        this.id = id;
    }
}

public class OnGetMapEvent : EventData
{
    public OnGetMapEvent(float cooldown = 0) : base(cooldown)
    {
        
    }
}

public class OnPressurePlatePressed : EventData
{
    public int id { get; private set; }

    public OnPressurePlatePressed(int id, float cooldown = 0) : base(cooldown)
    {
        this.id = id;
    }
}

public class OnSwitchHit : EventData
{
    public int id { get; private set; }

    public OnSwitchHit(int id, float cooldown = 0) : base(cooldown)
    {
        this.id = id;
    }
}

public class OnEnterDialogue : EventData
{
    public string knotName { get; private set; }

    public OnEnterDialogue(string knotName, float cooldown = 0) : base(cooldown)
    {
        this.knotName = knotName;
    }
}

public class OnDialogueStarted : EventData
{
    public OnDialogueStarted(float cooldown = 0) : base(cooldown)
    {
    }
}

public class OnDialogueFinished : EventData
{
    public OnDialogueFinished(float cooldown = 0) : base(cooldown)
    {
    }
}

public class OnDialogueDisplay: EventData
{
    public string dialogueLine { get; private set; } 
    public List<Choice> choices { get; private set; }
    
    public OnDialogueDisplay(string dialogueLine, List<Choice> choices, float cooldown = 0) : base(cooldown)
    {
        this.dialogueLine = dialogueLine;
        this.choices = choices;
    }
}

public class OnUpdateChoiceIndex : EventData
{
    public int choiceIndex { get; private set; }
    public OnUpdateChoiceIndex(int choiceIndex, float cooldown = 0) : base(cooldown)
    {
        this.choiceIndex = choiceIndex;
    }
}

public class OnSwitchPlayerMovement : EventData
{
    public OnSwitchPlayerMovement(float cooldown = 0) : base(cooldown)
    {
    }
}