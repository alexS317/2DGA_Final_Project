using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingFieldData : MonoBehaviour
{
    public float start { get; private set; }
    public float end { get; private set; }
    public float top { get; private set; }
    public float bottom { get; private set; }
    
    private static SpriteRenderer _field;
    // Start is called before the first frame update
    void Start()
    {
        _field = GameObject.Find("Background").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
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
