using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseManager : MonoBehaviour
{
    [System.Serializable]
    public class Phase
    {
        public GameObject objectToSpawn;
        public int spawnCount;
        public float phaseSpawnInterval;
        public string phaseText;  // Text to display when the phase starts
    }

    public Phase[] phases;
    public Transform[] spawnPoints;
    public Text phaseTextUI;  // Reference to the Text UI element

    private int currentPhaseIndex = 0;
    private int spawnedCount = 0;
    private Coroutine spawnCoroutine;
    private Coroutine textDisplayCoroutine;

    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (currentPhaseIndex < phases.Length)
        {
            Phase currentPhase = phases[currentPhaseIndex];
            GameObject chosenObject = currentPhase.objectToSpawn;
            phaseTextUI.text = currentPhase.phaseText;

            if (textDisplayCoroutine != null)
            {
                StopCoroutine(textDisplayCoroutine);
            }
            textDisplayCoroutine = StartCoroutine(DisplayPhaseText(currentPhase.phaseText));

            for (int i = 0; i < currentPhase.spawnCount; i++)
            {
                int randomSpawnIndex = Random.Range(0, spawnPoints.Length);
                Transform chosenSpawnPoint = spawnPoints[randomSpawnIndex];

                Instantiate(chosenObject, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
                spawnedCount++;
                yield return new WaitForSeconds(currentPhase.phaseSpawnInterval);
            }

            currentPhaseIndex++;

            if (currentPhaseIndex < phases.Length)
            {
                yield return new WaitForSeconds(phases[currentPhaseIndex].phaseSpawnInterval);
            }
        }
    }

    private IEnumerator DisplayPhaseText(string text)
    {
        phaseTextUI.gameObject.SetActive(true);
        phaseTextUI.text = text;
        yield return new WaitForSeconds(1f); // Display the text for 1 second
        phaseTextUI.text = "";
        phaseTextUI.gameObject.SetActive(false);
    }

    public void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }

    private void OnDisable()
    {
        spawnedCount = 0;
        currentPhaseIndex = 0;
    }
}
