using UnityEngine;

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

public class OnPressurePlatePressedEvent : EventData
{
    public int id { get; private set; }

    public OnPressurePlatePressedEvent(int id, float cooldown = 0) : base(cooldown)
    {
        this.id = id;
    }
}

public class OnSwitchHitEvent : EventData
{
    public int id { get; private set; }

    public OnSwitchHitEvent(int id, float cooldown = 0) : base(cooldown)
    {
        this.id = id;
    }
}

public class OnEnemiesZoneClearedEvent : EventData
{
    public int id { get; private set; }

    public OnEnemiesZoneClearedEvent(int id, float cooldown = 0) : base(cooldown)
    {
        this.id = id;
    }
}
