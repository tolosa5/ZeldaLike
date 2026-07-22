using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueChoiceButton : MonoBehaviour, ISelectHandler
{
    [Header("Components")]
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI choiceText;
    
    private OnUpdateChoiceIndexEvent onUpdateChoiceIndexEvent;

    private int choiceIndex = -1;

    public void SetChoiceText(string choiceText)
    {
        this.choiceText.text = choiceText;
    }

    public void SetChoiceIndex(int choiceIndex)
    {
        this.choiceIndex = choiceIndex;
    }

    public void SelectButton()
    {
        button.Select();
    }

    public void OnSelect(BaseEventData eventData)
    {
        onUpdateChoiceIndexEvent = new OnUpdateChoiceIndexEvent(choiceIndex);
        EventBus.Raise(onUpdateChoiceIndexEvent);
    }
}
