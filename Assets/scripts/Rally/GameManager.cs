using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> checkpointBlocks; // создаём список из checkpoint - ов

    public Text textCircle;
    public int nextCheckpointIndex = 0;
    public int completedCircles = 0;

    public CarMovementLight playerScript;
    public GameObject winScreen;

    private void Start() {
        winScreen.gameObject.SetActive(false);
    }


    private void Update() {
        textCircle.text = "ROUND: " + completedCircles;
    }

    public void CheckpointReached(GameObject checkpointBlock) {
        if (checkpointBlocks[nextCheckpointIndex] == checkpointBlock) {
            checkpointBlock.GetComponent<Renderer>().material.color = Color.green;
            nextCheckpointIndex++;
            Debug.Log(nextCheckpointIndex);
        }
    }

    public void FinishLineReached(GameObject finishBlock) {

        if (nextCheckpointIndex == checkpointBlocks.Count) {
            //finishBlock.GetComponent<Collider>().isTrigger = false;
            finishBlock.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log(finishBlock.name);

            completedCircles++;
            StartCoroutine(timer(0.5f, finishBlock));

            if (completedCircles >= 3) {
                Time.timeScale = 0f;
                winScreen.gameObject.SetActive(true);
            }
        }
    }

    private void ResetCheckpoints(GameObject finish) {
        foreach (GameObject block in checkpointBlocks) {
            block.GetComponent<Renderer>().material.color = Color.white;
        }
        finish.GetComponent<Renderer>().material.color = Color.white;

        nextCheckpointIndex = 0;
    }

    public void RestartGame() {
        Time.timeScale = 1f;
        winScreen.gameObject.SetActive(false);
        playerScript.ResetToStartPosition();
        completedCircles = 0;
    }

    IEnumerator timer(float time, GameObject block) {
        yield return new WaitForSeconds(time);
        ResetCheckpoints(block);
        //block.GetComponent<Collider>().isTrigger = true;
    }
}