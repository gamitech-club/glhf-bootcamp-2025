using UnityEngine;
using UnityEngine.InputSystem;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject Prefab;

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            GameObject obj = Instantiate(Prefab, Vector2.zero, Quaternion.identity);
            print($"Spawn: {obj.name}");
        }
    }
}
