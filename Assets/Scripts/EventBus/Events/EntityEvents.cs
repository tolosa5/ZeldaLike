public class OnPlayerDeathEvent : EventData
{
    public OnPlayerDeathEvent(float cooldown = 0) : base(cooldown)
    {
        
    }
}

public class OnEnemyDeathEvent : EventData
{
    public OnEnemyDeathEvent(float cooldown = 0) : base(cooldown)
    {
        
    }
}

public class OnEnemyBossDeathEvent : EventData
{
    public OnEnemyBossDeathEvent(float cooldown = 0) : base(cooldown)
    {
        
    }
}

