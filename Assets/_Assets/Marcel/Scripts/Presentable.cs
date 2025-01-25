using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Presentable : MonoBehaviour
{
    public bool isPresenting;

    public List<PresentationStep> presentationSteps;

    private int currentStepIndex = 0;
    private float stepTimer = 0f;

    private void OnEnable()
    {
        isPresenting = true;
        currentStepIndex = 0;
        stepTimer = 0f;

        if (presentationSteps.Count > 0)
        {
            presentationSteps[currentStepIndex].Step.Invoke();
            stepTimer = presentationSteps[currentStepIndex].time;
        }
        else
        {
            isPresenting = false;
        }
    }

    //go one at a time through the steps playing the first one then waiting the amount of time
    //when done isPresenting is set to false
    private void Update()
    {
        if (!isPresenting)
            return;

        // Check if we’ve finished all steps
        if (currentStepIndex >= presentationSteps.Count)
        {
            isPresenting = false;
            return;
        }

        // Countdown the step timer
        stepTimer -= Time.deltaTime;

        // Move to the next step if needed
        if (stepTimer <= 0)
        {
            if (currentStepIndex < presentationSteps.Count - 1)
            {
                currentStepIndex++;
                presentationSteps[currentStepIndex].Step.Invoke();
                stepTimer = presentationSteps[currentStepIndex].time;
            }
            else
            {
                isPresenting = false; // Done presenting
            }
        }
    }

    public float TotalTime()
    {
        float total = 0;

        foreach( var p in presentationSteps)
        {
            total += p.time;
        }

        return total;
    }

    [System.Serializable]
    public class PresentationStep
    {
        public float time;
        public UnityEvent Step;
    }
}
