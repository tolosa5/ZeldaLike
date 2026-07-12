public class EventData
{
    public float cooldown { get; private set; }

    protected EventData(float cooldown = 0)
    {
        this.cooldown = cooldown;
    }
}

public class ActivateTooltipEvent : EventData
{
    public string tooltip { get; private set; }

    public ActivateTooltipEvent(string tooltip, float cooldown = 0) : base(cooldown)
    {
        this.tooltip = tooltip;
    }
}

public class DeactivateTooltipEvent : EventData
{
    public DeactivateTooltipEvent(float cooldown = 0) : base(cooldown)
    {
        
    }
}