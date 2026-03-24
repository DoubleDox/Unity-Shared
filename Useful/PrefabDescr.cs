using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class PrefabDescr : MonoBehaviour, IResource
{
    [SerializeField]
    private string object_id_manual;

    [Obsolete("Use prefab fields")]
    public string object_title;

    public string Guid => object_id_manual;

    public string Id => object_id_manual;

    [SerializeField]
    List<PrefabField<string>> strings;

    [SerializeField]
    List<PrefabField<Sprite>> sprites;

    public override string ToString()
    {
        return Guid;
    }

    [Serializable]
    public class PrefabField<T>
    {
        public string name;
        public T value;
    }

    public string GetString(string name, string def = "")
    {
        if (!string.IsNullOrEmpty(name))
        {
            var ps = strings.Find(s => s.name == name);
            if (ps != null)
                return ps.value;
            return def;
        }
        else
        {
            var ps = strings.Find(s => string.IsNullOrEmpty(s.name));
            if (ps != null)
                return ps.value;
            return def;
        }
    }

    public Sprite GetSprite(string name = null)
    {
        if (!string.IsNullOrEmpty(name))
        {
            var ps = sprites.Find(s => s.name == name);
            if (ps != null)
                return ps.value;
        }
        else
        {
            var ps = sprites.Find(s => string.IsNullOrEmpty(s.name));
            if (ps != null)
                return ps.value;
        }
        return null;
    }

#if UNITY_EDITOR
    public void SetSprite(Sprite spr, string name = null)
    {
        if (sprites == null) sprites = new List<PrefabField<Sprite>>();
        var ent = sprites.Find(s => s.name == name || string.IsNullOrEmpty(name) && string.IsNullOrEmpty(s.name));
        if (ent != null)
            ent.value = spr;
        else
            sprites.Add(new PrefabField<Sprite>() { name = name, value = spr });
    }

    [UnityEditor.CustomEditor(typeof(PrefabDescr))]
    [UnityEditor.CanEditMultipleObjects]
    public class PrefabDescrEditor : UnityEditor.Editor
    {
        public override bool HasPreviewGUI()
        {
            return true;
        }

        public override void OnPreviewGUI(Rect rect, GUIStyle background)
        {
            var sprite = target as PrefabDescr;
            if (sprite == null || sprite.sprites == null || sprite.sprites.Count == 0) return;

            GUI.DrawTexture(rect, sprite.sprites[0].value.texture);
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }

    }

#endif
}