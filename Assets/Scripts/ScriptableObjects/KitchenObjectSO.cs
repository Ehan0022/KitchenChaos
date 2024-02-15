using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject
{
    public string objectName;
    public Sprite sprite;
    public Transform prefab;
    public bool sliceable;
    public bool canBeCookedFurther;
    public int maxSlices;

}
