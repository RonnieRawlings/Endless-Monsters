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

    #endregion
}
