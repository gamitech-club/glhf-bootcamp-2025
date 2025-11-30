using UnityEngine;

public class TestDebugLog : MonoBehaviour
{
    #if UNITY_EDITOR
    [UnityEditor.MenuItem("Tools/Test Debug Log")]
    private static void DebugLogs()
    {
        Debug.Log("Ini adalah log informasi.");
        Debug.LogWarning("Ini adalah log warning.");
        Debug.LogError("Ini adalah log error.");
    }
    #endif
}
