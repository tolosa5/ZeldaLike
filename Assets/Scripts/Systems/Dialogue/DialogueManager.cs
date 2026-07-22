using System;
using Game.Inputs;
using Ink.Runtime;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextAsset inkJson;
    private Story story;
    
    private int currentChoiceIndex = -1;
    private bool isDialoguePlaying = false;
    
    private OnSwitchPlayerMovementEvent onSwitchPlayerMovementEvent;
    private OnDialogueStartedEvent onDialogueStartedEvent;
    private OnDialogueFinishedEvent onDialogueFinishedEvent;
    private OnDialogueDisplayEvent onDialogueDisplayEvent;

    private void Awake()
    {
        story = new Story(inkJson.text);
    }

    private void Start()
    {
        EventBus.Subscribe<OnEnterDialogueEvent>(EnterDialogue);
        EventBus.Subscribe<OnUpdateChoiceIndexEvent>(UpdateChoiceIndex);
        InputManager.instance.inputSystemActions.UI.Submit.performed += _ => SubmitPressed();
        onDialogueStartedEvent = new OnDialogueStartedEvent();
        onDialogueFinishedEvent = new OnDialogueFinishedEvent();
        onSwitchPlayerMovementEvent = new OnSwitchPlayerMovementEvent();
    }

    private void SubmitPressed()
    {
        if (!isDialoguePlaying)
            return;
        
        ContinueOrExitStory();
    }

    private void EnterDialogue(OnEnterDialogueEvent data)
    {
        if (isDialoguePlaying)
            return;
        
        EventBus.Raise(onSwitchPlayerMovementEvent);
        EventBus.Raise(onDialogueStartedEvent);
        
        isDialoguePlaying = true;
        
        if (data.knotName != null)
            story.ChoosePathString(data.knotName);
        
        ContinueOrExitStory();
    }

    private void ContinueOrExitStory()
    {
        if (story.currentChoices.Count > 0 && currentChoiceIndex != -1)
        {
            story.ChooseChoiceIndex(currentChoiceIndex);
            currentChoiceIndex = -1;
        }
        
        if (story.canContinue)
        {
            string dialogueLine = story.Continue();

            while (IsLineBlank(dialogueLine) && story.canContinue)
            {
                dialogueLine = story.Continue();
            }

            if (IsLineBlank(dialogueLine) && !story.canContinue)
            {
                ExitDialogue();
            }
            else
            {
                onDialogueDisplayEvent = new OnDialogueDisplayEvent(dialogueLine, story.currentChoices);
                EventBus.Raise(onDialogueDisplayEvent);
            }
        }
        else if (story.currentChoices.Count == 0) 
            ExitDialogue();
    }

    private void UpdateChoiceIndex(OnUpdateChoiceIndexEvent data)
    {
        currentChoiceIndex = data.choiceIndex;
    }

    private void ExitDialogue()
    {
        isDialoguePlaying = false;
        story.ResetState();
        EventBus.Raise(onSwitchPlayerMovementEvent);
        EventBus.Raise(onDialogueFinishedEvent);
    }
    
    private bool IsLineBlank(string line)
    {
        return line.Trim().Equals("") || line.Trim().Equals("\n");
    }
}
