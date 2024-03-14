using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] Transform spawnPoint;
    public KitchenObject kitchenObjectOnTop;
    public static event EventHandler OnAnyObjectPlacedBaseCounter;


    public static void ResetStaticData()
    {
        OnAnyObjectPlacedBaseCounter = null;
    }



    public virtual void Interact(Player player)
    {

    }
    public virtual void InteractAlternate(Player player)
    {

    }

    public Transform returnSpawnPoint()
    {
        return spawnPoint;
    }

    public void setKitchenObject(KitchenObject kitchenObject)
    {
        kitchenObjectOnTop = kitchenObject;
        if(kitchenObject!=null)
            OnAnyObjectPlacedBaseCounter?.Invoke(this, EventArgs.Empty);
    }

    public KitchenObject getKitchenObject()
    {
        return kitchenObjectOnTop;
    }

    public void ClearKitchenObjectOnTop()
    {
        kitchenObjectOnTop = null;
    }

    public bool HasKitchenObject()
    {
        return (kitchenObjectOnTop != null);
    }
}
