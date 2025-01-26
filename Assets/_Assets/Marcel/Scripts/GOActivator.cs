using System.Collections;
using UnityEngine;

public class GOActivator : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Array of objects to activate
    public float totalTime = 5f; // Total duration to complete activation
    public AnimationCurve activationCurve = AnimationCurve.EaseInOut(0, 1, 1, 0); // Curve for timing

    private void OnEnable()
    {
        foreach (var go in objectsToActivate)
        {
            go.SetActive(false);
        }

        if (objectsToActivate.Length > 0)
        {
            StartCoroutine(ActivateObjects());
        }
    }

    private IEnumerator ActivateObjects()
    {
        int count = objectsToActivate.Length;

        for (int i = 0; i < count; i++)
        {
            objectsToActivate[i].SetActive(true);
            float curveTime = activationCurve.Evaluate((float)i / (count - 1)); // Get delay from curve
            float delay = totalTime * curveTime / count; // Scale by total time
            objectsToActivate[i].transform.parent = null;
            yield return new WaitForSeconds(delay);
        }

        
    }
}
