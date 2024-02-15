using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{

    [SerializeField] GameObject[] plates;

    [SerializeField] PlatesCounter platesCounter;

    private void Start()
    {
        platesCounter.OnPlateAmountChanged += PlatesCounter_OnPlateAmountChanged;
    }

    private void PlatesCounter_OnPlateAmountChanged(object sender, PlatesCounter.OnPlateAmountChangedEventArgs e)
    {
        int maxPlates = 4;

        // Loop through all the plates and set their active state
        for (int i = 0; i < maxPlates; i++)
        {
            // Activate plates up to e.plateAmount, deactivate the rest
            if (i < e.plateAmount)
            {
                plates[i].SetActive(true);
            }
            else
            {
                plates[i].SetActive(false);
            }
        }
    }
}
