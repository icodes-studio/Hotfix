using UnityEngine;
using UnityEditor;

namespace Hotfix.Unity
{
    [CustomEditor(typeof(MonoBehaviourTestAdaptor.Adaptor), true)]
    public class MonoBehaviourTestAdaptorEditor : UnityEditor.UI.GraphicEditor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            MonoBehaviourTestAdaptor.Adaptor clr = target as MonoBehaviourTestAdaptor.Adaptor;
            var instance = clr.ILInstance;
            if (instance != null)
            {
                EditorGUILayout.LabelField("Script", clr.ILInstance.Type.FullName);

                int index = 0;
                foreach (var field in instance.Type.FieldMapping)
                {
                    var name = field.Key;
                    var type = instance.Type.FieldTypes[index];
                    index++;

                    var cType = type.TypeForCLR;
                    if (cType.IsPrimitive)
                    {
                        if (cType == typeof(float))
                        {
                            instance[field.Value] = EditorGUILayout.FloatField(name, (float)instance[field.Value]);
                        }
                        else
                        {
                            // TODO: Everyone can make up the rest by themselves.
                            throw new System.NotImplementedException();
                        }
                    }
                    else
                    {
                        object obj = instance[field.Value];
                        if (cType == typeof(Vector2))
                        {
                            instance[field.Value] = EditorGUILayout.Vector2Field(name, (Vector2)instance[field.Value]);
                        }
                        else if (cType == typeof(Vector3))
                        {
                            instance[field.Value] = EditorGUILayout.Vector3Field(name, (Vector3)instance[field.Value]);
                        }
                        else if (cType == typeof(Vector4))
                        {
                            instance[field.Value] = EditorGUILayout.Vector4Field(name, (Vector4)instance[field.Value]);
                        }
                        else if (cType == typeof(Color))
                        {
                            instance[field.Value] = EditorGUILayout.ColorField(name, (Color)instance[field.Value]);
                        }
                        else if (cType == typeof(Bounds))
                        {
                            instance[field.Value] = EditorGUILayout.BoundsField(name, (Bounds)instance[field.Value]);
                        }
                        else if (cType == typeof(AnimationCurve))
                        {
                            instance[field.Value] = EditorGUILayout.CurveField(name, (AnimationCurve)instance[field.Value]);
                        }
                        else if (typeof(UnityEngine.Object).IsAssignableFrom(cType))
                        {
                            var res = EditorGUILayout.ObjectField(name, obj as UnityEngine.Object, cType, true);
                            instance[field.Value] = res;
                        }
                        else
                        {
                            // Other types cannot be processed now.
                            if (obj != null)
                                EditorGUILayout.LabelField(name, obj.ToString());
                            else
                                EditorGUILayout.LabelField(name, "(null)");
                        }
                    }
                }
            }
        }
    }
}