using UnityEngine;

public class AnimateBack : MonoBehaviour
{
    public float sizeChange;
    private RectTransform _rect;
    void Start()
    {
        _rect = GetComponent<RectTransform>();
    }
    
    void Update()
    {
        _rect.localScale = Vector3.Lerp(new Vector3(sizeChange, sizeChange, sizeChange), 
                new Vector3(-sizeChange, -sizeChange, -sizeChange), 
                Mathf.PingPong(Time.time, 1));
    }
}
