using UnityEngine;

public class CardSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    public bool isFaceUp = true;

    public bool useInvertedSkin = false;
    public Material normalMaterial;
    public Material invertedMaterial;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = isFaceUp ? cardFace : cardBack;

        ApplySkin();
    }

    void ApplySkin()
    {
        if (useInvertedSkin)
        {
            // Create a unique material instance
            spriteRenderer.material = new Material(invertedMaterial);
            spriteRenderer.material.SetFloat("_Invert", 1f);
        }
        else
        {
            spriteRenderer.material = new Material(normalMaterial);
            spriteRenderer.material.SetFloat("_Invert", 0f);
        }
    }


    public void SetSkin(bool inverted)
    {
        useInvertedSkin = inverted;
        ApplySkin();
    }
}
