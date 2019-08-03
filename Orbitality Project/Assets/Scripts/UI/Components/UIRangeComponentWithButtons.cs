using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class UIRangeComponentWithButtons : MonoBehaviour
{
    public event Action<int> OnChangeValueHandler;

    [SerializeField]
    private Text valueText;

    [SerializeField]
    private Button minusButton;
    [SerializeField]
    private Button plusButton;

    protected int minValue;
    protected int maxValue;
    protected int value;

    private void Start()
    {
        minusButton.onClick.AddListener(OnMinusClick);
        plusButton.onClick.AddListener(OnPlusClick);
    }

    private void OnMinusClick()
    {
        ClickSound.Click();

        value--;
        if (OnChangeValueHandler != null)
            OnChangeValueHandler.Invoke(value);
    }

    private void OnPlusClick()
    {
        ClickSound.Click();

        value++;
        if (OnChangeValueHandler != null)
            OnChangeValueHandler.Invoke(value);
    }

    private void UpdateInfo()
    {
        valueText.text = value.ToString();
        minusButton.interactable = value > minValue;
        plusButton.interactable = value < maxValue;


    }

    public int Value
    {
        set
        {
            this.value = value;
            UpdateInfo();
        }
    }

    public int MinValue
    {
        set
        {
            minValue = value;
            if(minValue > this.value)
            {
                Value = minValue;
            }
        }
    }
    public int MaxValue
    {
        set
        {
            maxValue = value;
            if (maxValue < this.value)
            {
                Value = maxValue;
            }
        }
    }
}
