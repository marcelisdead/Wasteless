using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GallonDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject textCanvas;

    public void SetGallons(int numberGallons)
    {
        textCanvas.SetActive(true);
        text.text = numberGallons.ToString();
    }

    public void ClearGallons()
    {
        textCanvas.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
