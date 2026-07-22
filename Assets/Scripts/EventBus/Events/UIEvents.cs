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

public class OnUpdateHealthUIEvent : EventData
{
    public int currentHealth { get; private set; }
    public int maxHealth { get; private set; }
    
    public OnUpdateHealthUIEvent(int currentHealth, int maxHealth, float cooldown = 0) : base(cooldown)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
    }
}