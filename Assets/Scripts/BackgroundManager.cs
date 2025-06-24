using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer bgMesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScaleBackground();
    }

    // Update is called once per frame
    void Update()
    {
        ScrollBackground();
    }
    void ScaleBackground()
    {
        float height = Camera.main.orthographicSize * 2f;
        float width = Camera.main.aspect * height;
        transform.localScale = new Vector3(width, height, 1);
    }
    void ScrollBackground()
    {
        bgMesh.material.mainTextureOffset = new Vector2(Const.SPEED_SCROLL * Time.time, 0);

    }

}
