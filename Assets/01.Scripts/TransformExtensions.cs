using UnityEngine;

public static class TransformExtensions
{
    // ---------------------------------------------------------------
    // ワールド座標
    // ---------------------------------------------------------------

    public static void SetPositionX (this Transform trans, float x)
    {
        Vector3 position = trans.position;
        position.x = x;
        trans.position = position;
    }

    public static void SetPositionY (this Transform trans, float y)
    {
        Vector3 position = trans.position;
        position.y = y;
        trans.position = position;
    }

    public static void SetPositionXY (this Transform trans, float x, float y)
    {
        Vector3 position = trans.position;
        position.x = x;
        position.y = y;
        trans.position = position;
    }

    public static void SetPositionZ (this Transform trans, float z)
    {
        Vector3 position = trans.position;
        position.z = z;
        trans.position = position;
    }

    public static void AddPositionX (this Transform trans, float x)
    {
        trans.SetPositionX (trans.transform.position.x + x);
    }

    public static void AddPositionY (this Transform trans, float y)
    {
        trans.SetPositionY (trans.transform.position.y + y);
    }

    public static void AddPositionZ (this Transform trans, float z)
    {
        trans.SetPositionZ (trans.transform.position.z + z);
    }

    // ---------------------------------------------------------------
    // ローカル座標
    // ---------------------------------------------------------------
    public static void SetLocalPositionX (this Transform trans, float x)
    {
        Vector3 position = trans.localPosition;
        position.x = x;
        trans.localPosition = position;
    }

    public static void SetLocalPositionY (this Transform trans, float y)
    {
        Vector3 position = trans.localPosition;
        position.y = y;
        trans.localPosition = position;
    }

    public static void SetLocalPositionZ (this Transform trans, float z)
    {
        Vector3 position = trans.localPosition;
        position.z = z;
        trans.localPosition = position;
    }

    public static void AddLocalPositionX (this Transform trans, float x)
    {
        trans.SetLocalPositionX (trans.transform.localPosition.x + x);
    }

    public static void AddLocalPositionY (this Transform trans, float y)
    {
        trans.SetLocalPositionY (trans.transform.localPosition.y + y);
    }

    public static void AddLocalPositionZ (this Transform trans, float z)
    {
        trans.SetLocalPositionZ (trans.transform.localPosition.z + z);
    }

    // ---------------------------------------------------------------
    // ワールドオイラー角
    // ---------------------------------------------------------------
    public static void SetEulerAnglesX (this Transform trans, float x)
    {
        Vector3 angle = trans.eulerAngles;
        angle.x = x;
        trans.eulerAngles = angle;
    }

    public static void SetEulerAnglesY (this Transform trans, float y)
    {
        Vector3 angle = trans.eulerAngles;
        angle.y = y;
        trans.eulerAngles = angle;
    }

    public static void SetEulerAnglesZ (this Transform trans, float z)
    {
        Vector3 angle = trans.eulerAngles;
        angle.z = z;
        trans.eulerAngles = angle;
    }

    public static void AddEulerAnglesX (this Transform trans, float x)
    {
        trans.SetEulerAnglesX (trans.transform.eulerAngles.x + x);
    }

    public static void AddEulerAnglesY (this Transform trans, float y)
    {
        trans.SetEulerAnglesY (trans.transform.eulerAngles.y + y);
    }

    public static void AddEulerAnglesZ (this Transform trans, float z)
    {
        trans.SetEulerAnglesZ (trans.transform.eulerAngles.z + z);
    }

    // ---------------------------------------------------------------
    // ローカルオイラー角
    // ---------------------------------------------------------------
    public static void SetLocalEulerAnglesX (this Transform trans, float x)
    {
        Vector3 angle = trans.localEulerAngles;
        angle.x = x;
        trans.localEulerAngles = angle;
    }

    public static void SetLocalEulerAnglesY (this Transform trans, float y)
    {
        Vector3 angle = trans.localEulerAngles;
        angle.y = y;
        trans.localEulerAngles = angle;
    }

    public static void SetLocalEulerAnglesZ (this Transform trans, float z)
    {
        Vector3 angle = trans.localEulerAngles;
        angle.z = z;
        trans.localEulerAngles = angle;
    }

    public static void AddLocalEulerAnglesX (this Transform trans, float x)
    {
        trans.SetLocalEulerAnglesX (trans.transform.localEulerAngles.x + x);
    }

