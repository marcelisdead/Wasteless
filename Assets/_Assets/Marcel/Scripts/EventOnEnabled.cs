using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventOnEnabled : MonoBehaviour
{
    public UnityEvent OnEnableEvent;
    // Start is called before the first frame update
    void OnEnable()
    {
        OnEnableEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
