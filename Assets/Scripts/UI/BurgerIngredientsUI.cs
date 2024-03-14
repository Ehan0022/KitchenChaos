using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BurgerIngredientsUI : MonoBehaviour
{
    [SerializeField] List<KitchenObjectSO_GameObject> Icons_KitchenObjectSO = new List<KitchenObjectSO_GameObject>();
    [SerializeField] PlateObject plateObject;

    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    private void Start()
    {
        plateObject.OnIngridientAdded += PlateObject_OnIngridientAdded;

    }

    private void PlateObject_OnIngridientAdded(object sender, PlateObject.OnIngridientAddedEventArgs e)
    {       
        for(int i=0; i<Icons_KitchenObjectSO.Count; i++)
        {
            if(plateObject.GetIngridientsOnThePlate().Contains(Icons_KitchenObjectSO[i].kitchenObjectSO))
            {
                Icons_KitchenObjectSO[i].gameObject.SetActive(true);
            }
        }
    }


}
