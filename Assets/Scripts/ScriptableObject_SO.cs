using UnityEngine;

//Editor tool to allow the creation of the scriptable objects
[CreateAssetMenu(fileName = "New Scriptable Object", menuName = "Scriptable Object")]
public class ScriptableObject_SO : ScriptableObject //Derive from scriptable object instead of monobehavior to utiliize the features built in
{
    public GameObject prefab; //Prefab object sitting in the Assets to be called for use later
    public int amountOfPrefabs; //integer value to use in another script to call how many prefabs to call
    public float spawnDelay; //Floating point value to delay each spawn
    public float speed; //Floating point value to use for the prefab being spawned into the scene
    public bool canSpawn; //Boolean value to determine whether we call the instantiation of the prefab/s
    public string[] prefabName; //Array of string values to set the name of the prefab on instantiation
}
