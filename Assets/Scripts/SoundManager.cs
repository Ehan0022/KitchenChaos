using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipsSO audioClipsSO;
    [SerializeField] private DeliveryCounter deliveryCounter;
    [SerializeField] private CutCounter cutCounter;
    [SerializeField] private Player player;
    [SerializeField] private TrashCounter trashCounter;
    [SerializeField] private CookingCounter cookingCounter;
    [SerializeField] private PlayerSound playerSound;
    
    

    private void Start()
    {
        deliveryCounter.OnOrderDeliveryFailDeliveryCounter += DeliveryCounter_OnOrderDeliveryFail;
        cutCounter.OnCut += CutCounter_OnCut;
        player.OnKitchenObjectPickedUp += Player_OnKitchenObjectPickedUp;
        BaseCounter.OnAnyObjectPlacedBaseCounter += BaseCounter_OnAnyObjectPlacedBaseCounter;
        trashCounter.OnObjectPutToTrash += TrashCounter_OnObjectPutToTrash;
        cookingCounter.OnCookableObjectPlaced += CookingCounter_OnCookableObjectPlaced;
        playerSound.OnFootStepOccured += PlayerSound_OnFootStepOccured;
        PlateObject.OnIngridientAddedSound += PlateObject_OnIngridientAddedSound;
    }

    //plate object start
    private void PlateObject_OnIngridientAddedSound(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsSO.objecDrop, Camera.main.transform.position);
    }
    //plate object end

    [SerializeField] GameObject StoveSound;
    private void CookingCounter_OnCookableObjectPlaced(object sender, CookingCounter.OnCookableObjectPlacedEventArgs e)
    {
        StoveSound.SetActive(e.thereIsCookableObjectOnTop);
    }

    //trash counter start
    private void TrashCounter_OnObjectPutToTrash(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsSO.trash, Camera.main.transform.position);
    }
    //trash counter end

    //base counter start
    private void BaseCounter_OnAnyObjectPlacedBaseCounter(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsSO.objecDrop, Camera.main.transform.position);
    }
    //base counter end

    //player start
    private void Player_OnKitchenObjectPickedUp(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsSO.ObjectPickup, Camera.main.transform.position);
    }

    private void PlayerSound_OnFootStepOccured(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsSO.footstep, Camera.main.transform.position, 0.2f);
    }

    //player end

    //delivery start
    private void DeliveryCounter_OnOrderDeliveryFail(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsSO.deliveryFail, Camera.main.transform.position);
    }
    public void DeliveryCounterOnOrderDeliveryFailSound()
    {
        PlaySound(audioClipsSO.deliveryFail, Camera.main.transform.position);
    }
    public void DeliveryCounterOnOrderDeliverySuccessSound()
    {
        PlaySound(audioClipsSO.deliverySucess, Camera.main.transform.position);
    }
    //delivery end

    //cutting counter start
    private void CutCounter_OnCut(object sender, System.EventArgs e)
    {
        PlaySound(audioClipsSO.chop, Camera.main.transform.position);
    }
    //cutting counter end


    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 0.5f)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[Random.Range(0, audioClipArray.Length)], position, volume);
    }
    
    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 0.5f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
