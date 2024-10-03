using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] GameObject startCutscene;
    [SerializeField] GameObject endGameCutscene;
    [SerializeField] GameObject gameOverCutscene;

    private void OnEnable()
    {
        Observer.onDeath += PlayGameOverCutscene;
        Observer.spawnPlayer += EndGameOverCutscene;
    }

    private void OnDisable()
    {
        Observer.onDeath -= PlayGameOverCutscene;
        Observer.spawnPlayer -= EndGameOverCutscene;
    }

    public void SetGameOverCutscene(GameObject cutscene)
    {
        gameOverCutscene = cutscene;
    }

    private void PlayGameOverCutscene()
    {
        gameOverCutscene.SetActive(true);
    }

    private void EndGameOverCutscene()
    {
        gameOverCutscene.SetActive(false);
    }
}
