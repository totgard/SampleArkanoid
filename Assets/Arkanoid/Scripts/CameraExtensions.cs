using UnityEngine;

public static class CameraExtensions
{
    public static Bounds OrthographicBounds(this Camera camera)
    {
        var screenAspect = Screen.width / (float)Screen.height;
        var cameraHeight = camera.orthographicSize * 2;
        var bounds = new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));
        return bounds;
    }
}