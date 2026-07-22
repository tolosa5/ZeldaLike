using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class OnEnterDialogueEvent : EventData
{
    public string knotName { get; private set; }

    public OnEnterDialogueEvent(string knotName, float cooldown = 0) : base(cooldown)
    {
        this.knotName = knotName;
    }
}

public class OnDialogueStartedEvent : EventData
{
    public OnDialogueStartedEvent(float cooldown = 0) : base(cooldown)
    {
    }
}

public class OnDialogueFinishedEvent : EventData
{
    public OnDialogueFinishedEvent(float cooldown = 0) : base(cooldown)
    {
    }
}

public class OnDialogueDisplayEvent: EventData
{
    public string dialogueLine { get; private set; } 
    public List<Choice> choices { get; private set; }
    
    public OnDialogueDisplayEvent(string dialogueLine, List<Choice> choices, float cooldown = 0) : base(cooldown)
    {
        this.dialogueLine = dialogueLine;
        this.choices = choices;
    }
}

public class OnUpdateChoiceIndexEvent : EventData
{
    public int choiceIndex { get; private set; }
    public OnUpdateChoiceIndexEvent(int choiceIndex, float cooldown = 0) : base(cooldown)
    {
        this.choiceIndex = choiceIndex;
    }
}
