using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScanningMachine : MonoBehaviour
{
    public Collider scanCollider, bagCollider;
    public Transform startPos, respawnPos;

    public Scannable[] scannables;
    public Presentable[] presentables;

    public GallonDisplay gDisplay;

    public int currentScannable = 0;

    public UnityEvent EventOnScan;
    public UnityEvent EventOnBag;


    public bool isPresenting;
    public float timeLeft;

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

        foreach (var p in presentables)
        {
            p.gameObject.SetActive(false);
        }
        scannables[0].transform.position = startPos.position;
        scannables[0].gameObject.SetActive(true);

        scanCollider.gameObject.SetActive(true);
        bagCollider.gameObject.SetActive(false);
        gDisplay.ClearGallons();
    }

    public void NextItem()
    {
        bagCollider.gameObject.SetActive(false);

        scannables[currentScannable].gameObject.SetActive(false);


        if (currentScannable >= scannables.Length)
        {
            Debug.Log("No more items to scan!");
            return;
        }

        currentScannable++;

        scannables[currentScannable].transform.position = startPos.position;
        scannables[currentScannable].gameObject.SetActive(true);

        scanCollider.gameObject.SetActive(true);

    }

    public void Scan()
    {
        EventOnScan.Invoke();
        gDisplay.SetGallons(scannables[currentScannable].gallonsOfWater);
        BeginPresentation();
    }

    public void Bag()
    {
        gDisplay.ClearGallons();
        presentables[currentScannable].gameObject.SetActive(false);
        EventOnBag.Invoke();
        NextItem();
    }

    void BeginPresentation()
    {
        scanCollider.gameObject.SetActive(false);

        if (currentScannable >= presentables.Length)
        {
            Debug.LogWarning("No Presentable for currentScannable index!");
            return;
        }

        presentables[currentScannable].gameObject.SetActive(true);
        isPresenting = true;
    }

    void EndPresentation()
    {
        
        isPresenting = false;
        bagCollider.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (!isPresenting)
            return;

        if (!presentables[currentScannable].isPresenting){
            EndPresentation();
        }
    }
}
