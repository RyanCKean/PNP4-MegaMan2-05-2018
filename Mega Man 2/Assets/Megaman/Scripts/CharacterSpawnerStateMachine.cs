using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/*--------------------------------------------------------------
 * Name: Nathan Geno
 * Date: 1/15/18
 * Credit: Project and Portfolio 4 - MegaMan 2 group project
 * Purpose: Create Character Spawner State Machine
 * ------------------------------------------------------------*/

public class CharacterSpawnerStateMachine : MonoBehaviour
{
    private GameObject spawnedCharacter;
    private CharacterSpawner characterSpawner;

    [SerializeField] bool isAlive = false;

    Dictionary<CharacterSpawnerStates, Action> cssm = new Dictionary<CharacterSpawnerStates, Action>();

    enum CharacterSpawnerStates
    {
        ON,
        OFF
    }

    private CharacterSpawnerStates currentState = CharacterSpawnerStates.OFF;

    void SetState(CharacterSpawnerStates newState)
    {
        currentState = newState;
    }

    // Use this for initialization
    void Start()
    {
        characterSpawner = GetComponent<CharacterSpawner>();

        cssm.Add(CharacterSpawnerStates.ON, new Action(OnState));
        cssm.Add(CharacterSpawnerStates.OFF, new Action(OffState));
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log(isAlive);
        characterSpawner.SpawnDistance = characterSpawner.MainCamera.transform.position.x - gameObject.transform.position.x;

        cssm[currentState].Invoke();
    }

    void OnState()
    {   
      //  Debug.Log("On");


        if (characterSpawner.CameraCanSee == true && isAlive == false)
        {
            spawnedCharacter = Instantiate(characterSpawner.Character, transform.position, transform.rotation);
            spawnedCharacter.transform.parent = gameObject.transform;
            //spawnedCharacter = characterSpawner.Character;
            //characterSpawner.Character.name = "Enemy " + spawnedCharacter + transform.position;
            isAlive = true;
            SetState(CharacterSpawnerStates.OFF);
        }
    }

    void OffState()
    {
      //  Debug.Log("Off");

        //GameObject newEnemy = GameObject.Find("Enemy " + transform.position + "(Clone)");
        if (gameObject.transform.Find(characterSpawner.Character.name + "(Clone)") == null)
        {
            isAlive = false;
           // Debug.Log(characterSpawner.Character.name);
        }
        else
            isAlive = true;


        if (characterSpawner.SpawnDistance >= 12 || characterSpawner.SpawnDistance <= -12)
        {
            characterSpawner.CameraCanSee = false;
        }

        if (characterSpawner.CameraCanSee == false && isAlive == false)
        {
            if (characterSpawner.SpawnDistance <= 11 && characterSpawner.SpawnDistance >= -11)
            {
                characterSpawner.CameraCanSee = true;
                SetState(CharacterSpawnerStates.ON);
            }
        }
    }
}
