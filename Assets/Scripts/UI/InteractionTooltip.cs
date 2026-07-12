using System;
using TMPro;
using UnityEngine;

public class InteractionTooltip : MonoBehaviour
{
    [SerializeField] private GameObject tooltipWrapper;
    [SerializeField] private TextMeshProUGUI tooltipText;

    private void Awake()
    {
        EventBus.Subscribe<ActivateTooltipEvent>(ShowTooltip);
        EventBus.Subscribe<DeactivateTooltipEvent>(HideTooltip);
    }
    
    private void ShowTooltip(ActivateTooltipEvent data)
    {
        if (tooltipWrapper.activeSelf)
            return;
        
        tooltipWrapper.SetActive(true);
        tooltipText.text = data.tooltip;
    }

    private void HideTooltip(DeactivateTooltipEvent data)
    {
        if (!tooltipWrapper.activeSelf)
            return;
        
        tooltipWrapper.SetActive(false);
    }
}
