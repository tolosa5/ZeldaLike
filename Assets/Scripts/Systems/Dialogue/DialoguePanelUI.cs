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
    
    private OnUpdateChoiceIndex onUpdateChoiceIndex;

    private void Awake()
    {
        contentPanel.SetActive(false);
        ResetPanel();
    }

    private void Start()
    {
        EventBus.Subscribe<OnDialogueStarted>(DialogueStarted);
        EventBus.Subscribe<OnDialogueFinished>(DialogueEnded);
        EventBus.Subscribe<OnDialogueDisplay>(DisplayDialogue);
    }

    private void DialogueStarted(OnDialogueStarted data)
    {
        contentPanel.SetActive(true);
    }

    private void DialogueEnded(OnDialogueFinished data)
    {
        contentPanel.SetActive(false);
    }

    private void DisplayDialogue(OnDialogueDisplay data)
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
                onUpdateChoiceIndex = new OnUpdateChoiceIndex(0);
                EventBus.Raise(onUpdateChoiceIndex);
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
        EventBus.Unsubscribe<OnDialogueStarted>(DialogueStarted);
        EventBus.Unsubscribe<OnDialogueFinished>(DialogueEnded);
        EventBus.Unsubscribe<OnDialogueDisplay>(DisplayDialogue);
    }
}
