using UnityEditor;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine.UIElements;


namespace Tweening
{
    [CustomEditor(typeof(CustomButton))]
    public class CustomButtonEditor : ButtonEditor
    {
        private SerializedProperty m_InteractableProperty;

        protected override void OnEnable()
        {
            m_InteractableProperty = serializedObject.FindProperty("m_Interactable");
        }

        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            var changeButtonType = new PropertyField(serializedObject.FindProperty(CustomButton.ChangeButtonType));
            var easeCurve = new PropertyField(serializedObject.FindProperty(CustomButton.EaseCurve));
            var duration = new PropertyField(serializedObject.FindProperty(CustomButton.Duration));

            var tweenLabel = new Label("Settings Tween");
            var interactableLabel = new Label("Interactable");

            root.Add(tweenLabel);
            root.Add(changeButtonType);
            root.Add(easeCurve);
            root.Add(duration);

            root.Add(interactableLabel);
            root.Add(new IMGUIContainer(OnInspectorGUI));

            return root;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(m_InteractableProperty);
            
            EditorGUI.BeginChangeCheck();

            serializedObject.ApplyModifiedProperties();
        }
    }
}