    public static void AddLocalEulerAnglesY (this Transform trans, float y)
    {
        trans.SetLocalEulerAnglesY (trans.transform.localEulerAngles.y + y);
    }

    public static void AddLocalEulerAnglesZ (this Transform trans, float z)
    {
        trans.SetLocalEulerAnglesZ (trans.transform.localEulerAngles.z + z);
    }

    // ---------------------------------------------------------------
    // 四元数
    // ---------------------------------------------------------------
    public static void SetRotationX (this Transform trans, float x)
    {
        Quaternion rotation = trans.rotation;
        rotation.x = x;
        trans.rotation = rotation;
    }

    public static void SetRotationY (this Transform trans, float y)
    {
        Quaternion rotation = trans.rotation;
        rotation.y = y;
        trans.rotation = rotation;
    }

    public static void SetRotationZ (this Transform trans, float z)
    {
        Quaternion rotation = trans.rotation;
        rotation.z = z;
        trans.rotation = rotation;
    }

    public static void SetRotationW (this Transform trans, float w)
    {
        Quaternion rotation = trans.rotation;
        rotation.w = w;
        trans.rotation = rotation;
    }

    public static void AddRotationX (this Transform trans, float x)
    {
        trans.SetRotationX (trans.rotation.x + x);
    }

    public static void AddRotationY (this Transform trans, float y)
    {
        trans.SetRotationY (trans.rotation.y + y);
    }

    public static void AddRotationZ (this Transform trans, float z)
    {
        trans.SetRotationZ (trans.rotation.z + z);
    }

    public static void AddRotationW (this Transform trans, float w)
    {
        trans.SetRotationW (trans.rotation.w + w);
    }

    // ---------------------------------------------------------------
    // ローカル四次元数
    // ---------------------------------------------------------------
    public static void SetLocalRotationX (this Transform trans, float x)
    {
        Quaternion rotation = trans.localRotation;
        rotation.x = x;
        trans.localRotation = rotation;
    }

    public static void SetLocalRotationY (this Transform trans, float y)
    {
        Quaternion rotation = trans.localRotation;
        rotation.y = y;
        trans.localRotation = rotation;
    }

    public static void SetLocalRotationZ (this Transform trans, float z)
    {
        Quaternion rotation = trans.localRotation;
        rotation.z = z;
        trans.localRotation = rotation;
    }

    public static void SetLocalRotationW (this Transform trans, float w)
    {
        Quaternion rotation = trans.localRotation;
        rotation.w = w;
        trans.localRotation = rotation;
    }

    public static void AddLocalRotationX (this Transform trans, float x)
    {
        trans.SetLocalRotationX (trans.localRotation.x + x);
    }

    public static void AddLocalRotationY (this Transform trans, float y)
    {
        trans.SetLocalRotationY (trans.localRotation.y + y);
    }

    public static void AddLocalRotationZ (this Transform trans, float z)
    {
        trans.SetLocalRotationZ (trans.localRotation.z + z);
    }

    public static void AddLocalRotationW (this Transform trans, float w)
    {
        trans.SetLocalRotationW (trans.localRotation.w + w);
    }

    // ---------------------------------------------------------------
    // ローカルスケール
    // ---------------------------------------------------------------
    public static void SetLocalScaleScaleX (this Transform trans, float x)
    {
        Vector3 scale = trans.localScale;
        scale.x = x;
        trans.localScale = scale;
    }

    public static void SetLocalScaleScaleY (this Transform trans, float y)
    {
        Vector3 scale = trans.localScale;
        scale.y = y;
        trans.localScale = scale;
    }

    public static void SetLocalScaleScaleZ (this Transform trans, float z)
    {
        Vector3 scale = trans.localScale;
        scale.z = z;
        trans.localScale = scale;
    }

    public static void AddLocalScaleScaleX (this Transform trans, float x)
    {
        trans.SetLocalScaleScaleX (trans.localScale.x + x);
    }

    public static void AddLocalScaleScaleY (this Transform trans, float y)
    {
        trans.SetLocalScaleScaleY (trans.localScale.y + y);
    }

    public static void AddLocalScaleScaleZ (this Transform trans, float z)
    {
        trans.SetLocalScaleScaleZ (trans.localScale.z + z);
    }
}
