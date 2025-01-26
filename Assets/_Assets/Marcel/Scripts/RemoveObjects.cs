using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remove : MonoBehaviour
{
    public List<GameObject> remove1;
    public List<GameObject> remove2;
    public List<GameObject> remove3;

    public void Remove1() {
        foreach(var a in remove1)
        {
            a.SetActive(false);
        }
    }

    public void Remove2()
    {
        foreach (var b in remove2)
        {
            b.SetActive(false);
        }
    }

    public void Remove3()
    {
        foreach (var c in remove3)
        {
            c.SetActive(false);
        }
    }

}
