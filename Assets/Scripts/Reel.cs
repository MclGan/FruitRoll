using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    public bool spin;
    public int speed = 2500;

    void Start()
    {
        spin = false;
    }

    void Update()
    {
        if (spin)
        {
            foreach (RectTransform image in transform)
            {
                image.anchoredPosition = new Vector2(image.anchoredPosition.x - (Time.deltaTime * speed), image.anchoredPosition.y);

                if (image.anchoredPosition.x < -600f)
                {
                    image.anchoredPosition = new Vector2(image.anchoredPosition.x + 1200f, image.anchoredPosition.y);
                }
            }
        }
    }

    public List<int> RandomPosition()
    {
        List<int> parts = new List<int>();

        int xMinCoordinate = -800;
        int xMaxCoordinate = 600;
        int xImageWidth = 200;
        for (int i = xMinCoordinate; i <= xMaxCoordinate; i+=xImageWidth)
            parts.Add(i);
        
        List<int> result = new List<int>();

        foreach (RectTransform image in transform)
        {
            int rand = Random.Range(0, parts.Count);

            image.anchoredPosition = new Vector2(parts[rand] + transform.parent.GetComponent<RectTransform>().anchoredPosition.x, image.anchoredPosition.y);
            result.Add(parts[rand]);
            parts.RemoveAt(rand);
        }
        return result;
    }
}
