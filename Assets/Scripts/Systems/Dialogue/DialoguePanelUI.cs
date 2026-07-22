using System;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;

public class DialoguePanelUI : MonoBehaviour
{
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private DialogueChoiceButton[] choiceButtons;
    
    private OnUpdateChoiceIndexEvent onUpdateChoiceIndexEvent;

    private void Awake()
    {
        contentPanel.SetActive(false);
        ResetPanel();
    }

    private void Start()
    {
        EventBus.Subscribe<OnDialogueStartedEvent>(DialogueStarted);
        EventBus.Subscribe<OnDialogueFinishedEvent>(DialogueEnded);
        EventBus.Subscribe<OnDialogueDisplayEvent>(DisplayDialogue);
    }

    private void DialogueStarted(OnDialogueStartedEvent data)
    {
        contentPanel.SetActive(true);
    }

    private void DialogueEnded(OnDialogueFinishedEvent data)
    {
        contentPanel.SetActive(false);
    }

    private void DisplayDialogue(OnDialogueDisplayEvent data)
    {
        dialogueText.text = data.dialogueLine;
        if (data.choices.Count > choiceButtons.Length)
            return;

        foreach (var choiceButton in choiceButtons)
        {
            choiceButton.gameObject.SetActive(false);
        }

        int choiceButtonIndex = data.choices.Count - 1;
        for (int i = 0; i < data.choices.Count; i++)
        {
            Choice dialogueChoice = data.choices[i];
            DialogueChoiceButton choiceButton = choiceButtons[choiceButtonIndex];
            choiceButton.gameObject.SetActive(true);
            choiceButton.SetChoiceText(dialogueChoice.text);
            choiceButton.SetChoiceIndex(i);

            if (i == 0)
            {
                choiceButton.SelectButton();
                onUpdateChoiceIndexEvent = new OnUpdateChoiceIndexEvent(0);
                EventBus.Raise(onUpdateChoiceIndexEvent);
            }

            choiceButtonIndex--;
        }
    }
    
    private void ResetPanel()
    {
        dialogueText.text = "";
    }

    private void OnDisable()
    {
        EventBus.Unsubscribe<OnDialogueStartedEvent>(DialogueStarted);
        EventBus.Unsubscribe<OnDialogueFinishedEvent>(DialogueEnded);
        EventBus.Unsubscribe<OnDialogueDisplayEvent>(DisplayDialogue);
    }
}
