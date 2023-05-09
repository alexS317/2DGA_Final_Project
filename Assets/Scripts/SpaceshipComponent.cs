using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipComponent : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private float curveHeight = 1f;
    private Vector3 _startPosition;

    private SpriteRenderer _objectData;
    private SpriteRenderer _backgroundData;

    private float _passedTime;

    // Start is called before the first frame update
    void Start()
    {
        _objectData = GetComponent<SpriteRenderer>();
        _backgroundData = GameObject.Find("Background").GetComponent<SpriteRenderer>();
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FlyOverScreen());
    }

    IEnumerator FlyOverScreen()
    {
        yield return new WaitForSeconds(3);
        Bounds backgroundBounds = _backgroundData.bounds;
        float fieldWidth = backgroundBounds.size.x;
        Vector3 origin = backgroundBounds.center;
        
        float end = origin.x + fieldWidth / 2f;

        Bounds objectBounds = _objectData.bounds;
        float width = objectBounds.size.x;

        Vector3 endPosition = new Vector3(end + width, _startPosition.y, _startPosition.z);

        transform.position = Vector3.Lerp(_startPosition, endPosition, _passedTime);
        transform.position = new Vector3(transform.position.x, _startPosition.y + Mathf.Sin(+curveHeight * Time.time),
            transform.position.z);
        _passedTime += Time.deltaTime * speed;

        if (transform.position.x == endPosition.x)
        {
            transform.position = _startPosition;
            _passedTime = 0;
        }
    }
}