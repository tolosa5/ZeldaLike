using System;
using TMPro;
using UnityEngine;

public class InteractionTooltip : MonoBehaviour
{
    [SerializeField] private GameObject tooltipWrapper;
    [SerializeField] private TextMeshProUGUI tooltipText;

    private void Awake()
    {
        EventBus.Subscribe<OnActivateTooltipEvent>(ShowTooltip);
        EventBus.Subscribe<OnDeactivateTooltipEvent>(HideTooltip);
    }
    
    private void ShowTooltip(OnActivateTooltipEvent data)
    {
        if (tooltipWrapper.activeSelf)
            return;
        
        tooltipWrapper.SetActive(true);
        tooltipText.text = data.tooltip;
    }

    private void HideTooltip(OnDeactivateTooltipEvent data)
    {
        if (!tooltipWrapper.activeSelf)
            return;
        
        tooltipWrapper.SetActive(false);
    }
}
