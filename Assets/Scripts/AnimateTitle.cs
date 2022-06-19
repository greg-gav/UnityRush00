using UnityEngine;

public class AnimateTitle : MonoBehaviour
{
    public float rotationAngele;
    private RectTransform _rect;
    void Start()
    {
        _rect = GetComponent<RectTransform>();
    }
    
    void Update()
    {
        _rect.rotation = Quaternion.Euler(
            Vector3.Lerp(new Vector3(0, 0, rotationAngele), 
                        new Vector3(0, 0, -rotationAngele), 
                        Mathf.PingPong(Time.time, 1)));
    }
}
