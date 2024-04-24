using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public Texture2D map;
    public ColorToPrefab[] colorMapping;
    public float offset = 5;

    public Material material1;
    public Material material2;

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if(pixelColor.a == 0)
        {
            return;
        }

        foreach(ColorToPrefab color in colorMapping)
        {
            if(color.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, y) * offset;
                Instantiate(color.prefab, position, Quaternion.identity, transform);
            }
        }
    }

    public void GenerateLabirynth()
    {
        for(int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                GenerateTile(x, z);
            }
        }

        ColorTheChildren();
    }

    public void ColorTheChildren()
    {
        foreach(Transform child in transform)
        {
            if (child.tag == "Wall")
            {
                if(Random.Range(1, 100) % 3 == 0)
                {
                    child.gameObject.GetComponent<Renderer>().material = material2;
                } else
                {
                    child.gameObject.GetComponent<Renderer>().material = material1;
                }
            }

            foreach (Transform grandchild in child.transform)
            {
                if (grandchild.tag == "Wall")
                {
                    if (Random.Range(1, 100) % 3 == 0)
                    {
                        grandchild.gameObject.GetComponent<Renderer>().material = material2;
                    }
                    else
                    {
                        grandchild.gameObject.GetComponent<Renderer>().material = material1;
                    }
                }
            }
        }
    }
 
}
