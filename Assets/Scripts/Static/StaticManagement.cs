// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticManagement
{
    #region Start Game Values

    // Starting objs enable on this bool being switched.
    public static bool newGameBegun = false;

    #endregion

    #region Object References

    // Refs to each sprite gameObj position.
    public static GameObject playerRef, enemyRef;

    // Player options ref.
    public static GameObject playerOptionsRef;

    // Active pet slots.
    public static List<GameObject> activePetSlots;

    // Pet collection slots ref.
    public static PetSlotData[] petSlotsRef;

    #endregion

    #region Enemy Resource Loads

    // Holds loaded enemy variants, different level arrays.
    public static GameObject[] lowLevelEnemies, midLevelEnemies, highLevelEnemies;

    #endregion

    /// <summary> constructor <c>StaticManagement</c> Fills variables before first update. </summary>
    static StaticManagement()
    {
        lowLevelEnemies = Resources.LoadAll<GameObject>("Prefabs/Enemies/Low Variants");
    }

    /// <summary> static method <c>ChangeEnemies</c> Updates the current loaded enemy + changes the reference. </summary>
    public static IEnumerator ChangeEnemies(float waitTime)
    {             
        // Wait specified time before changing enemies.
        yield return new WaitForSeconds(waitTime);

        // Captures enemy if an open slot is available.
        if (enemyRef.name != "BaseEnemy") { CheckForOpenPetSlot(); }

        // Get a random index from lowLevelEnemies array
        int randomIndex = UnityEngine.Random.Range(0, lowLevelEnemies.Length);

        // Get the position, rotation, and parent of the current enemy
        Vector3 position = enemyRef.transform.position;
        Quaternion rotation = enemyRef.transform.rotation;
        Transform parent = enemyRef.transform.parent;

        // Destroy the current enemy
        GameObject.Destroy(enemyRef);

        // Instantiate a new low level enemy at the position and rotation of the old enemy
        enemyRef = GameObject.Instantiate(lowLevelEnemies[randomIndex], position, rotation);
        enemyRef.name = enemyRef.name.Split("(Clone)")[0];

        // Set the parent of the new enemy to be the same as the old enemy
        enemyRef.transform.SetParent(parent);
    }

    /// <summary> static method <c>CheckForOpenPetSlot</c> finds the first open pet slot, fills it with current enemy data. </summary>
    public static void CheckForOpenPetSlot()
    {
        // Searches all slot refs for an open on.
        PetSlotData openSlot = null;
        foreach (PetSlotData petSlot in petSlotsRef)
        {
            // Pet already collected, don't collect again.
            if (petSlot.petName == enemyRef.gameObject.name) { break; }

            // Sets openSlot, ends loop.
            if (petSlot.slotOpen) 
            {
                openSlot = petSlot;
                break;
            }
        }

        // Prevents ref error.
        if (openSlot == null) { return; }

        // Sets open pet slot data.
        EnemyData enemyData = enemyRef.GetComponent<EnemyData>();
        openSlot.SetData(enemyData.gameObject.GetComponent<UnityEngine.UI.Image>().sprite, enemyData.gameObject.GetComponent<UnityEngine.UI.Image>().color, 
            enemyData.gameObject.name, (int)enemyData.enemyBasicDamage);
    }
}
