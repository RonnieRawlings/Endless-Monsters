// Author - Ronnie Rawlings.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    /// <summary> method <c>SetPlayerAndEnemyRefs</c> enables the player/enemy objs & sets the static refs. </summary>
    public void SetPlayerAndEnemyRefs()
    {
        // Enables player/enemy sprites
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(3).gameObject.SetActive(true);

        // Sets refs in static management, easier access.
        StaticManagement.playerRef = transform.GetChild(2).gameObject;
        StaticManagement.enemyRef = transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // Enables player/enemy sprites on Game Start.
        if (StaticManagement.newGameBegun)
        {
            SetPlayerAndEnemyRefs();
        }
    }
}
