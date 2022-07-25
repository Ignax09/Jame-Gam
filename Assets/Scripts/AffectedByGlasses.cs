using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AffectedByGlasses : MonoBehaviour
{
    [SerializeField] bool isFromNormalDimension;
    SpriteRenderer sRenderer;
    Collider2D objectCollider;
    [SerializeField] Material[] placeholderDifferentAppearance;
    void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
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
