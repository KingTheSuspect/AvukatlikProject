using NaughtyAttributes;
using UnityEngine;

public class CourtTextPanelAdjuster : MonoBehaviour
{
    [SerializeField] private RectTransform image;
    [SerializeField] private RectTransform text;

    [SerializeField] private float minHeight = 150;

    [SerializeField] private float heightAdditionalOffset = 10;

    [Button]
    public void Adjust()
    {
        float height = image.sizeDelta.y + text.sizeDelta.y + heightAdditionalOffset;

        if(height < minHeight)
            height = minHeight;

        image.sizeDelta = new Vector2(image.sizeDelta.x, height);
    }
}
