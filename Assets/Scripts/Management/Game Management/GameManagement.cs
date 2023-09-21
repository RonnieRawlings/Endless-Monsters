// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public bool alreadyCalled = false;

    /// <summary> method <c>SetStaticRefs</c> enables the player/enemy objs & sets the static refs. </summary>
    public void SetStaticRefs()
    {
        // Enables player/enemy sprites

        transform.Find("ActivePets").gameObject.SetActive(true);
        transform.Find("Player").gameObject.SetActive(true);
        transform.Find("BaseEnemy").gameObject.SetActive(true);
        
        // Sets refs in static management, easier access.
        StaticManagement.playerRef = transform.Find("Player").gameObject;
        StaticManagement.enemyRef = transform.Find("BaseEnemy").gameObject;
        StaticManagement.playerOptionsRef = transform.parent.Find("PlayerUI").Find("PlayerOptions").gameObject;

        // Enable PlayerUI Panel.
        transform.parent.Find("PlayerUI").gameObject.SetActive(true);

        // Sets reference to all pet slots.
        GameObject petCollection = transform.parent.Find("PlayerUI").Find("PetCollection").gameObject;
        List<PetSlotData> slotData = new List<PetSlotData>();
        foreach (Transform petShadow in petCollection.transform)
        {
            // Prevents first child from being selected.
            if (petShadow.name != "Title")
            {
                slotData.Add(petShadow.GetComponent<PetSlotData>());
            }           
        }

        // Convert list, assign to array ref.
        StaticManagement.petSlotsRef = slotData.ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        // Enables player/enemy sprites on Game Start.
        if (StaticManagement.newGameBegun && !alreadyCalled)
        {
            SetStaticRefs();
            alreadyCalled = true;            
        }     
    }
}