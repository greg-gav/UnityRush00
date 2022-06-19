using UnityEngine;
using UnityEngine.UI;

public class EnemyGenerator : MonoBehaviour
{
    public Sprite[] heads;
    public Sprite[] bodies;

    public SpriteRenderer thisHead;
    public SpriteRenderer thisBody;
    private void Awake()
    {
        thisHead.sprite = heads[Mathf.RoundToInt(Random.Range(0, heads.Length - 1))];
        thisBody.sprite = bodies[Mathf.RoundToInt(Random.Range(0, bodies.Length - 1))];
    }
}
