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
    
    private OnSwitchPlayerMovement onSwitchPlayerMovement;
    private OnDialogueStarted onDialogueStarted;
    private OnDialogueFinished onDialogueFinished;
    private OnDialogueDisplay onDialogueDisplay;

    private void Awake()
    {
        story = new Story(inkJson.text);
    }

    private void Start()
    {
        EventBus.Subscribe<OnEnterDialogue>(EnterDialogue);
        EventBus.Subscribe<OnUpdateChoiceIndex>(UpdateChoiceIndex);
        InputManager.instance.inputSystemActions.UI.Submit.performed += _ => ContinueOrExitStory();
        onDialogueStarted = new OnDialogueStarted();
        onDialogueFinished = new OnDialogueFinished();
        onSwitchPlayerMovement = new OnSwitchPlayerMovement();
    }

    private void SubmitPressed()
    {
        if (!isDialoguePlaying)
            return;
        
        ContinueOrExitStory();
    }

    private void EnterDialogue(OnEnterDialogue data)
    {
        if (isDialoguePlaying)
            return;
        
        EventBus.Raise(onSwitchPlayerMovement);
        EventBus.Raise(onDialogueStarted);
        
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
                onDialogueDisplay = new OnDialogueDisplay(dialogueLine, story.currentChoices);
                EventBus.Raise(onDialogueDisplay);
            }
        }
        else if (story.currentChoices.Count == 0) 
            ExitDialogue();
    }

    private void UpdateChoiceIndex(OnUpdateChoiceIndex data)
    {
        currentChoiceIndex = data.choiceIndex;
    }

    private void ExitDialogue()
    {
        isDialoguePlaying = false;
        story.ResetState();
        EventBus.Raise(onSwitchPlayerMovement);
        EventBus.Raise(onDialogueFinished);
    }
    
    private bool IsLineBlank(string line)
    {
        return line.Trim().Equals("") || line.Trim().Equals("\n");
    }
}
