using UnityEngine;

public class ComponentUsingScriptableObject : MonoBehaviour
{
    //Reference to the scriptable object we create in the assets folder
    public ScriptableObject_SO scriptableObject;

    //create an index variable to keep track fo which prefab we are on
    int currentPrefabIndex = 0;

    //create a variable for the spawn delay that can be modified by time and reset
    float delayTime = 0;

    private void Start()
    {
        //Once the scene starts set teh variable created above to the spawn delay
        //set from the scriptable object
        delayTime = scriptableObject.spawnDelay;
    }

    private void Update()
    {
        //Check to see if the boolean on the scriptable object canSpawn is true
        if(scriptableObject.canSpawn == true)
        {
            //Check if the current index of prefabs is less than the amount of prefabs set to spawn
            if (currentPrefabIndex < scriptableObject.amountOfPrefabs)
            {
                //count down from the number set on the delay timer by delta time so that it is frame independent
                delayTime -= Time.deltaTime;
                //once the delay timer hits zero
                if(delayTime < 0f)
                {
                    //instantiate the next prefab and reset the delay timer for the next prefab spawn
                    InstantiatePrefab();
                    delayTime = scriptableObject.spawnDelay;
                }
            }
        }
    }

    void InstantiatePrefab() 
    {
        //Create a variable of GameObject to keep as a reference / Then spawn the prefab from the 
        //scriptable object at zero, no rotation, and parent it to the GameObject holding this script
        GameObject go = Instantiate(scriptableObject.prefab, Vector3.zero, Quaternion.identity, transform);

        //Create an integer variable to use as a random index from the prefab names on the scriptable object
        //It is set random from zero to the max length of names in the array from the scriptable object
        //Rename the newly spawned GameObject from the list of names
        int randomNameIndex = Random.Range(0, scriptableObject.prefabName.Length);
        go.name = scriptableObject.prefabName[randomNameIndex];


        //Get a reference to the instantiated or spawned GameObject
        //Check if the prefab has a rigidbody component
        //Then push it with addforce to move it from it's spawn position at the 
        //speed set in the scriptable object
        Rigidbody rb = go.GetComponent<Rigidbody>();
        if (rb != null) rb.AddForce(Vector3.forward * scriptableObject.speed, ForceMode.Impulse);
        else Debug.Log("Prefab: " + go.name + "has no RigidBody Component attached. Please set one to the prefab" +
            "then try again");

        //Increment the index of prefabs after making sure all code is run for the currently spawned prefab object
        currentPrefabIndex++;
    }
}
