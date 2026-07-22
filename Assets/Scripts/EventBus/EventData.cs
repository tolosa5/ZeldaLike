public class EventData
{
    public float cooldown { get; private set; }

    protected EventData(float cooldown = 0)
    {
        this.cooldown = cooldown;
    }
}

public class OnSwitchPlayerMovementEvent : EventData
{
    public OnSwitchPlayerMovementEvent(float cooldown = 0) : base(cooldown)
    {
    }
}