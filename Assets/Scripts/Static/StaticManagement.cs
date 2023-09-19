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

    /// <summary> method <c>ChangeEnemies</c> Updates the current loaded enemy + changes the reference. </summary>
    public static IEnumerator ChangeEnemies(float waitTime)
    {
        // Wait specified time before changing enemies.
        yield return new WaitForSeconds(waitTime);

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

        // Set the parent of the new enemy to be the same as the old enemy
        enemyRef.transform.SetParent(parent);
    }
}
