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