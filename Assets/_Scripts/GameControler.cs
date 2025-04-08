using UnityEngine;

public static class GameControler
{
    private static int collectedCount;
    private static bool ReporterCaptured;


    public static bool gameOver
    {
        get
        {
            return collectedCount <= 0;
        }
    }
    public static bool CapturedReporter
    {
        get
        {
            return  ReporterCaptured;
        }
    }

    public static void Init()
    {
        collectedCount = 4;
        ReporterCaptured = false;
        TriangleMissing.Instance?.UpdateText();
    }

    public static void Collect()
    {
        collectedCount--;
        if (collectedCount < 0)
        {
            collectedCount = 0;
        }

        TriangleMissing.Instance?.UpdateText();
    }
    public static void CaptureReporter()
    {
        ReporterCaptured = true;
        
    }

    public static int GetRemaining()
    {
        return collectedCount;
    }
}
