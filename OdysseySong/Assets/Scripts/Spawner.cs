using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour{

    #region Inspector & Variables

    #region Base Setup

    [Space(10)]
    [Header("Base Setup :")]

    [Space(3)]
    public GameObject spawnerGameObject;

    [Space(3)]
    public GameObject prefabToSpawn;

    [Space(3)]
    public int amountToSpawn;

    #endregion

    #region Rotation

    [Space(10)]
    [Header("Rotation :")]

    [Space(20)]
    public bool useSpawnerRotation = true;

    [Space(3)]
    public Vector3 customRotation;

    #endregion

    #region Spawning Modes

    [Space(10)]
    [Header("Spawning Modes :")]

    [Space(20)]
    [Tooltip("Spawns the Prefabs only once...")]
    public bool onceMode;

    [Space(3)]
    [Tooltip("Spawns the Prefabs infinitely but with pauses in between...")]
    public bool burstMode;

    [Space(3)]
    [Tooltip("Spawns the Prefabs infinitely...")]
    public bool infiniteMode;

    [Space(20)]
    [Tooltip("")]
    public string readThis = "Don't tick more than one Mode !";

    #endregion

    #region Setup Modes

    #region Once Mode

    [Space(10)]
    [Header("Once Mode :")]

    [Space(20)]
    [Tooltip("Sets the delay before the first spawn. 0 for no delay, any number for the desired delay...")]
    public float onceFirstSpawnDelay;

    #endregion

    #region Burst Mode

    [Space(10)]
    [Header("Burst Mode :")]

    [Space(20)]
    [Tooltip("Sets the delay before the first spawn. 0 for no delay, any number for the desired delay...")]
    public float burstFirstSpawnDelay;

    [Space(3)]
    [Tooltip("Sets the delay between each spawning batch...")]
    [Range(0.1f, 600)]
    public float burstSpawningInterval = 0.1f;

    [Space(3)]
    [Tooltip("Sets the delay before the spawner stops working. 0 for a never ending spawning, any number for the desired delay...")]
    public int burstStopTimer;

    #endregion

    #region Infinite Mode

    [Space(10)]
    [Header("Infinite Mode :")]

    [Space(20)]
    [Tooltip("Sets the delay before the first spawn. 0 for no delay, any number for the desired delay...")]
    public float infiniteFirstSpawnDelay;

    [Space(3)]
    [Tooltip("Sets the delay before the spawner stops his spawning. 0 for a never ending spawning, any number for the desired delay...")]
    public int infiniteStopTimer;

    [Space(8)]
    public string ReadCarefully1 = "Watch out for the amount of prefabs spawned !";

    [Space(2)]
    public string ReadCarefully2 = "You can crash Unity if it's too much...";

    #endregion

    #endregion

    #region Debug & Stats

    [Space(10)]
    [Header("Debug & Stats :")]

    [Space(20)]
    public int amountSpawned;

    [Space(3)]
    public int setupErrorsCatched;

    [Space(3)]
    public bool deactivateErrorChecking;

    #endregion

    #endregion

    #region Awake & Start

    private void Awake(){

        #region Read Setup

        ReadCarefully1 = "Watch out for the amount of prefabs spawned !";
        ReadCarefully2 = "You can crash Unity or your pc...";
        readThis = "Don't tick more than one Mode !";

        #endregion

    }

    private void Start(){

        if (!deactivateErrorChecking){

            CheckForSetupErrors();

        }

        if (onceMode && !burstMode && !infiniteMode){

            Invoke("SpawnOnce", onceFirstSpawnDelay);

        }

        if (burstMode && !onceMode && !infiniteMode){

            Invoke("SpawnBurst", burstFirstSpawnDelay);

        }

        if (infiniteMode && !onceMode && !burstMode){

            Invoke("SpawnInfinite", infiniteFirstSpawnDelay);

        }

        if (burstStopTimer > 0){

            Invoke("StopTheBurstSpawn", burstStopTimer);

        }

        if (infiniteStopTimer > 0){

            Invoke("StopTheInfiniteSpawn", infiniteStopTimer);

        }

    }

    #endregion

    #region Spawning

    void SpawnOnce(){

        for (int i = 0; i < amountToSpawn; i++){

            if (useSpawnerRotation){

                Instantiate(prefabToSpawn, spawnerGameObject.transform.position, spawnerGameObject.transform.rotation);
                amountSpawned++;

            }

            if (!useSpawnerRotation){

                Instantiate(prefabToSpawn, spawnerGameObject.transform.position, Quaternion.Euler(customRotation));
                amountSpawned++;

            }

        }

    }

    void SpawnBurst(){

        StartCoroutine("SpawningBurst");

    }

    void SpawnInfinite(){

        StartCoroutine("SpawningInfinite");

    }

    IEnumerator SpawningBurst(){

        for (int i = 0; i < amountToSpawn; i++){

            if (useSpawnerRotation){

                Instantiate(prefabToSpawn, spawnerGameObject.transform.position, spawnerGameObject.transform.rotation);
                amountSpawned++;

            }

            if (!useSpawnerRotation){

                Instantiate(prefabToSpawn, spawnerGameObject.transform.position, Quaternion.Euler(customRotation));
                amountSpawned++;

            }

        }

        yield return new WaitForSeconds(burstSpawningInterval);

        StartCoroutine("SpawnBurst");

    }

    IEnumerator SpawningInfinite(){

        for (int i = 0; i < amountToSpawn; i++){

            if (useSpawnerRotation){

                Instantiate(prefabToSpawn, spawnerGameObject.transform.position, spawnerGameObject.transform.rotation);
                amountSpawned++;

            }

            if (!useSpawnerRotation){

                Instantiate(prefabToSpawn, spawnerGameObject.transform.position, Quaternion.Euler(customRotation));
                amountSpawned++;

            }

        }

        yield return new WaitForSeconds(0.01f);

        StartCoroutine("SpawnInfinite");

    }

    #endregion

    #region Stop Spawning

    void StopTheBurstSpawn(){

        StopCoroutine("SpawningBurst");

    }

    void StopTheInfiniteSpawn(){

        StopCoroutine("SpawningInfinite");

    }

    #endregion

    #region Extras

    void CheckForSetupErrors(){

        if (!spawnerGameObject){

            spawnerGameObject = gameObject;

        }

        if (!onceMode && !burstMode && !infiniteMode){

            Debug.LogError(gameObject.name + " : you have to tick one Spawning mode !");
            setupErrorsCatched++;

        }

        if (onceMode && burstMode && infiniteMode){

            Debug.LogError(gameObject.name + " : you can't have multiple spawning modes ticked at once !");
            setupErrorsCatched++;

        }

        if (onceMode && burstMode && !infiniteMode){

            Debug.LogError(gameObject.name + " : you can't have multiple spawning modes ticked at once !");
            setupErrorsCatched++;

        }

        if (burstMode && infiniteMode && !onceMode){

            Debug.LogError(gameObject.name + " : you can't have multiple spawning modes ticked at once !");
            setupErrorsCatched++;

        }

        if (onceMode && infiniteMode && !burstMode){

            Debug.LogError(gameObject.name + " : you can't have multiple spawning modes ticked at once !");
            setupErrorsCatched++;

        }

        if (amountToSpawn == 0){

            Debug.LogError(gameObject.name + " object isn't setup properly : you can't have '0' as the value of the variable 'amount to spawn'...");
            setupErrorsCatched++;

        }

        if (amountToSpawn < 0){

            amountToSpawn = 0;
            Debug.LogError(gameObject.name + " object isn't setup properly : you can't have a negative value as 'amount to spawn'...");
            setupErrorsCatched++;

        }

        if (spawnerGameObject == null){

            Debug.LogError(gameObject.name + " object isn't setup properly : no spawner has been defined in the editor...");
            setupErrorsCatched++;

        }

        if (prefabToSpawn == null){

            Debug.LogError(gameObject.name + " object isn't setup properly : no prefab to spawn has been defined in the editor...");
            setupErrorsCatched++;
        }

    }

    #endregion

}
