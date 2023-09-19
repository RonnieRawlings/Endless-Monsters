// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetSlotData : MonoBehaviour
{
    // Is the slot open.
    public bool slotOpen;

    // Collected string pet info, name etc.
    public string petName;

    // Collected int pet info, damage etc.
    public int petDamage;

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
    }
}
