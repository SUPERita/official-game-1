using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] DeathScreen deathScreen;
    [SerializeField] Canvas canvasUI;
    [SerializeField] Score score;
    [SerializeField] ShopCanvas shopCanvas;
    [SerializeField] Cash cash;
    //[SerializeField] Transform floor;

    [Header("effects")]
    [SerializeField] ParticleSystem deathExplosion;

    [Header("stuff for restarting")]
    [SerializeField] GameObject[] courses;
    [SerializeField] GameObject startingPos;
    [SerializeField] PlayerMovement playerPM;

    private bool PlayerAlive = true;
    private Queue<GameObject> usedCourses = new Queue<GameObject>(); // not sure if really needed
    [SerializeField] float coursePlacementDistance = 40f;
    [SerializeField] float coursePlacementTime = 4f;
    private float distanceIndex = 0f;
    private float startingDistanceIndex;

    //private int cash = 0;
    private bool hasExplosion = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartGame();
        startingDistanceIndex = distanceIndex;
    }

    public void StartGame()
    {
        //also show player
        DestroyAllCourses();
        playerPM.gameObject.transform.position = startingPos.transform.position;
        score.Reset();
        score.YesAlive();
        deathScreen.FadeOut();
        playerPM.enabled = true;
        canvasUI.enabled = true;
        playerPM.Respawn();
        PlayerAlive = true;

        StopCoroutine("SummonCourse");
        StartCoroutine("SummonCourse");

        Invoke("UseShopItems", 0.01f);

    }

    private void UseShopItems()
    {
        if (Data.Instance.playerMaterial != null)
        {
            playerPM.gameObject.GetComponent<MeshRenderer>().material = Data.Instance.playerMaterial;
            Debug.Log("used data-PlayerMat");
        }
        if (Data.Instance.playerExplosion != null)
        {
           hasExplosion = Data.Instance.playerExplosion;
        }

    }




    public void PlayerDied()
    {
        //vfx
        if (hasExplosion)
        {
            Instantiate(deathExplosion, playerPM.transform.position, Quaternion.identity);
        }

        canvasUI.enabled = false;
        deathScreen.FadeIn();
        score.NotAlive();
        PlayerAlive = false;
        distanceIndex = startingDistanceIndex;
    }

    IEnumerator SummonCourse()
    {
        playerPM.SpeedUp();
        int i = UnityEngine.Random.Range(0, courses.Length);
        //Vector3 playerPos = playerPM.gameObject.transform.position;
        //make courses delete themselfs after the player passes them
        distanceIndex += coursePlacementDistance;
        Vector3 spawnCoursePosition = new Vector3(0f, 0f, distanceIndex);

        GameObject tmp = Instantiate(courses[i], spawnCoursePosition, Quaternion.identity);
        usedCourses.Enqueue(tmp);
        yield return new WaitForSeconds(coursePlacementTime);
        if (PlayerAlive)
        {
            StartCoroutine("SummonCourse");
        }
    }

    private void DestroyAllCourses()
    {
        while(usedCourses.Count != 0)
        {
            GameObject tmp = usedCourses.Dequeue();
            Destroy(tmp);
        }
    }




    public Transform GetPlayerTransform()
    {
        return playerPM.transform;
    }

    public void GoToShopCanvas()
    {
        deathScreen.GetComponent<Canvas>().enabled = false;
        shopCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void GoToDeathCanvas()
    {
        deathScreen.GetComponent<Canvas>().enabled = true;
        shopCanvas.GetComponent<Canvas>().enabled = false;
    }

    public int GetCash()
    {
        return cash.GetCash();
    }

    public void AddCash(int amount)
    {
        cash.Add(amount);
    }

    public void TakeCash(int amount)
    {
        cash.Take(amount);
    }

}
