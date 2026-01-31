using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] RectField healthFill;
    Vector3 originalScale;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalScale = healthFill.localScale;
    }

    // Update is called once per frame
    public void UIUpdate()
    {
        float percent= (float)GameManager.Instance
    }
}
