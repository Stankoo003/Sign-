using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    public GameObject iconPrefab;
    List<Marker> questMarkers = new List<Marker>();

    public RawImage compassImage;
    public Transform player;

    public float maxDistance = 200f;

    float compassUnit;

    public Marker one;
    public Marker two;
    public Marker three;
    public Marker four;
    public Marker five;

    private void Start()
    {
        compassUnit = compassImage.rectTransform.rect.width / 360f;

        AddQuestionMarker(one);
        AddQuestionMarker(two);
        AddQuestionMarker(three);
        AddQuestionMarker(four);
        AddQuestionMarker(five);
    }

    private void Update()
    {
        compassImage.uvRect = new Rect(player.localEulerAngles.y / 360f, 0f, 1f, 1f);

        foreach (Marker marker in questMarkers)
        {
            if (marker != null) { 

            marker.image.rectTransform.anchoredPosition = GotPosOnCompass(marker);

            float dst = Vector2.Distance(new Vector2(player.transform.position.x, player.transform.position.z), marker.position);
            float scale = 0f;

            if (dst < maxDistance)
                scale = 1f - (dst / maxDistance);
            if(marker.transform.localScale == new Vector3(0f,0f,0f)){
                scale = 0f;
            }

            marker.image.rectTransform.localScale = Vector3.one * scale;
         
            }
            
        }
    }


    public void AddQuestionMarker (Marker marker)
    {
        GameObject newMarker = Instantiate(iconPrefab, compassImage.transform);
        marker.image = newMarker.GetComponent<Image>();
        marker.image.sprite = marker.icon;

        questMarkers.Add(marker);
    }

    Vector2 GotPosOnCompass (Marker marker)
    {
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.z);
        Vector2 playerFwd = new Vector2(player.transform.forward.x, player.transform.forward.z);

        float angle = Vector2.SignedAngle(marker.position - playerPos, playerFwd);

        return new Vector2(compassUnit * angle, 0f);
    }
}
