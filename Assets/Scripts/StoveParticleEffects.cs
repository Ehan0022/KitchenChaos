using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveParticleEffects : MonoBehaviour
{
    [SerializeField] CookingCounter cookingCounter;
    [SerializeField] GameObject particlesAndStoveVisual;

    private void Start()
    {
        cookingCounter.OnCookableObjectPlaced += CookingCounter_OnCookableObjectPlaced;
    }

    private void CookingCounter_OnCookableObjectPlaced(object sender, CookingCounter.OnCookableObjectPlacedEventArgs e)
    {
        particlesAndStoveVisual.SetActive(e.thereIsCookableObjectOnTop);
    }
}
