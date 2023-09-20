// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetSlotData : MonoBehaviour
{
    // PetInfo Script ref.
    [SerializeField] private PetInfoBox infoBoxRef;

    // Is the slot open/info displayed.
    public bool slotOpen, infoDisplayed;

    // Collected string pet info, name etc.
    public string petName;

    // Collected int pet info, damage etc.
    public int petDamage;

    /// <summary> method <c>SetData</c> takes info from enemy, uses it for collected pet data. </summary>
    public void SetData(Sprite sprite, Color spriteColour, string petName, int petDamage)
    {
        // Prevents slot from being filled again.
        slotOpen = false;

        // Sets pet sprite.
        GetComponent<Image>().sprite = sprite;
        GetComponent<Image>().color = spriteColour;

        // Sets info gathered from enemyData.
        this.petName = petName;
        this.petDamage = petDamage;

        // Allows use of collected pet button, displays info.
        GetComponent<Button>().enabled = true;
    }

    /// <summary> method <c>CallSetBoxData</c> allows extra data to be set from button press, calls SetBoxData. </summary>
    public void CallSetBoxData()
    {
        // Calls info box method, displays pet stats.
        infoBoxRef.SetBoxData(this);    
    }
}