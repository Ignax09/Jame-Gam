using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionSwitch : MonoBehaviour
{
    private SpriteRenderer sRenderer;
    public static bool isGlassesOn;
    [SerializeField] private GameObject filter;
    // Start is called before the first frame update
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.enabled = false;
        isGlassesOn = false;
        filter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isGlassesOn)
            {
                sRenderer.enabled = false;
                isGlassesOn = false;
                filter.SetActive(false);
            }
            else
            {
                sRenderer.enabled = true;
                isGlassesOn = true;
                filter.SetActive(true);
            }
        }
    }
}
