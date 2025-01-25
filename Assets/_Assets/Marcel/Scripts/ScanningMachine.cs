using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScanningMachine : MonoBehaviour
{
    public Collider scanCollider, bagCollider;
    public Transform startPos, respawnPos;

    public Scannable[] scannables;
    public Transform[] presentables;

    public int currentScannable = 0;

    public UnityEvent EventOnScan;
    public UnityEvent EventOnBag;

    public static ScanningMachine Instance;
    private void Awake()
    {
     if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
     foreach(var s in scannables)
        {
            s.gameObject.SetActive(false);
        }
        scannables[0].transform.position = startPos.position;
        scannables[0].gameObject.SetActive(true);
    }

    public void NextItem()
    {
        scannables[currentScannable].gameObject.SetActive(false);
        currentScannable++;

        scannables[currentScannable].transform.position = startPos.position;
        scannables[currentScannable].gameObject.SetActive(true);
    }

    public void Scan()
    {
        //presentables[currentScannable].gameObject.SetActive(true);
        EventOnScan.Invoke();
    }

    public void Bag()
    {
        EventOnBag.Invoke();
        NextItem();
    }
}
