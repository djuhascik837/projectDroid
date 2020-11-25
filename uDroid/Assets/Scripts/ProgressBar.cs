using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressBar : FillBar
{
    private UnityEvent onProgressComplete;
    public float fillMultiplier = 0.00153f;
    public bool start = false;
    public int plot = 0;

    public new float CurrentValue
    {
        get
        {
            return base.CurrentValue;
        }
        set
        {
            if(value >= slider.maxValue)
            {
                GlobalCoins.CoinCount += 1;
                // If the value exceeds the max fill, invoke the completion function
                onProgressComplete.Invoke();
            }

            // Remove any overfill (i.e. 105% fill -> 5% fill)
            base.CurrentValue = value % slider.maxValue;
        }
    }

    private void Start()
    {
        if (onProgressComplete == null)
        {
            onProgressComplete = new UnityEvent();
        }
        onProgressComplete.AddListener(OnProgressComplete);

        
    }

    private void Update()
    {
        if (start == true)
        {
            CurrentValue += fillMultiplier;
        }
    }

    void OnProgressComplete()
    {
        base.CurrentValue = 0;
        start = false;
    }

}
