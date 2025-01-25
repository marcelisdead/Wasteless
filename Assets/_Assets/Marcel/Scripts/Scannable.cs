using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Scannable : MonoBehaviour
{
    public bool isScanned;

    public int gallonsOfWater  = 1;

    public UnityEvent EventOnScan;
    public UnityEvent EventOnBag;

    private void OnTriggerEnter(Collider other)
    {
        if (!isScanned)
        {
            if(other == ScanningMachine.Instance.scanCollider)
            {
                isScanned = true;
                EventOnScan.Invoke();
                ScanningMachine.Instance.Scan();
            }
        }
        else
        {
            if(other == ScanningMachine.Instance.bagCollider)
            {
                EventOnBag.Invoke();
                ScanningMachine.Instance.Bag();
            }
        }
    }
}
