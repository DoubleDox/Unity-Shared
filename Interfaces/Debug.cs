using UnityEngine;

public static class DBG
{
    public static IDebugWatcher DebugWatcher { get; private set; }

    public static IDebugScene DebugScene { get; private set; }

    public static IDebugLog DebugLog { get; private set; }

    public static void Register(MonoBehaviour mb)
    {
        if (mb is IDebugWatcher idw)
            DebugWatcher = idw;

        if (mb is IDebugScene ids)
            DebugScene = ids;

        if (mb is IDebugLog log)
            DebugLog = log;
    }

    public static void UnRegister(MonoBehaviour mb)
    {
        if (mb is IDebugWatcher idw && idw == DebugWatcher)
            DebugWatcher = null;

        if (mb is IDebugScene ids && ids == DebugScene)
            DebugScene = ids;

        if (mb is IDebugLog log && log == DebugLog)
            DebugLog = log;
    }

    public static void Value(string name, float value)
    {
        if (DebugWatcher != null)
            DebugWatcher.ShowWatch(name, value);
    }

    public static void Point(string name, Vector3 point)
    {
        if (DebugScene != null)
            DebugScene.ShowPoint(name, point);
    }

    public static void Line(string name, Vector3 from, Vector3 to)
    {
        if (DebugScene != null)
            DebugScene.ShowLine(name, from, to);
    }

    public static void Log(string channel, string message)
    {
        if (DebugLog != null)
            DebugLog.Log(channel, message);
    }
}

public interface IDebugWatcher
{
    void ShowWatch(string name, float value);
}

public interface IDebugScene
{
    void ShowPoint(string name, Vector3 point);

    void ShowLine(string name, Vector3 from, Vector3 to);
}

public interface IDebugLog
{
    void Log(string channel, string message);
}

public enum DebugSceneFigure
{
    Point,
    Line,
    Vector,
    Box
}