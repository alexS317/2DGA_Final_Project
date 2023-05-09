using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  Helper class to get the data of the playing field
public class PlayingFieldData : MonoBehaviour
{
    private static SpriteRenderer _field;
    
    // Start is called before the first frame update
    void Start()
    {
        _field = GameObject.Find("Background").GetComponent<SpriteRenderer>();
    }

    // Get borders of the background image (= playing field)
    public static (float start, float end, float top, float bottom) GetPlayingField()
    {
        // Get properties of the background image
        Bounds bounds = _field.bounds;
        float fieldWidth = bounds.size.x;
        float fieldHeight = bounds.size.y;
        Vector3 origin = bounds.center;
        
        // Calculate border positions of the background image
        float start = origin.x - fieldWidth / 2f;
        float end = origin.x + fieldWidth / 2f;
        float top = origin.y + fieldHeight / 2f;
        float bottom = origin.y - fieldHeight / 2f;

        return (start, end, top, bottom);
    }
}
