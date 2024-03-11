using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlateObject : KitchenObject
{
    [SerializeField] List<KitchenObjectSO> validIngredients;

     public List<KitchenObjectSO> ingredientsSO = new List<KitchenObjectSO>();

     public event EventHandler <OnIngridientAddedEventArgs> OnIngridientAdded;
     public static event EventHandler OnIngridientAddedSound;

    public class OnIngridientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO KitchenObjectSO;
    }

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if(!validIngredients.Contains(kitchenObjectSO))
        {
            //not a valid object
            return false;
        }
        if (ingredientsSO.Contains(kitchenObjectSO))
        {
            //already has this type
            return false;
        }
        else
        {
            ingredientsSO.Add(kitchenObjectSO);
            OnIngridientAdded?.Invoke(this, new OnIngridientAddedEventArgs { KitchenObjectSO = kitchenObjectSO }) ;
            OnIngridientAddedSound?.Invoke(this, EventArgs.Empty);
            return true;
        }
    }

    public List<KitchenObjectSO> GetIngridientsOnThePlate()
    {
        return ingredientsSO;
    }
}
