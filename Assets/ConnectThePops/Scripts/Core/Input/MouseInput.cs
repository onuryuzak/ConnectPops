using UnityEngine;

public class MouseInput
{
    Camera camera;

    public MouseInput(Camera camera)
    {
        this.camera = camera;
    }

    public bool IsLeftButtonDown()
    {
        return Input.GetMouseButton(0);
    }

    public bool IsHitObject<T>(out T hit) where T : Component
    {
        hit = null;

        var hitObject = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hitObject.collider != null)
        {
            hit = hitObject.transform.GetComponentInParent<T>();

            if (hit != null)
            {
                return true;
            }
        }

        return false;
    }
}