using UnityEngine;

public static class GameControler
{
    private static int collectedCount;
    
    public static bool gameOver
    {
        get
        {
            return collectedCount <= 0;
        }
    }

    public static void Init()
    {
        collectedCount = 4;
    }

    public static void Collect()
    {
        collectedCount--;
        if (collectedCount < 0)
        {
            collectedCount = 0;
        }
    }
}
