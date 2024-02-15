using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BurgerVisual : MonoBehaviour
{
    [Serializable]
    public struct KitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }

    [SerializeField] PlateObject plateObject;
    [SerializeField] private List<KitchenObjectSO_GameObject> kitchenObjectSO_GameObjects;



    private void Start()
    {
        plateObject.OnIngridientAdded += PlateObject_OnIngridientAdded;
    }

    private void PlateObject_OnIngridientAdded(object sender, PlateObject.OnIngridientAddedEventArgs e)
    {
       for(int i=0; i<kitchenObjectSO_GameObjects.Count; i++)
        {
            if (kitchenObjectSO_GameObjects[i].kitchenObjectSO==e.KitchenObjectSO)
            {
                kitchenObjectSO_GameObjects[i].gameObject.SetActive(true);
            }
        }
    }


 
}
