using System;
using System.Collections.Generic;

public static class EventBus
{
    private static Dictionary<Type, Delegate> subscribers = new();
    
    public static void Raise(EventData data)
    {
        Type type = data.GetType();
        if (subscribers.TryGetValue(type, out Delegate subscriber))
            subscriber?.DynamicInvoke(data);
    }

    public static void Subscribe<T>(Action<T> action) where T : EventData
    {
        Type type = typeof(T);
        
        if (subscribers.ContainsKey(type))
            subscribers[type] = Delegate.Combine(subscribers[type], action);
        else
            subscribers[type] = action;
    }

    public static void Unsubscribe<T>(Action<T> action) where T : EventData
    {
        Type type = typeof(T);
        
        if (subscribers.ContainsKey(type))
            subscribers[type] = Delegate.Remove(subscribers[type], action);
    }
}