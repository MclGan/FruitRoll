using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slots : MonoBehaviour
{
    [SerializeField] private Reel[] reel;
    [SerializeField] private Text scoreText;
    private int ScoreSum;
    private bool startSpin;

    #region consts
    private const int minVisibleIndex = -400;
    private const int maxVisibleIndex = 400;
    private const int defaultBetScore = 10;
    #endregion

    #region private methods
    private void Start()
    {
        startSpin = false;
        ScoreSum = 0;
        scoreText.text = ScoreSum.ToString();
    }

    private IEnumerator Spinning()
    {
        foreach (Reel spinner in reel)
        {
            spinner.spin = true;
        }

        List<List<int>> randomResult = new List<List<int>>();

        for (int i = 0; i < reel.Length; i++)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(1, 3));
            reel[i].spin = false;
            randomResult.Add(reel[i].RandomPosition());
        }

        int numCouples = 0;

        for (int i = 0; i < randomResult.First().Count; i++)
        {
            if (randomResult[0].ElementAt(i) == randomResult[1].ElementAt(i))
            {
                if (randomResult[0].ElementAt(i) >= minVisibleIndex && randomResult[0].ElementAt(i) <= maxVisibleIndex)
                {
                    numCouples++;
                }
            }
        }

        startSpin = false;
        ScoreAddition(numCouples);
    }
    #endregion

    #region public methods

    public void OnClickPlay()
    {
        if (!startSpin)
        {
            startSpin = true;
            StartCoroutine(Spinning());
        }
    }

    public void ScoreAddition(int numCouples)
    {
        if (numCouples < 1)
            return;
        ScoreSum += defaultBetScore * Convert.ToInt32(Math.Pow(2, numCouples - 1));
        scoreText.text = ScoreSum.ToString();
    }
    #endregion
}
