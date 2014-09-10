using UnityEngine;
using System.Collections;

public class Glow : MonoBehaviour
{
    public GameObject[] glowParts;
    Color[] defaultColors;

    public float maxDistance = 1f;
    GameObject[] go;

    // Use this for initialization
    void Start()
    {

        defaultColors = new Color[glowParts.Length];

        if (glowParts.Length > 0)
            for (int i = 0; i < defaultColors.Length; i++)
                defaultColors[i] = glowParts[i].renderer.material.GetColor("_Color");
    }

    void FixedUpdate()
    {
        go = GameObject.FindGameObjectsWithTag("Player");
    }

    public void OnMouseEnter()
    {
        for (int i = 0; i < go.Length; i++)
        {
            if (Vector3.Distance(transform.position, go[i].transform.position) < maxDistance)
            {
                Debug.Log("Enter");
                Highlight(true);
            }
        }
    }

    public void OnMouseExit()
    {
        Debug.Log("Exit");
        Highlight(false);
    }

    void Highlight(bool glow)
    {
        if (glow)
        {
            if (glowParts.Length > 0)
                for (int i = 0; i < defaultColors.Length; i++)
                    glowParts[i].renderer.material.SetColor("_Color", Color.green);
        }
        else
        {
            if (glowParts.Length > 0)
                for (int i = 0; i < defaultColors.Length; i++)
                    glowParts[i].renderer.material.SetColor("_Color", defaultColors[i]);
        }
    }
}
