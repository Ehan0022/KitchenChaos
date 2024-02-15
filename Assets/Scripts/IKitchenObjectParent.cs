using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParent 
{
    public Transform returnSpawnPoint();


    public void setKitchenObject(KitchenObject kitchenObject);



    public KitchenObject getKitchenObject();



    public void ClearKitchenObjectOnTop();


    public bool HasKitchenObject();
    
}
