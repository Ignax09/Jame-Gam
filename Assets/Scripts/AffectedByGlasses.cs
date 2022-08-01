using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AffectedByGlasses : MonoBehaviour
{
    [SerializeField] bool isFromNormalDimension;
    TilemapRenderer sRenderer;
    Collider2D objectCollider;
    [SerializeField] Material[] placeholderDifferentAppearance;
    void Awake()
    {
        sRenderer = GetComponent<TilemapRenderer>();
        sRenderer.enabled = true;
        objectCollider = GetComponent<Collider2D>();
        if (isFromNormalDimension)
        {
            sRenderer.material = placeholderDifferentAppearance[0];
        }
        else
        {
            sRenderer.material = placeholderDifferentAppearance[1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFromNormalDimension)
        {
            sRenderer.enabled = !DimensionSwitch.isGlassesOn;
            objectCollider.enabled = !DimensionSwitch.isGlassesOn;
        }
        if (!isFromNormalDimension)
        {
            sRenderer.enabled = DimensionSwitch.isGlassesOn;
            objectCollider.enabled = DimensionSwitch.isGlassesOn;
        }
    }
}
